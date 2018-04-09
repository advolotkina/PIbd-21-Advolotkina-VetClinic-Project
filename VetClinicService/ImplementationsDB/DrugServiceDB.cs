using System;
using System.Collections.Generic;
using System.Linq;
using VetClinicModel;
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;

namespace VetClinicService.ImplementationsDB
{
    public class DrugServiceDB: IDrugService
    {
        private VetClinicDbContext context;

        public DrugServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public void AddElement(DrugBindingModel model)
        {
            Drug element = context.Drugs.FirstOrDefault(rec => rec.DrugName == model.DrugName);
            if (element != null)
            {
                throw new Exception("Уже есть медикамент с таким названием");
            }
            context.Drugs.Add(new Drug
            {
                DrugName = model.DrugName
            });
            context.SaveChanges();
        }

        public void DelElement(int id)
        {
            Drug element = context.Drugs.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Drugs.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        public DrugViewModel GetElement(int id)
        {
            Drug element = context.Drugs.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new DrugViewModel
                {
                    Id = element.Id,
                    DrugName = element.DrugName
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<DrugViewModel> GetList()
        {
            List<DrugViewModel> result = context.Drugs
               .Select(rec => new DrugViewModel
               {
                   Id = rec.Id,
                   DrugName = rec.DrugName
               })
               .ToList();
            return result;
        }

        public void UpdElement(DrugBindingModel model)
        {
            Drug element = context.Drugs.FirstOrDefault(rec =>
                                        rec.DrugName == model.DrugName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть медикамент с таким названием");
            }
            element = context.Drugs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.DrugName = model.DrugName;
            context.SaveChanges();
        }
    }
}
