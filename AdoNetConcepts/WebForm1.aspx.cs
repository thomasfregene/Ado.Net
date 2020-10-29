using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("data source=DESKTOP-44J960K\\SQLEXPRESS; database= Sample1; integrated security=SSPI");
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblProduct", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            con.Close();

            //connecting to an Oracle server
            //OracleConnection con = new OracleConnection("data source=DESKTOP-44J960K\\SQLEXPRESS; database= Sample1; integrated security=SSPI");
            //OracleCommand cmd = new OracleCommand("SELECT * FROM tblProduct", con);
            //con.Open();
            //OracleDataReader rdr = cmd.ExecuteReader();
            //GridView1.DataSource = rdr;
            //GridView1.DataBind();
            //con.Close();
        }
    }
}