using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinicService.ViewModels
{
    public class RequestDrugViewModel
    {
        public int Id { get; set; }

        public int RequestId { get; set; }

        public int DrugId { get; set; }

        public int Count { get; set; }

        public string DrugName { get; set; }
    }
}
