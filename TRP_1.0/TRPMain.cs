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

namespace TRP_1._0
{
    public partial class Main : Form
    {
        int a;
        public int userID;
        TRPDbEntities db = new TRPDbEntities();
        public Main()
        {
            InitializeComponent();

        }

        private void btnEditActionReport_Click(object sender, EventArgs e)
        {
            EditActionReport e1 = new EditActionReport();
            e1.ShowDialog();

        }
        private void gridsUpdate()
        {
            var rec = (dynamic)null;
            gridControl1.DataMember = "";
            gridControlRecentCases.DataMember = "";
            gridControlAllCases.DataMember = "";
            

            var ActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).FirstOrDefault();
            userID = ActiveUser.Id;

            //Changing Active Case Grid
            var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;

            //Changing Recent Case Grid
            var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();
            if (getActiveCaseNo != null)
            {
                var test1 = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No!=getActiveCaseNo.Case_No select new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();

                rec = (from t in test1 select new { t.Case_No, t.Customer_Name, t.Customer_No, t.Type, t.Title, t.Case_Comment, t.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
                // rec = (from t in db.TimeRegistrations where t.User_Id == userID select new { t.Start_Date_Time, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Distinct().OrderByDescending(x => x.Start_Date_Time).Take(5).ToList();
                //rec = (from t in db.TimeRegistrations orderby t.Id descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();
            }
            else
            {
                //rec = (from t in db.TimeRegistrations where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();
                //var rec1 = rec.DistinctBy(i => i.Case_No);
                //rec = db.TimeRegistrations.Select(t => new { t.Id, t.Case_No, Customer_Name = t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes })

                //    .GroupBy(t => t.Case_No)
                //   .Select(g => g.FirstOrDefault()).OrderByDescending(f => f.Id).Take(5).ToList();
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
                var test = allCases.Except(recentCases);
                gridControlAllCases.DataSource = test;
            }

           

        }
        private void buttonCreateCase_Click(object sender, EventArgs e)
        {
            //Stopping currently active case, changing status
            //b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" && s.Created_By_User_Id==userID select s).FirstOrDefault();
            if (stat != null)
            {
                stat.Status = "Closed";
                stat.Last_Edit_Date_Time = DateTime.Now;
                stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.Case_No == stat.Case_No select t).Take(1).FirstOrDefault();
                clos.Stop_Date_Time = DateTime.Now;
                DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
                TimeSpan difference = DateTime.Now.Subtract(last);
                clos.Time_In_Minutes = Convert.ToString(difference);
                db.SaveChanges();
                var sumTime = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).ToList();
                TimeSpan sum = TimeSpan.Zero;
                foreach (var item in sumTime)
                {
                    sum += TimeSpan.Parse(item.Time_In_Minutes);
                }
                stat.Worked_Time_in_Minutes = Convert.ToString(sum);
                db.SaveChanges();
            }
            textBoxActionComment.Clear();
            Case c = new Case();
            c.Title = textCaseTitle.Text;
            String type = comboBoxCaseType.Text;
            c.Case_Comment = textCaseComment.Text;
            //double add = Convert.ToDouble(textTimeInMinutes.Text);
            c.Manual_Work_Time = textTimeInMinutes.Text;
            c.Type_Id = Convert.ToInt16(comboBoxCaseType.SelectedValue);
            c.Customer_Id = Convert.ToInt16(comboBoxCustomerName.SelectedValue);
            c.Date_Time_Created = DateTime.Now;
            c.Created_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
            c.Status = "Open";       
            MessageBox.Show("New Case Added");
            db.Cases.Add(c);
            db.SaveChanges();
            TimeRegistration tr = new TimeRegistration();
            var time = (from cas in db.Cases orderby cas.Case_No descending select new {cas.Case_No, cas.TypeofCas.Invoice_Type}).Take(1).FirstOrDefault();
            tr.Case_No = time.Case_No;
            tr.Start_Date_Time = DateTime.Now;
            tr.Invoice = time.Invoice_Type;
            var us = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
            tr.User_Id= us.Id;
            db.TimeRegistrations.Add(tr);
            db.SaveChanges();
                              
            gridsUpdate();
            ////Changing currently active case grid
            //var activeCase = (from cas in db.Cases where cas.Status == "Open" && cas.Created_By_User_Id==userID select new { cas.Case_No, cas.Customer.Customer_Name, cas.Customer.Customer_No, cas.TypeofCas.Type, cas.Title, cas.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
            

            
            //var allCase = (from x in db.Cases where x.Created_By_User_Id==userID select new { x.Customer.Customer_Name, x.Customer.Customer_No, x.Case_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            //gridControlAllCases.DataSource = allCase;
            //var getActiveCaseNo = (from ci in db.Cases where ci.Status == "Open" && ci.Created_By_User_Id == userID select ci).FirstOrDefault();

