using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;
using VetClinicService.ImplementationsDB;
using VetClinicService.Interfaces;

namespace VetClinicView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IBackupService service;

        public FormMain(IBackupService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void servicesButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormServices>();
            form.ShowDialog();
        }

        private void drugsButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDrugs>();
            form.ShowDialog();
        }

        private void requestsButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormRequests>();
            form.ShowDialog();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReports>();
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var service = Container.Resolve<IClientImitationService>();
                service.imitate();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBackupDB_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { Filter = "Json files (*.json)|*.json|Text files (*.txt)|*.txt" };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamWriter writer = new StreamWriter(sfd.FileName);

                    writer.WriteLine(service.GetData());
                    writer.Dispose();

                    MessageBox.Show("Сохранение прошло успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
