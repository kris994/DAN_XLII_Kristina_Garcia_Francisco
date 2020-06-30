using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    class tblLocation
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

        public virtual ICollection<tblUser> tblUsers { get; set; }
    }
}
