using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;

namespace StudyPlannerWebApplication
{
    public partial class AddModules : System.Web.UI.Page
    {

        private StudyPlannerEntities db = new StudyPlannerEntities();
        public int weeks { get; set; }
        public DateTime startDate { get; set; }
        private bool closeScreen = false;

        public int user_id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_id"] != null)
            {
                user_id = Convert.ToInt32(Session["user_id"].ToString().Trim());
            }
        }


        public void recordModule()
        {
            Module module = new Module();
            module.module_code = txtCode.Value;
            module.module_name = txtName.Value;
            Boolean error = false;
            lblError.InnerText = "";
            try
            {
                //txtCredit.ApplyStyleSheetSkin = "backgroud:white";
                module.module_credit = Convert.ToInt32(txtCredit.Value.Trim());
            }
            catch (Exception e)
            {
                error = true;
                //txtCredit.Background = Brushes.Red;
                lblError.InnerText = "You have enter invalid on the highlighted Value boxes";
            }
            try
            {
                //txtClassHours.Background = Brushes.White;
                module.module_class_hours = Convert.ToInt32(txtClassHours.Value.Trim());

            }
            catch (Exception e)
            {
                error = true;
                //txtClassHours.Background = Brushes.Red;
                lblError.InnerText = "You have enter invalid on the highlighted Value boxes";
            }
            //public int selftStudyHouurs 

            if (!error)
            {
                module.user_id = user_id;
                //listModules.Where(m => m.moduleCode.ToUpper() == module.moduleCode.ToUpper() || m.moduleName.ToUpper() == module.moduleName.ToUpper()).FirstOrDefault() == null
                if (db.Modules.Where(m => (m.module_code.ToUpper() == module.module_code.ToUpper()
                || m.module_name.ToUpper() == module.module_name.ToUpper())
                && m.user_id == module.user_id).FirstOrDefault() == null)
                {

                    Module a = db.Modules.Add(module);
                    db.SaveChanges();
                    Module m = db.Modules.Where(ms => ms.user_id == user_id && ms.module_code == module.module_code).FirstOrDefault();
                    Module_Hours hours = new Module_Hours();
                    Semester_Details semester_details = db.Semester_Details.Where(s => s.user_id == user_id).FirstOrDefault();
                    if (semester_details != null)
                    {
                        hours.self_studying_hours = this.calcSelfStudyHours(semester_details.num_weeks, m.module_class_hours, m.module_credit);
                        hours.hours_remaining = hours.self_studying_hours;
                        hours.module_id = m.module_id;
                        hours.week_start_date = DateTime.Now.Date;
                        hours.week_end_date = DateTime.Now.Date;

                        //hours.module_ = module.moduleCode;
                        db.Module_Hours.Add(hours);
                        lblError.InnerText = "You have successfully added a module";
                        //lblError.Background = Brushes.Green;
                        clearValue();
                        error = false;
                        db.SaveChanges();

                    }

                }
                else
                {
                    lblError.InnerText = "This module has already been added";
                    //lblError.Background = Brushes.Red;
                }
            }
            else
            {
                //lblError.Background = Brushes.Red;
            }


        }

        private int calcSelfStudyHours(int numWeeks, int numHours, int numCredit)
        {
            return ((numCredit * 10) / numWeeks) - numHours;
        }

        public void clearValue()
        {
            txtClassHours.Value = "";
            txtName.Value="";
            txtCode.Value="";
            txtCredit.Value="";
        }

       /* private void cancelButton_CLick(object sender, RoutedEventArgs e)
        {

            goToHomePage();
            closeScreen = true;
            this.Close();
        }*/
       /* public void goToHomePage()
        {
            Home viewHome = new Home();
            viewHome.user_id = this.user_id;
            viewHome.loadingHomePage();

            viewHome.Show();
        }*/


      /*  private void CloseMain(object sender, EventArgs e)
        {
            if (!closeScreen)
            {
                goToHomePage();
            }

        }*/

        protected void btnAddModule_Click(object sender, EventArgs e)
        {
            recordModule();

        }
    }
}