using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Xpo;

namespace TRP_1._0
{
    public partial class EditActionReport : Form
    {
        int a = 0, b=0, cId=0, caseId=0, userID;
        public int pageSize = 20; // set your page size, which is number of records per page

        int page = 1; // set current page number, must be >= 1
        int skip;
        
        string invoice;
        TRPDbEntities db = new TRPDbEntities();
        public EditActionReport()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void EditActionReport_Load(object sender, EventArgs e)
        {
            var res1 = (from ct in db.Customers
                        select new { ct.Id, ct.Customer_Name }).ToList();
            comboBoxName.DataSource = res1;
            comboBoxName.DisplayMember = "Customer_Name";
            comboBoxName.ValueMember = "Id";

            var use = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
          
            userID = use.Id;
            labelActive.Text = use.Name;
            dateTimePicker1.Value = DateTime.Today.AddMonths(-1);
            // var ctr = (from c in db.Cases select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.Title, c.TypeofCas.Type, c.Case_Comment }).Take(20).ToList();

            skip = pageSize * (page - 1);
            if (page == 1)
                buttonPrevious.Enabled = false;
            var str = (from t in db.TimeRegistrations
                       orderby t.Id
                       where (t.User_Id==userID && t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Id, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Skip(skip).Take(pageSize).ToList();
            //XPQuery<TimeRegistration> tr = Session.DefaultSession.Query<TimeRegistration>();
            //xpCollection1.ObjectClassInfo = str;
            //xpPageSelector1.Collection = xpCollection1;
            gridControl1.DataSource = str;
            var Remaining = str.Count();
            if(Remaining<=skip)
                buttonNext.Enabled = false;
            

            var res = (from x in db.TypeofCases
                       select new { x.Id, x.Type }).ToList();
            comboBoxCaseType.DataSource = res;
            comboBoxCaseType.DisplayMember = "Type";
            comboBoxCaseType.ValueMember = "Id";
            buttonSave.Enabled = false;
            
        }
        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            page--;
            skip = pageSize * (page - 1);
            var str = (from t in db.TimeRegistrations
                       orderby t.Id
                       where (t.User_Id == userID && t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Id, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Skip(skip).Take(pageSize).ToList();
            gridControl1.DataSource = str;
            if (page == 1)
            {
                buttonPrevious.Enabled = false;
                buttonNext.Enabled = true;
            }
            else
                buttonPrevious.Enabled = true;
        }

       

        private void buttonNext_Click(object sender, EventArgs e)
        {
            page++;
            skip = pageSize * (page - 1);

            var str = (from t in db.TimeRegistrations
                       orderby t.Id
                       where (t.User_Id == userID && t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Id, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Skip(skip).Take(pageSize).ToList();
            gridControl1.DataSource = str;
            var Remaining = str.Count();
            if (Remaining <= skip)
                buttonNext.Enabled = false;
            if (page > 1)
                buttonPrevious.Enabled = true;
        }

        private void btnAddActionLine_Click(object sender, EventArgs e)
        {
            TimeRegistration tr = new TimeRegistration();
            tr.Case_No = caseId;
            tr.Start_Date_Time = dateTimePicker1.Value;
            double add = Convert.ToDouble(textBox5.Text);
          //  var test = dateTimePicker1.Value.AddMinutes(add);
            tr.Stop_Date_Time = dateTimePicker1.Value.AddMinutes(add);
            tr.Time_In_Minutes = textBox5.Text;
            tr.Invoice = invoice;
            tr.Action_Comment = textBox7.Text;
            var us = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
            tr.User_Id = us.Id;
            db.TimeRegistrations.Add(tr);
            db.SaveChanges();
            MessageBox.Show("Action Successfully Added");
            textBox7.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox3.Clear();
            textBox2.Clear();
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Id, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Take(20).ToList();
            gridControl1.DataSource = str;

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = "";
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Take(20).ToList();
            gridControl1.DataSource = str;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            b= Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Id"));
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No"));
            var str = (from t in db.TimeRegistrations
                       where (t.Id==b)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.Type_Id, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).FirstOrDefault();
            //textBox1.Text = str.Customer_Name;
            textBox2.Text = str.Customer_No;
            textBox3.Text = Convert.ToString(str.Case_No);
            //textBox4.Text = str.Title;
            var stri = (from t in db.TimeRegistrations
                        where t.Id==b
                        select t).FirstOrDefault();
            textBox5.Text = Convert.ToString(stri.Time_In_Minutes);
            comboBoxCaseType.SelectedValue = str.Type_Id;
            textBox6.Text = str.Case_Comment;
            textBox7.Text = str.Action_Comment;
            comboBoxName.SelectedValue = stri.Case.Customer_Id;
            cId = Convert.ToInt32(comboBoxName.SelectedValue);
            var res1 = (from c in db.Cases
                        where c.Customer_Id == cId
                        select new { c.Case_No, c.Title, c.TypeofCas.Type, c.Case_Comment, c.Customer.Customer_No }).ToList();
            comboBoxCaseTitle.DataSource = res1;
            comboBoxCaseTitle.DisplayMember = "Title";
            comboBoxCaseTitle.ValueMember = "Case_No";
            comboBoxCaseTitle.SelectedValue = str.Case_No;
            buttonSave.Enabled = true;
            //textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            //textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;
            dateTimePicker3.Enabled = false;
            comboBoxCaseType.Enabled = false;
            comboBoxName.Enabled = false;
            comboBoxCaseTitle.Enabled = false;
        }

        

        private void comboBoxCaseTitle_SelectionChangeCommitted(object sender, EventArgs e)
        {
            caseId = Convert.ToInt32(comboBoxCaseTitle.SelectedValue);
            var res = (from c in db.Cases where c.Case_No == caseId select c).FirstOrDefault();
            textBox3.Text = Convert.ToString(caseId);
           // textBox5.Text = res.Worked_Time_in_Minutes;
            textBox6.Text = res.Case_Comment;
            comboBoxCaseType.SelectedValue = res.TypeofCas.Id;
            invoice = res.TypeofCas.Invoice_Type;
        }

        private void comboBoxName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cId = Convert.ToInt32(comboBoxName.SelectedValue);
            var res1 = (from c in db.Cases
                        where c.Customer_Id == cId
                        select new { c.Case_No, c.Title, c.TypeofCas.Type, c.Case_Comment, c.Customer.Customer_No}).ToList();
            comboBoxCaseTitle.DataSource = res1;
            comboBoxCaseTitle.DisplayMember = "Title";
            comboBoxCaseTitle.ValueMember = "Case_No";
            var res2 = (from ct in db.Customers where ct.Id == cId select ct).FirstOrDefault();
            textBox2.Text = res2.Customer_No;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var stri = (from t in db.TimeRegistrations
                       where (t.Id==b)
                       select t).FirstOrDefault();
            stri.Time_In_Minutes = textBox5.Text;
            stri.Action_Comment = textBox7.Text;
            db.SaveChanges();
            MessageBox.Show("Edit Action Successfully Edited");
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new {t.Id, t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).Take(20).ToList();
            gridControl1.DataSource = str;
            buttonSave.Enabled = false;
            //textBox1.ReadOnly = false;
            textBox2.ReadOnly = false;
            textBox3.ReadOnly = false;
            //textBox4.ReadOnly = false;
            textBox6.ReadOnly = false;
            dateTimePicker3.Enabled = true;
            comboBoxCaseType.Enabled = true;
        }
    }
}
