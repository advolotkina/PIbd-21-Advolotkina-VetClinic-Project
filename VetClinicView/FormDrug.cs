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
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;

namespace VetClinicView
{
    public partial class FormDrug : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int Id { set { id = value; } }

        private readonly IDrugService service;

        private int? id;

        public FormDrug(IDrugService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormDrug_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    DrugViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.DrugName;
                        textBoxPrice.Text = view.Price.ToString();
                        textBoxCount.Text = view.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public FormDrug()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new DrugBindingModel
                    {
                        Id = id.Value,
                        DrugName = textBoxName.Text,
                        Price = Double.Parse(textBoxPrice.Text),
                        Count = Int32.Parse(textBoxCount.Text)
                    });
                }
                else
                {
                    service.AddElement(new DrugBindingModel
                    {
                        DrugName = textBoxName.Text,
                        Count = Int32.Parse(textBoxCount.Text),
                        Price = Double.Parse(textBoxPrice.Text)
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
