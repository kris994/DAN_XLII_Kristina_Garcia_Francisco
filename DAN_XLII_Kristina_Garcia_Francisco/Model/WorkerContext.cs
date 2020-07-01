using System.Data.Entity;

namespace DAN_XLII_Kristina_Garcia_Francisco.Model
{
    /// <summary>
    /// Database worker context 
    /// </summary>
    public class WorkerContext : DbContext
    {
        /// <summary>
        /// Constructor that connects to the WorkerDB database
        /// </summary>
        public WorkerContext() : base("name=WorkerDB")
        {

        }

        /// <summary>
        /// Table locations
        /// </summary>
        public virtual DbSet<tblLocation> tblLocations { get; set; }
        /// <summary>
        /// Table sector
        /// </summary>
        public virtual DbSet<tblSector> tblSector { get; set; }
        /// <summary>
        /// Table user
        /// </summary>
        public virtual DbSet<tblUser> tblUsers { get; set; }
    }
}
