namespace TRP_1._0
{
    partial class EditCase
    {
        /// <
        /// mary>
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBoxCaseType = new System.Windows.Forms.ComboBox();
            this.textBoxCaseComment = new System.Windows.Forms.TextBox();
            this.radioButtonClosed = new System.Windows.Forms.RadioButton();
            this.radioButtonOpen = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.CustomerNo = new System.Windows.Forms.TextBox();
            this.CaseTitle = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEdit.Location = new System.Drawing.Point(624, 442);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(78, 43);
            this.buttonEdit.TabIndex = 5;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(624, 118);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxCaseType
            // 
            this.comboBoxCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaseType.FormattingEnabled = true;
            this.comboBoxCaseType.Location = new System.Drawing.Point(402, 36);
            this.comboBoxCaseType.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.comboBoxCaseType.Name = "comboBoxCaseType";
            this.comboBoxCaseType.Size = new System.Drawing.Size(168, 24);
            this.comboBoxCaseType.TabIndex = 15;
            // 
            // textBoxCaseComment
            // 
            this.textBoxCaseComment.Location = new System.Drawing.Point(402, 68);
            this.textBoxCaseComment.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.textBoxCaseComment.Name = "textBoxCaseComment";
            this.textBoxCaseComment.Size = new System.Drawing.Size(168, 23);
            this.textBoxCaseComment.TabIndex = 1;
            // 
            // radioButtonClosed
            // 
            this.radioButtonClosed.AutoSize = true;
            this.radioButtonClosed.Location = new System.Drawing.Point(472, 114);
            this.radioButtonClosed.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButtonClosed.Name = "radioButtonClosed";
            this.radioButtonClosed.Size = new System.Drawing.Size(64, 20);
            this.radioButtonClosed.TabIndex = 3;
            this.radioButtonClosed.TabStop = true;
            this.radioButtonClosed.Text = "Closed";
            this.radioButtonClosed.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpen
            // 
            this.radioButtonOpen.AutoSize = true;
            this.radioButtonOpen.Location = new System.Drawing.Point(402, 114);
            this.radioButtonOpen.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.radioButtonOpen.Name = "radioButtonOpen";
            this.radioButtonOpen.Size = new System.Drawing.Size(56, 20);
            this.radioButtonOpen.TabIndex = 2;
            this.radioButtonOpen.TabStop = true;
            this.radioButtonOpen.Text = "Open";
            this.radioButtonOpen.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 114);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Case Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(292, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Case Comment";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(292, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Case Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Case Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 16);
            this.label2.TabIndex = 16;
            this.label2.Text = "Customer No.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Customer Name";
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridControl1.Location = new System.Drawing.Point(12, 170);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(689, 265);
            this.gridControl1.TabIndex = 28;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // CustomerName
            // 
            this.CustomerName.Enabled = false;
            this.CustomerName.Location = new System.Drawing.Point(151, 32);
            this.CustomerName.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(132, 23);
            this.CustomerName.TabIndex = 29;
            // 
            // CustomerNo
            // 
            this.CustomerNo.Enabled = false;
            this.CustomerNo.Location = new System.Drawing.Point(151, 71);
            this.CustomerNo.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.CustomerNo.Name = "CustomerNo";
            this.CustomerNo.Size = new System.Drawing.Size(132, 23);
            this.CustomerNo.TabIndex = 30;
            // 
            // CaseTitle
            // 
            this.CaseTitle.Enabled = false;
            this.CaseTitle.Location = new System.Drawing.Point(151, 114);
            this.CaseTitle.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.CaseTitle.Name = "CaseTitle";
            this.CaseTitle.Size = new System.Drawing.Size(132, 23);
            this.CaseTitle.TabIndex = 31;
            // 
            // EditCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 500);
            this.Controls.Add(this.CaseTitle);
            this.Controls.Add(this.CustomerNo);
            this.Controls.Add(this.CustomerName);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCaseType);
            this.Controls.Add(this.textBoxCaseComment);
            this.Controls.Add(this.radioButtonClosed);
            this.Controls.Add(this.radioButtonOpen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonEdit);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "EditCase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Case";
            this.Load += new System.EventHandler(this.EditCase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxCaseType;
        private System.Windows.Forms.TextBox textBoxCaseComment;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.TextBox CustomerNo;
        private System.Windows.Forms.TextBox CaseTitle;
        public System.Windows.Forms.Button buttonEdit;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.RadioButton radioButtonClosed;
        public System.Windows.Forms.RadioButton radioButtonOpen;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
    }
}