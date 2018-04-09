using System;
using System.Collections.Generic;

namespace VetClinicService.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public int AdminId { get; set; }

        public string DateCreate { get; set; }

        public string Address { get; set; }

        public string Format { get; set; }

        public virtual List<RequestDrugViewModel> RequestDrugs { get; set; }
    }
}
