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
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                //executing two sql statements
                SqlCommand cmd = new SqlCommand("Select * From tblProductInventory2; SELECT * FROM tblProductCategories", con);
                con.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    ProductsGridView.DataSource = rdr;
                    ProductsGridView.DataBind();

                    //getting more than one result set using the NextResult method
                    while (rdr.NextResult())
                    {
                        CategoriesGridView.DataSource = rdr;
                        CategoriesGridView.DataBind();
                    }
                }
            }
        }
    }
}