using System.Collections.Generic;
using VetClinicService.BindingModels;
using VetClinicService.ViewModels;

namespace VetClinicService.Interfaces
{
    public interface IReportService
    {
        List<RequestViewModel> GetRequestsList(ReportBindingModel model);

        List<ServiceViewModel> GetServicesList(ReportBindingModel model);

        void SaveToFile(ReportBindingModel model);
    }
}
