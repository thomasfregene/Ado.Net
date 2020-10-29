using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT ProductId, ProductName, UnitPrice FROM tblProductInventory2", con);
                //dataReader object the using is neccesary to close the reader
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    //doing additional manipulation of initial data
                    DataTable table = new DataTable();
                    table.Columns.Add("ID");
                    table.Columns.Add("Name");
                    table.Columns.Add("Price");
                    table.Columns.Add("DiscountedPrice");

                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();

                        int originalPrice = Convert.ToInt32(rdr["UnitPrice"]);
                        double discountedPrice = originalPrice * 0.9;

                        //assocating the original columns to a dataRow
                        dataRow["ID"] = rdr["ProductId"];
                        dataRow["Name"] = rdr["ProductName"];
                        dataRow["Price"] = originalPrice;
                        dataRow["DiscountedPrice"] = discountedPrice;
                        table.Rows.Add(dataRow);
                    }
                    GridView1.DataSource = table;
                    GridView1.DataBind();
                }
            }
        }
    }
}