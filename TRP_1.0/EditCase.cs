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
    public partial class EditCase : Form
    {
        public int userID;
        int a = 0;
        TRPDbEntities db = new TRPDbEntities();
        public EditCase()
        {
            InitializeComponent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Case_No"));
            var edit = (from c in db.Cases where c.Case_No == a select c).FirstOrDefault();
            CustomerName.Text = edit.Customer.Customer_Name;
            CustomerNo.Text = edit.Customer.Customer_No;
            CaseTitle.Text = edit.Title;
            comboBoxCaseType.SelectedValue = edit.Type_Id;
            textBoxCaseComment.Text = edit.Case_Comment;
            if (edit.Status == "Open")
                radioButtonOpen.Checked = true;
            else if (edit.Status== "Closed")
                radioButtonClosed.Checked = true;
            button1.Enabled = true;
        }

        private void EditCase_Load(object sender, EventArgs e)
        {
            var ActiveUser = (from u in db.Users where u.Status == "Active" select new { u.Id, u.Name }).FirstOrDefault();
            userID = ActiveUser.Id;
            button1.Enabled = false;
            var res = (from c in db.Cases where c.Created_By_User_Id==userID select new { c.Case_No, c.Customer.Customer_Name,c.Customer.Customer_No, c.Title, c.TypeofCas.Type, c.Case_Comment, c.Status }).ToList();
            gridControl1.DataSource = res;
            var res1= (from x in db.TypeofCases
                       select new { x.Id, x.Type }).ToList();
            comboBoxCaseType.DataSource = res1;
            comboBoxCaseType.DisplayMember = "Type";
            comboBoxCaseType.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var save = (from c in db.Cases where c.Case_No == a select c).FirstOrDefault();
            save.Type_Id = Convert.ToInt16(comboBoxCaseType.SelectedValue);
            save.Case_Comment = textBoxCaseComment.Text;
            if (radioButtonOpen.Checked)
            {
                save.Status = "Open";                
            }
            else if (radioButtonClosed.Checked)
                save.Status = "Closed";
            db.SaveChanges();
            MessageBox.Show("Case Successfully Edited");
            button1.Enabled = false;
            var res = (from c in db.Cases where c.Created_By_User_Id == userID select new { c.Case_No, c.Customer.Customer_Name, c.Customer.Customer_No, c.Title, c.TypeofCas.Type, c.Case_Comment, c.Status }).ToList();
            gridControl1.DataSource = res;
        }
    }
}
