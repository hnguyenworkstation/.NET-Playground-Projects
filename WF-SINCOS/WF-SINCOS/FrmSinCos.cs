using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_SINCOS
{
    public partial class FrmSinCos : Form
    {
        // Public Variables
        public int function = 0; // if function == 0 => find sin(X), else, function == 1, find cos(X)
         
        public FrmSinCos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // by default, the first displayed function is Sin(X) => function value = 0;
            function = 0;
            // setup Text for the Calculate button => "calculate Sin(X)" by default
            btnCal.Text = btnCal.Text + " " + cboSinCos.Items[0].ToString();
        }

        private void txtInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cboSinCos.Focus();
            }
        }

        private void cboSinCos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSinCos.Text.Equals(cboSinCos.Items[0].ToString()))
            {
                // by default, the first displayed function is Sin(X) => function value = 0;
                function = 0;
                // setup Text for the Calculate button => "calculate Sin(X)" by default
                btnCal.Text = "Calculate " + cboSinCos.Items[0].ToString();
            } else
            {
                // when option "Cos(X)" is selected
                function = 1;
                // setup Text for the Calculate button
                btnCal.Text = "Calculate " + cboSinCos.Items[1].ToString();
            }
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            // get the value of degree
            double x;
            double xRad; // convert degree to radian
            x = xRad = 0; // be default

            try
            {
                x = Double.Parse(txtInput.Text);
                xRad = (x * Math.PI) / 180;
                string result = " ";

                if(function == 0) // Calculate Sin
                {
                    result = "Sin of " + x + " is: " + Math.Round(FuntionLib.calSinX(xRad), 5); // round to 5 decimal
                }
                else // calculate Cos
                {
                    result = "Cos of " + x + " is: " + Math.Round(FuntionLib.calCosX(xRad), 5); // round to 5 decimal
                }

                // Display Message
                MessageBox.Show(result, "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
            }
            catch (FormatException)
            {
                // display error message
                MessageBox.Show("Invalid Value of X","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // focus to the textbox again to get another input
                txtInput.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInput.Text = "";
            cboSinCos.Text = cboSinCos.Items[0].ToString();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
