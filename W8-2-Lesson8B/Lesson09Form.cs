using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W8_2_Lesson8B
{
    public partial class Lesson09Form : Form
    {
        /// <summary>
        /// This is the constructor
        /// </summary>
        public Lesson09Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the shared Event Handler for all the calculator buttons' click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorNumbersClick(object sender, EventArgs e)
        {
            Button selectedButton = sender as Button; //casting the selectedButton as a Button-type obj.

            try
            {
                int.Parse(selectedButton.Text);
                ResultLabel.Text = selectedButton.Text;
            }
            catch
            {
                ResultLabel.Text = "Not a number";

            }

            /*
            switch (selectedButton.Text)
            {
                case "1":
                    ResultLabel.Text = "1";
                    break;
                default:
                    break;
            }
            */
            //ResultLabel.Text = selectedButton.Text;
        }
    }
}
