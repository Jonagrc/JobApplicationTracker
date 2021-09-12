using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApplicationDll;

namespace AppplicationTrackerWF
{
    public partial class Form2 : Form
    {
        ApplicationDll.Application newapp;
        //Application newapp;
        
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            this.Hide();//hides this form 
            Form3 f = new Form3();//need to create an instance IOT access second form 
            f.ShowDialog();//this method shows this form
            this.Close();
        }

        private void btnViewList_Click(object sender, EventArgs e)
        {//TODO ADD ASYNC IF  POSSIBLE 
            // bc there is 2 tables followup and application table we must use LINQ IOT join both tables and display them
            try
            {
            newapp = new ApplicationDll.Application();// creating an instance of a new application
            var applist = newapp.ReadTable(); // this is the readtable that read the application table 
            var followuplist = newapp.ReadData(); // this is the readtable that read the followup table 
            var list = from apps in applist//joining 2 tables with primary and foreign key //// var list will contain everything
                       join follows in followuplist on apps.Application_Id equals follows.Application_Id
                       select new
                       {//printing everthing that is in both tables
                           apps.Application_Id,
                           apps.Company,
                           apps.Date_Applied,
                           apps.Date_Posted,
                           apps.Role_Applied_For,
                           apps.Location,
                           apps.Website_Applied,
                           apps.Company_email,
                           apps.Salary,
                           apps.Industry,
                           follows.Followed_Up,
                           follows.FollowUp_Date,
                           follows.Interview_Date,
                           follows.POC_Name,
                           follows.POC_ContactInfo,
                           follows.LinkedIn,
                           follows.WebsiteLink,
                           follows.Comments,
                           follows.Application_Closed
                       };

            //LINQ to have inner join
            grdviewHomePage.Visible = true;
            grdviewHomePage.DataSource = null; // refreshed the grid view then next shows the list of both tables
            grdviewHomePage.DataSource = list.ToList(); // .ToList(); makes the list into a list so we can see it in the grid view
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try { 
            grdviewHomePage.Visible = false; // once the form loads we will not see the grid view until we click the view list button
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //job finder name 
        {
            this.Hide();//hides this form 
            Form4 f = new Form4();//need to create an instance IOT access second form 
            f.ShowDialog();//this method shows this form
            this.Close();
        }
    }
}
