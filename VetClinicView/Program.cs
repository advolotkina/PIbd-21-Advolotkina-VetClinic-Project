using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
using VetClinicService;
using VetClinicService.ImplementationsDB;
using VetClinicService.Interfaces;

namespace VetClinicView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(container.Resolve<FormLogin>());
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, VetClinicDbContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IDrugService, DrugServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRequestService, RequestServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IServiceService, ServiceServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAdminService, AdminServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IClientImitationService, ClientImitationServiceDB>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IBackupService, BackupServiceDB>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}
