using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppplicationTrackerWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtboxPassword.PasswordChar = '*';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtboxLogin.Text == "shabalala" & txtboxPassword.Text == "password")
            {
                this.Hide();//hides this form 
                Form2 f = new Form2();//need to create an instance IOT access second form 
                f.ShowDialog();//this method shows this form
                this.Close();
            }
            else
            {
                incorrectlabel.Text = "INCORRECT USERNAME OR PASSWORD";
               // MessageBox.Show("Incorrect Username or Password");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            txtboxLogin.Clear();
            txtboxPassword.Clear();
            incorrectlabel.Text = "       ";
        }

        private void forgotlabel_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Username = shabalala     Password = password");
        }

        private void txtboxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                e.SuppressKeyPress = true;
                btnLogin_Click(sender, e);
            }
        }

        private void txtboxLogin_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtboxLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtboxPassword.Focus();
                e.SuppressKeyPress = true;
            }
        }
    }
}
