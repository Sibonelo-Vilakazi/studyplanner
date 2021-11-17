using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;

namespace StudyPlannerWebApplication
{
    public partial class SiteMaster : MasterPage
    {
        StudyPlannerEntities db = new StudyPlannerEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] != null)
            {
                login.Visible = false;
                register.Visible = false;
                signout.Visible = true;
                view_modules.Visible = true;
                add_module.Visible = true;
                semester_details.Visible = true;
                loadingHomePage();
            }
            else
            {
                signout.Visible = false;
                view_modules.Visible = false;
                add_module.Visible = false;
                semester_details.Visible = false;

            }

            

        }
        protected void handleSignout(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("/");
        }


        public void loadingHomePage()
        {
            int user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
            Semester_Details semester_data = db.Semester_Details.Where(s => s.user_id == user_id).FirstOrDefault();
            if (semester_data != null)
            {
                String txtWeeks = semester_data.num_weeks.ToString();
                String datePicker = semester_data.start_date.Date.ToLongDateString();
                buttonEnabled(semester_data.num_weeks, semester_data.start_date.Date);
            }
            else
            {
                
                buttonEnabled(0, Convert.ToDateTime(null));
            }
        }


        public void buttonEnabled(int weeks, DateTime startDate)
        {
            if (weeks <= 0 || startDate == null)
            {
                add_module.Visible = false;
                view_modules.Visible = false;
            }
            else
            {
                add_module.Visible = true;
                view_modules.Visible = true;
               
            }
        }
    }
        
}