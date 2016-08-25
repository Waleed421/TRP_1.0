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
    public partial class EditCustomer : Form
    {
        public static int a = 0;
        TRPDbEntities db = new TRPDbEntities();
        public EditCustomer()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (Name.Text !="" && Number.Text != "")
            {
                Customer c = new Customer();
                c.Customer_Name = Name.Text;
                c.Customer_No = Number.Text;
                c.User_Id = Convert.ToInt16(comboBoxUsers.SelectedValue);
                if (radioButtonActive.Checked)
                    c.Customer_Status = "Active";
                else if (radioButtonInactive.Checked)
                    c.Customer_Status = "Inactive";
                db.Customers.Add(c);
                db.SaveChanges();
                MessageBox.Show("Customer successfully added");
            }
            else
                MessageBox.Show("Enter Customer Name and No.");
            var result = (from u in db.Customers select new { u.Id, u.Customer_Name, u.Customer_No, Customer_Manager = u.User.Name, u.Customer_Status }).ToList();
            gridControl1.DataSource = result;

        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tRPDbDataSet.Cases' table. You can move, or remove it, as needed.
            this.casesTableAdapter.Fill(this.tRPDbDataSet.Cases);
            // TODO: This line of code loads data into the 'tRPDbDataSet.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.tRPDbDataSet.Customer);
            var res = (from u in db.Users
                       select new { u.Id, u.Name }).ToList();
            comboBoxUsers.DataSource = res;
            comboBoxUsers.DisplayMember = "Name";
            comboBoxUsers.ValueMember = "Id";
            var result = (from u in db.Customers select new { u.Id, u.Customer_Name, u.Customer_No,Customer_Manager=u.User.Name, u.Customer_Status }).ToList();
            gridControl1.DataSource = result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Id"));
            //EditCustomerDetails ecd = new EditCustomerDetails();
            //this.Hide();
            //ecd.ShowDialog();
            var resActiveUser = (from u in db.Users select new { u.Id, u.Name }).ToList();
            comboBoxUsers.DataSource = resActiveUser;
            comboBoxUsers.DisplayMember = "Name";
            comboBoxUsers.ValueMember = "Id";
            var rec = (from u in db.Customers where u.Id == a select u).FirstOrDefault();
            Name.Text = rec.Customer_Name;
            Number.Text = rec.Customer_No;
            if (rec.Customer_Status == "Active")
                radioButtonActive.Checked = true;
            else if (rec.Customer_Status == "Inactive")
                radioButtonInactive.Checked = true;
            buttonSave.Enabled = true;
            Name.ReadOnly = true;
            Number.ReadOnly = true;

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var rec = (from u in db.Customers where u.Id == a select u).FirstOrDefault();
            if (radioButtonActive.Checked)
                rec.Customer_Status = "Active";
            else if (radioButtonInactive.Checked)
                rec.Customer_Status = "Inactive";
            rec.User_Id = Convert.ToInt16(comboBoxUsers.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("Customer Record Edited");
            var result = (from u in db.Customers select new { u.Id, u.Customer_Name, u.Customer_No, Customer_Manager = u.User.Name, u.Customer_Status }).ToList();
            gridControl1.DataSource = result;
            Name.ReadOnly = false;
            Number.ReadOnly = false;
            buttonSave.Enabled = false;
            Name.Clear();
            Number.Clear();            
        }

        private void Number_Leave(object sender, EventArgs e)
        {
            if (Number.ReadOnly == false)
            {
                var customer = from c in db.Customers select c;
                foreach (var item in customer)
                {
                    if (string.Equals(Number.Text, item.Customer_No, StringComparison.CurrentCultureIgnoreCase))
                    {
                        MessageBox.Show("Customer Number already exists");
                        Number.Focus();
                    }
                }
            }
        }
    }
}
