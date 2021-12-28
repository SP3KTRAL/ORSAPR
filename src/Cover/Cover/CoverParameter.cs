using System;

namespace Cover
{
    /// <summary>
    /// Класс параметра.
    /// </summary>
    public class CoverParameter
    {
        /// <summary>
        /// Минимальное значение диаметра крышки.
        /// </summary>
        public const double MIN_COVER_DIAMETER = 50;

        /// <summary>
        /// Максимальное значение диаметра крышки.
        /// </summary>
        public const double MAX_COVER_DIAMETER = 500;

        /// <summary>
        /// Минимальное значение диаметра малого ступенчатого отверстия.
        /// </summary>
        public const double MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER = 15;

        /// <summary>
        /// Минимальное значение диаметра большого ступенчатого отверстия.
        /// </summary>
        public const double MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE = 20;

        /// <summary>
        /// Минимальное значение диаметра малых отверстий.
        /// </summary>
        public const double MIN_SMALL_HOLE_DIAMETER = 2;

        /// <summary>
        /// Минимальное значение диаметра внешней ступени.
        /// </summary>
        public const double MIN_OUTER_STEP_DIAMETER = 35;

        /// <summary>
        /// Минимальное значение толщины крышки.
        /// </summary>
        public const double MIN_COVER_THICKNESS = 6;

        /// <summary>
        /// Максимальное значение толщины крышки.
        /// </summary>
        public const double MAX_COVER_THICKNESS = 60;

        /// <summary>
        /// Минимальное значение высоты ступени крышки.
        /// </summary>
        public const double MIN_COVER_STEP_HEIGHT = 4;

        /// <summary>
        /// Минимальное значение высоты внутренней ступени крышки.
        /// </summary>
        public const double MIN_HEIGHT_INNER_STEP_COVER = 5;

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
                if (value < MIN_COVER_DIAMETER || value > MAX_COVER_DIAMETER)
                {
                    throw new ArgumentException("Wrong cover diameter = " +
                                                $"{value} mm.\n" +
                                                $"Range: {MIN_COVER_DIAMETER} " +
                                                $"mm - {MAX_COVER_DIAMETER} mm!");
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
                if (value < MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER || 
                    value > MaxDiameterSmallSteppedHoleCover)
                {
                    throw new ArgumentException(
                        "Wrong diameter small stepped hole cover = " +
                        $"{value} mm.\nRange: {MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER} mm - " +
                        $"{MaxDiameterSmallSteppedHoleCover} mm!");
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
                if (value < MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE || 
                    value > MaxDiameterLargeSteppedCoverHole)
                {
                    throw new ArgumentException(
                        "Wrong diameter large stepped cover " +
                        $"hole = {value} mm.\nRange: " +
                        $"{MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE} mm - " +
                        $"{MaxDiameterLargeSteppedCoverHole} mm!");
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
                if (value < MIN_SMALL_HOLE_DIAMETER || 
                    value > MaxSmallHoleDiameter)
                {
                    throw new ArgumentException(
                        $"Wrong small hole diameter = {value} " +
                        $"mm.\nRange: {MIN_SMALL_HOLE_DIAMETER} mm - " +
                        $"{MaxSmallHoleDiameter} mm!");
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
            throw new ArgumentException("Value must be greater than zero");
        }

        /// <summary>
        /// Возвращает и задаёт диаметр внешней ступени.
        /// </summary>
        public double OuterStepDiameter
        {
            get => _outerStepDiameter;
            set
            {
                if (value < MIN_OUTER_STEP_DIAMETER 
                    || value > MaxOuterStepDiameter)
                {
                    throw new ArgumentException(
                        $"Wrong outer step diameter = {value} " +
                        $"mm.\nRange: {MIN_OUTER_STEP_DIAMETER} mm - " +
                        $"{MaxOuterStepDiameter} mm!");
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
                if (value < MIN_COVER_THICKNESS || value > MAX_COVER_THICKNESS)
                {
                    throw new ArgumentException(
                        $"Wrong cover thickness = {value} " +
                        $"mm.\nRange: {MIN_COVER_THICKNESS} mm - " +
                        $"{MAX_COVER_THICKNESS} mm!");
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
                if (value < MIN_COVER_STEP_HEIGHT || 
                    value > MaxCoverStepHeight)
                {
                    throw new ArgumentException(
                        $"Wrong cover step height = {value} mm." +
                        $"\nRange: {MIN_COVER_STEP_HEIGHT} mm - " +
                        $"{MaxCoverStepHeight} mm!");
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
                if (value < MIN_HEIGHT_INNER_STEP_COVER || 
                    value > MaxHeightInnerStepCover)
                {
                    throw new ArgumentException(
                        $"Wrong height inner step cover = {value} " +
                        $"mm.\nRange: {MIN_HEIGHT_INNER_STEP_COVER} mm - " +
                        $"{MaxHeightInnerStepCover} mm!");
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
        /// Конструктор, задающий значения по умолчанию.
        /// </summary>
        public CoverParameter()
        {
            CoverDiameter = 270;
            OuterStepDiameter = 185;
            DiameterLargeSteppedCoverHole = 115;
            DiameterSmallSteppedHoleCover = 92;
            SmallHoleDiameter = 20;
            CoverThickness = 37;
            CoverStepHeight = 23;
            HeightInnerStepCover = 22;
        }
    }
}
