using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace VetClinicModel
{
    [DataContract]
    public class Admin
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
        public string Login {  get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }

    }
}
