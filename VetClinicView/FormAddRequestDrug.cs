using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace VetClinicView
{
    public partial class FormAddRequestDrug : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IDrugService serviceDrug;

        public RequestDrugViewModel RequestProduct { set { requestProduct = value; } get { return requestProduct; } }

        private RequestDrugViewModel requestProduct;

        public FormAddRequestDrug(IDrugService service)
        {
            InitializeComponent();
            this.serviceDrug = service;
        }

        private void FormAddRequestDrug_Load(object sender, EventArgs e)
        {
            try
            {
                List<DrugViewModel> listDrugs = serviceDrug.GetList();
                comboBoxDrug.DisplayMember = "DrugName";
                comboBoxDrug.ValueMember = "Id";
                comboBoxDrug.DataSource = listDrugs;
                comboBoxDrug.SelectedItem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Введите количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxDrug.SelectedValue == null)
            {
                MessageBox.Show("Выберите медикамент для заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                DrugViewModel product = serviceDrug.GetElement(Convert.ToInt32(comboBoxDrug.SelectedValue));
                requestProduct = new RequestDrugViewModel
                {
                    DrugId = product.Id,
                    DrugName = product.DrugName,
                    Price = product.Price,
                    Count = Convert.ToInt32(textBoxCount.Text)
                };
                MessageBox.Show("Медикамент добавлен в заявку", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
