using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicModel
{
    public class Drug
    {
        public int Id { get; set; }

        [Required]
        public string DrugName { get; set; }

        [ForeignKey("DrugId")]
        public virtual List<ServiceDrug> ServiceDrugs { get; set; }

        [ForeignKey("DrugId")]
        public virtual List<RequestDrug> RequestDrugs { get; set; }
    }
}
