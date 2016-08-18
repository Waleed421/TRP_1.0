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
        int a = 0, b = 0;
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

        private void buttonCreateCase_Click(object sender, EventArgs e)
        {
            //Stopping currently active case, changing status
            //b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" select s).FirstOrDefault();
            stat.Status = "Closed";
            stat.Last_Edit_Date_Time = DateTime.Now;
            stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
            var clos = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).FirstOrDefault();
            clos.Stop_Date_Time = DateTime.Now;
            DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
            TimeSpan difference = DateTime.Now.Subtract(last);
            clos.Time_In_Minutes = difference;
            db.SaveChanges();

            Case c = new Case();
            c.Title = textCaseTitle.Text;
            String type = comboBoxCaseType.Text;
            c.Case_Comment = textCaseComment.Text;
            c.Worked_Time_in_Minutes = textTimeInMinutes.Text;
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
            db.TimeRegistrations.Add(tr);
            db.SaveChanges();

            ////Stopping currently active case, changing status
            ////b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            //var stat = (from s in db.Cases where s.Status=="Open" select s).FirstOrDefault();
            //stat.Status = "Closed";
            //stat.Last_Edit_Date_Time = DateTime.Now;
            //stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
            //var clos = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).FirstOrDefault();
            //clos.Stop_Date_Time = DateTime.Now;
            //DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
            //TimeSpan difference = DateTime.Now.Subtract(last);
            //clos.Time_In_Minutes = difference;
            //db.SaveChanges();

           

            //Changing currently active case grid
            var activeCase = (from cas in db.Cases where cas.Status == "Open" select new { cas.Case_No, cas.Customer.Customer_Name, cas.Customer.Customer_No, cas.TypeofCas.Type, cas.Title, cas.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;
            

            
            var allCase = (from x in db.Cases select new { x.Customer.Customer_Name, x.Customer.Customer_No, x.Case_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            gridControlAllCases.DataSource = allCase;
            var recCases = (from ca in db.Cases orderby ca.Case_No descending select new { ca.Case_No, ca.Customer.Customer_Name, ca.Customer.Customer_No, ca.TypeofCas.Type, ca.Title, ca.Case_Comment }).Take(5).ToList();
            gridControlRecentCases.DataSource = recCases;
            textCaseTitle.Clear();
            textTimeInMinutes.Clear();
            textCaseComment.Clear();

        }

        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tRPDbDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.tRPDbDataSet.Customer);
            // TODO: This line of code loads data into the 'tRPDbDataSet.Cases' table. You can move, or remove it, as needed.
            this.casesTableAdapter.Fill(this.tRPDbDataSet.Cases);
            var recCases = (from c in db.Cases orderby c.Case_No descending select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).Take(5).ToList();
            gridControlRecentCases.DataSource = recCases;
            var allCase = (from x in db.Cases select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No,  x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            gridControlAllCases.DataSource = allCase;
            var activeCase = (from c in db.Cases where c.Status=="Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;
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
            //var changeActiveUser= (from u in db.Users where u.Status=="Active" select new { u.Id, u.Name }).FirstOrDefault();
            //comboBoxUser.SelectedValue= changeActiveUser.Id;
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
            var recCases = (from c in db.Cases orderby c.Case_No descending select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).Take(5).ToList();
            gridControlRecentCases.DataSource = recCases;
            var allCase = (from x in db.Cases select new { x.Case_No, x.Customer.Customer_Name, x.Customer.Customer_No, x.Title, x.TypeofCas.Type, x.Case_Comment }).ToList();
            gridControlAllCases.DataSource = allCase;
            var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;
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
            //Stopping currently active case, changing status
           // b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" select s).FirstOrDefault();
            stat.Status = "Closed";
            stat.Last_Edit_Date_Time = DateTime.Now;
            stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
            var clos = (from t in db.TimeRegistrations where t.Case_No == stat.Case_No select t).FirstOrDefault();
            clos.Stop_Date_Time = DateTime.Now;
            DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
            TimeSpan difference = DateTime.Now.Subtract(last);
            clos.Time_In_Minutes = difference;
            db.SaveChanges();

            //Starting selected case, changing status
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No"));
            var up = (from c in db.Cases where c.Case_No == a select c).FirstOrDefault();
            up.Status = "Open";
            db.SaveChanges();

            //Changing currently active case grid
            var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;



        }

        
        private void comboBoxUser_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var inactiveStatus = (from u1 in db.Users select u1).ToList();
            foreach (var item in inactiveStatus)
            {
                item.Status = "Inactive";
            }
            db.SaveChanges();
            int id = Convert.ToInt16(comboBoxUser.SelectedValue);
            var res = (from u in db.Users where u.Id == id select u).FirstOrDefault();
            res.Status = "Active";
            db.SaveChanges();
        }

        private void btnStopDateTime_Click(object sender, EventArgs e)
        {
            var stopCase = (from c in db.Cases where c.Status == "Open" select c).FirstOrDefault();
            stopCase.Status = "Closed";
            stopCase.Last_Edit_Date_Time = DateTime.Now;
            stopCase.Last_Edit_By_User_Id= Convert.ToInt16(comboBoxUser.SelectedValue);
            var clos = (from t in db.TimeRegistrations where t.Case_No == stopCase.Case_No select t).FirstOrDefault();
            clos.Stop_Date_Time = DateTime.Now;
            DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
            TimeSpan difference = DateTime.Now.Subtract(last);
            clos.Time_In_Minutes = difference;
            db.SaveChanges();
            db.SaveChanges();
            var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;
        }

        

        private void buttonStartRecent_Click(object sender, EventArgs e)
        {
            //Stopping currently active case, changing status
                 b = Convert.ToInt32(gridView3.GetRowCellValue(gridView3.GetSelectedRows()[0], "Case_No"));
            var stat = (from s in db.Cases where s.Status == "Open" select s).FirstOrDefault(); stat.Status = "closed";
            stat.Last_Edit_Date_Time = DateTime.Now;
            stat.Last_Edit_By_User_Id = Convert.ToInt16(comboBoxUser.SelectedValue);
            var clos = (from t in db.TimeRegistrations where t.Case_No == b select t).FirstOrDefault();
            clos.Stop_Date_Time = DateTime.Now;
            DateTime last = Convert.ToDateTime(clos.Start_Date_Time);
            TimeSpan difference = DateTime.Now.Subtract(last);
            clos.Time_In_Minutes = difference;
            db.SaveChanges();

            //Starting selected case, changing status
            a = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.GetSelectedRows()[0], "Case_No"));
            var up = (from c in db.Cases where c.Case_No == a select c).FirstOrDefault();
            up.Status = "Open";
            db.SaveChanges();

            //Changing currently active case grid
            var activeCase = (from c in db.Cases where c.Status == "Open" select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.TypeofCas.Type, c.Title, c.Case_Comment }).ToList();
            gridControl1.DataSource = activeCase;
        }


    }
}

