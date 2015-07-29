using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//model references for EF
using ToDoList.Models;
using System.Web.ModelBinding;

namespace ToDoList
{
    public partial class editList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        if ((!IsPostBack))
            {
                GetTask();
            }

        }

        protected void GetTask()
        {

            //populate form with existing student record
            Int32 taskID = Convert.ToInt32(Request.QueryString["taskID"]);

            //connect to db via EF
            using (ToDoDBase db = new ToDoDBase())
            {
                //populate a student instance with the StudentID from the URL parameter
                ToDoTable s = (from objS in db.ToDoTables
                               where objS.taskID == taskID
                               select objS).FirstOrDefault();

                //map the student properties to the form controls if we found a match
                if (s != null)
                {
                    txtTask.Text = s.task;
                    ddlPriority.SelectedIndex = s.priority;
                    txtDueDate.Text = s.dueDate.ToString("yyyy-MM-dd");
                }


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            String user = User.Identity.Name;

            using (ToDoDBase db = new ToDoDBase())
            {

                
                Int32 taskID = 0;
                ToDoTable s = new ToDoTable();

                if (Request.QueryString["taskID"] != null)
                {
                    taskID = Convert.ToInt32(Request.QueryString["taskID"]);


                    s = (from objS in db.ToDoTables
                         where objS.taskID == taskID
                         select objS).FirstOrDefault();

                }

                    s.username = user;
                    s.task = txtTask.Text;
                    s.priority = ddlPriority.SelectedIndex;
                    s.dueDate = Convert.ToDateTime(txtDueDate.Text);
                    s.points = 0;

                

                //run the update or insert
                if (taskID == 0)
                {
                    db.ToDoTables.Add(s);
                    
                }

                db.SaveChanges();
                
            }

            using (ToDoDBase db = new ToDoDBase())
            {
                pointTracker s = new pointTracker();

                s = (from objS in db.pointTrackers
                     where objS.username == user
                     select objS).FirstOrDefault();


                if (s != null)
                {
                    if (s.username == null)
                        db.pointTrackers.Add(s);
                    else
                        s.username = user;
                }
                else
                {
                    db.pointTrackers.Add(s);
                }

                db.SaveChanges();
            }

            Response.Redirect("ToDo.aspx");
        }

    
    }
}