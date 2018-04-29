using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicService.BindingModels;

namespace VetClinicService.Interfaces
{
    public interface IAdminService
    {
        Boolean login(AdminBindingModel model);
    }
}
