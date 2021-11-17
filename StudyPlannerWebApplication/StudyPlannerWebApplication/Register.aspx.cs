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
    public partial class Register : System.Web.UI.Page    
    {
        StudyPlannerEntities db = new StudyPlannerEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
           removeMessage();
        }

        public void removeMessage()
        {
            error_message.Visible = false;
            success_message.Visible = false;
        }

        public void RegisterUser()
        {
            removeMessage();
            String username = txtUsername.Value;
            User user = db.Users.Where(u => u.username == username).FirstOrDefault();
            
            if (txtPassword.Value.ToString().Trim() != txtConfirmPassword.Value.ToString().Trim())
            {
                error_message.InnerText = "Passwords do not match";
                
            }
            else
            {



                if (user != null)
                {
                    error_message.InnerText = "This username already exists";
                    error_message.Visible = true;

                }
                else
                {
                    user = new User();
                    user.username = username;
                    string password = txtPassword.Value.ToString();
                    user.password = Secrecy.HashPassword(password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    success_message.InnerText = "You have successfully registered an account";
                    success_message.Visible = true;
                }

            }



        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterUser();
        }
    }
}