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
        Customers customers;
        public frmBanking()
        {
            InitializeComponent();
        }

        private void frmBanking_Load(object sender, EventArgs e)
        {
            dgvCustomers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomers.MultiSelect = false;
            try
            {
                customers = new Customers();
                customers.GetAll();
                Rebind();
            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
            }

     
            
        }
  
        private void Rebind()
        {
            // Bind computers list to the datagrid view
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = customers;
                                 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;

                Customer customer = new Customer();

                //computer.Id = computers.Max(p => p.Id) + 1;
                // Call to a method that encompasses an anonymous function.
                customer.CustomerID = customers.GetNewId();

                customer.FirstName = txtFirstName.Text;
                customer.LastName = txtLastName.Text;
                customer.SSN = txtSSN.Text;
                customer.BirthDate = datetimeBirthday.Value;

              

                customers.Add(customer);
                Rebind();

            }
            catch (Exception ex)
            {
                
                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
                
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.ForeColor = Color.Black;
                if (dgvCustomers.CurrentRow.Index > -1)
                {
                    Customer customer = customers[dgvCustomers.CurrentRow.Index];

                    customer.CustomerID = customers.GetNewId();

                    customer.FirstName = txtFirstName.Text;
                    customer.LastName = txtLastName.Text;
                    customer.SSN = txtSSN.Text;
                    customer.BirthDate = datetimeBirthday.Value;

                    Rebind();
                }
                else
                {
                    throw new Exception("Please select a computer to update.");
                }

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = customers[dgvCustomers.CurrentRow.Index];
                int result = customer.Delete();
                lblStatus.Text = "Deleted " + result + " rows.";
                customers.Remove(customer);
                Rebind();

            }
            catch (Exception ex)
            {
                lblStatus.Text = ex.Message;
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
