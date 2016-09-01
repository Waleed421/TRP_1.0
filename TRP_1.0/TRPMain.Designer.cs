namespace TRP_1._0
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.panelOtherCase = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxUser = new System.Windows.Forms.ComboBox();
            this.gridControlAllCases = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.buttonStartSearched = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditActionReport = new System.Windows.Forms.Button();
            this.casesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tRPDbDataSet = new TRP_1._0.TRPDbDataSet();
            this.panelCaseList = new System.Windows.Forms.Panel();
            this.btnStopDateTime = new System.Windows.Forms.Button();
            this.textBoxActionComment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControlRecentCases = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonStartRecent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelCreateCase = new System.Windows.Forms.Panel();
            this.textTimeInMinutes = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxCustomerName = new System.Windows.Forms.ComboBox();
            this.comboBoxCaseType = new System.Windows.Forms.ComboBox();
            this.textCaseComment = new System.Windows.Forms.TextBox();
            this.textCaseTitle = new System.Windows.Forms.TextBox();
            this.buttonCreateCase = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelEdit = new System.Windows.Forms.Panel();
            this.buttonCaseType = new System.Windows.Forms.Button();
            this.buttonEditCustomer = new System.Windows.Forms.Button();
            this.buttonEditCase = new System.Windows.Forms.Button();
            this.buttonChangeUser = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.casesTableAdapter = new TRP_1._0.TRPDbDataSetTableAdapters.CasesTableAdapter();
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customerTableAdapter = new TRP_1._0.TRPDbDataSetTableAdapters.CustomerTableAdapter();
            this.panelOtherCase.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRPDbDataSet)).BeginInit();
            this.panelCaseList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRecentCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panelCreateCase.SuspendLayout();
            this.panelEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // panelOtherCase
            // 
            this.panelOtherCase.Controls.Add(this.label7);
            this.panelOtherCase.Controls.Add(this.comboBoxUser);
            this.panelOtherCase.Controls.Add(this.gridControlAllCases);
            this.panelOtherCase.Controls.Add(this.buttonStartSearched);
            this.panelOtherCase.Controls.Add(this.label2);
            resources.ApplyResources(this.panelOtherCase, "panelOtherCase");
            this.panelOtherCase.Name = "panelOtherCase";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUser.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxUser, "comboBoxUser");
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.SelectionChangeCommitted += new System.EventHandler(this.comboBoxUser_SelectionChangeCommitted);
            // 
            // gridControlAllCases
            // 
            resources.ApplyResources(this.gridControlAllCases, "gridControlAllCases");
            this.gridControlAllCases.MainView = this.gridView1;
            this.gridControlAllCases.Name = "gridControlAllCases";
            this.gridControlAllCases.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControlAllCases;
            this.gridView1.Name = "gridView1";
            // 
            // buttonStartSearched
            // 
            resources.ApplyResources(this.buttonStartSearched, "buttonStartSearched");
            this.buttonStartSearched.Name = "buttonStartSearched";
            this.buttonStartSearched.UseVisualStyleBackColor = true;
            this.buttonStartSearched.Click += new System.EventHandler(this.buttonStartSearched_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // btnEditActionReport
            // 
            resources.ApplyResources(this.btnEditActionReport, "btnEditActionReport");
            this.btnEditActionReport.Name = "btnEditActionReport";
            this.btnEditActionReport.UseVisualStyleBackColor = true;
            this.btnEditActionReport.Click += new System.EventHandler(this.btnEditActionReport_Click);
            // 
            // casesBindingSource
            // 
            this.casesBindingSource.DataMember = "Cases";
            this.casesBindingSource.DataSource = this.tRPDbDataSet;
            // 
            // tRPDbDataSet
            // 
            this.tRPDbDataSet.DataSetName = "TRPDbDataSet";
            this.tRPDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panelCaseList
            // 
            this.panelCaseList.Controls.Add(this.btnStopDateTime);
            this.panelCaseList.Controls.Add(this.textBoxActionComment);
            this.panelCaseList.Controls.Add(this.label12);
            this.panelCaseList.Controls.Add(this.gridControl1);
            this.panelCaseList.Controls.Add(this.gridControlRecentCases);
            this.panelCaseList.Controls.Add(this.label17);
            this.panelCaseList.Controls.Add(this.buttonStartRecent);
            resources.ApplyResources(this.panelCaseList, "panelCaseList");
            this.panelCaseList.Name = "panelCaseList";
            // 
            // btnStopDateTime
            // 
            resources.ApplyResources(this.btnStopDateTime, "btnStopDateTime");
            this.btnStopDateTime.Name = "btnStopDateTime";
            this.btnStopDateTime.UseVisualStyleBackColor = true;
            this.btnStopDateTime.Click += new System.EventHandler(this.btnStopDateTime_Click);
            // 
            // textBoxActionComment
            // 
            resources.ApplyResources(this.textBoxActionComment, "textBoxActionComment");
            this.textBoxActionComment.Name = "textBoxActionComment";
            this.textBoxActionComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxActionComment_KeyDown);
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // gridControl1
            // 
            resources.ApplyResources(this.gridControl1, "gridControl1");
            this.gridControl1.MainView = this.gridView3;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView3});
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.gridControl1;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsFilter.AllowFilterIncrementalSearch = false;
            // 
            // gridControlRecentCases
            // 
            resources.ApplyResources(this.gridControlRecentCases, "gridControlRecentCases");
            this.gridControlRecentCases.MainView = this.gridView2;
            this.gridControlRecentCases.Name = "gridControlRecentCases";
            this.gridControlRecentCases.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControlRecentCases;
            this.gridView2.Name = "gridView2";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // buttonStartRecent
            // 
            resources.ApplyResources(this.buttonStartRecent, "buttonStartRecent");
            this.buttonStartRecent.Name = "buttonStartRecent";
            this.buttonStartRecent.UseVisualStyleBackColor = true;
            this.buttonStartRecent.Click += new System.EventHandler(this.buttonStartRecent_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // panelCreateCase
            // 
            this.panelCreateCase.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelCreateCase.Controls.Add(this.textTimeInMinutes);
            this.panelCreateCase.Controls.Add(this.comboBoxCustomerName);
            this.panelCreateCase.Controls.Add(this.comboBoxCaseType);
            this.panelCreateCase.Controls.Add(this.textCaseComment);
            this.panelCreateCase.Controls.Add(this.textCaseTitle);
            this.panelCreateCase.Controls.Add(this.buttonCreateCase);
            this.panelCreateCase.Controls.Add(this.label11);
            this.panelCreateCase.Controls.Add(this.label10);
            this.panelCreateCase.Controls.Add(this.label9);
            this.panelCreateCase.Controls.Add(this.label8);
            this.panelCreateCase.Controls.Add(this.label6);
            this.panelCreateCase.Controls.Add(this.label4);
            resources.ApplyResources(this.panelCreateCase, "panelCreateCase");
            this.panelCreateCase.Name = "panelCreateCase";
            // 
            // textTimeInMinutes
            // 
            resources.ApplyResources(this.textTimeInMinutes, "textTimeInMinutes");
            this.textTimeInMinutes.Name = "textTimeInMinutes";
            // 
            // comboBoxCustomerName
            // 
            this.comboBoxCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomerName.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxCustomerName, "comboBoxCustomerName");
            this.comboBoxCustomerName.Name = "comboBoxCustomerName";
            // 
            // comboBoxCaseType
            // 
            this.comboBoxCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaseType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxCaseType, "comboBoxCaseType");
            this.comboBoxCaseType.Name = "comboBoxCaseType";
            // 
            // textCaseComment
            // 
            resources.ApplyResources(this.textCaseComment, "textCaseComment");
            this.textCaseComment.Name = "textCaseComment";
            // 
            // textCaseTitle
            // 
            resources.ApplyResources(this.textCaseTitle, "textCaseTitle");
            this.textCaseTitle.Name = "textCaseTitle";
            // 
            // buttonCreateCase
            // 
            resources.ApplyResources(this.buttonCreateCase, "buttonCreateCase");
            this.buttonCreateCase.Name = "buttonCreateCase";
            this.buttonCreateCase.UseVisualStyleBackColor = true;
            this.buttonCreateCase.Click += new System.EventHandler(this.buttonCreateCase_Click);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.buttonCaseType);
            this.panelEdit.Controls.Add(this.buttonEditCustomer);
            this.panelEdit.Controls.Add(this.btnEditActionReport);
            this.panelEdit.Controls.Add(this.buttonEditCase);
            this.panelEdit.Controls.Add(this.buttonChangeUser);
            this.panelEdit.Controls.Add(this.label5);
            resources.ApplyResources(this.panelEdit, "panelEdit");
            this.panelEdit.Name = "panelEdit";
            // 
            // buttonCaseType
            // 
            resources.ApplyResources(this.buttonCaseType, "buttonCaseType");
            this.buttonCaseType.Name = "buttonCaseType";
            this.buttonCaseType.UseVisualStyleBackColor = true;
            this.buttonCaseType.Click += new System.EventHandler(this.buttonCaseType_Click);
            // 
            // buttonEditCustomer
            // 
            resources.ApplyResources(this.buttonEditCustomer, "buttonEditCustomer");
            this.buttonEditCustomer.Name = "buttonEditCustomer";
            this.buttonEditCustomer.UseVisualStyleBackColor = true;
            this.buttonEditCustomer.Click += new System.EventHandler(this.buttonEditCustomer_Click);
            // 
            // buttonEditCase
            // 
            resources.ApplyResources(this.buttonEditCase, "buttonEditCase");
            this.buttonEditCase.Name = "buttonEditCase";
            this.buttonEditCase.UseVisualStyleBackColor = true;
            this.buttonEditCase.Click += new System.EventHandler(this.buttonEditCase_Click);
            // 
            // buttonChangeUser
            // 
            resources.ApplyResources(this.buttonChangeUser, "buttonChangeUser");
            this.buttonChangeUser.Name = "buttonChangeUser";
            this.buttonChangeUser.UseVisualStyleBackColor = true;
            this.buttonChangeUser.Click += new System.EventHandler(this.buttonChangeUser_Click);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // casesTableAdapter
            // 
            this.casesTableAdapter.ClearBeforeFill = true;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataMember = "Customer";
            this.customerBindingSource.DataSource = this.tRPDbDataSet;
            // 
            // customerTableAdapter
            // 
            this.customerTableAdapter.ClearBeforeFill = true;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelCreateCase);
            this.Controls.Add(this.panelCaseList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelOtherCase);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelOtherCase.ResumeLayout(false);
            this.panelOtherCase.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAllCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.casesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tRPDbDataSet)).EndInit();
            this.panelCaseList.ResumeLayout(false);
            this.panelCaseList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRecentCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panelCreateCase.ResumeLayout(false);
            this.panelCreateCase.PerformLayout();
            this.panelEdit.ResumeLayout(false);
            this.panelEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panelOtherCase;
        private System.Windows.Forms.Panel panelCaseList;
        private System.Windows.Forms.Panel panelCreateCase;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.TextBox textCaseComment;
        private System.Windows.Forms.TextBox textCaseTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonChangeUser;
        private System.Windows.Forms.ComboBox comboBoxCaseType;
        private TRPDbDataSet tRPDbDataSet;
        private System.Windows.Forms.BindingSource casesBindingSource;
        private TRPDbDataSetTableAdapters.CasesTableAdapter casesTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private TRPDbDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxCustomerName;
        private DevExpress.XtraGrid.GridControl gridControlRecentCases;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.TextBox textBoxActionComment;
        private DevExpress.XtraGrid.GridControl gridControlAllCases;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MaskedTextBox textTimeInMinutes;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button buttonCreateCase;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnEditActionReport;
        public System.Windows.Forms.Button buttonCaseType;
        public System.Windows.Forms.Button buttonEditCustomer;
        public System.Windows.Forms.Button buttonEditCase;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnStopDateTime;
        public System.Windows.Forms.Button buttonStartSearched;
        public System.Windows.Forms.Button buttonStartRecent;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label12;
    }
}

