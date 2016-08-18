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
    public partial class EditUserDetails : Form
    {

        int a = EditUser.a;
        TRPDbEntities db = new TRPDbEntities();
        public EditUserDetails()
        {
            InitializeComponent();
        }

        private void EditUserDetails_Load(object sender, EventArgs e)
        {
            var rec = (from u in db.Users where u.Id == a select u).FirstOrDefault();
            Name.Text = rec.Name;
            Number.Text = rec.Number;
            if (rec.Status == "Active")
                radioButtonActive.Enabled = true;
            else if (rec.Status == "Inactive")
                radioButtonInactive.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var rec = (from u in db.Users where u.Id == a select u).FirstOrDefault();
            if (radioButtonActive.Checked)
                rec.Status = "Active";
            else if (radioButtonInactive.Checked)
                rec.Status = "Inactive";
            rec.Language = Convert.ToString(comboBox1.SelectedText);
            db.SaveChanges();
            MessageBox.Show("User Record Changed");
            this.Hide();
            EditUser eu = new EditUser();
            eu.ShowDialog();
        }
    }
}
