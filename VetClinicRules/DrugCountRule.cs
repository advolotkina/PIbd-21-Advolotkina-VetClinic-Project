using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetClinicModel;
using VetClinicService;

namespace VetClinicRules
{
    public class DrugCountRule : Rule
    {
        private VetClinicDbContext context;
        public override void Define()
        {
            IEnumerable<Drug> drugs = null;

            When()
                .Query(() => drugs, q => q
                .Match<Drug>(o => o.Count < 100)
                .Collect()
                .Where(x => x.Count() >= 0));

            Then()
                .Do(ctx => Notify());
        }

        private static void Notify()
        {
            MessageBox.Show("dsfsfsdfdafs");
        }
    }
}
