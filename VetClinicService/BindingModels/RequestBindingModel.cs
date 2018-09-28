using System;
using System.Collections.Generic;

namespace VetClinicService.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }
        
        
        public DateTime DateCreate { get; set; }

        public int Price { get; set; }

        public virtual List<RequestDrugBindingModel> RequestDrugs { get; set; }
    }
}
