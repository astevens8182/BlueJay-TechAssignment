using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace v1
{
    public partial class Form1 : Form
    {
        string lastDirection = string.Empty;
        string directionHolder = string.Empty;
        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbDirection.SelectedIndex = 0;
            cbLight.SelectedIndex = 0;
            lblLightStatus.Text = "Green";
            lblDirection.Text = "Not moving";
            radSemiTruck.Select();
        }

        private void btnSim_Click(object sender, EventArgs e)
        {

            directionHolder = cbDirection.Text;

            if((lblDirection.Text.Equals("Jack Knife to a Stop") && !(cbDirection.SelectedIndex.Equals(0))) ||
                lblDirection.Text.Equals("Run Over Ford Pinto") && !(cbDirection.SelectedIndex.Equals(0)))
            {
                MessageBox.Show($"After {lblDirection.Text} you can only move forward!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
      
            if (lastDirection.Equals("Move Forward") && directionHolder.Equals("Move Forward"))
            {
                MessageBox.Show("Cannot move forward twice in a row!","Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cbDirection.SelectedIndex.Equals(1) && !(cbLight.SelectedIndex.Equals(3)))
            {
                MessageBox.Show("Can only make left turn on signal Left-Turn Green", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (cbLight.SelectedIndex)
            {
                case 0:
                case 3:
                    lblLightStatus.ForeColor = Color.Green;
                    break;

                case 1:
                    lblLightStatus.ForeColor = Color.Yellow;
                    break;

                case 2:
                    lblLightStatus.ForeColor = Color.Red;
                    break;
            }
            lblDirection.Text = cbDirection.SelectedItem.ToString();
            lblLightStatus.Text = cbLight.SelectedItem.ToString();
            lastDirection = cbDirection.SelectedItem.ToString();
            cbLight.SelectedIndex = 0;


        }

        private void lblLightStatus_Click(object sender, EventArgs e)
        {

        }

        private void radSemiTruck_CheckedChanged(object sender, EventArgs e)
        {
            cbDirection.Items.RemoveAt(3);
            cbDirection.Items.Add("Jack Knife to a Stop");
            cbDirection.SelectedIndex = 0;
            cbLight.SelectedIndex = 0;
            lblLightStatus.Text = "Green";
            lblDirection.Text = "Not moving";
        }

        private void radSuv_CheckedChanged(object sender, EventArgs e)
        {
            cbDirection.Items.RemoveAt(3);
            cbDirection.Items.Add("Run Over Ford Pinto");
            cbDirection.SelectedIndex = 0;
            cbLight.SelectedIndex = 0;
            lblLightStatus.Text = "Green";
            lblDirection.Text = "Not moving";
        }
    }
}
