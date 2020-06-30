using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    class tblSector
    {
        public tblSector()
        {
            this.tblUsers = new HashSet<tblUser>();
        }

        [Key]
        public int SectorID { get; set; }
        public string SectorName { get; set; }

        public virtual ICollection<tblUser> tblUsers { get; set; }
    }
}
