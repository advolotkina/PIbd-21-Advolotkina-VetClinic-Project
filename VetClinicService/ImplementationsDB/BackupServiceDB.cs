using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicService.Interfaces;
using System.Runtime.Serialization.Json;
using VetClinicModel;
using System.IO;

namespace VetClinicService.ImplementationsDB
{
    public class BackupServiceDB : IBackupService
    {
        private VetClinicDbContext context;

        public BackupServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public string GetData()
        {
            DataContractJsonSerializer adminJS = new DataContractJsonSerializer(typeof(List<Admin>));
            String admins = "";
            MemoryStream ms = new MemoryStream();
            adminJS.WriteObject(ms, context.Admins);
            ms.Position = 0;
            admins = (new StreamReader(ms)).ReadToEnd();

            DataContractJsonSerializer drugJS = new DataContractJsonSerializer(typeof(List<Drug>));
            String drugs = "";
            MemoryStream msDrug = new MemoryStream();
            drugJS.WriteObject(msDrug, context.Drugs);
            msDrug.Position = 0;
            drugs = (new StreamReader(msDrug)).ReadToEnd();

            DataContractJsonSerializer requestDrugJS = new DataContractJsonSerializer(typeof(List<RequestDrug>));
            String requestDrugs = "";
            MemoryStream msRequestDrug = new MemoryStream();
            requestDrugJS.WriteObject(msRequestDrug, context.RequestDrugs);
            msRequestDrug.Position = 0;
            requestDrugs = (new StreamReader(msRequestDrug)).ReadToEnd();

            DataContractJsonSerializer requestsJS = new DataContractJsonSerializer(typeof(List<Request>));
            String requests = "";
            MemoryStream msRequests = new MemoryStream();
            requestsJS.WriteObject(msRequests, context.Requests);
            msRequests.Position = 0;
            requests = (new StreamReader(msRequests)).ReadToEnd();

            DataContractJsonSerializer servicesJS = new DataContractJsonSerializer(typeof(List<Service>));
            String services = "";
            MemoryStream msServices = new MemoryStream();
            servicesJS.WriteObject(msServices, context.Services);
            msServices.Position = 0;
            services = (new StreamReader(msServices)).ReadToEnd();

            DataContractJsonSerializer serviceDrugJS = new DataContractJsonSerializer(typeof(List<ServiceDrug>));
            String serviceDrugs = "";
            MemoryStream msServiceDrugs = new MemoryStream();
            serviceDrugJS.WriteObject(msServiceDrugs, context.ServiceDrugs);
            msServiceDrugs.Position = 0;
            serviceDrugs = (new StreamReader(msServiceDrugs)).ReadToEnd();

            return
                "{\n" + "\"VetClinicDatabaseTables\":\n"+
                admins + ",\n" +
                drugs + ",\n" +
                requestDrugs + ",\n" +
                requests + ",\n" +
                services + ",\n" +
                serviceDrugs + ",\n" +
                "}";
        }
    }
}
