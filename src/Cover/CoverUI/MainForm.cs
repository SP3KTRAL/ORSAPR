using System;
using System.Drawing;
using System.Windows.Forms;
using Cover;
using ArgumentException = System.ArgumentException;

namespace CoverUI
{
    public partial class MainForm : Form
    {

        CoverParameter _coverParameter;

        public MainForm()
        {
            InitializeComponent();
            _coverParameter = new CoverParameter();
        }

        private void coverThicknessTextBox_Leave(object sender, EventArgs e)
        {
            ChangeParameter(sender, nameof(_coverParameter.CoverThickness));
        }

        private void buildButton_Click(object sender, EventArgs e)
        {

        }

        private void coverStepHeightTextBox_Leave(object sender, EventArgs e)
        {
            ChangeParameter(sender, nameof(_coverParameter.CoverStepHeight));
        }

        private void heightInnerStepCoverTextBox_Leave(object sender, EventArgs e)
        {
            ChangeParameter(sender, nameof(_coverParameter.HeightInnerStepCover));
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(((TextBox)sender).Name);
        }

        private void ChangeParameter(object sender, string parameterName)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
            if (((TextBox)sender).Text == string.Empty)
            {
                return;
            }

            try
            {
                double value = Convert.ToDouble(((TextBox) sender).Text);
                
                switch (parameterName)
                {
                    case nameof(_coverParameter.CoverThickness):
                        _coverParameter.CoverThickness = value;

                        minMaxCoverStepHeightLabel.Text = 
                            "(4 mm – " + _coverParameter.MaxValueCoverStepHeight + " mm)";

                        minMaxHeightInnerStepCoverLabel.Text =
                            "(5 mm – " + _coverParameter.MaxValueHeightInnerStepCover + " mm)";
                        break;
                    case nameof(_coverParameter.HeightInnerStepCover):
                        _coverParameter.HeightInnerStepCover = value;
                        break;
                    case nameof(_coverParameter.CoverStepHeight):
                        _coverParameter.CoverStepHeight = value;
                        break;
                    default: break;
                }

            }
            catch (FormatException exception)
            {
                ShowMessage(sender, exception.Message);
            }
            catch (ArgumentException exception)
            {
                ShowMessage(sender, exception.Message);
            }
        }

        private static void ShowMessage(object sender, string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            ((TextBox) sender).Focus();
        }
    }
}
