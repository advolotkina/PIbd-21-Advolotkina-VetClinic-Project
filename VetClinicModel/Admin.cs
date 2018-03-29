using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetClinicModel
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string Login {  get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("AdminId")]
        public virtual List<Request> Requests { get; set; }
    }
}
