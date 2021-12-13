using System;
using System.Drawing;
using System.Windows.Forms;
using Cover;
using ArgumentException = System.ArgumentException;

namespace CoverUI
{
     //TODO: XML
    public partial class MainForm : Form
    {
        readonly CoverParameter _coverParameter;

        public MainForm()
        {
            InitializeComponent();
            _coverParameter = new CoverParameter();
        }

        private void BuildButtonClick(object sender, EventArgs e)
        {
            Control thisTextBox = null;
            try
            {
                foreach (Control textBox in Controls)
                {
                    if (textBox is TextBox)
                    {
                        thisTextBox = textBox;
                        ChangeParameter(textBox);
                    }
                }
            }
            catch (Exception exception)
            {
                ShowMessage(thisTextBox, exception.Message);
                return;
            }

            buildButton.Text = "Building...";
            buildButton.Enabled = false;

            CoverBuilder coverBuilder = new CoverBuilder();

            coverBuilder.CreateModel(_coverParameter);

            buildButton.Enabled = true;
            buildButton.Text = "Build";
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            pictureBox.Image = 
                (Image)Properties.Resources.ResourceManager.
                    GetObject(((TextBox)sender).Name);
        }

        private void TextBoxLeave(object sender, EventArgs e)
        {
            try
            {
                ChangeParameter(sender);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        private void ChangeParameter(object sender)
        {
            ((TextBox)sender).Text = 
                ((TextBox)sender).Text.Replace('.', ',');

            double value = Convert.ToDouble(((TextBox) sender).Text);
            
            switch (((TextBox)sender).Name)
            {
                case nameof(coverDiameterTextBox):
                    _coverParameter.CoverDiameter = value;

                    minMaxSmallHoleDiameterLabel.Text = 
                        //TODO:
                        $@"(2 mm – {_coverParameter.MaxSmallHoleDiameter} mm)";

                    minMaxOuterStepDiameterLabel.Text = 
                        "(35 mm – " + _coverParameter.MaxOuterStepDiameter + " mm)";

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        "(20 mm – " + 
                        _coverParameter.MaxDiameterLargeSteppedCoverHole + " mm)";

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        "(15 mm – " + 
                        _coverParameter.MaxDiameterSmallSteppedHoleCover + " mm)";
                    break;

                case nameof(diameterSmallSteppedHoleCoverTextBox):
                    _coverParameter.DiameterSmallSteppedHoleCover = value;
                    break;

                case nameof(diameterLargeSteppedCoverHoleTextBox):
                    _coverParameter.DiameterLargeSteppedCoverHole = value;

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text = 
                        "(15 mm – " + 
                        _coverParameter.MaxDiameterSmallSteppedHoleCover + " mm)";
                    break;

                case nameof(smallHoleDiameterTextBox):
                    _coverParameter.SmallHoleDiameter = value;
                    break;

                case nameof(outerStepDiameterTextBox):
                    _coverParameter.OuterStepDiameter = value;

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        "(20 mm – " + 
                        _coverParameter.MaxDiameterLargeSteppedCoverHole + " mm)";

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        "(15 mm – " + 
                        _coverParameter.MaxDiameterSmallSteppedHoleCover + " mm)";
                    break;

                case nameof(coverThicknessTextBox):
                    _coverParameter.CoverThickness = value;

                    minMaxCoverStepHeightLabel.Text = 
                        "(4 mm – " + _coverParameter.MaxCoverStepHeight + " mm)";

                    minMaxHeightInnerStepCoverLabel.Text =
                        "(5 mm – " + 
                        _coverParameter.MaxHeightInnerStepCover + " mm)";
                    break;

                case nameof(heightInnerStepCoverTextBox):
                    _coverParameter.HeightInnerStepCover = value;
                    break;

                case nameof(coverStepHeightTextBox):
                    _coverParameter.CoverStepHeight = value;
                    break;
                default: break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="message"></param>
        private static void ShowMessage(object sender, string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            ((TextBox) sender).Focus();
        }
    }
}
