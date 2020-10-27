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
                //command object
                SqlCommand cmd = new SqlCommand("Select ProductId, Name, UnitPrice, QtyAvailable from tblProduct", con);
                //opening the aqlconnection
                con.Open();
                //bing the data from the command object to a gridview
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }
    }
}