using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicModel;

namespace VetClinicService
{
    public class ClientOrder
    {
        public string FIO;

        public List<Service> Services;

        public DateTime Date;
    }
}
