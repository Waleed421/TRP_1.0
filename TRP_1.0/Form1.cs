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
    public partial class Main : Form
    {
        PrintJobDbEntities db = new PrintJobDbEntities();
        public Main()
        {
            InitializeComponent();
        }

        private void btnEditActionReport_Click(object sender, EventArgs e)
        {
            Edit_Action_Report e1 = new Edit_Action_Report();
            this.Hide();
            e1.Show();
        }
    }
}
