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
        //PRIVATE DATA MEMBERS
        private Label m_activeLabel;

        // PUBLIC PROPERTIES
        public string outputString { get; set; }
        public float outputValue { get; set; }
        public bool decimalExists { get; set; }
        public Label ActiveLabel
        {
            get
            {
                return m_activeLabel;
            }
            set(Label newLabel)
            {
            if (m_activeLabel != null)
            {
            m_activeLabel.BackColor = Color.White;
            }
    m_activeLabel=value;
        if (m_ActiveLabel != null)
        {
            m_activeLabel.BackColor=Color.LightBlue;
        }
            }
        }

        /// <summary>
        /// This is the constructor
        /// </summary>
        public Lesson09Form()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This is the event handler for the form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lesson09Form_Load(object sender, EventArgs e)
        {
    this.Size = new Size(320, 480);
            clearNumericKeyboard();
    NumberButtonTableLayoutPannel.Visible = false;



        }
        /// <summary>
        /// This is the event handler for the form click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Calculatorform_Click(object sender, EventArgs e)
        {
            NumberButtonTableLayoutPannel.Visible = false;
          ActiveLabel = null;
            clearNumericKeyboard();
        }

        /// <summary>
        /// This is the shared Event Handler for all the calculator buttons' click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculatorButtons_Click(object sender, EventArgs e)
        {
            Button TheButton = sender as Button; //casting the selectedButton as a Button-type obj.
            var tag = TheButton.Tag.ToString();
            int numericValue = 0;

            bool numericResult = int.TryParse(tag, out numericValue);

            if (numericResult)
            {
                int maxSize = (decimalExists) ? 5 : 3;

                if (outputString == "0")
                {
                    outputString = tag;
                }
                else if (outputString.Length < maxSize)

                {
                    outputString += tag;
                }
                ResultLabel.Text = outputString;
            }
            else
            {
                switch (tag)
                {
                    case "back":
                        removeLastCharacterFromResultLabel();
                        break;
                    case "done":
                        finalizeOutput();
                        break;
                    case "clear":
                        clearNumericKeyboard();
                        break;
                    case "decimal":
                        addDecimalToResultLabel();
                        break;
                }
            }
        }

        /// <summary>
        /// This method adds the decimal to the results label
        /// </summary>
        private void addDecimalToResultLabel()
        {
            if (!decimalExists)
            {
                outputString += ".";
                decimalExists = true;
            }
        }

        private void finalizeOutput()
        {
            //if (decimalExists)
            //{
                
            //    if (outputString.Length>3)
            //    {
            //        int charactersToRemove = outputString.IndexOf('.') + 2;
            //        outputString = outputString.Remove(charactersToRemove);
            //    }


            //}

            outputValue = float.Parse(outputString);

            //rounds up the height to 1 decimal place
            outputValue = (float)(Math.Round(outputValue, 1));

            if (outputValue < 0.1f)
            {
                outputValue = 0.1f;
            }
            ActiveLabel.Text = outputValue.ToString();
            clearNumericKeyboard();
            NumberButtonTableLayoutPannel.Visible = false;
            ActiveLabel.BackColor = Color.White;
            ActiveLabel = null;
        }

        private void removeLastCharacterFromResultLabel()
        {
            var lastChar = outputString.Substring(outputString.Length - 1);
            if (lastChar == ".")
            {
                decimalExists = false;
            }
            outputString = outputString.Remove(outputString.Length - 1);
            if (outputString.Length == 0)
            {
                outputString = "0";
            }
            ResultLabel.Text = outputString;
        }

        /// <summary>
        /// This method resets the numeric keyboard and related variables
        /// </summary>
        private void clearNumericKeyboard()
        {
            ResultLabel.Text = "0";
            outputString = "0";
            outputValue = 0.0f;
            decimalExists = false;
        }
        
        /// <summary>
        /// This is the event handler 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActiveLable_Click(object sender, EventArgs e)
        {

            if (ActiveLabel != null)
            {
                clearNumericKeyboard();
            }


            ActiveLabel = sender as Label;
            ActiveLabel.BackColor = Color.LightBlue;

    NumberButtonTableLayoutPannel.Location.Y = new Point(12, ActiveLabel.Location.Y +55);
    NumberButtonTableLayoutPannel.BringToFront();

    if (ActiveLabel.Text!="0")
            {
                outputString = ActiveLabel.Text;
                ResultLabel.Text = ActiveLabel.Text;
            }

            NumberButtonTableLayoutPannel.Visible = true;
        }


    }
}
