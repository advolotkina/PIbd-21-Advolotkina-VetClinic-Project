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
    public partial class FormRequests : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        public FormRequests(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRequests_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                List<RequestViewModel> list = service.GetList();
                dataGridViewRequests.DataSource = list;
                dataGridViewRequests.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAddRequest_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormAddRequest>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void buttonViewRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormViewRequest>();
                form.Id = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonSendRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormSendRequest>();
                form.Id = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells[0].Value);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }

        private void buttonSaveToExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                SaveFileDialog sfd = new SaveFileDialog{ Filter = "xls|*.xls|xlsx|*.xlsx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        service.SaveRequestToXlsFile(
                            service.GetElement((int)dataGridViewRequests.SelectedRows[0].Cells[0].Value),
                            sfd.FileName
                        );
                        MessageBox.Show("Заявка сохранена в xls файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonSaveToWord_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                SaveFileDialog sfd = new SaveFileDialog { Filter = "doc|*.doc|docx|*.docx" };
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        service.SaveRequestToDocFile(
                            service.GetElement((int)dataGridViewRequests.SelectedRows[0].Cells[0].Value),
                            sfd.FileName
                        );
                        MessageBox.Show("Заявка сохранена в doc файл", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void buttonDeleteRequest_Click(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить заявку?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells[0].Value);
                    try
                    {
                        service.DelElement(id);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
    }
}
