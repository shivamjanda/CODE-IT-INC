/*
 * Name: Shivam Janda
 * Date: Ocotber 2, 2022
 * Description: program class for project
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;



namespace CODE_IT_INC
{
    public class Program
    {

        private string projectName;
        private double budget;
        private double amountSpent;
        private int hoursRemaining;
        private string projectStatus;

        // Paramertized Constructor 
        public Program(string projectName, double budget, double amountSpent, int hoursRemaining, string projectStatus)
        {
            this.projectName = projectName;
            this.budget = budget;
            this.amountSpent = amountSpent;
            this.hoursRemaining = hoursRemaining;
            this.projectStatus = projectStatus;
        }

        // Getters and Setters
        public string ProjectName
        {
            get { return this.projectName; }
            set { this.projectName = value; }
        }

        public double ProjectBudget
        {
            get { return this.budget; }
            set { this.budget = value; }
        }
        public double ProjectSpent
        {
            get { return this.amountSpent; }
            set { this.amountSpent = value; }
        }

        public int ProjectEstHours
        {
            get { return this.hoursRemaining; }
            set { this.hoursRemaining = value; }

        }

        public String ProjectStatus
        {
            get { return this.projectStatus; }
            set { this.projectStatus = value; }
        }
    }
}
