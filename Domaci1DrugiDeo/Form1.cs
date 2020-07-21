using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace Domaci1DrugiDeo
{
    public partial class Form1 : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cn"].ConnectionString;
        
        
        clsDataAccess x = new clsDataAccess();
        
        public Form1()
        {
            try
            {
                SqlConnection Cn = new SqlConnection(conn);
                InitializeComponent();
                DataTable dt = new DataTable();
                int retVal = x.CustomerData(Cn, ref dt);

                dgCustomers.DataSource = dt;
                if (retVal == 0)
                {
                    MessageBox.Show("Ucitano!");
                }
                Cn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnRefreshGrid_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Cn = new SqlConnection(conn);
                DataTable dt = new DataTable();
                dgCustomers.DataSource = null;
                int retVal = x.CustomerData(Cn, ref dt);

                dgCustomers.DataSource = dt;

                if (retVal == 0)
                {
                    MessageBox.Show("Osvezeno!");
                }
                Cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete "+ dgCustomers.CurrentRow.Cells[1].Value.ToString(), "Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    SqlConnection Cn = new SqlConnection(conn);
                    int selectedrowindex = dgCustomers.SelectedCells[0].RowIndex;
                    DataGridViewRow selectedRow = dgCustomers.Rows[selectedrowindex];
                    string id = Convert.ToString(selectedRow.Cells["KlijentId"].Value);
                    int retVal = x.DeleteCustomer(int.Parse(id), Cn);
                    if (retVal == 0)
                    {
                        MessageBox.Show("Obrisano!");
                    }
                    Cn.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Text = "Insert";
            f2.btnInsert.Visible = true;
            f2.btnUpdate.Visible = false;
            f2.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f2 = new Form2();
                f2.Text = "Update";
                f2.txtId.Text = dgCustomers.CurrentRow.Cells[0].Value.ToString();
                f2.txtName.Text = dgCustomers.CurrentRow.Cells[1].Value.ToString();
                f2.txtContact.Text = dgCustomers.CurrentRow.Cells[2].Value.ToString();
                f2.txtCity.Text = dgCustomers.CurrentRow.Cells[3].Value.ToString();
                f2.txtCountry.Text = dgCustomers.CurrentRow.Cells[4].Value.ToString();
                f2.btnInsert.Visible = false;
                f2.btnUpdate.Visible = true;
                f2.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
