using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class RequestDrug
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int RequestId { get; set; }

        [DataMember]
        public int DrugId { get; set; }

        [DataMember]
        public int Count { get; set; }

        public virtual Request Request { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
