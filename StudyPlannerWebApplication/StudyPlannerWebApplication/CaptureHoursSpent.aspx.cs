using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;
namespace StudyPlannerWebApplication
{
    public partial class CaptureHoursSpent : System.Web.UI.Page
    {
        private string moduleName;
        private int hours;
        private string moduleCode;
        private bool closeScreen = false;
        private bool error = false;
        private int module_id = 0;

        public int user_id { get; set; }

        StudyPlannerEntities db = new StudyPlannerEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
                int module_id=Convert.ToInt32(Request.QueryString["ID"]);
                Module module = db.Modules.Where(m => m.module_id == module_id).FirstOrDefault();
                setPopUp(module.module_name, module.module_code, module_id);
            }
        }


        public void setPopUp(String moduleName, string moduleCode, int module_id)
        {
            lblPrompt.InnerText = "Enter the number of hours you spent on " + moduleName + " today";
            lblError.InnerText = "";
            //txtHours.Background = Brushes.White;
            this.moduleName = moduleName;
            this.moduleCode = moduleCode;
            this.module_id = module_id;
            //date_picker.Value = DateTime.Now.Date.ToLongDateString();
        }

        /*private void Ok_Click(object sender, RoutedEventArgs e)
        {
            validateInput();

            if (!error)
            {
                redirectToViewModule();
                this.Close();

            }

        }*/

        private void validateInput()
        {
            try
            {
                //txtHours.Background = Brushes.White;
                lblError.InnerText = "";
                //txtError.Background = Brushes.White;
                //txtHours.Background = Brushes.White;
                hours = Convert.ToInt32(txtHours.Value.Trim());
                error = false;

                StoreTrack(moduleCode, hours);
                updateHoursRequired(moduleCode);

            }
            catch (Exception e)
            {
                lblError.InnerText = "Invalid value entered";
                //txtHours.Background = Brushes.Red;
                //lblError.Background = Brushes.Red;
                error = true;
            }
        }

        public void StoreTrack(string moduleCode, int studyHour)
        {

            DateTime timePicked= Convert.ToDateTime(date_picker.Value).Date;
            if (timePicked <= DateTime.Now.Date)
            {

                Track_Module storedTrack = db.Track_Module
                .Where(t => t.module_id == this.module_id && t.track_date == timePicked.Date).FirstOrDefault();

                if (storedTrack == null)
                {
                    Track_Module track = new Track_Module();

                    track.track_date = timePicked;
                    track.track_study_hour = studyHour;
                    track.module_id = this.module_id;
                    db.Track_Module.Add(track);
                    db.SaveChanges();
                }
                else
                {
                    storedTrack.track_study_hour = studyHour;
                    db.SaveChanges();
                }
            }
            else
            {
                //MessageBox.Show("You can not record for future dates as tomorrow is not determined");
                error = true;
            }

        }

        public void updateHoursRequired(string moduleCode)
        {
            DateTime current_date = DateTime.Now.Date;
            int remain = 7 - (int)current_date.DayOfWeek;
            int current_day = (int)current_date.DayOfWeek;
            DateTime next_sunday = current_date.AddDays(remain).Date;
            if (current_day== 0)
            {
                current_day = 7;
            }
            DateTime monday = current_date.AddDays((current_day - 1) * -1).Date;
            List<Track_Module> tempHours = db.Track_Module
                .Where(c => c.module_id == module_id && c.track_date >= monday
                 && c.track_date <= next_sunday).ToList();
            Module_Hours modulehour = db.Module_Hours.Where(c => c.module_id == module_id).FirstOrDefault();
            int sumHours = 0;
            foreach (Track_Module t in tempHours)
            {
                sumHours += t.track_study_hour;
            }
            modulehour.hours_remaining = modulehour.self_studying_hours - sumHours;
            if (modulehour.hours_remaining < 0)
            {
                modulehour.hours_remaining = 0;
            }


            db.SaveChanges();


        }

        /*private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            redirectToViewModule();
            this.Close();
        }*/

        /*public void redirectToViewModule()
        {
            ViewModules view = new ViewModules();
            view.user_id = user_id;
            view.setupView();

            view.Show();
            this.closeScreen = true;

        }*/

        protected void btnCapture_Click(object sender, EventArgs e)
        {
            validateInput();

            if (!error)
            {
                Response.Redirect("ViewModules.aspx");
                //this.Close();

            }
        }
    }
}