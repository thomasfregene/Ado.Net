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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLoadData_Click(object sender, EventArgs e)
        {
            //initial loading of data
            if (Cache["Data"] == null)
            {
                string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tblProductInventory2", con);

                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    //caching the dataset
                    Cache["Data"] = ds;
                    gvProducts.DataSource = ds;
                    gvProducts.DataBind();
                }

                lblMessage.Text = "Data Loaded from the Database";
            }
            else
            {
                //using cache to get data
                gvProducts.DataSource = (DataSet)Cache["Data"];
                gvProducts.DataBind();

                lblMessage.Text = "Data Loaded from the Cache";
            }
        }

        protected void btnClearCache_Click(object sender, EventArgs e)
        {
            if (Cache["Data"] != null)
            {
                Cache.Remove("Data");

                lblMessage.Text = "The DataSet is removed from the cache";
            }
            else
            {
                lblMessage.Text = "There is nothing in the cache to be removed";
            }
        }
    }
}