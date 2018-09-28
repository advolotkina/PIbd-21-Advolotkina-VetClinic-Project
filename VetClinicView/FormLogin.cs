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

namespace VetClinicView
{
    public partial class FormLogin : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IAdminService service;

        public FormLogin(IAdminService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            AdminBindingModel admin = new AdminBindingModel();
            admin.Login = login.Text;
            admin.Password = password.Text;
            if (service.login(admin))
            {
                var form = Container.Resolve<FormMain>();
                this.Visible = false;
                form.ShowDialog();
                this.Visible = true;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль.");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
