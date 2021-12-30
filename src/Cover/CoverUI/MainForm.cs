using System;
using System.Drawing;
using System.Windows.Forms;
using Cover;
using KompasWrapper;
using ArgumentException = System.ArgumentException;

namespace CoverUI
{
    /// <summary>
    /// Форма для задания параметров модели.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Поле параметров.
        /// </summary>
        private readonly CoverParameter _coverParameter;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _coverParameter = new CoverParameter();

            countSmallHoleComboBox.SelectedIndex = 4;

            minMaxSmallHoleDiameterLabel.Text =
                RenameTextLabel(CoverParameter.MIN_SMALL_HOLE_DIAMETER,
                    _coverParameter.MaxSmallHoleDiameter);

            minMaxOuterStepDiameterLabel.Text =
                RenameTextLabel(CoverParameter.MIN_OUTER_STEP_DIAMETER,
                    _coverParameter.MaxOuterStepDiameter);

            minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                RenameTextLabel(
                    CoverParameter.MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE,
                    _coverParameter.MaxDiameterLargeSteppedCoverHole);

            minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                RenameTextLabel(
                    CoverParameter.MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER,
                    _coverParameter.MaxDiameterSmallSteppedHoleCover);

            minMaxCoverStepHeightLabel.Text =
                RenameTextLabel(CoverParameter.MIN_COVER_STEP_HEIGHT,
                    _coverParameter.MaxCoverStepHeight);

            minMaxHeightInnerStepCoverLabel.Text =
                RenameTextLabel(CoverParameter.MIN_HEIGHT_INNER_STEP_COVER,
                    _coverParameter.MaxHeightInnerStepCover);

            labelMinMaxSmallHoleCircleDiameter.Text =
                RenameTextLabel(_coverParameter.MinSmallHoleCircleDiameter,
                    _coverParameter.MaxSmallHoleCircleDiameter);
        }

        /// <summary>
        /// Событие, при нажатии на кнопку "Build".
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
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
                ((TextBox)thisTextBox).BackColor = Color.MistyRose;
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

        /// <summary>
        /// Событие, при наведении фокуса на Control.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void ControlEnter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                pictureBox.Image =
                    (Image)Properties.Resources.ResourceManager.
                        GetObject(((TextBox)sender).Name);
            }
            else
            {
                pictureBox.Image = 
                    (Image)Properties.Resources.ResourceManager.
                        GetObject(((ComboBox)sender).Name);
            }
        }

        /// <summary>
        /// Событие, при потери фокуса с TextBox.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void TextBoxLeave(object sender, EventArgs e)
        {
            try
            {
                ChangeParameter(sender);
                ((TextBox)sender).BackColor = Color.White;
            }
            catch (FormatException exception)
            {
                ((TextBox)sender).BackColor = Color.MistyRose;
                ShowMessage(sender, exception.Message);
            }
            catch (ArgumentException exception)
            {
                ((TextBox)sender).BackColor = Color.MistyRose;
                ShowMessage(sender, exception.Message);
            }
        }

        /// <summary>
        /// Заносит значение из TextBox в поле параметров.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
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
                        RenameTextLabel(CoverParameter.MIN_SMALL_HOLE_DIAMETER, 
                            _coverParameter.MaxSmallHoleDiameter);

                    minMaxOuterStepDiameterLabel.Text =
                        RenameTextLabel(CoverParameter.MIN_OUTER_STEP_DIAMETER, 
                            _coverParameter.MaxOuterStepDiameter);

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        RenameTextLabel(
                            CoverParameter.MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE, 
                            _coverParameter.MaxDiameterLargeSteppedCoverHole);

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(
                            CoverParameter.MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);

                    labelMinMaxSmallHoleCircleDiameter.Text =
                        RenameTextLabel(_coverParameter.MinSmallHoleCircleDiameter,
                            _coverParameter.MaxSmallHoleCircleDiameter);
                    break;

                case nameof(diameterSmallSteppedHoleCoverTextBox):
                    _coverParameter.DiameterSmallSteppedHoleCover = value;
                    break;

                case nameof(diameterLargeSteppedCoverHoleTextBox):
                    _coverParameter.DiameterLargeSteppedCoverHole = value;

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(
                            CoverParameter.MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);
                    break;

                case nameof(smallHoleDiameterTextBox):
                    _coverParameter.SmallHoleDiameter = value;

                    labelMinMaxSmallHoleCircleDiameter.Text =
                        RenameTextLabel(_coverParameter.MinSmallHoleCircleDiameter,
                            _coverParameter.MaxSmallHoleCircleDiameter);
                    break;

                case nameof(outerStepDiameterTextBox):
                    _coverParameter.OuterStepDiameter = value;

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        RenameTextLabel(
                            CoverParameter.MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE, 
                            _coverParameter.MaxDiameterLargeSteppedCoverHole);

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(
                            CoverParameter.MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);

                    labelMinMaxSmallHoleCircleDiameter.Text =
                        RenameTextLabel(_coverParameter.MinSmallHoleCircleDiameter,
                            _coverParameter.MaxSmallHoleCircleDiameter);
                    break;

                case nameof(coverThicknessTextBox):
                    _coverParameter.CoverThickness = value;

                    minMaxCoverStepHeightLabel.Text =
                        RenameTextLabel(CoverParameter.MIN_COVER_STEP_HEIGHT, 
                            _coverParameter.MaxCoverStepHeight);

                    minMaxHeightInnerStepCoverLabel.Text = 
                        RenameTextLabel(
                            CoverParameter.MIN_HEIGHT_INNER_STEP_COVER, 
                            _coverParameter.MaxHeightInnerStepCover);
                    break;

                case nameof(heightInnerStepCoverTextBox):
                    _coverParameter.HeightInnerStepCover = value;
                    break;

                case nameof(coverStepHeightTextBox):
                    _coverParameter.CoverStepHeight = value;
                    break;

                case nameof(smallHoleCircleDiameterTextBox):
                    _coverParameter.SmallHoleCircleDiameter = value;
                    break;
                default: break;
            }
        }

        /// <summary>
        /// Меняет текст для Label.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Строка, с новыми значениями минимального и максимального.</returns>
        private string RenameTextLabel(double min, double max)
        {
            return $@"({min} mm – {max} mm)";
        }

        /// <summary>
        /// Выводит сообщение об ошибке.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="message">Сообщение ошибки.</param>
        private static void ShowMessage(object sender, string message)
        {
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            ((TextBox) sender).Focus();
        }

        /// <summary>
        /// Событие, при потери фокуса с ComboBox.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void CountSmallHoleComboBoxLeave(object sender, EventArgs e)
        {
            _coverParameter.CountSmallHole = 
                Convert.ToInt32(((ComboBox)sender).SelectedItem);
        }
    }
}
