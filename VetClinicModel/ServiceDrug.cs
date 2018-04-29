using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class ServiceDrug
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ServiceId { get; set; }

        [DataMember]
        public int DrugId { get; set; }

        [DataMember]
        public int Count { get; set; }

        public virtual Service Service { get; set; }

        public virtual Drug Drug { get; set; }
    }
}
