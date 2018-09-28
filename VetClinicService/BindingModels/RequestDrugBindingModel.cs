
namespace VetClinicService.BindingModels
{
    public class RequestDrugBindingModel
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }
    }
}
