using System.Collections.Generic;
using VetClinicService.BindingModels;
using VetClinicService.ViewModels;

namespace VetClinicService.Interfaces
{
    public interface IRequestService
    {
        List<RequestViewModel> GetList();

        RequestViewModel GetElement(int id);

        void AddElement(RequestBindingModel model);

        void SaveRequestToDocFile(RequestViewModel model, string filename);

        void SaveRequestToXlslFile(RequestViewModel model, string filename);
    }
}
