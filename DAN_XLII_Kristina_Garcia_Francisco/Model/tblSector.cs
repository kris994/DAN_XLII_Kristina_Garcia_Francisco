using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// Sector table
    /// </summary>
    public class tblSector
    {
        /// <summary>
        /// Contains all users
        /// </summary>
        public tblSector()
        {
            this.tblUsers = new HashSet<tblUser>();
        }

        /// <summary>
        /// Sector Id
        /// </summary>
        [Key]
        public int SectorID { get; set; }
        /// <summary>
        /// SectorName
        /// </summary>
        public string SectorName { get; set; }

        /// <summary>
        /// List of all Users
        /// </summary>
        public virtual ICollection<tblUser> tblUsers { get; set; }
    }
}
