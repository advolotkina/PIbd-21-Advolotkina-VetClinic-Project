using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class Service
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string ServiceName { get; set; }

        [DataMember]
        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ServiceId")]
        public virtual List<ServiceDrug> ServiceDrugs { get; set; }

    }
}
