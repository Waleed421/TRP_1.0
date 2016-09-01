using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TRP_1._0;
using DevExpress.XtraGrid.Columns;
using System.Globalization;
using System.Threading;
using System.Reflection;


namespace TRP_1._0
{
    public partial class Main : Form
    {
        public int a;
        int min = 0;
        public int userID;
        EditActionReport ear = new EditActionReport();
        EditCaseType ect = new EditCaseType();
        EditCase ec = new EditCase();
        EditUser eu = new EditUser();
        EditCustomer ecr = new EditCustomer();

        TRPDbEntities db = new TRPDbEntities();

        public Main()
        {
            // C#
            // Sets the UI culture to French (France).
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        var cp = base.CreateParams;
        //        cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
        //        return cp;
        //    }
        //}

        private void btnEditActionReport_Click(object sender, EventArgs e)
        {
            EditActionReport.userID = userID;
            //EditActionReport e1 = new EditActionReport();
            ear.ShowDialog();
        }

        private void stopCase()
        {
            //Stopping currently active case, changing status
            var stat = (from s in db.Cases where s.Status == "Open" && s.Created_By_User_Id == userID select s).FirstOrDefault();
            if (stat != null)
            {
                stat.Status = "Closed";
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.Case_No == stat.Case_No select t).Take(1).FirstOrDefault();
                clos.Stop_Date_Time = DateTime.Now;
                clos.Action_Comment = textBoxActionComment.Text;
                DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
                TimeSpan difference = DateTime.Now.Subtract(last);
                clos.Time_In_Minutes = Convert.ToString(difference.Minutes);
                db.SaveChanges();
                var sumTime = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).ToList();
                int sum = 0;
                foreach (var item in sumTime)
                {
                    TimeSpan interval = TimeSpan.Parse(item.Time_In_Minutes);
                    sum += interval.Minutes;
                }
                bool res = int.TryParse(stat.Manual_Work_Time, out min);
                if (res)
                    stat.Worked_Time_in_Minutes = Convert.ToString(sum + min);
                else
                    stat.Worked_Time_in_Minutes = Convert.ToString(sum);

                db.SaveChanges();
            }
            textBoxActionComment.Clear();
        }
        private void startCase()
        {
            //Starting selected case, changing status
            var actionComment = (from tc in db.TimeRegistrations orderby tc.Id descending where tc.Case_No == a select tc).Take(1).FirstOrDefault();
            textBoxActionComment.Text = actionComment.Action_Comment;
            this.ActiveControl = textBoxActionComment;

            var up = (from c in db.Cases where c.Case_No == a select c).FirstOrDefault();
            up.Status = "Open";
            db.SaveChanges();

            TimeRegistration tr = new TimeRegistration();
            tr.Case_No = a;
            tr.Start_Date_Time = DateTime.Now;
            tr.Invoice = up.TypeofCas.Invoice_Type;
            db.TimeRegistrations.Add(tr);
            tr.User_Id = userID;
            db.SaveChanges();
            gridsUpdate();

        }
        private void gridsUpdate()
        {
            var rec = (dynamic)null;
            gridControl1.DataSource = null;
            gridControlRecentCases.DataSource = null;
            gridControlAllCases.DataSource = null;


            userID = Convert.ToInt32(comboBoxUser.SelectedValue);


            //Changing Active Case Grid
            var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;

            var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();

            if (getActiveCaseNo != null)
            {
                var actionComment = (from tc in db.TimeRegistrations orderby tc.Id descending where tc.Case_No == getActiveCaseNo.Case_No select tc).Skip(1).Take(1).FirstOrDefault();
                textBoxActionComment.Text = actionComment == null ? " " : actionComment.Action_Comment;
                this.ActiveControl = textBoxActionComment;
            }

            //Changing Recent Case Grid
            if (getActiveCaseNo != null)
            {
                var test1 = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();

                rec = (from t in test1 select new { t.Case_No, t.Customer_Name, t.Customer_No, t.Type, t.Title, t.Case_Comment, t.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            }
            else
            {
                var test1 = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();
                rec = (from t in test1 select new { t.Case_No, t.Customer_Name, t.Customer_No, t.Type, t.Title, t.Case_Comment, t.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            }
            gridControlRecentCases.DataSource = rec;

            if (getActiveCaseNo != null)
            {
                //Changing All Cases Grid
                var test2 = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();
                var recentCases = (from t in test2 select new { t.Case_No, t.Customer_Name, t.Customer_No, t.Type, t.Title, t.Case_Comment, t.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
                var allCases = (from t in db.TimeRegistrations where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Distinct().ToList();
                var test = allCases.Except(recentCases);
                gridControlAllCases.DataSource = test;
            }
            else
            {
                var test2 = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();
                var recentCases = (from t in test2 select new { t.Case_No, t.Customer_Name, t.Customer_No, t.Type, t.Title, t.Case_Comment, t.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
                var allCases = (from t in db.TimeRegistrations where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Distinct().ToList();
                var test = allCases.Except(recentCases).ToList();
                gridControlAllCases.DataSource = test;
            }

            if (gridView1.RowCount > 0)
                buttonStartSearched.Enabled = true;

        }
        private void buttonCreateCase_Click(object sender, EventArgs e)
        {
            stopCase();

            if (textCaseTitle.Text != "")
            {
                Case c = new Case();
                c.Title = textCaseTitle.Text;
                String type = comboBoxCaseType.Text;
                c.Case_Comment = textCaseComment.Text;
                c.Manual_Work_Time = textTimeInMinutes.Text;
                c.Worked_Time_in_Minutes = textTimeInMinutes.Text;
                c.Type_Id = Convert.ToInt16(comboBoxCaseType.SelectedValue);
                c.Customer_Id = Convert.ToInt16(comboBoxCustomerName.SelectedValue);
                c.Date_Time_Created = DateTime.Now;
                c.Created_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                c.Last_Edit_Date_Time = DateTime.Now;
                c.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                c.Status = "Open";
                MessageBox.Show("New Case Added");
                db.Cases.Add(c);
                db.SaveChanges();

                TimeRegistration tr = new TimeRegistration();
                var time = (from cas in db.Cases orderby cas.Case_No descending select new { cas.Case_No, cas.TypeofCas.Invoice_Type }).Take(1).FirstOrDefault();
                tr.Case_No = time.Case_No;
                tr.Start_Date_Time = DateTime.Now;
                tr.Invoice = time.Invoice_Type;
                tr.User_Id = userID;
                db.TimeRegistrations.Add(tr);
                db.SaveChanges();
            }
            else
                MessageBox.Show("Enter Case Title");
            gridsUpdate();
            textCaseTitle.Clear();
            textTimeInMinutes.Clear();
            textCaseComment.Clear();
            buttonStartRecent.Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            gridView3.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false;
            //foreach (Control c in this.Controls)
            //{
            //    ComponentResourceManager resources = new ComponentResourceManager(typeof(Main));
            //    resources.ApplyResources(c, c.Name, new System.Globalization.CultureInfo("fr - FR"));
            //}
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";

            var resActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).ToList();
            comboBoxUser.DataSource = resActiveUser;
            var changeActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).FirstOrDefault();
            comboBoxUser.SelectedValue = changeActiveUser.Id;

            gridsUpdate();

            var res = (from x in db.TypeofCases
                       select new { x.Id, x.Type }).ToList();
            comboBoxCaseType.DataSource = res;
            comboBoxCaseType.DisplayMember = "Type";
            comboBoxCaseType.ValueMember = "Id";
            var res1 = (from ct in db.Customers
                        select new { ct.Id, ct.Customer_Name }).ToList();
            comboBoxCustomerName.DataSource = res1;
            comboBoxCustomerName.DisplayMember = "Customer_Name";
            comboBoxCustomerName.ValueMember = "Id";
            if (gridView1.RowCount == 0)
            {
                buttonStartSearched.Enabled = false;
            }
            if (gridView2.RowCount == 0)
            {
                buttonStartRecent.Enabled = false;
            }
        }

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {
            //EditUser eu = new EditUser();
            eu.ShowDialog();
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";

            var resActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).ToList();
            comboBoxUser.DataSource = resActiveUser;

        }

        private void buttonEditCase_Click(object sender, EventArgs e)
        {
            EditCase.userID = userID;
           // EditCase ec = new EditCase();
            ec.ShowDialog();
            gridsUpdate();
            if (gridView3.RowCount == 0)
                textBoxActionComment.Clear();
        }

        private void buttonEditCustomer_Click(object sender, EventArgs e)
        {
            //EditCustomer ec = new EditCustomer();
            ecr.ShowDialog();
        }

        private void buttonCaseType_Click(object sender, EventArgs e)
        {
            //EditCaseType ect = new EditCaseType();
            ect.ShowDialog();
        }

        private void buttonStartSearched_Click(object sender, EventArgs e)
        {
            stopCase();
            if (gridView1.RowCount > 0)
            {
                //Starting selected case, changing status
                var id = gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No");
                a = Convert.ToInt32(id);
                startCase();
            }

        }

        private void comboBoxUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            userID = Convert.ToInt16(comboBoxUser.SelectedValue);
            var res = (from u in db.Users where u.Id == userID select u).FirstOrDefault();
            res.Status = "Active";
            db.SaveChanges();
            if (res.Language == "French")
            {
                ChangeLanguage("fr");
            }
            else if (res.Language == "Dutch")
            {
                ChangeLanguage("Dutch");
            }
            textBoxActionComment.Clear();
            gridsUpdate();
        }

        private void ChangeLanguage(string Lang)
        {
            switch (Lang)
            {
                case "fr":
                    label1.Text = ResourceLangfr.timeRegistrationProgramTitle;
                    label2.Text = ResourceLangfr.otherCaseSelection;
                    label7.Text = ResourceLangfr.activeUser;
                    buttonStartSearched.Text = ResourceLangfr.startDateTime;
                    label3.Text = ResourceLangfr.activeCase;
                    label12.Text = ResourceLangfr.actionComment;
                    label17.Text = ResourceLangfr.recentCases;
                    btnStopDateTime.Text = ResourceLangfr.stopDateTime;
                    buttonStartRecent.Text = ResourceLangfr.startDateTime;
                    label4.Text= ResourceLangfr.createCaseLine;
                    label6.Text = ResourceLangfr.customerName;
                    label9.Text = ResourceLangfr.caseType;
                    label11.Text = ResourceLangfr.timeInMinutes;
                    label8.Text = ResourceLangfr.caseTitle;
                    label10.Text = ResourceLangfr.caseComment;
                    buttonCreateCase.Text = ResourceLangfr.createCase;
                    label5.Text = ResourceLangfr.edit;
                    buttonChangeUser.Text = ResourceLangfr.user;
                    buttonEditCase.Text = ResourceLangfr.cases;
                    buttonEditCustomer.Text = ResourceLangfr.customer;
                    buttonCaseType.Text = ResourceLangfr.caseType;
                    btnEditActionReport.Text = ResourceLangfr.editActionReport;
                    ear.label1.Text = ResourceLangfr.editActionReport;
                    ear.label3.Text = ResourceLangfr.startDate;
                    ear.label4.Text = ResourceLangfr.endDate;
                    ear.buttonSearch.Text = ResourceLangfr.search;
                    ear.label2.Text = ResourceLangfr.user;
                    ear.buttonPrevious.Text = ResourceLangfr.previous;
                    ear.buttonNext.Text = ResourceLangfr.next;
                    ear.buttonEdit.Text = ResourceLangfr.edit;
                    ear.label6.Text = ResourceLangfr.customerName;
                    ear.label8.Text = ResourceLangfr.caseNo;
                    ear.label12.Text = ResourceLangfr.startDateTime;
                    ear.label7.Text = ResourceLangfr.customerNo;
                    ear.label11.Text = ResourceLangfr.caseType;
                    ear.label13.Text = ResourceLangfr.timeInMinutes;
                    ear.label9.Text = ResourceLangfr.caseTitle;
                    ear.label10.Text = ResourceLangfr.caseComment;
                    ear.label14.Text = ResourceLangfr.actionComment;
                    ear.btnAddActionLine.Text = ResourceLangfr.add;
                    ear.buttonSave.Text = ResourceLangfr.update;
                    ec.label1.Text = ResourceLangfr.customerName;
                    ec.label4.Text = ResourceLangfr.caseType;
                    ec.label2.Text = ResourceLangfr.customerNo;
                    ec.label5.Text = ResourceLangfr.caseComment;
                    ec.label3.Text = ResourceLangfr.caseTitle;
                    ec.label6.Text = ResourceLangfr.caseStatus;
                    ec.radioButtonOpen.Text = ResourceLangfr.open;
                    ec.radioButtonClosed.Text = ResourceLangfr.closed;
                    ec.button1.Text = ResourceLangfr.save;
                    ec.buttonEdit.Text = ResourceLangfr.edit;
                    ect.label6.Text = ResourceLangfr.description;
                    ect.label8.Text = ResourceLangfr.invoice;
                    ect.radioButtonYes.Text = ResourceLangfr.yes;
                    ect.radioButtonNo.Text = ResourceLangfr.no;
                    ect.buttonAdd.Text = ResourceLangfr.addCaseType;
                    ect.buttonSave.Text = ResourceLangfr.save;
                    ect.buttonEdit.Text = ResourceLangfr.edit;
                    ecr.label6.Text = ResourceLangfr.name;
                    ecr.label8.Text = ResourceLangfr.status;
                    ecr.radioButtonActive.Text = ResourceLangfr.active;
                    ecr.radioButtonInactive.Text = ResourceLangfr.inactive;
                    ecr.label7.Text = ResourceLangfr.number;
                    ecr.label4.Text = ResourceLangfr.manager;
                    ecr.buttonAdd.Text = ResourceLangfr.addCustomer;
                    ecr.buttonSave.Text = ResourceLangfr.save;
                    ecr.button1.Text = ResourceLangfr.editCustomer;
                    eu.label3.Text = ResourceLangfr.addNewUser;
                    eu.label1.Text = ResourceLangfr.editUser;
                    eu.label4.Text = ResourceLangfr.name;
                    eu.label5.Text = ResourceLangfr.number;
                    eu.label6.Text = ResourceLangfr.status;
                    eu.radioButtonActive.Text = ResourceLangfr.active;
                    eu.radioButtonInactive.Text = ResourceLangfr.inactive;
                    eu.label7.Text = ResourceLangfr.language;
                    eu.button1.Text = ResourceLangfr.addUser;
                    eu.buttonSave.Text = ResourceLangfr.save;
                    eu.button2.Text = ResourceLangfr.editUser;

                    break;
                case "du":
                    break;
                case "en":
                default:
                    break;
            }




        }

        private void applyResources(ComponentResourceManager resources, Control.ControlCollection controls)
        {
            foreach (Control ctl in controls)
            {
                resources.ApplyResources(ctl, ctl.Name);
                applyResources(resources, ctl.Controls);
            }
        }

        private void btnStopDateTime_Click(object sender, EventArgs e)
        {
            stopCase();
            textBoxActionComment.Clear();
            gridsUpdate();

        }


        private void textBoxActionComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.User_Id == userID select t).Take(1).FirstOrDefault();
                clos.Action_Comment = textBoxActionComment.Text;
                db.SaveChanges();
                MessageBox.Show("New Action Comment Saved");
                btnStopDateTime.Focus();
            }
        }

        private void buttonStartRecent_Click(object sender, EventArgs e)
        {
            stopCase();
            if (gridView2.RowCount > 0)
            {
                //Starting selected case, changing status
                var id = gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "Case_No");
                a = Convert.ToInt32(id);
                startCase();
            }
            gridsUpdate();

        }
    }
}

