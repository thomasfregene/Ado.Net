﻿using System;
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
    public partial class WebForm8 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using(SqlConnection con = new SqlConnection(CS))
            {
                //dataAdapter
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = new SqlCommand("spGetProductInventory2ById", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@ProductId", TextBox1.Text);
                DataSet ds = new DataSet();
                //opening connection using fill method
                da.Fill(ds);

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
        }
    }
}