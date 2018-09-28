namespace VetClinicView
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.servicesButton = new System.Windows.Forms.Button();
            this.drugsButton = new System.Windows.Forms.Button();
            this.requestsButton = new System.Windows.Forms.Button();
            this.reportButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonBackupDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // servicesButton
            // 
            this.servicesButton.Location = new System.Drawing.Point(49, 27);
            this.servicesButton.Name = "servicesButton";
            this.servicesButton.Size = new System.Drawing.Size(157, 26);
            this.servicesButton.TabIndex = 0;
            this.servicesButton.Text = "Список услуг";
            this.servicesButton.UseVisualStyleBackColor = true;
            this.servicesButton.Click += new System.EventHandler(this.servicesButton_Click);
            // 
            // drugsButton
            // 
            this.drugsButton.Location = new System.Drawing.Point(49, 75);
            this.drugsButton.Name = "drugsButton";
            this.drugsButton.Size = new System.Drawing.Size(157, 26);
            this.drugsButton.TabIndex = 1;
            this.drugsButton.Text = "Список медикаментов";
            this.drugsButton.UseVisualStyleBackColor = true;
            this.drugsButton.Click += new System.EventHandler(this.drugsButton_Click);
            // 
            // requestsButton
            // 
            this.requestsButton.Location = new System.Drawing.Point(49, 124);
            this.requestsButton.Name = "requestsButton";
            this.requestsButton.Size = new System.Drawing.Size(157, 26);
            this.requestsButton.TabIndex = 2;
            this.requestsButton.Text = "Список заявок";
            this.requestsButton.UseVisualStyleBackColor = true;
            this.requestsButton.Click += new System.EventHandler(this.requestsButton_Click);
            // 
            // reportButton
            // 
            this.reportButton.Location = new System.Drawing.Point(49, 172);
            this.reportButton.Name = "reportButton";
            this.reportButton.Size = new System.Drawing.Size(157, 26);
            this.reportButton.TabIndex = 3;
            this.reportButton.Text = "Сформировать отчет";
            this.reportButton.UseVisualStyleBackColor = true;
            this.reportButton.Click += new System.EventHandler(this.reportButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Клиент";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBackupDB
            // 
            this.buttonBackupDB.Location = new System.Drawing.Point(49, 263);
            this.buttonBackupDB.Name = "buttonBackupDB";
            this.buttonBackupDB.Size = new System.Drawing.Size(157, 23);
            this.buttonBackupDB.TabIndex = 5;
            this.buttonBackupDB.Text = "Сохранить бд";
            this.buttonBackupDB.UseVisualStyleBackColor = true;
            this.buttonBackupDB.Click += new System.EventHandler(this.buttonBackupDB_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 313);
            this.Controls.Add(this.buttonBackupDB);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportButton);
            this.Controls.Add(this.requestsButton);
            this.Controls.Add(this.drugsButton);
            this.Controls.Add(this.servicesButton);
            this.Name = "FormMain";
            this.Text = "Ветклиника \"АйБолит\"";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button servicesButton;
        private System.Windows.Forms.Button drugsButton;
        private System.Windows.Forms.Button requestsButton;
        private System.Windows.Forms.Button reportButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonBackupDB;
    }
}