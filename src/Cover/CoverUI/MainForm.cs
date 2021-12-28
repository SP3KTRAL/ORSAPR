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
        //TODO: RSDN
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
            minMaxSmallHoleDiameterLabel.Text =
                RenameTextLabel(2,
                    _coverParameter.MaxSmallHoleDiameter);

            minMaxOuterStepDiameterLabel.Text =
                RenameTextLabel(35,
                    _coverParameter.MaxOuterStepDiameter);

            minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                RenameTextLabel(20,
                    _coverParameter.MaxDiameterLargeSteppedCoverHole);

            minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                RenameTextLabel(15,
                    _coverParameter.MaxDiameterSmallSteppedHoleCover);

            minMaxCoverStepHeightLabel.Text =
                RenameTextLabel(4,
                    _coverParameter.MaxCoverStepHeight);

            minMaxHeightInnerStepCoverLabel.Text =
                RenameTextLabel(5,
                    _coverParameter.MaxHeightInnerStepCover);
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
        /// Событие, при наведении фокуса на TextBox.
        /// </summary>
        /// <param name="sender">Ссылка на объект, который вызвал событие.</param>
        /// <param name="e">Передает объект, относящийся к обрабатываемому событию.</param>
        private void TextBoxEnter(object sender, EventArgs e)
        {
            pictureBox.Image = 
                (Image)Properties.Resources.ResourceManager.
                    GetObject(((TextBox)sender).Name);
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
                        RenameTextLabel(2, 
                            _coverParameter.MaxSmallHoleDiameter);

                    minMaxOuterStepDiameterLabel.Text =
                        RenameTextLabel(35, 
                            _coverParameter.MaxOuterStepDiameter);

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        RenameTextLabel(20, 
                            _coverParameter.MaxDiameterLargeSteppedCoverHole);

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(15, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);
                    break;

                case nameof(diameterSmallSteppedHoleCoverTextBox):
                    _coverParameter.DiameterSmallSteppedHoleCover = value;
                    break;

                case nameof(diameterLargeSteppedCoverHoleTextBox):
                    _coverParameter.DiameterLargeSteppedCoverHole = value;

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(15, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);
                    break;

                case nameof(smallHoleDiameterTextBox):
                    _coverParameter.SmallHoleDiameter = value;
                    break;

                case nameof(outerStepDiameterTextBox):
                    _coverParameter.OuterStepDiameter = value;

                    minMaxDiameterLargeSteppedCoverHoleLabel.Text =
                        RenameTextLabel(20, 
                            _coverParameter.MaxDiameterLargeSteppedCoverHole);

                    minMaxDiameterSmallSteppedHoleCoverLabel.Text =
                        RenameTextLabel(15, 
                            _coverParameter.MaxDiameterSmallSteppedHoleCover);
                    break;

                case nameof(coverThicknessTextBox):
                    _coverParameter.CoverThickness = value;

                    minMaxCoverStepHeightLabel.Text =
                        RenameTextLabel(4, 
                            _coverParameter.MaxCoverStepHeight);

                    minMaxHeightInnerStepCoverLabel.Text = 
                        RenameTextLabel(5, 
                            _coverParameter.MaxHeightInnerStepCover);
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
        /// Меняет текст для Label.
        /// </summary>
        /// <param name="min">Минимальное значение.</param>
        /// <param name="max">Максимальное значение.</param>
        /// <returns>Строка, с новыми значениями минимального и максимального.</returns>
        private string RenameTextLabel(int min, double max)
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
    }
}
