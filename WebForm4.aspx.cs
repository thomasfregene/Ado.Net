﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ado.NetIntro
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                //Sql injection
                string Command = "Select * From tblProductInventory Where ProductName Like '" + TextBox1.Text + "%'";
                SqlCommand cmd = new SqlCommand(Command, con);
                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using(SqlConnection con = new SqlConnection(CS))
        //    {
        //        //Sql injection
        //        string Command = "Select * From tblProductInventory Where ProductName Like '" + TextBox1.Text + "%'";
        //        SqlCommand cmd = new SqlCommand(Command, con);
        //        con.Open();
        //        GridView1.DataSource = cmd.ExecuteReader();
        //        GridView1.DataBind();
        //    }
        //}

    }
}