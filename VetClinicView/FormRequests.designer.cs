namespace VetClinicView
{
    partial class FormRequests
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewRequests = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requestViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAddRequest = new System.Windows.Forms.Button();
            this.buttonSaveToExcel = new System.Windows.Forms.Button();
            this.buttonSendRequest = new System.Windows.Forms.Button();
            this.buttonSaveToWord = new System.Windows.Forms.Button();
            this.buttonDeleteRequest = new System.Windows.Forms.Button();
            this.buttonViewRequest = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequests
            // 
            this.dataGridViewRequests.AllowUserToAddRows = false;
            this.dataGridViewRequests.AllowUserToDeleteRows = false;
            this.dataGridViewRequests.AutoGenerateColumns = false;
            this.dataGridViewRequests.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DateCreate,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridViewRequests.DataSource = this.requestViewModelBindingSource;
            this.dataGridViewRequests.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewRequests.MultiSelect = false;
            this.dataGridViewRequests.Name = "dataGridViewRequests";
            this.dataGridViewRequests.ReadOnly = true;
            this.dataGridViewRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequests.Size = new System.Drawing.Size(469, 291);
            this.dataGridViewRequests.TabIndex = 7;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // DateCreate
            // 
            this.DateCreate.DataPropertyName = "DateCreate";
            this.DateCreate.HeaderText = "DateCreate";
            this.DateCreate.Name = "DateCreate";
            this.DateCreate.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // requestViewModelBindingSource
            // 
            this.requestViewModelBindingSource.DataSource = typeof(VetClinicService.ViewModels.RequestViewModel);
            // 
            // buttonAddRequest
            // 
            this.buttonAddRequest.Location = new System.Drawing.Point(495, 12);
            this.buttonAddRequest.Name = "buttonAddRequest";
            this.buttonAddRequest.Size = new System.Drawing.Size(139, 32);
            this.buttonAddRequest.TabIndex = 4;
            this.buttonAddRequest.Text = "Добавить заявку";
            this.buttonAddRequest.UseVisualStyleBackColor = true;
            this.buttonAddRequest.Click += new System.EventHandler(this.buttonAddRequest_Click);
            // 
            // buttonSaveToExcel
            // 
            this.buttonSaveToExcel.Location = new System.Drawing.Point(181, 309);
            this.buttonSaveToExcel.Name = "buttonSaveToExcel";
            this.buttonSaveToExcel.Size = new System.Drawing.Size(139, 32);
            this.buttonSaveToExcel.TabIndex = 8;
            this.buttonSaveToExcel.Text = "Сохранить в xls";
            this.buttonSaveToExcel.UseVisualStyleBackColor = true;
            this.buttonSaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // buttonSendRequest
            // 
            this.buttonSendRequest.Location = new System.Drawing.Point(495, 88);
            this.buttonSendRequest.Name = "buttonSendRequest";
            this.buttonSendRequest.Size = new System.Drawing.Size(139, 32);
            this.buttonSendRequest.TabIndex = 9;
            this.buttonSendRequest.Text = "Отправить заявку";
            this.buttonSendRequest.UseVisualStyleBackColor = true;
            this.buttonSendRequest.Click += new System.EventHandler(this.buttonSendRequest_Click);
            // 
            // buttonSaveToWord
            // 
            this.buttonSaveToWord.Location = new System.Drawing.Point(326, 309);
            this.buttonSaveToWord.Name = "buttonSaveToWord";
            this.buttonSaveToWord.Size = new System.Drawing.Size(139, 32);
            this.buttonSaveToWord.TabIndex = 10;
            this.buttonSaveToWord.Text = "Сохранить в doc";
            this.buttonSaveToWord.UseVisualStyleBackColor = true;
            this.buttonSaveToWord.Click += new System.EventHandler(this.buttonSaveToWord_Click);
            // 
            // buttonDeleteRequest
            // 
            this.buttonDeleteRequest.Location = new System.Drawing.Point(495, 50);
            this.buttonDeleteRequest.Name = "buttonDeleteRequest";
            this.buttonDeleteRequest.Size = new System.Drawing.Size(139, 32);
            this.buttonDeleteRequest.TabIndex = 11;
            this.buttonDeleteRequest.Text = "Удалить заявку";
            this.buttonDeleteRequest.UseVisualStyleBackColor = true;
            this.buttonDeleteRequest.Click += new System.EventHandler(this.buttonDeleteRequest_Click);
            // 
            // buttonViewRequest
            // 
            this.buttonViewRequest.Location = new System.Drawing.Point(495, 126);
            this.buttonViewRequest.Name = "buttonViewRequest";
            this.buttonViewRequest.Size = new System.Drawing.Size(140, 33);
            this.buttonViewRequest.TabIndex = 12;
            this.buttonViewRequest.Text = "Просмотреть заявку";
            this.buttonViewRequest.UseVisualStyleBackColor = true;
            this.buttonViewRequest.Click += new System.EventHandler(this.buttonViewRequest_Click);
            // 
            // FormRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 351);
            this.Controls.Add(this.buttonViewRequest);
            this.Controls.Add(this.buttonDeleteRequest);
            this.Controls.Add(this.buttonSaveToWord);
            this.Controls.Add(this.buttonSendRequest);
            this.Controls.Add(this.buttonSaveToExcel);
            this.Controls.Add(this.dataGridViewRequests);
            this.Controls.Add(this.buttonAddRequest);
            this.Name = "FormRequests";
            this.Text = "Список заявок";
            this.Load += new System.EventHandler(this.FormRequests_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequests)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRequests;
        private System.Windows.Forms.Button buttonAddRequest;
        private System.Windows.Forms.BindingSource requestViewModelBindingSource;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private System.Windows.Forms.Button buttonSendRequest;
        private System.Windows.Forms.Button buttonSaveToWord;
        private System.Windows.Forms.Button buttonDeleteRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonViewRequest;
    }
}