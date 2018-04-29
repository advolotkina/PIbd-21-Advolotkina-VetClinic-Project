using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VetClinicModel;

namespace VetClinicService.Rules
{
    public class DrugCountRule : Rule
    {
        public override void Define()
        {
            IEnumerable<Drug> drugs = null;

            When()
                .Query(() => drugs, q => q
                .Match<Drug>(o => (o.Count < 100))
                .Collect()
                .Where(x => x.Count() > 0));

            Then()
                .Do(ctx => Notify(drugs));
        }

        private static void Notify(IEnumerable<Drug> drugs)
        {
            foreach(var drug in drugs)
            {
                MessageBox.Show("Кончается "+drug.DrugName+", осталось " + drug.Count);
            }
        }
    }
}
