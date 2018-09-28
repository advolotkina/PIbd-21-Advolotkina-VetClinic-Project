using System;
using System.Collections.Generic;

namespace VetClinicService.ViewModels
{
    public class RequestViewModel
    {
        public int Id { get; set; }

        public string DateCreate { get; set; }

        public double Price { get; set; }

        public virtual List<RequestDrugViewModel> RequestDrugs { get; set; }
    }
}
