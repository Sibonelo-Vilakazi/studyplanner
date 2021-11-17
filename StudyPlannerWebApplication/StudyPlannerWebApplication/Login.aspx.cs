using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;
using StudyPlannerWebApplication.Models;
namespace StudyPlannerWebApplication
{
    public partial class Login : Page
    {
        StudyPlannerEntities db = new StudyPlannerEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            error_message.Visible = false;
            success_message.Visible = false;
        }

        public void LoginUser()
        {
           
            String username = txtUsername.Value;
            User user = db.Users.Where(u => u.username == username).FirstOrDefault();
            //lblError.Background = Brushes.White;




            if (user == null)
            {
                error_message.InnerText = "Invaild username or password";
                error_message.Visible = true;
            }
            else
            {
                string password = txtPassword.Value;

                if (user.password != Secrecy.HashPassword(password))
                {
                    error_message.InnerText = "Invaild username or password";
                    error_message.Visible = true;
                    // lblError.Background = Brushes.Red;

                }
                else
                {
                    Session["username"] = username;
                    Session["user_id"] = user.user_id;
                   
                    user.username = username;
                    error_message.InnerText ="";
                    error_message.Visible = false;
                    // when the user is logged i successfully
                    //gotToHomePage(user.user_id);
                    Response.Redirect("ViewModules.aspx");
                }

            }



        }

        private void gotToHomePage(int user_id)
        {
           /* Home viewHome = new Home();
            viewHome.user_id = user_id;
            viewHome.loadingHomePage();
            viewHome.Show();
           // this.Close();*/
        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // redirect

            LoginUser();
        }
    }
}