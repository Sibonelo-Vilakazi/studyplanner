using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;

namespace StudyPlannerWebApplication
{
    public partial class ViewReport : System.Web.UI.Page
    {
        StudyPlannerEntities db = new StudyPlannerEntities();
        private int user_id = 0;
        private DateTime date_time;
        private int module_id =0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //series_id.Points.AddXY(10,10);
            if (Session["user_id"] != null)
            {
                user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
                module_id= Convert.ToInt32(Request.QueryString["ID"].ToString().Trim());
                date_time = Convert.ToDateTime(Request.QueryString["start"].ToString().Trim()).Date;
                displayChart();
            }
        }

        private void displayChart()
        {
            String[] labels = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            int[] daily_data = { 0, 0, 0, 0, 0, 0, 0 };
            int current_day = (int)date_time.DayOfWeek;
            for (int i = current_day-1; i < daily_data.Length; i++)
            {
                DateTime next_day = date_time.AddDays(current_day +i ).Date;
                Track_Module track = db.Track_Module.Where(m => m.module_id == module_id && m.track_date== next_day).FirstOrDefault();
                if (track==null)
                {
                    daily_data[i] = 0;
                }
                else
                {
                    daily_data[i] = track.track_study_hour;
                }

            }
            chart.Series.FindByName("Series1").Points.DataBindXY(labels, daily_data);

        }
    }
}