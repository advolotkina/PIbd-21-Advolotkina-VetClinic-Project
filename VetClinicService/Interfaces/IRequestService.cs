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

        void DelElement(int id);

        void SaveRequestToDocFile(RequestViewModel model, string filename);

        void SaveRequestToXlsFile(RequestViewModel model, string filename);
    }
}