            //var rec = (dynamic)null;
            //if (getActiveCaseNo != null)
            //{
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            //}
            //else
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            //gridControlRecentCases.DataSource = rec;

            textCaseTitle.Clear();
            textTimeInMinutes.Clear();
            textCaseComment.Clear();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            gridView3.OptionsView.ShowGroupPanel = false;
            // TODO: This line of code loads data into the 'tRPDbDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.tRPDbDataSet.Customer);
            // TODO: This line of code loads data into the 'tRPDbDataSet.Cases' table. You can move, or remove it, as needed.
            this.casesTableAdapter.Fill(this.tRPDbDataSet.Cases);
            var ActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).FirstOrDefault();
            userID = ActiveUser.Id;

            gridsUpdate();

          //  var rec= (dynamic)null; 
          //  var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
          //  gridControl1.DataSource = activeCase;
            var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();
          //  if (getActiveCaseNo != null)
          //  {
          //      rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();
          //      //rec = (from t in db.TimeRegistrations orderby t.Id descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();
          //  }
          //  else
          //  {
          //      rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID  select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();

          //  }
          //  var recentCases = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).Take(5).ToList();
          //  var allCases = (from t in db.TimeRegistrations where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, t.Case.Worked_Time_in_Minutes }).ToList();
          //  //var allCase = (from x in db.Cases where x.Created_By_User_Id == userID select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
          ////  var recentCases = (from x in db.Cases orderby x.Case_No descending where x.Created_By_User_Id == userID select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).Distinct().Take(5).ToList();
          //  var test = allCases.Except(recentCases);
          //  gridControlRecentCases.DataSource = rec;
           
          //   //var minus = allCase.Except(rec);
            
          //  gridControlAllCases.DataSource = test;


            if (getActiveCaseNo != null)
            {
                var actionComment = (from tc in db.TimeRegistrations orderby tc.Id descending where tc.Case_No == getActiveCaseNo.Case_No select tc).Take(1).FirstOrDefault();
                textBoxActionComment.Text = actionComment.Action_Comment;
                this.ActiveControl = textBoxActionComment;
            }
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
            
            comboBoxUser.DisplayMember = "Name";
            comboBoxUser.ValueMember = "Id";

