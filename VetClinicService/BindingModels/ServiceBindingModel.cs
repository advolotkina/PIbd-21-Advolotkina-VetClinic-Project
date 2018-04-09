using System.Collections.Generic;

namespace VetClinicService.BindingModels
{
    public class ServiceBindingModel
    {
        public int Id { get; set; }
        
        public string ServiceName { get; set; }
        
        public decimal Price { get; set; }
        
        public virtual List<ServiceDrugBindingModel> ServiceDrugs { get; set; }
    }
}
