using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class frmCal : Form
    {
        string input = string.Empty;
        string operacija;
        double rezultat = 0.0;
        bool tacka = false;

        private void Reset()
        {
            lblScreen.Text = string.Empty;
            input = string.Empty;
            tacka = false;
        }
        public frmCal()
        {
            InitializeComponent();
        }

        private void frmCal_Load(object sender, EventArgs e)
        {

        }
        private void buttonPress(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lblScreen.Text = lblScreen.Text + btn.Text;
        }

        private void buttonOperacija(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "-" && string.IsNullOrEmpty(input) && string.IsNullOrEmpty(lblScreen.Text))
            {
                lblScreen.Text = "-";
            }
            else
            {
                if (string.IsNullOrEmpty(input))
                {
                    input = lblScreen.Text;
                }
                operacija = btn.Text;
                lblScreen.Text = string.Empty;
                tacka = false;
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (string.IsNullOrEmpty(lblScreen.Text) && !tacka)
            {
                lblScreen.Text = "0.";
                tacka = true;
            }
            else if (!string.IsNullOrEmpty(lblScreen.Text) && !tacka)
            {
                lblScreen.Text = lblScreen.Text + ".";
                tacka = true;
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblScreen.Text))
            {
                if (input != string.Empty)
                {
                    if (operacija == "+") rezultat = double.Parse(input, CultureInfo.InvariantCulture) + double.Parse(lblScreen.Text, CultureInfo.InvariantCulture);
                    else if (operacija == "-") rezultat = double.Parse(input, CultureInfo.InvariantCulture) - double.Parse(lblScreen.Text, CultureInfo.InvariantCulture);
                    else if (operacija == "x") rezultat = double.Parse(input, CultureInfo.InvariantCulture) * double.Parse(lblScreen.Text, CultureInfo.InvariantCulture);
                    else if (operacija == "/")
                    {
                        if (lblScreen.Text == "0")
                        {
                            MessageBox.Show("Can't divide with 0!");
                            Reset();
                            return;
                        }
                        else
                        {
                            rezultat = double.Parse(input, CultureInfo.InvariantCulture) / double.Parse(lblScreen.Text, CultureInfo.InvariantCulture);
                        }
                    }
                    Reset();
                    lblScreen.Text = rezultat.ToString();
                }
            }
        }
    }
}
