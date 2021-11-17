using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;

namespace StudyPlannerWebApplication
{
    public partial class SemesterDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"]!=null)
            {
                user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
                loadingHomePage();
            }
            else
            {
                user_id = 0;
            }
        }

        public void loadingHomePage()
        {
            error_message.Visible = false;
            Semester_Details semester_data = db.Semester_Details.Where(s => s.user_id == this.user_id).FirstOrDefault();
            if (semester_data != null)
            {
                txtWeeks.Value = semester_data.num_weeks.ToString();
                dateStart.Value = semester_data.start_date.Date.ToLongDateString();
                datePicker.Visible = false;
                buttonEnabled(semester_data.num_weeks, semester_data.start_date.Date);
            }
            else
            {
                datePicker.Visible = true;
                dateStart.Visible = false;
                buttonEnabled(0, Convert.ToDateTime(null));
            }
        }


        public void buttonEnabled(int weeks, DateTime startDate)
        {
            if (weeks <= 0 || startDate == null)
            {
                txtWeeks.Disabled = false;
                datePicker.Disabled = false;
                btnSubmit.Enabled = true;
            }
            else
            {
                txtWeeks.Disabled = true;
                dateStart.Disabled = true;
                btnSubmit.Enabled = false;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            validInput();
            if (!error)
            {
                //btnSubmit = false;
                datePicker.Disabled = true;
                txtWeeks.Disabled = true;
                datePicker.Disabled = true;
                 saveSemesterDetails(this.user_id, Convert.ToDateTime(datePicker.Value).Date, this.weeks);
            }

        }

        private int weeks = 0;
        private DateTime startDate;
        private bool error = false;
        // initialising the database 
        StudyPlannerEntities db = new StudyPlannerEntities();
        public int user_id { get; set; }
        
        public void validInput()
        {
            //txtError.Background = Brushes.White;
            //txtError.Text = "";
            error_message.Visible = false;
            try
            {
                weeks = Convert.ToInt32(txtWeeks.Value);
                //txtWeeks.Background = Brushes.White;
                //txtError.Text = "";
                error_message.Visible = false;
                error = false;
                if (weeks <= 0)
                {
                    error = true;
                    error_message.Visible = true;
                    error_message.InnerText = "Number of weeks should be 1 or more";
                    //txtWeeks.Background = Brushes.Red;
                }

            }
            catch (Exception ex)
            {
                
                error = true;
                error_message.Visible = true;
                error_message.InnerText = "Invalid input for the number of weeks";
                
                
            }

            try
            {
                
                startDate = Convert.ToDateTime(datePicker.Value).Date;
                //datePicker.Background = Brushes.White;
                if (!error)
                    error = false;
            }
            catch (Exception ex)
            {
                error = true;
                //datePicker.Background = Brushes.Red;
                error_message.Visible = true;
                error_message.InnerText = "Start Date is required";
            }
        }
        public void setWeek(int week)
        {
            this.weeks = week;
        }
        public void setStart(DateTime startDate)
        {
            this.startDate = startDate;
        }

        public void saveSemesterDetails(int user_id, DateTime date, int weeks)
        {
            error_message.Visible = false;
            try
            {
                Semester_Details semester = new Semester_Details();
                semester.user_id = user_id;
                semester.start_date = date.Date;
                semester.num_weeks = weeks;
                semester.User = null;
                db.Semester_Details.Add(semester);
                db.SaveChanges();
                error_message.InnerText = "You have successfully captured your data";
                error_message.Visible = true;
                error_message.Style.Add("color", "green");
            }
            catch(Exception ex)
            {
                error_message.Visible = true;
                error_message.InnerText = "Invalid input ";
                error_message.Style.Add("color", "red");
            }
          ;
            
        }
    }

    
}