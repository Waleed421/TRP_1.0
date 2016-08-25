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
    public partial class EditCaseType : Form
    {
        int a = 0;
        TRPDbEntities db = new TRPDbEntities();
        public EditCaseType()
        {
            InitializeComponent();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(gridView1.GetRowCellValue(gridView1.GetSelectedRows()[0], "Id"));
            var edit = (from t in db.TypeofCases where t.Id == a select t).FirstOrDefault();
            textBoxType.Text = edit.Type;
            if (edit.Invoice_Type == "Yes")
                radioButtonYes.Checked = true;
            else if (edit.Invoice_Type == "No")
                radioButtonNo.Checked = true;
            if (edit.Status == "Active")
                radioButtonActive.Checked = true;
            else if (edit.Status == "Inactive")
                radioButtonInactive.Checked = true;
            buttonSave.Enabled = true;
            textBoxType.ReadOnly = true;
            buttonAdd.Enabled = false;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var save = (from t in db.TypeofCases where t.Id == a select t).FirstOrDefault();
            save.Type = textBoxType.Text;
            if (radioButtonYes.Checked)
                save.Invoice_Type = "Yes";
            else if (radioButtonNo.Checked)
                save.Invoice_Type = "No";
            if (radioButtonActive.Checked)
                save.Status = "Active";
            else if (radioButtonInactive.Checked)
                save.Status = "Inactive";
            db.SaveChanges();
            MessageBox.Show("Case Type successfully edited");
            var type = (from t in db.TypeofCases select new { t.Id, t.Type, t.Invoice_Type, t.Status }).ToList();
            gridControl1.DataSource = type;
            gridView1.Columns["Id"].Visible = false;

            buttonSave.Enabled = false;
            textBoxType.ReadOnly = false;
            buttonAdd.Enabled = true;
        }

        private void EditCaseType_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            var type = (from t in db.TypeofCases select new { t.Id, t.Type, t.Invoice_Type, t.Status }).ToList();
            gridControl1.DataSource = type;

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            TypeofCas tc = new TypeofCas();
            tc.Type = textBoxType.Text;
            if (radioButtonYes.Checked)
                tc.Invoice_Type = "Yes";
            else if (radioButtonNo.Checked)
                tc.Invoice_Type = "No";
            if (radioButtonActive.Checked)
                tc.Status = "Active";
            else if (radioButtonInactive.Checked)
                tc.Status = "Inactive";
            db.TypeofCases.Add(tc);
            db.SaveChanges();
            MessageBox.Show("Case Type successfully added");
            var type = (from t in db.TypeofCases select new { t.Id, t.Type, t.Invoice_Type, t.Status }).ToList();
            gridControl1.DataSource = type;
        }

        private void textBoxType_Leave(object sender, EventArgs e)
        {
            if (textBoxType.ReadOnly == false)
            {
                var type = from t in db.TypeofCases select t;
                foreach (var item in type)
                {
                    if (string.Equals(textBoxType.Text, item.Type, StringComparison.CurrentCultureIgnoreCase))
                    {
                        MessageBox.Show("Description already exists");
                        textBoxType.Focus();
                    }
                }
            }
        }
    }
}
