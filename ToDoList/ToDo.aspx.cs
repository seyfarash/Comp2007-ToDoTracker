using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF models
using ToDoList.Models;
using System.Web.ModelBinding;

namespace ToDoList
{
    public partial class ToDo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GetTasks();
            }

        }

        protected void GetTasks()
        {
            using (ToDoDBase db = new ToDoDBase())
            {

                String user = User.Identity.Name;

                //query the students table using EF and LINQ
                var tasks = from s in db.ToDoTables
                            where s.username == user 
                               select s;

                //bind the result to the gridview
                grdTasks.DataSource = tasks.ToList();
                grdTasks.DataBind();

            }
        }

        protected void grdTasks_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdTasks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            //store which row was clicked
            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grid's Data Key collection
            int taskID = Convert.ToInt32(grdTasks.DataKeys[selectedRow].Values["taskID"]);

            //use EF to remove the selected student from the db
            using (ToDoDBase db = new ToDoDBase())
            {

                ToDoTable s = (from objS in db.ToDoTables
                             where objS.taskID == taskID
                             select objS).FirstOrDefault();

                //do the delete
                db.ToDoTables.Remove(s);
                db.SaveChanges();
            }

            //refresh the grid
            GetTasks();

        }

        protected void grdTasks_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdTasks_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdTasks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Complete")
            {
                //store which row was clicked
                Int32 selectedRow = Convert.ToInt32(e.CommandArgument);
                String user = User.Identity.Name;

                //get the selected StudentID using the grid's Data Key collection
                int taskID = Convert.ToInt32(grdTasks.DataKeys[selectedRow].Values["taskID"]);

                //use EF to remove the selected student from the db
                using (ToDoDBase db = new ToDoDBase())
                {

                    ToDoTable s = (from objS in db.ToDoTables
                                   where objS.taskID == taskID
                                   select objS).FirstOrDefault();
                    //do the delete
                    db.ToDoTables.Remove(s);
                    db.SaveChanges();
                }

                using (ToDoDBase db = new ToDoDBase())
                {
                    pointTracker s = (from objS in db.pointTrackers
                                      where objS.username == user
                                      select objS).FirstOrDefault();
                    if(s != null)
                    s.points += 5;

                    db.SaveChanges();
                }

                //refresh the grid
                GetTasks();

            }
        }

    }
}