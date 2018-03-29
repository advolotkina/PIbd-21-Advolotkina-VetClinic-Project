namespace VetClinicModel
{
    public class RequestDrug
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }

        public virtual Request Request { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
