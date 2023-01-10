/*
 * Name: Shivam Janda
 * Date: Ocotber 2, 2022
 * Description: Main Window properties
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace CODE_IT_INC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // creates object from the program class
        Program newProject;
        // creates a list of objects from the program class
        List<Program> newProjects = new List<Program>();
        //creats a listbox 
        ListBox listOfNewProjects;

        /// <summary>
        /// If the create project button is clicked then check for validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void click(object sender, RoutedEventArgs e)
        {
            // Declare variables for validation
            String validation = "";
            double budget;
            double spent;
            int estHours;
            String projectName = "";
            String status = "";

            // adds current list box project into the list of projects created 
            listOfNewProjects = lbAllProjects;

            // if the project name textbox is empty then
            if (txtProjectName.Text == "")
            {
                // set validation variable to whats below 
                validation += " Please have a name for the project!";
            }
            else
            {
                projectName = txtProjectName.Text;
            }

       
            // if the value in the text box spent can be put into a double then continue 
            if (double.TryParse(txtSpent.Text, out spent)) { }

            //otherwise
            else
            {
                // add the text below to the validation variable 
                validation += " Spent has to be a valid number!";
            }

            // if the value in the text box budget can be put into a double then continue 
            if (double.TryParse(txtBudget.Text, out budget)) { }

            //otherwise
            else
            {
                // add the text below to the validation variable 
                validation += " Budget has to be a valid number!";
              }

           

            // if the value in the text box EstHoursRemaining can be put into a int then continue 
            if (int.TryParse(txtEstHoursRemaining.Text, out estHours)) { }

           // otherwise
             else
           {
            // add the text below to the validation variable 

           validation += " Hours has to be a whole number and cannot be empty!";
           }
        
            // if nothing is selected from the combo box then
            
            if (cboStatus.Text == "")
            {
                // add the text below to the validation variable 
                validation += " Make sure you have a status!";

            }
            //otherwise
            else
            {
                // have the status selected from the combo box into the status variable declared above
                status = cboStatus.Text;
            }

            // if there is text in the validation variabe (if there are any errors) then
            if (validation != String.Empty)
            {
                // put up a message box to display the error messages
                MessageBox.Show(validation, "", MessageBoxButton.OK);
            }
            //otherwise
            else
            {
                // creaste a new project by calling the CreateProject function that takes in all the parameters of a project recived from the user input
                CreateProject(projectName, budget, spent, estHours, status);
                // have the project name of the created project set into the list of projects on the right side of the window application
                listOfNewProjects.Items.Add(projectName);
                // add the new created project into the list of projects declared earlier by calling the GetProject() function to recieve the recently created project
                newProjects.Add(GetProject());
            }
        }

        /// <summary>
        /// When one of the item in the list box is double clicked then open a new window of ProjectWindow.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow newWindow = new ProjectWindow();

            // display the new window of ProjectWindow.xaml
            newWindow.Show();
        }

        /// <summary>
        /// When the drop down is closed, it will check if the combo box has completed selected. If so then have the estimated hours remaining as zero.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboStatus_DropDownClosed(object sender, EventArgs e)
        {
            if (cboStatus.Text == "Completed")
                {
                txtEstHoursRemaining.Text = "0"; // according to requirments if the user selected completed in the combo box list then set the estimated hours remaining to zero
                }
        }
        /// <summary>
        /// if the list of all the projects is not empty then loop through the list and insert the new altered project and remove the old project that was altered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Switch(object sender, EventArgs e)
        {
            if (listOfNewProjects != null)
            {
                for  (int i = 0; GetList().Count() > i; i++)
                {
                    listOfNewProjects.Items.Insert(i, GetList()[i].ProjectName);
                    listOfNewProjects.Items.RemoveAt(i + 1);
                }
            }
        }
        /// <summary>
        /// Creates a new project taking in values that the user inputs into the textboxes after they are valid
        /// </summary>
        /// <param name="projectName"></param>
        /// <param name="budget"></param>
        /// <param name="spent"></param>
        /// <param name="estHours"></param>
        /// <param name="status"></param>
        public void CreateProject(string projectName, double budget, double spent, int estHours, string status)
        {
            // creates a new project
            newProject = new Program(projectName, budget, spent, estHours, status);
        }
        /// <summary>
        /// Recieves the current new project
        /// </summary>
        /// <returns></returns>
        public Program GetProject()
        {
            return newProject;
        }
        /// <summary>
        /// Receives the List of created projects
        /// </summary>
        /// <returns></returns>
        public List<Program> GetList()
        {
            return newProjects;
        }

        /// <summary>
        /// Recieves the index of the selected project in the list
        /// </summary>
        /// <returns></returns>
        public int GetIndex()
        {
            return listOfNewProjects.SelectedIndex;
        }

      
    }

   
}
