using System.Collections.Generic;
using VetClinicService.BindingModels;
using VetClinicService.ViewModels;

namespace VetClinicService.Interfaces
{
    public interface IDrugService
    {
        List<DrugViewModel> GetList();

        DrugViewModel GetElement(int id);

        void AddElement(DrugBindingModel model);

        void UpdElement(DrugBindingModel model);

        void DelElement(int id);
    }
}
