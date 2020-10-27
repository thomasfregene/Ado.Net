using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //SqlConnection string
            string CS = "data source=DESKTOP-44J960K\\SQLEXPRESS; database= Sample1; integrated security=SSPI";


            //to ensure connection is closed as soon as possible use the trycatch and finally or use the using block
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblProduct", con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
            
            //catch (Exception)
            //{

            //    throw;
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
    }
}