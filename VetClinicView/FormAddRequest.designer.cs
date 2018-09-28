namespace VetClinicView
{
    partial class FormAddRequest
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalSum = new System.Windows.Forms.TextBox();
            this.buttonAddRequest = new System.Windows.Forms.Button();
            this.buttonAddDrugToRequest = new System.Windows.Forms.Button();
            this.buttonDeleteDrugFromRequest = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewRequestDrugs = new System.Windows.Forms.DataGridView();
            this.requestViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Цена = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestDrugs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Итог:";
            // 
            // textBoxTotalSum
            // 
            this.textBoxTotalSum.Enabled = false;
            this.textBoxTotalSum.Location = new System.Drawing.Point(473, 264);
            this.textBoxTotalSum.Name = "textBoxTotalSum";
            this.textBoxTotalSum.ReadOnly = true;
            this.textBoxTotalSum.Size = new System.Drawing.Size(67, 20);
            this.textBoxTotalSum.TabIndex = 4;
            // 
            // buttonAddRequest
            // 
            this.buttonAddRequest.Location = new System.Drawing.Point(413, 290);
            this.buttonAddRequest.Name = "buttonAddRequest";
            this.buttonAddRequest.Size = new System.Drawing.Size(127, 22);
            this.buttonAddRequest.TabIndex = 5;
            this.buttonAddRequest.Text = "Добавить заявку";
            this.buttonAddRequest.UseVisualStyleBackColor = true;
            this.buttonAddRequest.Click += new System.EventHandler(this.buttonAddRequest_Click);
            // 
            // buttonAddDrugToRequest
            // 
            this.buttonAddDrugToRequest.Location = new System.Drawing.Point(12, 291);
            this.buttonAddDrugToRequest.Name = "buttonAddDrugToRequest";
            this.buttonAddDrugToRequest.Size = new System.Drawing.Size(124, 53);
            this.buttonAddDrugToRequest.TabIndex = 6;
            this.buttonAddDrugToRequest.Text = "Добавить медикамент в заявку";
            this.buttonAddDrugToRequest.UseVisualStyleBackColor = true;
            this.buttonAddDrugToRequest.Click += new System.EventHandler(this.buttonAddDrugToRequest_Click);
            // 
            // buttonDeleteDrugFromRequest
            // 
            this.buttonDeleteDrugFromRequest.Location = new System.Drawing.Point(142, 291);
            this.buttonDeleteDrugFromRequest.Name = "buttonDeleteDrugFromRequest";
            this.buttonDeleteDrugFromRequest.Size = new System.Drawing.Size(124, 51);
            this.buttonDeleteDrugFromRequest.TabIndex = 7;
            this.buttonDeleteDrugFromRequest.Text = "Удалить медикамент из заявки";
            this.buttonDeleteDrugFromRequest.UseVisualStyleBackColor = true;
            this.buttonDeleteDrugFromRequest.Click += new System.EventHandler(this.buttonDeleteDrugFromRequest_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(413, 318);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(127, 24);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewRequestDrugs
            // 
            this.dataGridViewRequestDrugs.AllowUserToAddRows = false;
            this.dataGridViewRequestDrugs.AllowUserToDeleteRows = false;
            this.dataGridViewRequestDrugs.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewRequestDrugs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestDrugs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnProductName,
            this.ColumnCount,
            this.Цена});
            this.dataGridViewRequestDrugs.Location = new System.Drawing.Point(12, 22);
            this.dataGridViewRequestDrugs.MultiSelect = false;
            this.dataGridViewRequestDrugs.Name = "dataGridViewRequestDrugs";
            this.dataGridViewRequestDrugs.ReadOnly = true;
            this.dataGridViewRequestDrugs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequestDrugs.Size = new System.Drawing.Size(528, 236);
            this.dataGridViewRequestDrugs.TabIndex = 0;
            // 
            // requestViewModelBindingSource
            // 
            this.requestViewModelBindingSource.DataSource = typeof(VetClinicService.ViewModels.RequestViewModel);
            // 
            // ColumnProductName
            // 
            this.ColumnProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProductName.DataPropertyName = "DrugName";
            this.ColumnProductName.HeaderText = "Медикамент";
            this.ColumnProductName.Name = "ColumnProductName";
            this.ColumnProductName.ReadOnly = true;
            // 
            // ColumnCount
            // 
            this.ColumnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCount.DataPropertyName = "Count";
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            // 
            // Цена
            // 
            this.Цена.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Цена.DataPropertyName = "Price";
            this.Цена.HeaderText = "Цена";
            this.Цена.Name = "Цена";
            this.Цена.ReadOnly = true;
            // 
            // FormAddRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 356);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDeleteDrugFromRequest);
            this.Controls.Add(this.buttonAddDrugToRequest);
            this.Controls.Add(this.buttonAddRequest);
            this.Controls.Add(this.textBoxTotalSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewRequestDrugs);
            this.Name = "FormAddRequest";
            this.Text = "Формирование заявки";
            this.Load += new System.EventHandler(this.FormAddRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestDrugs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalSum;
        private System.Windows.Forms.Button buttonAddRequest;
        private System.Windows.Forms.Button buttonAddDrugToRequest;
        private System.Windows.Forms.Button buttonDeleteDrugFromRequest;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewRequestDrugs;
        private System.Windows.Forms.BindingSource requestViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Цена;
    }
}