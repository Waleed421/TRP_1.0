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

namespace TRP_1._0
{
    public partial class Main : Form
    {
        public int a;
        int min = 0;
        public int userID;
        TRPDbEntities db = new TRPDbEntities();
        public Main()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x80;  // Turn on WS_EX_TOOLWINDOW
                return cp;
            }
        }

        private void btnEditActionReport_Click(object sender, EventArgs e)
        {
            EditActionReport.userID = userID;
            EditActionReport e1 = new EditActionReport();
            e1.ShowDialog();
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

            var up = (from c in db.Cases join y in db.TypeofCases on c.Type_Id equals y.Id where c.Case_No == a select new { c, y}).FirstOrDefault();
            up.c.Status = "Open";
            db.SaveChanges();

            TimeRegistration tr = new TimeRegistration();
            tr.Case_No = a;
            tr.Start_Date_Time = DateTime.Now;
            tr.Invoice = up.y.Invoice_Type;
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
            gridView3.OptionsView.ShowGroupPanel = false;
            gridView2.OptionsView.ShowGroupPanel = false;

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
            EditUser eu = new EditUser();
            eu.ShowDialog();
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";

            var resActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).ToList();
            comboBoxUser.DataSource = resActiveUser;

        }

        private void buttonEditCase_Click(object sender, EventArgs e)
        {
            EditCase.userID = userID;
            EditCase ec = new EditCase();
            ec.ShowDialog();
            gridsUpdate();
            if (gridView3.RowCount == 0)
                textBoxActionComment.Clear();
        }

        private void buttonEditCustomer_Click(object sender, EventArgs e)
        {
            EditCustomer ec = new EditCustomer();
            ec.ShowDialog();
        }

        private void buttonCaseType_Click(object sender, EventArgs e)
        {
            EditCaseType ect = new EditCaseType();
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
            textBoxActionComment.Clear();
            gridsUpdate();
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

