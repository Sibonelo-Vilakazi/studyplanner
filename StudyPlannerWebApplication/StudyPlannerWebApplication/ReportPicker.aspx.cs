using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;
namespace StudyPlannerWebApplication
{
    public partial class ReportPicker : System.Web.UI.Page
    {
        StudyPlannerEntities db = new StudyPlannerEntities();
        private int user_id = 0; 
        private int module_id =0;
        private DateTime time_date ;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
                Semester_Details semester = db.Semester_Details.Where(s => s.user_id == user_id).FirstOrDefault();
                module_id = Convert.ToInt32(Request.QueryString["ID"].Trim());
                time_date = semester.start_date;
                DisplayWeeks(semester.num_weeks);
            }
        }

        public void DisplayWeeks(int weeks)
        {
            String display = "";
            for (int i = 0; i < weeks; i++)
            {
                DateTime current_date = time_date.Date;
                current_date = current_date.AddDays(i*7).Date;
                int remain = 7 - (int)current_date.DayOfWeek;
                int current_day = (int)current_date.DayOfWeek;
                DateTime next_sunday = current_date.AddDays(remain).Date;
                if (current_day == 0)
                {
                    current_day = 7;
                }
                DateTime monday = current_date.AddDays((current_day - 1) * -1).Date;

                display += "<div class='single_row'>" +
                "<h2> Week</h2>" +
                "<h3>" + (i + 1) + "</h3>" +
                "<p>" + monday.ToString().Trim().Split(' ')[0] + " - " + next_sunday.ToString().Trim().Split(' ')[0] + "</p>"+
                "<a href='ViewReport.aspx?ID="+module_id+"&Week=" + (i + 1) +"&start="+ monday.ToString().Trim().Split(' ')[0] + "'>"+
                "<div class='btn'>View Report</div></a>" +
                "</div>";
            }

            row_display.InnerHtml += display;


        }
    }
}