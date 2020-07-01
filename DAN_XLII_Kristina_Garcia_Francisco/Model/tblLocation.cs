using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// Table with all locations
    /// </summary>
    public class tblLocation
    {
        /// <summary>
        /// Contains list of all users
        /// </summary>
        public tblLocation()
        {
            this.tblUsers = new HashSet<tblUser>();
        }

        /// <summary>
        /// LocationId
        /// </summary>
        [Key]
        public int LocationID { get; set; }
        /// <summary>
        /// LocationAddress
        /// </summary>
        public string LocationAddress { get; set; }
        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="locationID"></param>
        /// <param name="locationAddress"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        public tblLocation(int locationID, string locationAddress, string city, string country)
        {
            LocationID = locationID;
            LocationAddress = locationAddress;
            City = city;
            Country = country;
        }

        /// <summary>
        /// List of all users
        /// </summary>
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
