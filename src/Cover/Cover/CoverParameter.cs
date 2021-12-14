using System;

namespace Cover
{
    /// <summary>
    /// Класс параметра.
    /// </summary>
    public class CoverParameter
    {
        /// <summary>
        /// Диаметр крышки.
        /// </summary>
        private double _coverDiameter;

        /// <summary>
        /// Диаметр малого ступенчатого отверстия.
        /// </summary>
        private double _diameterSmallSteppedHoleCover;

        /// <summary>
        /// Максимальное значение диаметра малого ступенчатого отверстия.
        /// </summary>
        private double _maxDiameterSmallSteppedHoleCover;

        /// <summary>
        /// Диаметр большого ступенчатого отверстия.
        /// </summary>
        private double _diameterLargeSteppedCoverHole;

        /// <summary>
        /// Максимальное значение диаметра большого ступенчатого отверстия.
        /// </summary>
        private double _maxDiameterLargeSteppedCoverHole;

        /// <summary>
        /// Диаметр малых отверстий.
        /// </summary>
        private double _smallHoleDiameter;

        /// <summary>
        /// Максимальное значение диаметра малых отверстий.
        /// </summary>
        private double _maxSmallHoleDiameter;

        /// <summary>
        /// Диаметр внешней ступени.
        /// </summary>
        private double _outerStepDiameter;

        /// <summary>
        /// Максимальное значение диаметра внешней ступени.
        /// </summary>
        private double _maxOuterStepDiameter;

        /// <summary>
        /// Толщина крышки.
        /// </summary>
        private double _coverThickness;

        /// <summary>
        /// Высота ступени крышки.
        /// </summary>
        private double _coverStepHeight;

        /// <summary>
        /// Максимальное значение высоты ступени крышки.
        /// </summary>
        private double _maxCoverStepHeight;

        /// <summary>
        /// Высота внутренней ступени крышки.
        /// </summary>
        private double _heightInnerStepCover;

        /// <summary>
        /// Максимальное значение высоты внутренней ступени крышки.
        /// </summary>
        private double _maxHeightInnerStepCover;

