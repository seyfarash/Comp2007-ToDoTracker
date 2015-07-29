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
    public partial class highscore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPoints();
            }
        }

        protected void GetPoints()
        {
            using (ToDoDBase db = new ToDoDBase())
            {

                String user = User.Identity.Name;

                //query the points table using EF and LINQ
                var points = from s in db.pointTrackers
                            select s;

                //bind the result to the gridview
                grdScores.DataSource = points.ToList();
                grdScores.DataBind();

            }
        }

    }
}