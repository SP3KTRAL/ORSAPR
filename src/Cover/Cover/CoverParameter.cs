namespace Cover
{
    class CoverParameter
    {
        private double _coverDiameter;
        private double _diameterSmallSteppedHoleCover;
        private double _diameterLargeSteppedCoverHole;
        private double _smallHoleDiameter;
        private double _outerStepDiameter;
        private double _coverThickness;
        private double _coverStepHeight;
        private double _heightInnerStepCover;

        public double CoverDiameter
        {
            get
            {
                return _coverDiameter;
            }
            set
            {
                _coverDiameter = value;
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
            get
            {
                return _coverThickness;
            }
            set
            {
                _coverThickness = value;
            }
        }

        public double CoverStepHeight
        {
            get
            {
                return _coverStepHeight;
            }
            set
            {
                _coverStepHeight = value;
            }
        }

        public double HeightInnerStepCover
        {
            get
            {
                return _heightInnerStepCover;
            }
            set
            {
                _heightInnerStepCover = value;
            }
        }
    }
}
