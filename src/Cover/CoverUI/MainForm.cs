using System.Drawing;
using System.Windows.Forms;
using Cover;

namespace CoverUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private void coverDiameterTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverDiameter_A_;
        }

        private void diameterSmallSteppedHoleCoverTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.DiameterSmallSteppedHoleCover_B_;
        }

        private void diameterLargeSteppedCoverHoleTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.DiameterLargeSteppedCoverHole_C_;
        }

        private void smallHoleDiameterTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.SmallHoleDiameter_D_;
        }

        private void outerStepDiameterTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.OuterStepDiameter_E_;
        }

        private void coverThicknessTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverThickness_F_;
        }

        private void coverStepHeightTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.CoverStepHeight_G_;
        }

        private void heightInnerStepCoverTextBox_Click(object sender, System.EventArgs e)
        {
            pictureBox.Image = Properties.Resources.HeightInnerStepCover_H_;
        }

        private void coverDiameterTextBox_Leave(object sender, System.EventArgs e)
        {
            
        }

        private void buildButton_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Invalid value cover diameter!");
        }
    }
}
