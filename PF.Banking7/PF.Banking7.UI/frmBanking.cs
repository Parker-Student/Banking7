using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PF.Banking.BL;

namespace PF.Banking7.UI
{
    public partial class frmBanking : Form
    {
        Customer customer;
        public frmBanking()
        {
            InitializeComponent();
        }

        private void frmBanking_Load(object sender, EventArgs e)
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;

        }
    }
}
