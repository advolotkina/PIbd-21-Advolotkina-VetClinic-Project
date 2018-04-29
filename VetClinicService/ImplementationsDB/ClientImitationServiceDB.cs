using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VetClinicService.Interfaces;
using System.Threading.Tasks;
using VetClinicService.ViewModels;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using VetClinicModel;
using NRules.Fluent;
using NRules;
using VetClinicService.Rules;

namespace VetClinicService.ImplementationsDB
{
    public class ClientImitationServiceDB : IClientImitationService
    {
        private VetClinicDbContext context;

        public ClientImitationServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }
        public void imitate()
        {
            int numOfServices = context.Services.Count();
            Random rand = new Random();
            for (int k = 0; k < 10; k++)
            {
                int num = rand.Next(numOfServices);
                for (int i = 0; i < num; i++)
                {
                    var service = context.Services.ToArray()[rand.Next(num)];
                    var drugs = context.Drugs;
                    var serviceDrugs = context.ServiceDrugs.Where(rec => rec.ServiceId == service.Id);
                    Console.WriteLine(serviceDrugs.Count());
                    foreach (var serviceDrug in serviceDrugs)
                    {
                        Drug drug = context.Drugs.FirstOrDefault(rec =>
                                            rec.Id == serviceDrug.Id);
                        Console.WriteLine(drug.DrugName);
                        if (drug.Count < serviceDrug.Count)
                        {
                            throw new Exception("Недостаточно медикаментов");
                        }
                        else
                        {
                            drug.Count = drug.Count - serviceDrug.Count;
                            Console.WriteLine(drug.Count + "" + drug.DrugName);
                        }
                    }

                }
                context.SaveChanges();
            }
        }
    }
}