        /// <summary>
        /// Возвращает и задаёт диаметр крышки.
        /// </summary>
        public double CoverDiameter
        {
            get => _coverDiameter;
            set
            {
                if (value < 50 || value > 500)
                {
                    throw new ArgumentException("Wrong cover diameter = " 
                                                + value + " " + "mm. Range: 50 " 
                                                + "mm - 500 mm!");
                }

                _coverDiameter = value;

                SmallHoleCircleDiameter = (value + OuterStepDiameter) / 2;

                MaxSmallHoleDiameter = Math.Round(value / 12.5, 1);
                MaxOuterStepDiameter = Math.Round(value / (500.0 / 350.0), 1);

                if (OuterStepDiameter == 0 || 
                    OuterStepDiameter > MaxOuterStepDiameter)
                {
                    MaxDiameterLargeSteppedCoverHole = MaxOuterStepDiameter - 15;
                }
                else
                {
                    MaxDiameterLargeSteppedCoverHole = OuterStepDiameter - 15;
                }

                if (DiameterLargeSteppedCoverHole == 0 || 
                    DiameterLargeSteppedCoverHole > MaxDiameterLargeSteppedCoverHole)
                {
                    MaxDiameterSmallSteppedHoleCover = 
                        MaxDiameterLargeSteppedCoverHole - 5;
                }
                else
                {
                    MaxDiameterSmallSteppedHoleCover = 
                        DiameterLargeSteppedCoverHole - 5;
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр малого ступенчатого отверстия.
        /// </summary>
        public double DiameterSmallSteppedHoleCover
        {
            get => _diameterSmallSteppedHoleCover;
            set
            {
                if (value < 15 || value > MaxDiameterSmallSteppedHoleCover)
                {
                    throw new ArgumentException(
                        "Wrong diameter small stepped hole cover = " 
                        + value + " " + "mm. Range: 15 mm - " +
                        MaxDiameterSmallSteppedHoleCover + " mm!");
                }

                _diameterSmallSteppedHoleCover = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр малого ступенчатого отверстия.
        /// </summary>
        public double MaxDiameterSmallSteppedHoleCover
        {
            get => _maxDiameterSmallSteppedHoleCover;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxDiameterSmallSteppedHoleCover = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр большого ступенчатого отверстия.
        /// </summary>
        public double DiameterLargeSteppedCoverHole
        {
            get => _diameterLargeSteppedCoverHole;
            set
            {
                if (value < 20 || value > MaxDiameterLargeSteppedCoverHole)
                {
                    throw new ArgumentException(
                        "Wrong diameter large stepped cover hole = " +
                        value + " " + "mm. Range: 20 mm - " + 
                        MaxDiameterLargeSteppedCoverHole + " mm!");
                }

                _diameterLargeSteppedCoverHole = value;

                MaxDiameterSmallSteppedHoleCover = value - 5;
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр большого ступенчатого отверстия.
        /// </summary>
        public double MaxDiameterLargeSteppedCoverHole
        {
            get => _maxDiameterLargeSteppedCoverHole;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxDiameterLargeSteppedCoverHole = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр малых отверстий.
        /// </summary>
        public double SmallHoleDiameter
        {
            get => _smallHoleDiameter;
            set
            {
                if (value < 2 || value > MaxSmallHoleDiameter)
                {
                    throw new ArgumentException(
                        "Wrong small hole diameter = " + value + " " +
                        "mm. Range: 2 mm - " + MaxSmallHoleDiameter + " mm!");
                }

                _smallHoleDiameter = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр малых отверстий.
        /// </summary>
        public double MaxSmallHoleDiameter
        {
            get => _maxSmallHoleDiameter;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxSmallHoleDiameter = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр окружности, на которой лежат малые отверстия.
        /// </summary>
        public double SmallHoleCircleDiameter { get; set; }
        
        /// <summary>
        /// Создаёт сообщение об ошибке, если значение меньше нуля.
        /// </summary>
        private static void ThrowArgumentExceptionLessZero()
        {
            throw new ArgumentException($"Value must be greater than zero");
        }

        /// <summary>
        /// Возвращает и задаёт диаметр внешней ступени.
        /// </summary>
        public double OuterStepDiameter
        {
            get => _outerStepDiameter;
            set
            {
                if (value < 35 || value > MaxOuterStepDiameter)
                {
                    throw new ArgumentException(
                        "Wrong outer step diameter = " + value + " " +
                        "mm. Range: 35 mm - " + MaxOuterStepDiameter + " mm!");
                }

                _outerStepDiameter = value;

                SmallHoleCircleDiameter = (CoverDiameter + value) / 2;

                MaxDiameterLargeSteppedCoverHole = value - 15;

                if (DiameterLargeSteppedCoverHole == 0 || 
                    DiameterLargeSteppedCoverHole > MaxDiameterLargeSteppedCoverHole)
                {
                    MaxDiameterSmallSteppedHoleCover = 
                        MaxDiameterLargeSteppedCoverHole - 5;
                }
                else
                {
                    MaxDiameterSmallSteppedHoleCover = 
                        DiameterLargeSteppedCoverHole - 5;
                }
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр внешней ступени.
        /// </summary>
        public double MaxOuterStepDiameter
        {
            get => _maxOuterStepDiameter;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxOuterStepDiameter = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт толщину крышки.
        /// </summary>
        public double CoverThickness
        {
            get => _coverThickness;
            set
            {
                if (value < 6  || value > 60)
                {
                    throw new ArgumentException("Wrong cover thickness = "
                                                + value + " mm. Range: 6 mm - 60" 
                                                + " mm!");
                }

                _coverThickness = value;

                MaxCoverStepHeight = Math.Round(value / 1.5, 1);
                MaxHeightInnerStepCover = Math.Round(value / 1.2, 1);
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту ступени крышки.
        /// </summary>
        public double CoverStepHeight
        {
            get => _coverStepHeight;
            set
            {
                if (value < 4 || value > MaxCoverStepHeight)
                {
                    throw new ArgumentException("Wrong cover step " +
                                                "height = " + value + " mm. " +
                                                "Range: 6 mm - " + 
                                                MaxCoverStepHeight + " mm!");
                }

                _coverStepHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальную высоту ступени крышки.
        /// </summary>
        public double MaxCoverStepHeight
        {
            get => _maxCoverStepHeight;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxCoverStepHeight = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт высоту внутренней ступени крышки.
        /// </summary>
        public double HeightInnerStepCover
        {
            get => _heightInnerStepCover;
            set
            {
                if (value < 5 || value > MaxHeightInnerStepCover)
                {
                    throw new ArgumentException("Wrong height inner " +
                                                "step cover = " + value + 
                                                " mm. Range: 5 mm - " + 
                                                MaxHeightInnerStepCover + " mm!");
                }

                _heightInnerStepCover = value;
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальную высоту внутренней ступени крышки.
        /// </summary>
        public double MaxHeightInnerStepCover
        {
            get => _maxHeightInnerStepCover;
            set
            {
                if (value < 0)
                {
                    ThrowArgumentExceptionLessZero();
                }

                _maxHeightInnerStepCover = value;
            }
        }

        /// <summary>
        /// Конструктор, задающий максимальные значения по умолчанию.
        /// </summary>
        public CoverParameter()
        {
            MaxDiameterSmallSteppedHoleCover = 330;
            MaxDiameterLargeSteppedCoverHole = 335;
            MaxSmallHoleDiameter = 40;
            MaxOuterStepDiameter = 350;
            MaxCoverStepHeight = 40;
            MaxHeightInnerStepCover = 50;
        }
    }
}
