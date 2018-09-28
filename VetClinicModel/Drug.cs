using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class Drug
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string DrugName { get; set; }

        [DataMember]
        [Required]
        public double Price { get; set; }

        [DataMember]
        [Required]
        public int Count { get; set; }

        [ForeignKey("DrugId")]
        public virtual List<ServiceDrug> ServiceDrugs { get; set; }

        [ForeignKey("DrugId")]
        public virtual List<RequestDrug> RequestDrugs { get; set; }
    }
}
