using System;
using System.Windows.Forms;


namespace Cover
{
    public class CoverParameter
    {
        private double _coverDiameter;
        private double _diameterSmallSteppedHoleCover;
        private double _diameterLargeSteppedCoverHole;
        private double _smallHoleDiameter;
        private double _outerStepDiameter;
        private double _coverThickness;
        private double _coverStepHeight;
        private double _heightInnerStepCover;
        private double _maxValueCoverStepHeight = 40;
        private double _maxValueHeightInnerStepCover = 50;

        public double CoverDiameter
        {
            get => _coverDiameter;
            set
            {
                if (value > 50 && value < 500)
                {
                    _coverDiameter = value;
                }
                else
                {
                    throw new ArgumentException("Wrong cover diameter = " + 
                                                value + " " + "mm. Range: 50 mm - 500 mm!");
                }
            }
        }

        public double DiameterSmallSteppedHoleCover
        {
            get
            {
                return _diameterSmallSteppedHoleCover;
            }
            set
            {
                _diameterSmallSteppedHoleCover = value;
            }
        }

        public double DiameterLargeSteppedCoverHole
        {
            get
            {
                return _diameterLargeSteppedCoverHole;
            }
            set
            {
                _diameterLargeSteppedCoverHole = value;
            }
        }

        public double SmallHoleDiameter
        {
            get
            {
                return _smallHoleDiameter;
            }
            set
            {
                _smallHoleDiameter = value;
            }
        }

        public double OuterStepDiameter
        {
            get
            {
                return _outerStepDiameter;
            }
            set
            {
                _outerStepDiameter = value;
            }
        }

        public double CoverThickness
        {
            get => _coverThickness;
            set
            {
                if (value >= 6  && value <= 60)
                {
                    _coverThickness = value;
                }
                else
                {
                    throw new ArgumentException("Wrong cover thickness = " + 
                                                value + " mm. Range: 6 mm - 60 mm!");
                }

                MaxValueCoverStepHeight = Math.Round(CoverThickness / 1.5, 1);
                MaxValueHeightInnerStepCover = Math.Round(CoverThickness / 1.2, 1);
            }
        }

        public double CoverStepHeight
        {
            get => _coverStepHeight;
            set
            {
                if (value >= 4 && value <= MaxValueCoverStepHeight)
                {
                    _coverStepHeight = value;
                }
                else
                {
                    throw new ArgumentException("Wrong cover step height = " + 
                                                value + " mm. Range: 6 mm - " + MaxValueCoverStepHeight + " mm!");
                }
            }
        }

        public double MaxValueCoverStepHeight
        {
            get => _maxValueCoverStepHeight;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Value must be greater than zero");
                }

                _maxValueCoverStepHeight = value;
            }
        }

        public double MaxValueHeightInnerStepCover
        {
            get => _maxValueHeightInnerStepCover;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Value must be greater than zero");
                }

                _maxValueHeightInnerStepCover = value;
            }
        }

        public double HeightInnerStepCover
        {
            get => _heightInnerStepCover;
            set
            {
                if (value < 5 || value > MaxValueHeightInnerStepCover)
                {
                    throw new ArgumentException(
                        "Wrong height inner step cover = " + value + 
                        " mm. Range: 5 mm - " + MaxValueHeightInnerStepCover + " mm!");
                }

                _heightInnerStepCover = value;
            }
        }
    }
}
