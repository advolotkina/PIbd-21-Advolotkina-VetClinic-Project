using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicModel
{
    public class Request
    {
        public int Id { get; set; }

        [Required]
        public int AdminId { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Format { get; set; }

        [ForeignKey("RequestId")]
        public virtual List<RequestDrug> RequestDrugs { get; set; }
    }
}
