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
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(199, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(322, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "TIME REGISTRATION PROGRAM";
            // 
            // panelOtherCase
            // 
            this.panelOtherCase.Controls.Add(this.label7);
            this.panelOtherCase.Controls.Add(this.comboBoxUser);
            this.panelOtherCase.Controls.Add(this.gridControlAllCases);
            this.panelOtherCase.Controls.Add(this.buttonStartSearched);
            this.panelOtherCase.Controls.Add(this.label2);
            this.panelOtherCase.Location = new System.Drawing.Point(11, 45);
            this.panelOtherCase.Name = "panelOtherCase";
            this.panelOtherCase.Size = new System.Drawing.Size(677, 191);
            this.panelOtherCase.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(460, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Active User";
            // 
            // comboBoxUser
            // 
            this.comboBoxUser.FormattingEnabled = true;
            this.comboBoxUser.Location = new System.Drawing.Point(542, -1);
            this.comboBoxUser.Name = "comboBoxUser";
            this.comboBoxUser.Size = new System.Drawing.Size(135, 21);
            this.comboBoxUser.TabIndex = 6;
            this.comboBoxUser.SelectionChangeCommitted += new System.EventHandler(this.comboBoxUser_SelectionChangeCommitted);
            // 
            // gridControlAllCases
            // 
            this.gridControlAllCases.Location = new System.Drawing.Point(2, 22);
            this.gridControlAllCases.MainView = this.gridView1;
            this.gridControlAllCases.Name = "gridControlAllCases";
            this.gridControlAllCases.Size = new System.Drawing.Size(541, 166);
            this.gridControlAllCases.TabIndex = 23;
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
            this.buttonStartSearched.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartSearched.Location = new System.Drawing.Point(549, 75);
            this.buttonStartSearched.Name = "buttonStartSearched";
            this.buttonStartSearched.Size = new System.Drawing.Size(107, 45);
            this.buttonStartSearched.TabIndex = 22;
            this.buttonStartSearched.Text = "Start Date/Time Stamp";
            this.buttonStartSearched.UseVisualStyleBackColor = true;
            this.buttonStartSearched.Click += new System.EventHandler(this.buttonStartSearched_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Other Case Selection";
            // 
            // btnEditActionReport
            // 
            this.btnEditActionReport.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditActionReport.Location = new System.Drawing.Point(518, 4);
            this.btnEditActionReport.Name = "btnEditActionReport";
            this.btnEditActionReport.Size = new System.Drawing.Size(138, 38);
            this.btnEditActionReport.TabIndex = 11;
            this.btnEditActionReport.Text = "Edit Action Report";
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
            this.panelCaseList.Location = new System.Drawing.Point(13, 261);
            this.panelCaseList.Name = "panelCaseList";
            this.panelCaseList.Size = new System.Drawing.Size(675, 229);
            this.panelCaseList.TabIndex = 2;
            // 
            // btnStopDateTime
            // 
            this.btnStopDateTime.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStopDateTime.Location = new System.Drawing.Point(550, 46);
            this.btnStopDateTime.Name = "btnStopDateTime";
            this.btnStopDateTime.Size = new System.Drawing.Size(104, 44);
            this.btnStopDateTime.TabIndex = 5;
            this.btnStopDateTime.Text = "Stop Date/Time";
            this.btnStopDateTime.UseVisualStyleBackColor = true;
            this.btnStopDateTime.Click += new System.EventHandler(this.btnStopDateTime_Click);
            // 
            // textBoxActionComment
            // 
            this.textBoxActionComment.Location = new System.Drawing.Point(550, 19);
            this.textBoxActionComment.Name = "textBoxActionComment";
            this.textBoxActionComment.Size = new System.Drawing.Size(104, 21);
            this.textBoxActionComment.TabIndex = 6;
            this.textBoxActionComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxActionComment_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(547, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(102, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "Action Comment";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 3);
            this.gridControl1.MainView = this.gridView3;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(541, 46);
            this.gridControl1.TabIndex = 24;
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
            this.gridControlRecentCases.Location = new System.Drawing.Point(1, 74);
            this.gridControlRecentCases.MainView = this.gridView2;
            this.gridControlRecentCases.Name = "gridControlRecentCases";
            this.gridControlRecentCases.Size = new System.Drawing.Size(540, 130);
            this.gridControlRecentCases.TabIndex = 26;
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
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(118, 19);
            this.label17.TabIndex = 24;
            this.label17.Text = "Recent Cases";
            // 
            // buttonStartRecent
            // 
            this.buttonStartRecent.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartRecent.Location = new System.Drawing.Point(550, 136);
            this.buttonStartRecent.Name = "buttonStartRecent";
            this.buttonStartRecent.Size = new System.Drawing.Size(104, 42);
            this.buttonStartRecent.TabIndex = 23;
            this.buttonStartRecent.Text = "Start Date/Time Stamp";
            this.buttonStartRecent.UseVisualStyleBackColor = true;
            this.buttonStartRecent.Click += new System.EventHandler(this.buttonStartRecent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Active Case";
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
            this.panelCreateCase.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelCreateCase.Location = new System.Drawing.Point(13, 471);
            this.panelCreateCase.Name = "panelCreateCase";
            this.panelCreateCase.Size = new System.Drawing.Size(675, 108);
            this.panelCreateCase.TabIndex = 3;
            // 
            // textTimeInMinutes
            // 
            this.textTimeInMinutes.Location = new System.Drawing.Point(549, 27);
            this.textTimeInMinutes.Mask = "00000";
            this.textTimeInMinutes.Name = "textTimeInMinutes";
            this.textTimeInMinutes.PromptChar = ' ';
            this.textTimeInMinutes.Size = new System.Drawing.Size(105, 23);
            this.textTimeInMinutes.TabIndex = 5;
            // 
            // comboBoxCustomerName
            // 
            this.comboBoxCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomerName.FormattingEnabled = true;
            this.comboBoxCustomerName.Location = new System.Drawing.Point(99, 27);
            this.comboBoxCustomerName.Name = "comboBoxCustomerName";
            this.comboBoxCustomerName.Size = new System.Drawing.Size(109, 24);
            this.comboBoxCustomerName.TabIndex = 1;
            // 
            // comboBoxCaseType
            // 
            this.comboBoxCaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCaseType.FormattingEnabled = true;
            this.comboBoxCaseType.Location = new System.Drawing.Point(315, 27);
            this.comboBoxCaseType.Name = "comboBoxCaseType";
            this.comboBoxCaseType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCaseType.TabIndex = 3;
            // 
            // textCaseComment
            // 
            this.textCaseComment.Location = new System.Drawing.Point(315, 75);
            this.textCaseComment.Name = "textCaseComment";
            this.textCaseComment.Size = new System.Drawing.Size(121, 23);
            this.textCaseComment.TabIndex = 4;
            // 
            // textCaseTitle
            // 
            this.textCaseTitle.Location = new System.Drawing.Point(99, 75);
            this.textCaseTitle.Name = "textCaseTitle";
            this.textCaseTitle.Size = new System.Drawing.Size(109, 23);
            this.textCaseTitle.TabIndex = 2;
            // 
            // buttonCreateCase
            // 
            this.buttonCreateCase.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCreateCase.Location = new System.Drawing.Point(550, 63);
            this.buttonCreateCase.Name = "buttonCreateCase";
            this.buttonCreateCase.Size = new System.Drawing.Size(104, 35);
            this.buttonCreateCase.TabIndex = 6;
            this.buttonCreateCase.Text = "Create Case";
            this.buttonCreateCase.UseVisualStyleBackColor = true;
            this.buttonCreateCase.Click += new System.EventHandler(this.buttonCreateCase_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(440, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 6;
            this.label11.Text = "Time in Minutes";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 16);
            this.label10.TabIndex = 5;
            this.label10.Text = "Case Comment";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 16);
            this.label9.TabIndex = 4;
            this.label9.Text = "Case Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 82);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Case Title";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Customer Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Create Case Line";
            // 
            // panelEdit
            // 
            this.panelEdit.Controls.Add(this.buttonCaseType);
            this.panelEdit.Controls.Add(this.buttonEditCustomer);
            this.panelEdit.Controls.Add(this.btnEditActionReport);
            this.panelEdit.Controls.Add(this.buttonEditCase);
            this.panelEdit.Controls.Add(this.buttonChangeUser);
            this.panelEdit.Controls.Add(this.label5);
            this.panelEdit.Location = new System.Drawing.Point(11, 585);
            this.panelEdit.Name = "panelEdit";
            this.panelEdit.Size = new System.Drawing.Size(677, 57);
            this.panelEdit.TabIndex = 4;
            // 
            // buttonCaseType
            // 
            this.buttonCaseType.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCaseType.Location = new System.Drawing.Point(414, 5);
            this.buttonCaseType.Name = "buttonCaseType";
            this.buttonCaseType.Size = new System.Drawing.Size(83, 37);
            this.buttonCaseType.TabIndex = 10;
            this.buttonCaseType.Text = "Case Type";
            this.buttonCaseType.UseVisualStyleBackColor = true;
            this.buttonCaseType.Click += new System.EventHandler(this.buttonCaseType_Click);
            // 
            // buttonEditCustomer
            // 
            this.buttonEditCustomer.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCustomer.Location = new System.Drawing.Point(314, 5);
            this.buttonEditCustomer.Name = "buttonEditCustomer";
            this.buttonEditCustomer.Size = new System.Drawing.Size(79, 38);
            this.buttonEditCustomer.TabIndex = 9;
            this.buttonEditCustomer.Text = "Customer";
            this.buttonEditCustomer.UseVisualStyleBackColor = true;
            this.buttonEditCustomer.Click += new System.EventHandler(this.buttonEditCustomer_Click);
            // 
            // buttonEditCase
            // 
            this.buttonEditCase.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditCase.Location = new System.Drawing.Point(204, 5);
            this.buttonEditCase.Name = "buttonEditCase";
            this.buttonEditCase.Size = new System.Drawing.Size(75, 37);
            this.buttonEditCase.TabIndex = 8;
            this.buttonEditCase.Text = "Case";
            this.buttonEditCase.UseVisualStyleBackColor = true;
            this.buttonEditCase.Click += new System.EventHandler(this.buttonEditCase_Click);
            // 
            // buttonChangeUser
            // 
            this.buttonChangeUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeUser.Location = new System.Drawing.Point(83, 4);
            this.buttonChangeUser.Name = "buttonChangeUser";
            this.buttonChangeUser.Size = new System.Drawing.Size(87, 38);
            this.buttonChangeUser.TabIndex = 7;
            this.buttonChangeUser.Text = "User";
            this.buttonChangeUser.UseVisualStyleBackColor = true;
            this.buttonChangeUser.Click += new System.EventHandler(this.buttonChangeUser_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "Edit";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 643);
            this.Controls.Add(this.panelEdit);
            this.Controls.Add(this.panelCreateCase);
            this.Controls.Add(this.panelCaseList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelOtherCase);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Registration Program";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelOtherCase;
        private System.Windows.Forms.Panel panelCaseList;
        private System.Windows.Forms.Panel panelCreateCase;
        private System.Windows.Forms.Panel panelEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCaseComment;
        private System.Windows.Forms.TextBox textCaseTitle;
        private System.Windows.Forms.Button buttonCreateCase;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditActionReport;
        private System.Windows.Forms.Button buttonCaseType;
        private System.Windows.Forms.Button buttonEditCustomer;
        private System.Windows.Forms.Button buttonEditCase;
        private System.Windows.Forms.Button buttonChangeUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStopDateTime;
        private System.Windows.Forms.Button buttonStartSearched;
        private System.Windows.Forms.Button buttonStartRecent;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox comboBoxCaseType;
        private TRPDbDataSet tRPDbDataSet;
        private System.Windows.Forms.BindingSource casesBindingSource;
        private TRPDbDataSetTableAdapters.CasesTableAdapter casesTableAdapter;
        private System.Windows.Forms.BindingSource customerBindingSource;
        private TRPDbDataSetTableAdapters.CustomerTableAdapter customerTableAdapter;
        private System.Windows.Forms.ComboBox comboBoxCustomerName;
        private DevExpress.XtraGrid.GridControl gridControlRecentCases;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxUser;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxActionComment;
        private DevExpress.XtraGrid.GridControl gridControlAllCases;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.MaskedTextBox textTimeInMinutes;
    }
}

