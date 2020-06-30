using System.Data.Entity;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    public class WorkerContext : DbContext
    {
        public WorkerContext() : base("name=WorkerDB")
        {

        }

        public virtual DbSet<tblLocation> tblLocations { get; set; }
        public virtual DbSet<tblSector> tblSector { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
