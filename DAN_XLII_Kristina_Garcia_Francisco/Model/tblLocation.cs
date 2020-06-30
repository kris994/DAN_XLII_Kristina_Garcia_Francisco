using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    public class tblLocation
    {
        public tblLocation()
        {
            this.tblUsers = new HashSet<tblUser>();
        }

        [Key]
        public int LocationID { get; set; }
        public string LocationAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public tblLocation(int locationID, string locationAddress, string city, string country)
        {
            LocationID = locationID;
            LocationAddress = locationAddress;
            City = city;
            Country = country;
        }

        public virtual ICollection<tblUser> tblUsers { get; set; }

        /// <summary>
        /// Returns full location name
        /// </summary>
        public string FullLocation
        {
            get
            {
                return $"{LocationAddress}, {City}, {Country}";
            }
        }
    }
}
