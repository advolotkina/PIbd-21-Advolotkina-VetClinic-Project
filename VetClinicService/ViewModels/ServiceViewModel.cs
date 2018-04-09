﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicService.ViewModels
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public decimal Price { get; set; }

        public virtual List<ServiceDrugViewModel> ServiceDrugs { get; set; }
    }
}
