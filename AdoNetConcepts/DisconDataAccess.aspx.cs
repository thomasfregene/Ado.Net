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
    public partial class DisconDataAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //method for getting data
        private void GetDataFromDB()
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(CS);

            //select query
            string strSelectQuery = "Select * From tblStudents";

            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

            DataSet ds = new DataSet();
            da.Fill(ds, "Students");

            //associating the table with it's primary key
            ds.Tables["Students"].PrimaryKey = new DataColumn[] { ds.Tables["Students"].Columns["ID"] };
            //caching the dataset
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);

            //associating ds with gridview control
            gvStudents.DataSource = ds;
            gvStudents.DataBind();

            lblMessage.Text = "Data Loaded from Database";
        }
        

        private void GetDataFromCache()
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];

                gvStudents.DataSource = ds;
                gvStudents.DataBind();
            }
        }
        protected void btnGetDataFromDB_Click(object sender, EventArgs e)
        {
            GetDataFromDB();
        }

        protected void gvStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStudents.EditIndex = e.NewEditIndex;
            GetDataFromCache();
        }

        protected void gvStudents_RowUpdated(object sender, GridViewUpdatedEventArgs e)
        {
            //error code see gvStudents_RowUpdating below for correction
        }

        protected void gvStudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStudents.EditIndex = -1;
            GetDataFromCache();
        }

        protected void gvStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataSet ds = (DataSet)Cache["DATASET"];
            //updating table by Id
            DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
            dr.Delete();

            //storing new value in cache
            Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
            GetDataFromCache();
        }

        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Cache["DATASET"] != null)
            {
                DataSet ds = (DataSet)Cache["DATASET"];
                //updating table by Id
                DataRow dr = ds.Tables["Students"].Rows.Find(e.Keys["ID"]);
                dr["Name"] = e.NewValues["Name"];
                dr["Gender"] = e.NewValues["Gender"];
                dr["TotalMarks"] = e.NewValues["TotalMarks"];

                //storing new value in cache
                Cache.Insert("DATASET", ds, null, DateTime.Now.AddHours(24), System.Web.Caching.Cache.NoSlidingExpiration);
                //removing row from edit mode
                gvStudents.EditIndex = -1;
                GetDataFromCache();
            }
        }

        protected void btnUpdateDB_Click(object sender, EventArgs e)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(CS);

            //select query
            string strSelectQuery = "Select * From tblStudents";

            SqlDataAdapter da = new SqlDataAdapter(strSelectQuery, con);

            DataSet ds = (DataSet)Cache["DATASET"];

            //update request
            string strUpdateCommand = "Update tblStudents Set Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks Where ID = @ID";
            SqlCommand updateCommand = new SqlCommand(strUpdateCommand, con);
            updateCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
            updateCommand.Parameters.Add("@Gender", SqlDbType.NVarChar, 20, "Gender");
            updateCommand.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            updateCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            //associating dataadapter with update command
            da.UpdateCommand = updateCommand;

            //delete request
            string strdeleteCommand = "Delete From tblStudents Where ID = @ID";

            SqlCommand deleteCommand = new SqlCommand(strdeleteCommand, con);
            deleteCommand.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");
            da.DeleteCommand = deleteCommand;


            da.Update(ds, "Students");

            lblMessage.Text = "Database Table Updated";
        }
    }
}