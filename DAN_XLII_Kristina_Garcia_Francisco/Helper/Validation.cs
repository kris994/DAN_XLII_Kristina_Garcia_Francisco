using DAN_XLII_Kristina_Garcia_Francisco.Model;
using System;
using System.Collections.Generic;


namespace DAN_XLII_Kristina_Garcia_Francisco.Helper
{
    /// <summary>
    /// Validates the user inputs
    /// </summary>
    class Validation
    {
        InputCalculator iv = new InputCalculator();

        /// <summary>
        /// Checks if the jmbg is correct
        /// </summary>
        /// <param name="jmbg">the jmbg we are checking</param>
        /// <param name="id">for the specific user</param>
        /// <returns></returns>
        public string JMBGChecker(string jmbg, int id)
        {
            Service service = new Service();

            List<tblUser> AllUsers = service.GetAllUsers();
            DateTime dt = default(DateTime);
            string currentJbmg = "";

            try
            {
                // Get the current users jmbg
                for (int i = 0; i < AllUsers.Count; i++)
                {
                    if (AllUsers[i].UserID == id)
                    {
                        currentJbmg = AllUsers[i].JMBG;
                        break;
                    }
                }

                // Check if the jmbg already exists, but it is not the current user jmbg
                for (int i = 0; i < AllUsers.Count; i++)
                {
                    if (AllUsers[i].JMBG == jmbg && currentJbmg != jmbg)
                    {
                        return "This JMBG already exists!";
                    }
                }

                if (!(jmbg.Length == 13))
                {
                    return "Please enter a number with 13 characters.";
                }

                // Get date
                dt = iv.CountDateOfBirth(jmbg);

                if (dt == default(DateTime))
                {
                    return "Incorrect JMBG Format.";
                }
            }
            catch (NullReferenceException)
            {
                return "Please enter a number with 13 characters.";
            }

            return null;
        }

        /// <summary>
        /// The input cannot be empty
        /// </summary>
        /// <param name="name">name of the input</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string CannotBeEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Cannot be empty";
            }
            else
            {
                return null;
            }
        }

        public string TooShort(string name, int number)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < number)
            {
                return "Cannot be shorter than " + number + " characters.";
            }
            else
            {
                return null;
            }
        }
    }
}
