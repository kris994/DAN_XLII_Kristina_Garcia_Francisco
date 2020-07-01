using DAN_XLII_Kristina_Garcia_Francisco.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    public class tblUser : IDataErrorInfo
    {
        [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JMBG { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string IDCard { get; set; }
        public string PhoneNumber { get; set; }
        public int LocationID { get; set; }
        public int SectorID { get; set; }
        public int? MenagerID { get; set; }

        public virtual tblLocation tblLocation { get; set; }
        public virtual tblSector tblSector { get; set; }
        public virtual tblUser Manager { get; set; }

        public ICollection<tblUser> Menagers { get; private set; }

        /// <summary>
        /// Returns full location name
        /// </summary>
        public string FullName
        {
            get
            {
                return $"{FirstName}, {LastName}";
            }
        }

        Validation validation = new Validation();

        /// <summary>
        /// Total amount of propertis we are checking
        /// </summary>
        static readonly string[] ValidatedProperties =
        {
            "JMBG",
            "Gender",
            "IDCard",
            "PhoneNumber"
        };

        /// <summary>
        /// Returns true if this object has no validation errors.
        /// </summary>
        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    // there is an error
                    if (this[property] != null)
                        return false;
                }

                return true;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Does validations on the property location
        /// </summary>
        /// <param name="propertyName">property we are checking</param>
        /// <returns>if the property is valid (null) or error (string)</returns>
        public string this[string propertyName]
        {
            get
            {
                string result = null;

                switch (propertyName)
                {
                    case "JMBG":
                        result = this.validation.JMBGChecker(JMBG, UserID);
                        break;

                    case "Gender":
                        result = this.validation.CannotBeEmpty(Gender);
                        break;

                    case "IDCard":
                        result = this.validation.TooShort(IDCard, 9);
                        break;

                    case "PhoneNumber":
                        result = this.validation.TooShort(PhoneNumber, 3);
                        break;

                    default:
                        result = null;
                        break;
                }

                return result;
            }
        }
    }
}
