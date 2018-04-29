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
    public partial class FormViewRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private BindingList<RequestDrugViewModel> requestProducts;

        public int Id { set { id = value; } }

        private int? id;

        public FormViewRequest(IRequestService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void FormRequest_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RequestViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        requestProducts = new BindingList<RequestDrugViewModel>(view.RequestDrugs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (requestProducts == null)
            {
                requestProducts = new BindingList<RequestDrugViewModel>();
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dataGridViewRequests.DataSource = requestProducts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            double sum = 0;
            foreach (var productRequest in requestProducts)
            {
                sum += productRequest.Count * productRequest.Price;
            }
            textBoxTotalSum.Text = sum.ToString();
        }
    }
}
