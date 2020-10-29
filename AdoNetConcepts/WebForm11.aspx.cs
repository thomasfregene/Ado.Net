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
    public partial class WebForm11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGetStudent_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                string sqlQuery = "SELECT * FROM tblStudents WHERE ID = " + txtStudentID.Text;
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);

                DataSet ds = new DataSet();
                da.Fill(ds, "Students");

                //storing sqlQuery and dataset in view state
                ViewState["SQL_QUERY"] = sqlQuery;
                ViewState["DATASET"] = ds;

                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    //storing the record from the table in datarow
                    DataRow dr = ds.Tables["Students"].Rows[0];

                    //passing the records to corresponding text box
                    txtStudentName.Text = dr["Name"].ToString();
                    txtTotalMarks.Text = dr["TotalMarks"].ToString();
                    ddlGender.SelectedValue = dr["Gender"].ToString();
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No Student record with ID = " + txtStudentID.Text;
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlDataAdapter da = new SqlDataAdapter((string)ViewState["SQL_QUERY"], con);

                //using SqlCommandBuilder for DML Operation
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                DataSet ds = (DataSet)ViewState["DATASET"];

                if (ds.Tables["Students"].Rows.Count > 0)
                {
                    //storing the record from the table in datarow
                    DataRow dr = ds.Tables["Students"].Rows[0];

                    //passing the records to corresponding text box
                    dr["Name"] = txtStudentName.Text;
                    dr["TotalMarks"] = txtTotalMarks.Text;
                    dr["Gender"] = ddlGender.SelectedValue;
                }
                int rowsUpdated = da.Update(ds, "Students");
                if (rowsUpdated > 0)
                {
                    lblStatus.ForeColor = System.Drawing.Color.Green;
                    lblStatus.Text = rowsUpdated.ToString() + " row(s) updated";
                }
                else
                {
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    lblStatus.Text = "No row updated";
                }
            }
        }
    }
}