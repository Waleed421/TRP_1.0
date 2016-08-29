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
    public partial class EditUser : Form
    {
        public static int a = 0;
        TRPDbEntities db = new TRPDbEntities();
        public EditUser()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            var res = (from u in db.Users select new {u.Id, u.Name, u.Status, u.Language }).ToList();
            gridControlUsers.DataSource = res;
            gridView1.Columns["Id"].Visible = false;

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text != "" && textBoxNumber.Text != "")
            {
                User u = new User();
                u.Name = textBoxName.Text;
                u.Number = textBoxNumber.Text;
                u.Language = comboBoxLanguage.Text;
                if (radioButtonActive.Checked)
                    u.Status = "Active";
                else if (radioButtonInactive.Checked)
                    u.Status = "Inactive";
                db.Users.Add(u);
                db.SaveChanges();
                MessageBox.Show("New User Added");
                textBoxName.Clear();
                textBoxNumber.Clear();
                var res = (from ur in db.Users select new { ur.Id, ur.Name, ur.Status, ur.Language }).ToList();
                gridControlUsers.DataSource = res;
            }
            else
                MessageBox.Show("Enter User Name and No.");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Id"));
            var user = (from u in db.Users where u.Id == a select u).FirstOrDefault();
            textBoxName.Text = user.Name;
            textBoxNumber.Text = user.Number;
            if (user.Status == "Active")
                radioButtonActive.Checked = true;
            else if (user.Status == "Inactive")
                radioButtonInactive.Checked = true;
            button1.Enabled = false;
            buttonSave.Enabled = true;
            textBoxName.ReadOnly = true;
            textBoxNumber.ReadOnly = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var save = (from u in db.Users where u.Id == a select u).FirstOrDefault();
            if (radioButtonActive.Checked)
                save.Status = "Active";
            else if (radioButtonInactive.Checked)
                save.Status = "Inactive";
            save.Language = comboBoxLanguage.Text;
            db.SaveChanges();
            MessageBox.Show("User Record Edited");
            var res = (from u in db.Users select new { u.Id, u.Name, u.Status, u.Language }).ToList();
            gridControlUsers.DataSource = res;
            buttonSave.Enabled = false;
            textBoxName.ReadOnly = false;
            textBoxNumber.ReadOnly = false;
            button1.Enabled = true;
            textBoxName.Clear();
            textBoxNumber.Clear();
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if(textBoxName.ReadOnly==false)
            {
                var user = from u in db.Users select u;
                foreach(var item in user)
                {
                    if(string.Equals(textBoxName.Text, item.Name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        MessageBox.Show("Name already exists");
                        textBoxName.Focus();
                    }
                }
            }

        }
    }
}
