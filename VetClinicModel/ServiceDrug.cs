namespace VetClinicModel
{
    public class ServiceDrug
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }

        public virtual Service Service { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
