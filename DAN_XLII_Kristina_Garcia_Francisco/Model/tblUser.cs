using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    public class tblUser
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
    }
}
