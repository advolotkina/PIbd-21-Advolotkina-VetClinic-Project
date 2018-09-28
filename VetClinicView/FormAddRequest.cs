using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace VetClinicView
{
    public partial class FormAddRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private BindingList<RequestDrugViewModel> requestDrugs;

        public FormAddRequest(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormAddRequest_Load(object sender, EventArgs e)
        {
            requestDrugs = new BindingList<RequestDrugViewModel>();
            dataGridViewRequestDrugs.DataSource = requestDrugs;
            dataGridViewRequestDrugs.Columns[0].Visible = false;
            dataGridViewRequestDrugs.Columns[1].Visible = false;
            dataGridViewRequestDrugs.Columns[2].Visible = false;
            dataGridViewRequestDrugs.Columns[4].Visible = false;
            //dataGridViewRequestDrugs.Columns[5].Visible = false;
            LoadData();

        }

        private void LoadData()
        {
            double sum = 0;
            foreach (var drugRequest in requestDrugs)
            {
                sum += drugRequest.Count * drugRequest.Price;
            }
            textBoxTotalSum.Text = sum.ToString();
        }

        private void buttonAddDrugToRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddRequestDrug>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.RequestProduct != null)
                {
                    requestDrugs.Add(form.RequestProduct);
                }
                LoadData();
            }
        }

        private void buttonDeleteDrugFromRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequestDrugs.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить медикамент из запроса?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = dataGridViewRequestDrugs.SelectedRows[0].Cells[0].RowIndex;
                    try
                    {
                        requestDrugs.RemoveAt(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonAddRequest_Click(object sender, EventArgs e)
        {
            if (requestDrugs == null || requestDrugs.Count == 0)
            {
                MessageBox.Show("Выберите медикаменты для заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<RequestDrugBindingModel> requestDrugsBM = new List<RequestDrugBindingModel>();
                for (int i = 0; i < requestDrugs.Count; ++i)
                {
                    requestDrugsBM.Add(new RequestDrugBindingModel
                        {
                            Id = requestDrugs[i].Id,
                            RequestId = requestDrugs[i].RequestId,
                            DrugId = requestDrugs[i].DrugId,
                            Count = requestDrugs[i].Count
                        }
                    );
                }
                service.AddElement(new RequestBindingModel
                    {
                        Price = Convert.ToInt32(textBoxTotalSum.Text),
                        DateCreate = DateTime.Now,
                        RequestDrugs = requestDrugsBM
                    }
                );
                MessageBox.Show("Добавлена новое заявка", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
