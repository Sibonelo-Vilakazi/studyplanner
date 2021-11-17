using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyPlannerWebApplication.DataAccess;

namespace StudyPlannerWebApplication
{
    public partial class ViewModules : System.Web.UI.Page
    {
        private StudyPlannerEntities db = new StudyPlannerEntities();
        private bool closeScreen = false;
        public List<Module> listModules { get; set; }
        //public List<ModuleHours> listModuleHours { get; set; }
        //public List<TrackHours> listModuleTracks { get; set; }
        public int weeks { get; set; }
        public DateTime startDate { get; set; }

        public int user_id { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user_id"] != null)
            {
                user_id =Convert.ToInt32(Session["user_id"].ToString().Trim());
                setupView();
            }
        }

        public void setupView()
        {
            listModules = db.Modules.Where(u => u.user_id == user_id).ToList();
            // listModuleHours = 
            foreach (Module m in listModules)
            {
                Module_Hours h = m.Module_Hours.Where(d => d.module_id == m.module_id).FirstOrDefault();
                String table_data = "<tr>" +
                    "<td>" + m.module_name + "</td >" +
                    "<td>" + h.self_studying_hours + "</td>" +
                    "<td>" + h.hours_remaining + "</td>" +
                    "<td><a href = 'ReportPicker.aspx?ID=" + m.module_id + "'>"
                           + "View Report</a></td>";
                if (h.hours_remaining <= 0)
                {
                    table_data += "<td>Completed</td >" +
                        "</tr>";
                }
                else
                {
                    
                    table_data += "<td><a href='CaptureHoursSpent.aspx?ID=" + m.module_id + "'>"
                        +"Click here to Capture</a></td>" +
                    "</tr>";
                }
                table_details.InnerHtml += table_data;

                /*int rowCount = ViewModulesGrid.RowDefinitions.Count();
                 
                displaySingleItem(new TextBlock(), ViewModulesGrid, rowCount, 1, m.module_code, "");
                Module_Hours h = m.Module_Hours.Where(d => d.module_id == m.module_id).FirstOrDefault();
                displaySingleItem(new TextBlock(), ViewModulesGrid, rowCount, 2, h.self_studying_hours.ToString(), "");
                displaySingleItem(new TextBlock(), ViewModulesGrid, rowCount, 3, h.hours_remaining.ToString(), "");
                if (h.hours_remaining <= 0)
                {
                    displaySingleItem(new Button(), ViewModulesGrid, rowCount, 4, "Capture Hours Studied today", "disabled");

                }
                else
                {
                    displaySingleItem(new Button(), ViewModulesGrid, rowCount, 4, "Capture Hours Studied today", m.module_code);

                }*/

            }


        }


        /*public void setModules(List<Module> list)
        {
            this.listModules = list;
        }

        public List<Module> getListModules()
        {
            return this.listModules;
        }*/

      /*  public void displaySingleItem(UIElement ui, Grid grid, int row, int col, String Text, String Name)
        {
            grid.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });

            if (ui is TextBlock)
            {
                TextBlock t = (TextBlock)ui;
                t.Text = Text;
                Thickness margin = t.Margin;
                margin.Left = 50;
                margin.Top = 5;
                t.Margin = margin;
                Grid.SetColumn(t, col);
                Grid.SetRow(t, row);
                grid.Children.Add(t);
            }
            else if (ui is Button)
            {
                Button btn = (Button)ui;
                btn.Content = Text;
                btn.Name = Name;
                Thickness margin = btn.Margin;
                margin.Left = 50;
                margin.Top = 5;
                btn.Margin = margin;
                if (Name.Equals("disabled"))
                {
                    btn.Click += new RoutedEventHandler(NoRedirect_Click);

                }
                else
                {
                    btn.Click += new RoutedEventHandler(DynamicButton_Click);

                }
                Grid.SetColumn(btn, col);
                Grid.SetRow(btn, row);
                grid.Children.Add(btn);
            }

        }*/

        /*public void updateHoursRequired()
        {
            DateTime timeW = DateTime.Now.AddDays(5 * 7);

            if (DateTime.Now.ToString("ddd") == "MON")
            {

            }
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {
            //

            CaputerHoursSpent capture = new CaputerHoursSpent();
            string code = (sender as Button).Name;
            Module module = listModules.Where(m => m.module_code.ToUpper().Trim() == code.ToUpper().Trim() && m.user_id == user_id).FirstOrDefault();
            capture.user_id = user_id;
            capture.setPopUp(module.module_name, module.module_code, module.module_id);
            capture.Show();
            closeScreen = true;
            this.Close();
        }

        private void NoRedirect_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have completed your study hours for the week you can \n"
                + "you can focus on the other modules");
        }

        public void goToHomePage()
        {
            Home viewHome = new Home();
            viewHome.user_id = this.user_id;
            viewHome.loadingHomePage();

            viewHome.Show();
        }

        public void CloseView(object sender, EventArgs e)
        {
            if (!closeScreen)
            {
                goToHomePage();
            }
        }*/


    }
}