using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_LOGIN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If user hits ENTER key, cusor focuses on the Password textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtPass.Focus();
            }
        }

        /// <summary>
        /// If user hits ENTER key, cusor focuses on the Login Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin.Focus();
            }
        }

        /// <summary>
        /// Display a message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUser.Text == null || txtPass.Text == null)
            {
                MessageBox.Show("Invalid Username/Password","Attention!");
            } else
            {
                string Message;

                Message = "Your Username is: ";
                Message += this.txtUser.Text;
                Message += "\n" + "Your Password is: ";
                Message += this.txtPass.Text;

                if(this.chkSave.Checked == true)
                {
                    Message += "\nYour account is saved on the system.";
                }

                MessageBox.Show(Message, "Successfully!");
            }
        }

        /// <summary>
        /// Clear all text boxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPass.Text = "";
            txtUser.Text = "";
            chkSave.Checked = false;
            txtUser.Focus();
        }

        /// <summary>
        /// Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtUser.Text == null || txtPass.Text == null)
            {
                MessageBox.Show("Invalid Username/Password", "Attention!");
            }
            else
            {
                string Message;

                Message = "Your Username is: ";
                Message += this.txtUser.Text;
                Message += "\n" + "Your Password is: ";
                Message += this.txtPass.Text;

                if (this.chkSave.Checked == true)
                {
                    Message += "\nYour account is saved on the system.";
                }

                MessageBox.Show(Message, "Successfully!");
            }
        }
    }
}
