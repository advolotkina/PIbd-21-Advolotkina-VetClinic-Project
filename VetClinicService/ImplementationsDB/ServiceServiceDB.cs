using System;
using System.Collections.Generic;
using System.Linq;
using VetClinicModel;
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;

namespace VetClinicService.ImplementationsDB
{
    public class ServiceServiceDB: IServiceService
    {
        private VetClinicDbContext context;

        public ServiceServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public void AddElement(ServiceBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Service element = context.Services.FirstOrDefault(rec => rec.ServiceName == model.ServiceName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть услуга с таким названием");
                    }
                    element = new Service
                    {
                        ServiceName = model.ServiceName,
                        Price = model.Price
                    };
                    context.Services.Add(element);
                    context.SaveChanges();
                    var groupDrugs = model.ServiceDrugs
                                                .GroupBy(rec => rec.DrugId)
                                                .Select(rec => new
                                                {
                                                    DrugId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });

                    foreach (var groupIngredient in groupDrugs)
                    {
                        context.ServiceDrugs.Add(new ServiceDrug
                        {
                            ServiceId = element.Id,
                            DrugId = groupIngredient.DrugId,
                            Count = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Service element = context.Services.FirstOrDefault(rec => rec.Id == id);
                    if (element != null)
                    {
                        context.ServiceDrugs.RemoveRange(
                                            context.ServiceDrugs.Where(rec => rec.ServiceId == id));
                        context.Services.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public ServiceViewModel GetElement(int id)
        {
            Service element = context.Services.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new ServiceViewModel
                {
                    Id = element.Id,
                    ServiceName = element.ServiceName,
                    Price = element.Price,
                    ServiceDrugs = context.ServiceDrugs
                            .Where(recPC => recPC.ServiceId == element.Id)
                            .Select(recPC => new ServiceDrugViewModel
                            {
                                Id = recPC.Id,
                                ServiceId = recPC.ServiceId,
                                DrugId = recPC.DrugId,
                                DrugName = recPC.Drug.DrugName,
                                Count = recPC.Count
                            })
                            .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public List<ServiceViewModel> GetList()
        {
            List<ServiceViewModel> result = context.Services
                .Select(rec => new ServiceViewModel
                {
                    Id = rec.Id,
                    ServiceName = rec.ServiceName,
                    Price = rec.Price,
                    ServiceDrugs = context.ServiceDrugs
                            .Where(recPC => recPC.ServiceId == rec.Id)
                            .Select(recPC => new ServiceDrugViewModel
                            {
                                Id = recPC.Id,
                                ServiceId = recPC.ServiceId,
                                DrugId = recPC.DrugId,
                                DrugName = recPC.Drug.DrugName,
                                Count = recPC.Count
                            })
                            .ToList()
                })
                .ToList();
            return result;
        }

        public void UpdElement(ServiceBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Service element = context.Services.FirstOrDefault(rec =>
                                        rec.ServiceName == model.ServiceName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть услуга с таким названием");
                    }
                    element = context.Services.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.ServiceName = model.ServiceName;
                    element.Price = model.Price;
                    context.SaveChanges();


                    var drugsIds = model.ServiceDrugs.Select(rec => rec.DrugId).Distinct();
                    var updateDrugs = context.ServiceDrugs
                                                    .Where(rec => rec.ServiceId == model.Id &&
                                                        drugsIds.Contains(rec.DrugId));
                    foreach (var updateDrug in updateDrugs)
                    {
                        updateDrug.Count = model.ServiceDrugs
                                                        .FirstOrDefault(rec => rec.Id == updateDrug.Id).Count;
                    }
                    context.SaveChanges();
                    context.ServiceDrugs.RemoveRange(
                                        context.ServiceDrugs.Where(rec => rec.ServiceId == model.Id &&
                                                                            !drugsIds.Contains(rec.DrugId)));
                    context.SaveChanges();

                    var groupDrugs = model.ServiceDrugs
                                                .Where(rec => rec.Id == 0)
                                                .GroupBy(rec => rec.DrugId)
                                                .Select(rec => new
                                                {
                                                    DrugId = rec.Key,
                                                    Count = rec.Sum(r => r.Count)
                                                });
                    foreach (var groupDrug in groupDrugs)
                    {
                        ServiceDrug elementPC = context.ServiceDrugs
                                                .FirstOrDefault(rec => rec.ServiceId == model.Id &&
                                                                rec.DrugId == groupDrug.DrugId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupDrug.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.ServiceDrugs.Add(new ServiceDrug
                            {
                                ServiceId = model.Id,
                                DrugId = groupDrug.DrugId,
                                Count = groupDrug.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
