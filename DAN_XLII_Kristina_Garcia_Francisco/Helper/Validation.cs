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

        /// <summary>
        /// Input cannot be shorter than expected
        /// </summary>
        /// <param name="name">name of the input</param>
        /// <param name="number">length of the input</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
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

        /// <summary>
        /// Checks if the id card is valid
        /// </summary>
        /// <param name="idCard">name of the input</param>
        /// <param name="id">the users id who has the id card</param>
        /// <returns>null if the input is correct or string error message if its wrong</returns>
        public string IDCardChecker(string idCard, int id)
        {
            Service service = new Service();
            List<tblUser> AllUsers = service.GetAllUsers();
            string currentIDCard = "";

            // Get the current id card
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].UserID == id)
                {
                    currentIDCard = AllUsers[i].IDCard;
                    break;
                }
            }

            // Check if thelength of the id card is correct
            if (string.IsNullOrWhiteSpace(idCard) || idCard.Length != 9)
            {
                return "The input length has to be 9 characters.";
            }

            // Check if the id card already exists, but it is not the current user jmbg
            for (int i = 0; i < AllUsers.Count; i++)
            {
                if (AllUsers[i].IDCard == idCard && currentIDCard != idCard)
                {
                    return "This ID Card already exists!";
                }
            }

            return null;
        }
    }
}
