using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinfoFormsApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int i = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("You clicked the button", "Box caption", MessageBoxButtons.OKCancel);
            //lblOutput.Text = "Button clicked " + ++i +" times";
            lblOutput.Text = String.Format("Button clicked {0} times", ++i);
            
        }
    }
}