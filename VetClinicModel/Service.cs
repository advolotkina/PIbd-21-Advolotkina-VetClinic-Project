using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicModel
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string ServiceName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ServiceId")]
        public virtual List<ServiceDrug> ServiceDrugs { get; set; }
    }
}
