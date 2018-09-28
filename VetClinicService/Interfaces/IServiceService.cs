using System.Collections.Generic;
using VetClinicService.BindingModels;
using VetClinicService.ViewModels;

namespace VetClinicService.Interfaces
{
    public interface IServiceService
    {
        List<ServiceViewModel> GetList();

        ServiceViewModel GetElement(int id);

        void AddElement(ServiceBindingModel model);

        void UpdElement(ServiceBindingModel model);

        void DelElement(int id);
    }
}
