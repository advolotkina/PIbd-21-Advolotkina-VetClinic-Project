using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicService.ViewModels
{
    public class ServiceDrugViewModel
    {
        public int Id { get; set; }

        public int ServiceId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }

        public double DrugPrice { set; get; }

        public string DrugName { get; set; }
    }
}
