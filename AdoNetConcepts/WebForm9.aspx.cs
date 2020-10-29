using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro.AdoNetConcepts
{
    public partial class WebForm9 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter("spGetData", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                /*dataset is an in memory rep of a database i.e stores tables in data and there relationship*/
                DataSet ds = new DataSet();
                da.Fill(ds);

                //change the default names of ds tables
                ds.Tables[0].TableName = "Products";
                ds.Tables[1].TableName = "Categories";

                GridView1.DataSource = ds.Tables["Products"];
                GridView1.DataBind();

                GridView2.DataSource = ds.Tables["Categories"];
                GridView2.DataBind();
            }
        }
    }
}