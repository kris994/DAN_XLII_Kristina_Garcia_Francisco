using DAN_XLII_Kristina_Garcia_Francisco.Helper;
using DAN_XLII_Kristina_Garcia_Francisco.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// The user table class
    /// </summary>
    public class tblUser : BaseViewModel, IDataErrorInfo
    {
        /// <summary>
        /// UserID
        /// </summary>
        [Key]
        public int UserID { get; set; }
        /// <summary>
        /// User First Name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// User Last Name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// User JMBG
        /// </summary>
        public string JMBG { get; set; }
        /// <summary>
        /// User DateOfBirth
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// User Gender
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Gender IDCard
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// User PhoneNumber
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// User Location
        /// </summary>
        public int LocationID { get; set; }
        /// <summary>
        /// User Sector
        /// </summary>
        public int SectorID { get; set; }
        /// <summary>
        /// Urer manager
        /// </summary>
        public int? MenagerID { get; set; }

        /// <summary>
        /// All locations
        /// </summary>
        public virtual tblLocation tblLocation { get; set; }
        /// <summary>
        /// All sectors
        /// </summary>
        public virtual tblSector tblSector { get; set; }
        /// <summary>
        /// All managers
        /// </summary>
        public virtual tblUser Manager { get; set; }

        /// <summary>
        /// List of all managers
        /// </summary>
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

        /// <summary>
        /// Checks if the inputs are incorrect
        /// </summary>
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
                        result = this.validation.IDCardChecker(IDCard, UserID);
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
