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
    public partial class EditCustomerDetails : Form
    {
        int a = EditCustomer.a;
        TRPDbEntities db = new TRPDbEntities();
        public EditCustomerDetails()
        {
            InitializeComponent();
        }

        private void EditCustomerDetails_Load(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
