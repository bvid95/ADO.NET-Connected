using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Domaci1DrugiDeo
{
    class clsDataAccess
    {
        public int CustomerData(SqlConnection Cn, ref DataTable dt)
        {
            
            int RetVal = 0; 
            
            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.CommandText = "dbo.CustomersSelect";
            Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "",
                DataRowVersion.Default, null));
            SqlDataAdapter da = new SqlDataAdapter(Cm);
            try
            {
                if (Cn.State != ConnectionState.Open) { Cn.Open(); }
                Cm.ExecuteNonQuery();
                
                da.Fill(dt);

                RetVal = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return RetVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int CustomerInsert(string name, string contact, string city, string country, SqlConnection Cn)
        {

            int RetVal = 0;
            
            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.CommandText = "dbo.CustomersInsert";

            // parametri
            Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "",
                DataRowVersion.Default, null));

           
            Cm.Parameters.AddWithValue("@name", name);
            Cm.Parameters.AddWithValue("@contact", contact);
            Cm.Parameters.AddWithValue("@city", city);
            Cm.Parameters.AddWithValue("@country", country);

            // zavrseni parametri

            try
            {
                if (Cn.State != ConnectionState.Open) { Cn.Open(); }
                Cm.ExecuteNonQuery();
                RetVal = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return RetVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int CustomerUpdate(int id, string name, string contact, string city, string country, SqlConnection Cn)
        {
            int RetVal = 0;

            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.CommandText = "dbo.CustomersUpdate";

            // parametri
            Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "",
                DataRowVersion.Default, null));

            Cm.Parameters.AddWithValue("@id", id);
            Cm.Parameters.AddWithValue("@name", name);
            Cm.Parameters.AddWithValue("@contact", contact);
            Cm.Parameters.AddWithValue("@city", city);
            Cm.Parameters.AddWithValue("@country", country);

            // zavrseni parametri

            try
            {
                if (Cn.State != ConnectionState.Open) { Cn.Open(); }
                Cm.ExecuteNonQuery();
                RetVal = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return RetVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public int DeleteCustomer(int id, SqlConnection Cn)
        {
            int RetVal = 0;

            SqlCommand Cm = new SqlCommand();
            Cm.Connection = Cn;
            Cm.CommandType = CommandType.StoredProcedure;
            Cm.CommandText = "dbo.CustomersDelete";

            // parametri
            Cm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "",
                DataRowVersion.Default, null));

            Cm.Parameters.AddWithValue("@id", id);


            // zavrseni parametri

            try
            {
                if (Cn.State != ConnectionState.Open) { Cn.Open(); }
                Cm.ExecuteNonQuery();
                RetVal = (int)Cm.Parameters["@RETURN_VALUE"].Value;
                return RetVal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
