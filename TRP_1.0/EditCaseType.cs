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
            buttonSave.Enabled = true;
            textBoxType.ReadOnly = true;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var save = (from t in db.TypeofCases where t.Id == a select t).FirstOrDefault();
            save.Type = textBoxType.Text;
            if (radioButtonYes.Checked)
                save.Invoice_Type = "Yes";
            else if (radioButtonNo.Checked)
                save.Invoice_Type = "No";
            db.SaveChanges();
            MessageBox.Show("Case Type successfully edited");
            var type = (from t in db.TypeofCases select t).ToList();
            gridControl1.DataSource = type;
            buttonSave.Enabled = false;
            textBoxType.ReadOnly = false;
        }

        private void EditCaseType_Load(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;
            var type = (from t in db.TypeofCases select t).ToList();
            gridControl1.DataSource = type;           
                       
        }
    }
}
