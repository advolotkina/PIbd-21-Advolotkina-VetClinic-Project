using System.Data.Entity;
using VetClinicModel;

namespace VetClinicService
{
    public class VetClinicDbContext: DbContext
    {
        public VetClinicDbContext() : base("VetClinicDatabase")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<Drug> Drugs { get; set; }

        public virtual DbSet<Service> Services { get; set; }

        public virtual DbSet<Request> Requests { get; set; }

        public virtual DbSet<RequestDrug> RequestDrugs { get; set; }

        public virtual DbSet<ServiceDrug> ServiceDrugs { get; set; }
    }
}
