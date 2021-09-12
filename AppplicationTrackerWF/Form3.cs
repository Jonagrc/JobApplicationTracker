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
{ //TODO USE ASYNC , TASK AWAIT
    //TODO ADVANCE UI 
    public partial class Form3 : Form
    {
        ApplicationDll.Application newapp;

        public Form3()
        {
            InitializeComponent();

        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();//hides this form 
            Form2 f = new Form2();//need to create an instance IOT access second form 
            f.ShowDialog();//this method shows this form
            this.Close();
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {//TODO CHANGE TO TRY CATCH

            btnDeleteApp.Enabled = false;
            btnSelect.Enabled = false;
            if (txtBoxAppId.Text == "") //making sure there is nothing in the text appid textbox
            {
                ClearDataNew();
                MessageBox.Show("Add Info then press Add");
                this.ActiveControl = txtBoxCoName;
                txtBoxCoName.Focus();

            }
            if (!string.IsNullOrWhiteSpace(txtBoxCoName.Text) && !string.IsNullOrWhiteSpace(txtBoxAppId.Text)) //checks to make sure coname, appid and followup date isnt null or blank
            {
                var app = new ApplicationDll.applicationtable();//this is only fpr app table not follow up/2 diff tables
                    var fol = new ApplicationDll.FollowUp();//needed to add bc this is a diff table from application table  23
                
                    app.Application_Id = Convert.ToInt32(txtBoxAppId.Text); // convert textbox to int
                    CheckNull(app);//used to check NULL or not

                    fol.Application_Id = Convert.ToInt32(txtBoxAppId.Text);// NEED TO add APPLICATION ID FIRST same for the 
                    fol.Followed_Up = Convert.ToBoolean(chckBoxFollowedUp.Checked); //CANT BE NULL 
                    fol.Application_Closed = Convert.ToBoolean(chckBoxAppClosed.CheckState); //cant be null || check if button is checked return bool
                    CheckFolNull(fol);

                    newapp.AddApplication(app);// need to add APP FIRST BEFORE FOL bc it has the primary key 
                    newapp.AddFollowUpTable(fol);//adds this to the followup obj to the followup table

                    Clear();
                AutoRefresh();
            }

            
        }
        private void ClearDataNew()
        {// clearing all the data to make it ready to enter in the text boxes 
            try 
            { 
            txtBoxAppId.Clear();
            txtBoxAppId.ReadOnly = true;
            txtBoxAppId.Text = (newapp.GetMaxId() + 1).ToString(); //auto generates the new number for the application id
            txtBoxCoName.Clear();
            txtBoxDateApplied.Clear(); //appli.Date_Applied 
            txtBoxDatePosted.Clear(); //appli.Date_Posted 
            txtBoxRole.Clear(); //appli.Role_Applied_For 
            txtBoxLocation.Clear(); //appli.Location 
            txtBoxWebsite.Clear(); //appli.Website_Applied
            txtBoxCoEmail.Clear(); //appli.Company_email 
            txtBoxSalary.Clear(); //appli.Salary 
            txtBoxIndustry.Clear(); //appli.Industry 
            txtBoxFollowDate.Clear();  //appli.FollowUp.FollowUp_Date 
            txtBoxInterviewDate.Clear(); //appli.FollowUp.Interview_Date 
            txtBoxPOCName.Clear(); //appli.FollowUp.POC_Name 
            txtBoxPOCNum.Clear(); //appli.FollowUp.POC_ContactInfo 
            txtBoxLinkedIn.Clear(); //appli.FollowUp.LinkedIn 
            txtBoxWebLink.Clear(); //appli.FollowUp.WebsiteLink 
            txtBoxComments.Clear(); //appli.FollowUp.Comments
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void Clear()
        {
            try { 
            txtBoxAppId.Clear();
            txtBoxCoName.Clear();
            txtBoxDateApplied.Clear(); //appli.Date_Applied 
            txtBoxDatePosted.Clear(); //appli.Date_Posted 
            txtBoxRole.Clear(); //appli.Role_Applied_For 
            txtBoxLocation.Clear(); //appli.Location 
            txtBoxWebsite.Clear(); //appli.Website_Applied
            txtBoxCoEmail.Clear(); //appli.Company_email 
            txtBoxSalary.Clear(); //appli.Salary 
            txtBoxIndustry.Clear(); //appli.Industry 
            txtBoxFollowDate.Clear();  //appli.FollowUp.FollowUp_Date 
            txtBoxInterviewDate.Clear(); //appli.FollowUp.Interview_Date 
            txtBoxPOCName.Clear(); //appli.FollowUp.POC_Name 
            txtBoxPOCNum.Clear(); //appli.FollowUp.POC_ContactInfo 
            txtBoxLinkedIn.Clear(); //appli.FollowUp.LinkedIn 
            txtBoxWebLink.Clear(); //appli.FollowUp.WebsiteLink 
            txtBoxComments.Clear(); //appli.FollowUp.Comments
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CheckNull(applicationtable app)
        {//chekcing if text boxes are null or not if not print to what is in the text box 
            //TODO CHANGE TO TRY PARSE

            //add date time function to check for all date time and decimal function
            DateTime none;
            decimal num;
            if (!string.IsNullOrWhiteSpace(txtBoxDateApplied.Text))//if its null or whitespace
            {

                if (DateTime.TryParse(txtBoxDateApplied.Text, out none))//if there is text in the textbox check if its formatted right
                {
                    app.Date_Applied = Convert.ToDateTime(txtBoxDateApplied.Text);//convert text to date time
                }
                else //if not user will receive message
                {
                    app.Date_Applied = none;
                    MessageBox.Show("Invalid Date Applied , please update application");
                }
            }
            else
            {
                app.Date_Applied = null;
            }

            if (string.IsNullOrWhiteSpace(txtBoxCoName.Text))
            {
                app.Company = null;
            }
            else
            {
                app.Company = txtBoxCoName.Text; //cant be NULL

            }
            if (string.IsNullOrWhiteSpace(txtBoxLocation.Text))
            {
                app.Location = null;
                //txtBoxLocation.Text = " ";
            }
            else
            {
                app.Location = txtBoxLocation.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtBoxDatePosted.Text))
            {

                if (DateTime.TryParse(txtBoxDatePosted.Text, out none))//if there is text in the textbox check if its formatted right
                {
                    app.Date_Posted = Convert.ToDateTime(txtBoxDatePosted.Text);//convert text to date time
                }
                else //if not user will receive message
                {
                    app.Date_Posted = none;
                    MessageBox.Show("Invalid Date Posted , please update application");
                }
            }
            else
            {
                app.Date_Posted = null;
            }
            if (string.IsNullOrWhiteSpace(txtBoxRole.Text))
            {
                app.Role_Applied_For = null;
            }
            else
            {
                app.Role_Applied_For = txtBoxRole.Text;
            }
            if (string.IsNullOrWhiteSpace(txtBoxWebsite.Text))
            {
                app.Website_Applied = null;
            }
            else
            {
                app.Website_Applied = txtBoxWebsite.Text;

            }
            if (string.IsNullOrWhiteSpace(txtBoxCoEmail.Text))
            {
                app.Company_email = null;
            }
            else
            {
                app.Company_email = txtBoxCoEmail.Text;
            }
            if (!string.IsNullOrWhiteSpace(txtBoxSalary.Text))
            {
                if (Decimal.TryParse(txtBoxSalary.Text, out num))//if there is text in the textbox check if its formatted right
                {
                    app.Salary = Convert.ToDecimal(txtBoxSalary.Text);//convert text to date time
                }
                else
                {
                    app.Salary = num;
                    MessageBox.Show("Invalid Salary entry, please update application with 00000 format");
                }
            }
            else
            {
                app.Salary = null;
            }
            if (string.IsNullOrWhiteSpace(txtBoxIndustry.Text))
            {
                app.Industry = null;
            }
                else
                {
                app.Industry = txtBoxIndustry.Text;
                }



        }
        private void CheckFolNull(FollowUp fol)
        {//TODO CHANGE TO TRY PARSE 
            DateTime none;
            if (!string.IsNullOrWhiteSpace(txtBoxInterviewDate.Text))
            {
                if (DateTime.TryParse(txtBoxInterviewDate.Text, out none))//if there is text in the textbox check if its formatted right
                {
                    fol.Interview_Date = Convert.ToDateTime(txtBoxInterviewDate.Text);//convert text to date time
                }
                else //if not user will receive message
                {
                    fol.Interview_Date = none;
                    MessageBox.Show("Invalid Interview Date, please update application Interview Date");
                }
            }
            else
            {
               // fol.Interview_Date = Convert.ToDateTime(txtBoxInterviewDate.Text);
                fol.Interview_Date = null;
            }
            if (string.IsNullOrWhiteSpace(txtBoxPOCName.Text))
            {
                fol.POC_Name = null;
            }
            else
            {
                fol.POC_Name = txtBoxPOCName.Text;

            }
            if (!string.IsNullOrWhiteSpace(txtBoxFollowDate.Text))
            {
                if (DateTime.TryParse(txtBoxFollowDate.Text, out none))//if there is text in the textbox check if its formatted right
                {
                    fol.FollowUp_Date = Convert.ToDateTime(txtBoxFollowDate.Text);//convert text to date time
                }
                else //if not user will receive message
                {
                    fol.FollowUp_Date = none;
                    MessageBox.Show("Invalid Follow Up Date, please update application Follow Up Date");
                }
            }
            else
            {
                //fol.FollowUp_Date = Convert.ToDateTime(txtBoxFollowDate.Text);// cant be NULL 
                fol.FollowUp_Date = DateTime.MinValue;
            }
            if (string.IsNullOrWhiteSpace(txtBoxPOCNum.Text))
            {
                fol.POC_ContactInfo = null;
            }
            else
            {
                fol.POC_ContactInfo = txtBoxPOCNum.Text;

            }
            if (string.IsNullOrWhiteSpace(txtBoxLinkedIn.Text))
            {
                fol.LinkedIn = null;
            }
            else
            {
                fol.LinkedIn = txtBoxLinkedIn.Text;

            }
            if (string.IsNullOrWhiteSpace(txtBoxWebLink.Text))
            {
                fol.WebsiteLink = null;
            }
            else
            {
                fol.WebsiteLink = txtBoxWebLink.Text;

            }
            if (string.IsNullOrWhiteSpace(txtBoxComments.Text))
            {
                fol.Comments = null;
            }
            else
            {
                fol.Comments = txtBoxComments.Text;

            }
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            try
            {
                var id = grdviewHomePage.CurrentRow.Cells[0].Value;
                if (Convert.ToInt32(id) == 1)
                {
                    MessageBox.Show("Can not Delete the first application");
                }
                else
                {
                    var apptodel = newapp.FindApp((int)id);
                    newapp.DeleteApplication(apptodel);
                    MessageBox.Show("Application was deleted");

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                this.ActiveControl = txtBoxCoName;
                txtBoxCoName.Focus();
                AutoRefresh();
            }

        }
        

        private void btnUpdateApp_Click(object sender, EventArgs e)
        {// TODO CHANGE TO TRY PARSE
         
            try
            {
                btnAddApp.Enabled = true;
                btnDeleteApp.Enabled = true;
                var id = Convert.ToInt32(txtBoxAppId.Text);
                var apptoupdate = newapp.FindApp((int)id);//this finds the application in apptable
                var foltoupdate = newapp.FindFollowUp((int)id);//needed to create a find followmethod IOT also find the followup table 
                apptoupdate.Application_Id = Convert.ToInt32(txtBoxAppId.Text);
                CheckNull(apptoupdate);//doing null checks
                CheckFolNull(foltoupdate);// doing null checks
                foltoupdate.Application_Id = Convert.ToInt32(txtBoxAppId.Text);
                foltoupdate.Followed_Up = Convert.ToBoolean(chckBoxFollowedUp.Checked);
                foltoupdate.Application_Closed = Convert.ToBoolean(chckBoxAppClosed.Checked);

                newapp.UpdateApplication((decimal)id, apptoupdate);
                newapp.UpdateFollowUp((decimal)id, foltoupdate);//needed to update followup table as well 
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                MessageBox.Show("This app has been update");
                AutoRefresh();
            }
        }
        private void AutoRefresh()
        {
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
            btnUpdateApp.Enabled = false;
            btnDeleteApp.Enabled = false;
            btnSelect.Enabled = true;
            btnAddApp.Enabled = true;
            Clear();
        }

        private void Form3_Load(object sender, EventArgs e)
        { // ADD TRY CATCH BLOCKS\
            try 
            {
                btnUpdateApp.Enabled = false;
                btnDeleteApp.Enabled = false;
                newapp = new ApplicationDll.Application();
            //USE LINQ AS WAY OF ACCESSING DATA THATS IT 
            var applist = newapp.ReadTable();
            var followuplist = newapp.ReadData();
            var list = from apps in applist
                       join follows in followuplist on apps.Application_Id equals follows.Application_Id
                       select new
                       {
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
            grdviewHomePage.DataSource = null;
            grdviewHomePage.DataSource = list.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
         //grdviewHomePage.DataSource = null;
         //grdviewHomePage.DataSource = newapp.ReadTable();
            try
            {
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
                btnUpdateApp.Enabled = false;
                btnDeleteApp.Enabled = false;
                btnSelect.Enabled = true;
                btnAddApp.Enabled = true;
                this.ActiveControl = txtBoxCoName;
                txtBoxCoName.Focus();
                Clear();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.ActiveControl = txtBoxCoName;
            txtBoxCoName.Focus();
            var id = grdviewHomePage.CurrentRow.Cells[0].Value;
            var apptoupdate = newapp.FindApp((int)id);
            txtBoxAppId.Text = apptoupdate.Application_Id.ToString();
            txtBoxAppId.ReadOnly = true;

            txtBoxCoName.Text = apptoupdate.Company;
            txtBoxDateApplied.Text = apptoupdate.Date_Applied.ToString();
            txtBoxDatePosted.Text = apptoupdate.Date_Posted.ToString();
            txtBoxRole.Text = apptoupdate.Role_Applied_For;
            txtBoxLocation.Text = apptoupdate.Location;
            txtBoxWebsite.Text = apptoupdate.Website_Applied;
            txtBoxCoEmail.Text = apptoupdate.Company_email;
            txtBoxSalary.Text = apptoupdate.Salary.ToString();
            txtBoxIndustry.Text = apptoupdate.Industry;

            
           // txtBoxFollowedUp.Text = apptoupdate.FollowUp.ToString();
            txtBoxFollowDate.Text = apptoupdate.FollowUp.FollowUp_Date.ToString();
            txtBoxInterviewDate.Text = apptoupdate.FollowUp.FollowUp_Date.ToString();
            txtBoxPOCName.Text = apptoupdate.FollowUp.POC_Name;
            txtBoxPOCNum.Text = apptoupdate.FollowUp.POC_Name;
            txtBoxLinkedIn.Text = apptoupdate.FollowUp.LinkedIn;
            txtBoxWebLink.Text = apptoupdate.FollowUp.WebsiteLink;
            txtBoxComments.Text = apptoupdate.FollowUp.Comments;
           // txtBoxAppClosed.Text = apptoupdate.FollowUp.Application_Closed.ToString();
            btnUpdateApp.Enabled = true;
            btnDeleteApp.Enabled = true;
            btnAddApp.Enabled = false;
           // btnDeleteApp.Enabled = false;
        }

        private void txtBoxAppId_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBoxCoName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBoxAppId_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtBoxCoName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                txtBoxDateApplied.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxDateApplied_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxDatePosted.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxDatePosted_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxRole.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxRole_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxLocation.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxWebsite.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxWebsite_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxCoEmail.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxCoEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxSalary.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxSalary_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxIndustry.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxIndustry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxFollowDate.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxFollowDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxInterviewDate.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxInterviewDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxPOCName.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxPOCName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxPOCNum.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxPOCNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxLinkedIn.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxLinkedIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxWebLink.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtBoxWebLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBoxComments.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void grdviewHomePage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSelect_Click(sender,e);
        }
    }
}
