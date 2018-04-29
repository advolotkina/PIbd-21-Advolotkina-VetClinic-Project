using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class Request
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public DateTime DateCreate { get; set; }

        [DataMember]
        [Required]
        public int Price { get; set; }

        [ForeignKey("RequestId")]
        public virtual List<RequestDrug> RequestDrugs { get; set; }
    }
}
