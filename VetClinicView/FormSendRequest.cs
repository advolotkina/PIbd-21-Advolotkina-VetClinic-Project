using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Unity;
using Unity.Attributes;

namespace VetClinicView
{
    public partial class FormSendRequest : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        private readonly IRequestService service;

        private List<RequestDrugViewModel> requestProducts;

        public int Id { set { id = value; } }

        private int? id;

        public FormSendRequest(IRequestService service)
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
                        requestProducts = view.RequestDrugs;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (requestProducts == null)
            {
                requestProducts = new List<RequestDrugViewModel>();
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните Email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string mail = textBoxEmail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (comboBoxFormatFile.Text == "")
            {
                MessageBox.Show("Выберите формат отправляемой заявки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SendEmail(textBoxEmail.Text, comboBoxFormatFile.Text);
            Close();
        }

        private void SendEmail(string mailAddress, string formatFile)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            String filePath = "";

            if (formatFile == "xls")
            {
                try
                {
                    filePath = Path.GetFullPath("Request.xls");
                    service.SaveRequestToXlsFile(service.GetElement(id.Value), filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (formatFile == "doc")
            {
                try
                {
                    filePath = Path.GetFullPath("Request.doc");
                    service.SaveRequestToDocFile(service.GetElement(id.Value), filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            try
            {
                objMailMessage.From = new MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = "Новая заявка на медикменты";
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;

                string file = Path.GetFullPath(filePath);
                Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                objMailMessage.Attachments.Add(attach);

                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                    ConfigurationManager.AppSettings["MailPassword"]);

                objSmtpClient.Send(objMailMessage);
               // File.Delete(filePath);
                MessageBox.Show("Заявка отправлена", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так"+" "+ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