            var resActiveUser = (from u in db.Users select new { u.Id, u.Name }).ToList();
            comboBoxUser.DataSource = resActiveUser;
            var changeActiveUser= (from u in db.Users where u.Status=="Active" select new { u.Id, u.Name }).FirstOrDefault();
            comboBoxUser.SelectedValue= changeActiveUser.Id;
        }

        private void buttonChangeUser_Click(object sender, EventArgs e)
        {
            EditUser eu = new EditUser();
            eu.ShowDialog();
        }

        private void buttonEditCase_Click(object sender, EventArgs e)
        {
            EditCase ec = new EditCase();
            ec.ShowDialog();
            gridsUpdate();
            //var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();
            //var recCases = (dynamic)null;
            //if (getActiveCaseNo != null)
            //{
            //    recCases = (from c in db.Cases orderby c.Case_No descending where c.Created_By_User_Id == userID && c.Case_No != getActiveCaseNo.Case_No select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).Take(5).ToList();
            //}
            //else
            //recCases = (from c in db.Cases orderby c.Case_No descending where c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).Take(5).ToList();
            
            //gridControlRecentCases.DataSource = recCases;
            //var allCase = (from x in db.Cases select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            //gridControlAllCases.DataSource = allCase;
            //var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id==userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
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
            var ActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).FirstOrDefault();
            int userID = ActiveUser.Id;

            //Stopping currently active case, changing status
            // b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" select s).FirstOrDefault();

            if (stat != null)
            {
                stat.Status = "Closed";
                //stat.Last_Edit_Date_Time = DateTime.Now;
                //stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.Case_No == stat.Case_No select t).Take(1).FirstOrDefault();

                clos.Stop_Date_Time = DateTime.Now;
                
                DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
                TimeSpan difference = DateTime.Now.Subtract(last);
                clos.Time_In_Minutes = Convert.ToString(difference);
                db.SaveChanges();

                var sumTime = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).ToList();
                TimeSpan sum = TimeSpan.Zero;
                foreach (var item in sumTime)
                {
                    if((item.Time_In_Minutes)!=null)
                    sum += TimeSpan.Parse(item.Time_In_Minutes);
                }
                stat.Worked_Time_in_Minutes = Convert.ToString(sum);
                
                db.SaveChanges();
            }
            textBoxActionComment.Clear();
            //var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();
            //var rec = (dynamic)null;
            //if (getActiveCaseNo != null)
            //{
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            //}
            //else
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();

            //gridControlRecentCases.DataSource = rec;

            //Starting selected case, changing status
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No"));
            var actionComment = (from tc in db.TimeRegistrations orderby tc.Id descending where tc.Case_No ==a select tc).Take(1).FirstOrDefault();
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
            var us = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
            tr.User_Id = us.Id;
            db.SaveChanges();

            ////Changing currently active case grid
            //var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
            gridsUpdate();



        }


        private void comboBoxUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var inactiveStatus = (from u1 in db.Users select u1).ToList();
            foreach (var item in inactiveStatus)
            {
                item.Status = "Inactive";
            }
            db.SaveChanges();
            userID = Convert.ToInt16(comboBoxUser.SelectedValue);
            var res = (from u in db.Users where u.Id == userID select u).FirstOrDefault();
            res.Status = "Active";
            db.SaveChanges();
            gridsUpdate();

            //var getActiveCaseNo = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select c).FirstOrDefault();
            //var rec = (dynamic)null;
            //if (getActiveCaseNo != null)
            //{
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID && t.Case_No != getActiveCaseNo.Case_No select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();
            //}
            //else
            //    rec = (from t in db.TimeRegistrations orderby t.Start_Date_Time descending where t.User_Id == userID select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.TypeofCas.Type, t.Case.Title, t.Case.Case_Comment, Time_In_Minutes = t.Case.Worked_Time_in_Minutes }).Distinct().Take(5).ToList();

            //// var recCases = (from c in db.Cases where c.Case_No== rec select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControlRecentCases.DataSource = rec;
            //var allCase = (from x in db.Cases where x.Created_By_User_Id == userID select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            //gridControlAllCases.DataSource = allCase;
            //var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
        }

        private void btnStopDateTime_Click(object sender, EventArgs e)
        {
            var stopCase = (from c in db.Cases where c.Status == "Open" select c).FirstOrDefault();
            if (stopCase != null)
            {
                stopCase.Status = "Closed";
                //stopCase.Last_Edit_Date_Time = DateTime.Now;
                //stopCase.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.Case_No == stopCase.Case_No select t).Take(1).FirstOrDefault();
                clos.Stop_Date_Time = DateTime.Now;
                DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
                TimeSpan difference = DateTime.Now.Subtract(last);
                clos.Time_In_Minutes = Convert.ToString(difference);
                db.SaveChanges();
                var sumTime = (from t in db.TimeRegistrations where t.Case_No == stopCase.Case_No select t).ToList();
                TimeSpan sum = TimeSpan.Zero;
                foreach (var item in sumTime)
                {
                    sum += TimeSpan.Parse(item.Time_In_Minutes);
                }
                stopCase.Worked_Time_in_Minutes = Convert.ToString(sum);
                
                db.SaveChanges();
                
            }
            textBoxActionComment.Clear();
            //var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
            gridsUpdate();

        }


        private void textBoxActionComment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var clos = (from t in db.TimeRegistrations orderby t.Id descending select t).Take(1).FirstOrDefault();
                clos.Action_Comment = textBoxActionComment.Text;
                db.SaveChanges();
                MessageBox.Show("New Action Comment Saved");                
            }
        }

        private void buttonStartRecent_Click(object sender, EventArgs e)
        {
            //Stopping currently active case, changing status
               //  b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" && s.Created_By_User_Id==userID select s).FirstOrDefault();
            if (stat != null)
            {
                stat.Status = "Closed";
                //stat.Last_Edit_Date_Time = DateTime.Now;
                //stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
                var clos = (from t in db.TimeRegistrations orderby t.Id descending where t.Case_No == stat.Case_No select t).Take(1).FirstOrDefault();
                clos.Stop_Date_Time = DateTime.Now;
                DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
                TimeSpan difference = DateTime.Now.Subtract(last);
                clos.Time_In_Minutes = Convert.ToString(difference);
                db.SaveChanges();
                var sumTime = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).ToList();
                TimeSpan sum = TimeSpan.Zero;
                foreach (var item in sumTime)
                {
                    sum += TimeSpan.Parse(item.Time_In_Minutes);
                }
                stat.Worked_Time_in_Minutes += sum;
                
                db.SaveChanges();
            }
            textBoxActionComment.Clear();
            //Starting selected case, changing status
            a = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "Case_No"));
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
            var us = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
            tr.User_Id = us.Id;
            db.TimeRegistrations.Add(tr);
            db.SaveChanges();

            ////Changing currently active case grid
            //var activeCase = (from c in db.Cases where c.Status == "Open" && c.Created_By_User_Id==userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            //gridControl1.DataSource = activeCase;
            gridsUpdate();

        }


    }
}

