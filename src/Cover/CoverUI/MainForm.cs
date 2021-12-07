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


        private void coverDiameterTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverDiameter_A_;
        }

        private void diameterSmallSteppedHoleCoverTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.DiameterSmallSteppedHoleCover_B_;
        }

        private void diameterLargeSteppedCoverHoleTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.DiameterLargeSteppedCoverHole_C_;
        }

        private void smallHoleDiameterTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.SmallHoleDiameter_D_;
        }

        private void outerStepDiameterTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.OuterStepDiameter_E_;
        }

        private void coverThicknessTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverThickness_F_;
        }

        private void coverThicknessTextBox_Leave(object sender, EventArgs e)
        {
            //ChangeParameter(sender);
            //if (coverThicknessTextBox.Text != string.Empty)
            //{
            //    try
            //    {
            //        if (!double.TryParse(coverThicknessTextBox.Text, out _))
            //        {
            //            throw new ArgumentException("This is a number only field");
            //        }
            //        _coverParameter.CoverThickness = Convert.ToDouble(coverThicknessTextBox.Text);
            //    }
            //    catch (ArgumentException exception)
            //    {
            //        MessageBox.Show(exception.Message, "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        coverThicknessTextBox.Focus();
            //        return;
            //    }

            //    double coverThickness = _coverParameter.CoverThickness;

            //    _coverParameter.MaxValueCoverStepHeight = Math.Round(coverThickness / 1.5, 1);
            //    minMaxCoverStepHeightLabel.Text = "(4 mm – " + _coverParameter.MaxValueCoverStepHeight + " mm)";

            //    _coverParameter.MaxValueHeightInnerStepCover = Math.Round(coverThickness / 1.2, 1);
            //    minMaxHeightInnerStepCoverLabel.Text =
            //        "(5 mm – " + _coverParameter.MaxValueHeightInnerStepCover + " mm)";
            //}
        }

        private void coverStepHeightTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverStepHeight_G_;
        }

        private void heightInnerStepCoverTextBox_Click(object sender, EventArgs e)
        {
            pictureBox.Image = Properties.Resources.HeightInnerStepCover_H_;
        }

        private void coverDiameterTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                //ChangeParameter(sender);
            }
            catch (Exception exception)
            {
                
            }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {

        }

        private void coverStepHeightTextBox_Leave(object sender, EventArgs e)
        {
            ChangeParameter(sender, _coverParameter.CoverStepHeight);
            //if (coverStepHeightTextBox.Text != string.Empty)
            //{
            //    try
            //    {
            //        if (!double.TryParse(coverStepHeightTextBox.Text, out _))
            //        {
            //            throw new ArgumentException("This is a number only field");
            //        }
            //        _coverParameter.CoverStepHeight = Convert.ToDouble(coverStepHeightTextBox.Text);
            //    }
            //    catch (ArgumentException exception)
            //    {
            //        MessageBox.Show(exception.Message, "Error",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        coverStepHeightTextBox.Focus();
            //    }
            //}
        }

        private void heightInnerStepCoverTextBox_Leave(object sender, EventArgs e)
        {
            ChangeParameter(sender, _coverParameter.HeightInnerStepCover);
            //if (heightInnerStepCoverTextBox.Text == string.Empty)
            //{
            //    return;
            //}

            //try
            //{
            //    if (!double.TryParse(heightInnerStepCoverTextBox.Text, out _))
            //    {
            //        throw new ArgumentException("This is a number only field");
            //    }
            //    _coverParameter.HeightInnerStepCover = Convert.ToDouble(heightInnerStepCoverTextBox.Text);
            //}
            //catch (ArgumentException exception)
            //{
            //    MessageBox.Show(exception.Message, "Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    heightInnerStepCoverTextBox.Focus();
            //}
        }

        private void ChangeParameter(object sender, double coverParameter)
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace('.', ',');
            if (((TextBox)sender).Text == string.Empty)
            {
                return;
            }

            try
            {
                if (!double.TryParse(((TextBox)sender).Text, out _))
                {
                    throw new ArgumentException("This is a number only field");
                }
                coverParameter = Convert.ToDouble(((TextBox)sender).Text);
            }
            catch (ArgumentException exception)
            {
                MessageBox.Show(exception.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ((TextBox)sender).Focus();
            }
        }
    }
}
