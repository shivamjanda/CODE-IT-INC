/*
 * Name: Shivam Janda
 * Date: Ocotber 2, 2022
 * Description: Project Window properties
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
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        public ProjectWindow()
        {
            InitializeComponent();
            //  when the 
            this.Loaded += new RoutedEventHandler(ProjectWindow_Loaded);
        }
        // variable for index of the list which will be passed through from the main window
        int i;
        // 
        MainWindow homePage = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        /// <summary>
        /// Gets the list from the main window 
        /// </summary>
        /// <returns></returns>
        private List<Program> GetListFromMainWindow()
        {
            return homePage.GetList();
        }

        /// <summary>
        /// gets the index of the list from the main window
        /// </summary>
        /// <returns></returns>
        private int GetIndexFromMainWindow()
        {
            return homePage.GetIndex();

        }

        /// <summary>
        /// When the project window is open the recieve the list from the main window and using the class setter to put it into the new list in this window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ProjectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            i = GetIndexFromMainWindow();

            List<Program> projects = GetListFromMainWindow();

            // using he program cs setters to set the new values
            txtProjectName.Text = projects[i].ProjectName;
            txtBudget.Text = projects[i].ProjectBudget.ToString();
            txtSpent.Text = projects[i].ProjectSpent.ToString();
            txtEstHours.Text = projects[i].ProjectEstHours.ToString();
            cboStatus.Text = projects[i].ProjectStatus;
        }

        /// <summary>
        /// when the alter button is clicked the new values entered are validated. If they do not meet the requirements then a error message box will show up. If they
        /// are valid then set the new values entered into the old project
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAlter_Click(object sender, RoutedEventArgs e)
        {
            List<Program> projects = GetListFromMainWindow();
            double budget;
            double amountSpent;
            int hoursRemaining;
            string validation = "";

            // validation similar to the on in mainWindow.xaml.cs
            if (txtProjectName.Text == String.Empty)
            {
                validation += " Please enter a project name!";
            }
            else
            {
                projects[i].ProjectName = txtProjectName.Text;
            }

            if (double.TryParse(txtSpent.Text, out amountSpent))
            {
                projects[i].ProjectSpent = amountSpent;
            }

            else
            {
                validation += " Spent has to be a valid number!";
            }

            if (double.TryParse(txtBudget.Text, out budget))
            {
                projects[i].ProjectBudget = budget;
            }

            else
            {
                validation += " Budget has to be a valid number!";
            }

            if (int.TryParse(txtEstHours.Text, out hoursRemaining)) 
            {
                projects[i].ProjectEstHours = hoursRemaining;

            }

            else
            {
                validation += " Hours has to be a whole number and cannot be empty!";
            }

            if (cboStatus.Text == String.Empty)
            {
                validation += " Make sure you have a status!";

            }
            else
            {
                projects[i].ProjectStatus = cboStatus.Text; 
            }
            
            if (validation != String.Empty)
                {
                MessageBox.Show(validation, "", MessageBoxButton.OK);
            }


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
                txtEstHours.Text = "0"; // according to requirments if the user selected completed in the combo box list then set the estimated hours remaining to zero
            }
        }
        /// <summary>
        /// when the user presses the close button, it will close the project window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       
    }
}
