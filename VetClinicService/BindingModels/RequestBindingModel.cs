using System;
using System.Collections.Generic;

namespace VetClinicService.BindingModels
{
    public class RequestBindingModel
    {
        public int Id { get; set; }
        
        public int AdminId { get; set; }
        
        public DateTime DateCreate { get; set; }
        
        public string Address { get; set; }
        
        public string Format { get; set; }

        public virtual List<RequestDrugBindingModel> RequestDrugs { get; set; }
    }
}
