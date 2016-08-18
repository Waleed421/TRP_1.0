using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRP_1._0
{
    public partial class EditActionReport : Form
    {
        int a = 0;
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
            var use = (from u in db.Users where u.Status == "Active" select u).FirstOrDefault();
            labelActive.Text = use.Name;
            dateTimePicker1.Value = DateTime.Today.AddMonths(-1);
           // var ctr = (from c in db.Cases select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.Title, c.TypeofCas.Type, c.Case_Comment }).Take(20).ToList();
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).ToList();
            gridControl1.DataSource = str;
            var res = (from x in db.TypeofCases
                       select new { x.Id, x.Type }).ToList();
            comboBoxCaseType.DataSource = res;
            comboBoxCaseType.DisplayMember = "Type";
            comboBoxCaseType.ValueMember = "Id";
            buttonSave.Enabled = false;
        }

        private void btnAddActionLine_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = "";
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).ToList();
            gridControl1.DataSource = str;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No"));
            var str = (from t in db.TimeRegistrations
                       where (t.Case_No == a)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.Type_Id, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).FirstOrDefault();
            textBox1.Text = str.Customer_Name;
            textBox2.Text = str.Customer_No;
            textBox3.Text = Convert.ToString(str.Case_No);
            textBox4.Text = str.Title;
            var stri = (from t in db.TimeRegistrations
                        where t.Case_No == a
                        select t).FirstOrDefault();
            textBox5.Text = Convert.ToString(stri.Time_In_Minutes);
            comboBoxCaseType.SelectedValue = str.Type_Id;
            textBox6.Text = str.Case_Comment;
            textBox7.Text = str.Action_Comment;
            buttonSave.Enabled = true;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox6.ReadOnly = true;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var stri = (from t in db.TimeRegistrations
                       where (t.Case_No == a)
                       select t).FirstOrDefault();
            stri.Time_In_Minutes = TimeSpan.Parse(textBox5.Text);
            stri.Action_Comment = textBox7.Text;
            db.SaveChanges();
            var str = (from t in db.TimeRegistrations
                       where (t.Start_Date_Time >= dateTimePicker1.Value && t.Start_Date_Time <= dateTimePicker2.Value)
                       select new { t.Case_No, t.Case.Customer.Customer_Name, t.Case.Customer.Customer_No, t.Case.Title, t.Case.TypeofCas.Type, t.Case.Case_Comment, t.Time_In_Minutes, t.Action_Comment }).ToList();
            gridControl1.DataSource = str;
        }
    }
}
