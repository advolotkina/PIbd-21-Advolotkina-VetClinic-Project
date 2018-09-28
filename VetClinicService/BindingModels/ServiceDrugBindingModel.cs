using VetClinicModel;

namespace VetClinicService.BindingModels
{
    public class ServiceDrugBindingModel
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }
    }
}
