using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicModel;
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;

namespace VetClinicService.ImplementationsDB
{
    public class AdminServiceDB: IAdminService
    {
        private VetClinicDbContext context;

        public AdminServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public Boolean login(AdminBindingModel model)
        {
            Admin element = context.Admins.FirstOrDefault(rec => rec.Login == model.Login);
            
            if (element != null)
            {
                if (element.Password.Equals(model.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
