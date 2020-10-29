using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //reading connectionString from web.config file
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //SqlConnection Object to pass connection string
            using(SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand();  
                cmd.Connection = con;
                con.Open();

                //delete
                cmd.CommandText = "Delete from tblProduct where ProductId = 4";
                int TotalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Deleted = " + TotalRowsAffected.ToString() + "<br/>");

                //insert
                cmd.CommandText = "Insert Into tblProduct Values(4, 'Calculators', 100, 230)";
                TotalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Inserted = " + TotalRowsAffected.ToString() + "<br/>");

                //update
                cmd.CommandText = "update tblProduct set QtyAvailable = 200 where ProductId = 2";
                TotalRowsAffected = cmd.ExecuteNonQuery();
                Response.Write("Total Rows Updated = " + TotalRowsAffected.ToString());
            }
        }
    }
}