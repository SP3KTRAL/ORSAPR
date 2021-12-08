using System;
using System.Windows.Forms;


namespace Cover
{
    public class CoverParameter
    {
        private double _coverDiameter;

        private double _diameterSmallSteppedHoleCover;
        private double _maxDiameterSmallSteppedHoleCover = 330;

        private double _diameterLargeSteppedCoverHole;
        private double _maxDiameterLargeSteppedCoverHole = 335;

        private double _smallHoleDiameter;
        private double _maxSmallHoleDiameter = 40;

        private double _outerStepDiameter;
        private double _maxOuterStepDiameter = 350;

        private double _coverThickness;

        private double _coverStepHeight;
        private double _maxCoverStepHeight = 40;

        private double _heightInnerStepCover;
        private double _maxHeightInnerStepCover = 50;

        public double CoverDiameter
        {
            get => _coverDiameter;
            set
            {
                if (value < 50 || value > 500)
                {
                    throw new ArgumentException("Wrong cover diameter = " + 
                                                value + " " + "mm. Range: 50 mm - 500 mm!");
                }

                _coverDiameter = value;

                SmallHoleCircleDiameter = value - 5 - SmallHoleDiameter;

                MaxSmallHoleDiameter = Math.Round(value / 12.5, 1);
                MaxOuterStepDiameter = Math.Round(value / (500.0 / 350.0), 1);

                if (OuterStepDiameter == 0 || OuterStepDiameter > MaxOuterStepDiameter)
                {
                    MaxDiameterLargeSteppedCoverHole = MaxOuterStepDiameter - 15;
                }
                else
                {
                    MaxDiameterLargeSteppedCoverHole = OuterStepDiameter - 15;
                }

                if (DiameterLargeSteppedCoverHole == 0 || DiameterLargeSteppedCoverHole > MaxDiameterLargeSteppedCoverHole)
                {
                    MaxDiameterSmallSteppedHoleCover = MaxDiameterLargeSteppedCoverHole - 5;
                }
                else
                {
                    MaxDiameterSmallSteppedHoleCover = DiameterLargeSteppedCoverHole - 5;
                }
            }
        }

        public double DiameterSmallSteppedHoleCover
        {
            get => _diameterSmallSteppedHoleCover;
            set
            {
                if (value < 15 || value > MaxDiameterSmallSteppedHoleCover)
                {
                    throw new ArgumentException(
                        "Wrong diameter small stepped hole cover = " + value +
                        " " + "mm. Range: 15 mm - " + MaxDiameterSmallSteppedHoleCover + " mm!");
                }

                _diameterSmallSteppedHoleCover = value;
            }
        }

        public double MaxDiameterSmallSteppedHoleCover
        {
            get => _maxDiameterSmallSteppedHoleCover;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxDiameterSmallSteppedHoleCover = value;
            }
        }

        public double DiameterLargeSteppedCoverHole
        {
            get => _diameterLargeSteppedCoverHole;
            set
            {
                if (value < 20 || value > MaxDiameterLargeSteppedCoverHole)
                {
                    throw new ArgumentException(
                        "Wrong diameter large stepped cover hole = " + value +
                        " " + "mm. Range: 20 mm - " + MaxDiameterLargeSteppedCoverHole + " mm!");
                }

                _diameterLargeSteppedCoverHole = value;

                MaxDiameterSmallSteppedHoleCover = value - 5;
            }
        }

        public double MaxDiameterLargeSteppedCoverHole
        {
            get => _maxDiameterLargeSteppedCoverHole;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxDiameterLargeSteppedCoverHole = value;
            }
        }
        
        public double SmallHoleDiameter
        {
            get => _smallHoleDiameter;
            set
            {
                if (value < 2 || value > MaxSmallHoleDiameter)
                {
                    throw new ArgumentException(
                        "Wrong small hole diameter = " + value +
                        " " + "mm. Range: 2 mm - " + MaxSmallHoleDiameter + " mm!");
                }

                _smallHoleDiameter = value;
                SmallHoleCircleDiameter = value - 5 - CoverDiameter;
            }
        }

        public double MaxSmallHoleDiameter
        {
            get => _maxSmallHoleDiameter;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxSmallHoleDiameter = value;
            }
        }

        public double SmallHoleCircleDiameter { get; set; }

        private static void ArgumentException()
        {
            throw new ArgumentException($"Value must be greater than zero");
        }

        public double OuterStepDiameter
        {
            get => _outerStepDiameter;
            set
            {
                if (value < 35 || value > MaxOuterStepDiameter)
                {
                    throw new ArgumentException(
                        "Wrong outer step diameter = " + value +
                        " " + "mm. Range: 35 mm - " + MaxOuterStepDiameter + " mm!");
                }

                _outerStepDiameter = value;

                MaxDiameterLargeSteppedCoverHole = value - 15;

                if (DiameterLargeSteppedCoverHole == 0 || 
                    DiameterLargeSteppedCoverHole > MaxDiameterLargeSteppedCoverHole)
                {
                    MaxDiameterSmallSteppedHoleCover = MaxDiameterLargeSteppedCoverHole - 5;
                }
                else
                {
                    MaxDiameterSmallSteppedHoleCover = DiameterLargeSteppedCoverHole - 5;
                }
            }
        }

        public double MaxOuterStepDiameter
        {
            get => _maxOuterStepDiameter;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxOuterStepDiameter = value;
            }
        }

        public double CoverThickness
        {
            get => _coverThickness;
            set
            {
                if (value < 6  || value > 60)
                {
                    throw new ArgumentException("Wrong cover thickness = " + 
                                                value + " mm. Range: 6 mm - 60 mm!");
                }

                _coverThickness = value;

                MaxCoverStepHeight = Math.Round(value / 1.5, 1);
                MaxHeightInnerStepCover = Math.Round(value / 1.2, 1);
            }
        }

        public double CoverStepHeight
        {
            get => _coverStepHeight;
            set
            {
                if (value < 4 || value > MaxCoverStepHeight)
                {
                    throw new ArgumentException("Wrong cover step height = " + 
                                                value + " mm. Range: 6 mm - " + MaxCoverStepHeight + " mm!");
                }

                _coverStepHeight = value;
            }
        }

        public double MaxCoverStepHeight
        {
            get => _maxCoverStepHeight;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxCoverStepHeight = value;
            }
        }

        public double HeightInnerStepCover
        {
            get => _heightInnerStepCover;
            set
            {
                if (value < 5 || value > MaxHeightInnerStepCover)
                {
                    throw new ArgumentException(
                        "Wrong height inner step cover = " + value + 
                        " mm. Range: 5 mm - " + MaxHeightInnerStepCover + " mm!");
                }

                _heightInnerStepCover = value;
            }
        }

        public double MaxHeightInnerStepCover
        {
            get => _maxHeightInnerStepCover;
            set
            {
                if (value < 0)
                {
                    ArgumentException();
                }

                _maxHeightInnerStepCover = value;
            }
        }
    }
}
