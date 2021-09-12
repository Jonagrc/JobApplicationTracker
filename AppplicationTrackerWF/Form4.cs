using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace AppplicationTrackerWF
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://builtin.com/");
        }

        private void LinkedInlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.linkedin.com/jobs");
        }

        private void indeedlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.indeed.com/");
        }

        private void ziprecuiterlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.ziprecruiter.com/search-jobs?tsid=101050038&utm_source=dgljs|bing-search|cmp-396459554|adg-1252344292790729|kw-kwd-78271802329780:loc-190|mt-e|device-c|cr-78271643587570|uid-01b2e803414616edb18989248503342b&utm_medium=cpc&msclkid=01b2e803414616edb18989248503342b");
        }

        private void UsaJobslink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.usajobs.gov/search/results?");
        }

        private void monsterlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.monster.com/");
        }

        private void recruitmilitarylink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://recruitmilitary.com/");
        }

        private void microsoftlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://careers.microsoft.com/us/en");
        }

        private void Dicelink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.dice.com/");
        }

        private void Careerbuilderlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.careerbuilder.com/");
        }

        private void Hirectlink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.hirect.org/");
        }

        private void hireveteranslink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.hireveterans.com/");
        }

        private void btnReturnMenu_Click(object sender, EventArgs e)
        {
            this.Hide();//hides this form 
            Form2 f = new Form2();//need to create an instance IOT access second form 
            f.ShowDialog();//this method shows this form
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
    }
}
