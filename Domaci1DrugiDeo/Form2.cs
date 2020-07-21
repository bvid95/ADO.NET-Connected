using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Domaci1DrugiDeo
{
    public partial class Form2 : Form
    {
        string conn = ConfigurationManager.ConnectionStrings["Cn"].ConnectionString;
        
        clsDataAccess x = new clsDataAccess();
        public Form2()
        {
            InitializeComponent();
            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Cn = new SqlConnection(conn);
                int RetVal = x.CustomerInsert(txtName.Text, txtContact.Text, txtCity.Text, txtCountry.Text, Cn);
                if (RetVal == 0)
                {
                    MessageBox.Show("Ubaceno!");
                }
                Cn.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Cn = new SqlConnection(conn);
                int RetVal = x.CustomerUpdate(Int32.Parse(txtId.Text), txtName.Text, txtContact.Text, txtCity.Text, txtCountry.Text, Cn);
                if (RetVal == 0)
                {
                    MessageBox.Show("Azuzirano!");
                }
                Cn.Close();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
