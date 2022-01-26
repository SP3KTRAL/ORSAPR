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
        /// Отступ для диаметра окружности малых отверстий.
        /// </summary>
        private const double RETRACT_SMALL_HOLE_CIRCLE_DIAMETER = 4;

        /// <summary>
        /// Отступ для диаметра большого ступенчатого отверстия крышки.
        /// </summary>
        private const double RETRACT_DIAMETER_LARGE_STEPPED_COVER_HOLE = 15;

        /// <summary>
        /// Отступ для диаметра малого ступенчатого отверстия крышки.
        /// </summary>
        private const double RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER = 5;

        /// <summary>
        /// Диаметр крышки.
        /// </summary>
        private double _coverDiameter;

        /// <summary>
        /// Диаметр малого ступенчатого отверстия.
        /// </summary>
        private double _diameterSmallSteppedHoleCover;

        /// <summary>
        /// Максимальное значение диаметра
        /// малого ступенчатого отверстия.
        /// </summary>
        private double _maxDiameterSmallSteppedHoleCover;

        /// <summary>
        /// Диаметр большого ступенчатого отверстия.
        /// </summary>
        private double _diameterLargeSteppedCoverHole;

        /// <summary>
        /// Максимальное значение диаметра
        /// большого ступенчатого отверстия.
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
        /// Максимальное значение высоты
        /// внутренней ступени крышки.
        /// </summary>
        private double _maxHeightInnerStepCover;

        /// <summary>
        /// Диаметр круга малых ступенчатых отверстий.
        /// </summary>
        private double _smallHoleCircleDiameter;

        /// <summary>
        /// Минимальный диаметр круга
        /// малых ступенчатых отверстий.
        /// </summary>
        private double _minSmallHoleCircleDiameter;

        /// <summary>
        /// Максимальный диаметр круга
        /// малых ступенчатых отверстий.
        /// </summary>
        private double _maxSmallHoleCircleDiameter;

        /// <summary>
        /// Возвращает и задаёт диаметр крышки.
        /// </summary>
        public double CoverDiameter
        {
            get => _coverDiameter;
            set
            {
                if (value >= MIN_COVER_DIAMETER && 
                    value <= MAX_COVER_DIAMETER)
                {
                    _coverDiameter = value;

                    //TODO: to const
                    MaxSmallHoleCircleDiameter = 
                        value - RETRACT_SMALL_HOLE_CIRCLE_DIAMETER - 
                        SmallHoleDiameter;

                    MinSmallHoleCircleDiameter = 
                        OuterStepDiameter + 
                        RETRACT_SMALL_HOLE_CIRCLE_DIAMETER + 
                        SmallHoleDiameter;

                    MaxSmallHoleDiameter = Math.Round(value / 25, 1);
                    MaxOuterStepDiameter = 
                        Math.Round(value / (500.0 / 350.0), 1);

                    //TODO: to const
                    if (OuterStepDiameter == 0 ||
                        OuterStepDiameter > MaxOuterStepDiameter)
                    {
                        MaxDiameterLargeSteppedCoverHole = 
                            MaxOuterStepDiameter - 
                            RETRACT_DIAMETER_LARGE_STEPPED_COVER_HOLE;
                    }
                    else
                    {
                        MaxDiameterLargeSteppedCoverHole = 
                            OuterStepDiameter - 
                            RETRACT_DIAMETER_LARGE_STEPPED_COVER_HOLE;
                    }

                    //TODO: to const
                    if (DiameterLargeSteppedCoverHole == 0 ||
                        DiameterLargeSteppedCoverHole > 
                        MaxDiameterLargeSteppedCoverHole)
                    {
                        MaxDiameterSmallSteppedHoleCover =
                            MaxDiameterLargeSteppedCoverHole - 
                            RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER;
                    }
                    else
                    {
                        MaxDiameterSmallSteppedHoleCover =
                            DiameterLargeSteppedCoverHole - 
                            RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER;
                    }

                    return;
                }

                string parameterName = "Cover Diameter";

                ExceptionCallText(parameterName, value,
                    MIN_COVER_DIAMETER, MAX_COVER_DIAMETER);
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
                if (value >= MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER &&
                    value <= MaxDiameterSmallSteppedHoleCover)
                {
                    _diameterSmallSteppedHoleCover = value;
                    return;
                }

                string parameterName = "Diameter Small Stepped Hole Cover";

                ExceptionCallText(parameterName, value,
                    MIN_DIAMETER_SMALL_STEPPED_HOLE_COVER,
                    MaxDiameterSmallSteppedHoleCover);
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный
        /// диаметр малого ступенчатого отверстия.
        /// </summary>
        public double MaxDiameterSmallSteppedHoleCover
        {
            get => _maxDiameterSmallSteppedHoleCover;
            set
            {
                if (value > 0)
                {
                    _maxDiameterSmallSteppedHoleCover = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр
        /// большого ступенчатого отверстия.
        /// </summary>
        public double DiameterLargeSteppedCoverHole
        {
            get => _diameterLargeSteppedCoverHole;
            set
            {
                if (value >= MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE &&
                    value <= MaxDiameterLargeSteppedCoverHole)
                {
                    //TODO: to const
                    _diameterLargeSteppedCoverHole = value;
                    MaxDiameterSmallSteppedHoleCover = 
                        value - RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER;
                    return;
                }

                string parameterName = "Diameter Large Stepped Cover Hole";

                ExceptionCallText(parameterName, value,
                    MIN_DIAMETER_LARGE_STEPPED_COVER_HOLE,
                    MaxDiameterLargeSteppedCoverHole);
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр
        /// большого ступенчатого отверстия.
        /// </summary>
        public double MaxDiameterLargeSteppedCoverHole
        {
            get => _maxDiameterLargeSteppedCoverHole;
            set
            {
                if (value > 0)
                {
                    _maxDiameterLargeSteppedCoverHole = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
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
                if (value >= MIN_SMALL_HOLE_DIAMETER &&
                    value <= MaxSmallHoleDiameter)
                {
                    _smallHoleDiameter = value;

                    //TODO: to const
                    MaxSmallHoleCircleDiameter = 
                        CoverDiameter - 
                        RETRACT_SMALL_HOLE_CIRCLE_DIAMETER - value;

                    MinSmallHoleCircleDiameter = 
                        OuterStepDiameter + 
                        RETRACT_SMALL_HOLE_CIRCLE_DIAMETER + value;

                    return;
                }

                string parameterName = "Small Hole Diameter";

                ExceptionCallText(parameterName, value,
                    MIN_SMALL_HOLE_DIAMETER, MaxSmallHoleDiameter);
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
                if (value > 0)
                {
                    _maxSmallHoleDiameter = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
            }
        }
        
        /// <summary>
        /// Создаёт сообщение об ошибке, если значение меньше нуля.
        /// </summary>
        private static void ThrowArgumentExceptionLessZero()
        {
            throw new ArgumentException(
                "Value must be greater than zero");
        }

        /// <summary>
        /// Возвращает и задаёт диаметр внешней ступени.
        /// </summary>
        public double OuterStepDiameter
        {
            get => _outerStepDiameter;
            set
            {
                if (value >= MIN_OUTER_STEP_DIAMETER &&
                    value <= MaxOuterStepDiameter)
                {
                    _outerStepDiameter = value;

                    //TODO: to const
                    MinSmallHoleCircleDiameter = 
                        value + 
                        RETRACT_SMALL_HOLE_CIRCLE_DIAMETER + SmallHoleDiameter;

                    MaxDiameterLargeSteppedCoverHole = 
                        value - RETRACT_DIAMETER_LARGE_STEPPED_COVER_HOLE;

                    if (DiameterLargeSteppedCoverHole == 0 ||
                        DiameterLargeSteppedCoverHole > 
                        MaxDiameterLargeSteppedCoverHole)
                    {
                        MaxDiameterSmallSteppedHoleCover =
                            MaxDiameterLargeSteppedCoverHole - 
                            RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER;
                    }
                    else
                    {
                        MaxDiameterSmallSteppedHoleCover =
                            DiameterLargeSteppedCoverHole - 
                            RETRACT_DIAMETER_SMALL_STEPPED_HOLE_COVER;
                    }

                    return;
                }

                string parameterName = "Outer Step Diameter";

                ExceptionCallText(parameterName, value,
                    MIN_OUTER_STEP_DIAMETER, MaxOuterStepDiameter);
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальный
        /// диаметр внешней ступени.
        /// </summary>
        public double MaxOuterStepDiameter
        {
            get => _maxOuterStepDiameter;
            set
            {
                if (value > 0)
                {
                    _maxOuterStepDiameter = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
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
                if (value >= MIN_COVER_THICKNESS &&
                    value <= MAX_COVER_THICKNESS)
                {
                    _coverThickness = value;

                    MaxCoverStepHeight = Math.Round(value / 1.5, 1);
                    MaxHeightInnerStepCover = Math.Round(value / 1.2, 1);

                    return;
                }

                string parameterName = "Cover Thickness";

                ExceptionCallText(parameterName, value,
                    MIN_COVER_THICKNESS, MAX_COVER_THICKNESS);
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
                if (value >= MIN_COVER_STEP_HEIGHT &&
                    value <= MaxCoverStepHeight)
                {
                    _coverStepHeight = value;
                    return;
                }

                string parameterName = "Cover Step Height";

                ExceptionCallText(parameterName, value,
                    MIN_COVER_STEP_HEIGHT, MaxCoverStepHeight);
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
                if (value > 0)
                {
                    _maxCoverStepHeight = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
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
                if (value >= MIN_HEIGHT_INNER_STEP_COVER &&
                    value <= MaxHeightInnerStepCover)
                {
                    _heightInnerStepCover = value;
                    return;
                }

                string parameterName = "Height Inner Step Cover";

                ExceptionCallText(parameterName, value,
                    MIN_HEIGHT_INNER_STEP_COVER, MaxHeightInnerStepCover);
            }
        }

        /// <summary>
        /// Возвращает и задаёт максимальную
        /// высоту внутренней ступени крышки.
        /// </summary>
        public double MaxHeightInnerStepCover
        {
            get => _maxHeightInnerStepCover;
            set
            {
                if (value > 0)
                {
                    _maxHeightInnerStepCover = value;
                    return;
                }

                ThrowArgumentExceptionLessZero();
            }
        }

        /// <summary>
        /// Возвращает и задаёт диаметр
        /// круга малых ступенчатых отверстий.
        /// </summary>
        public double SmallHoleCircleDiameter
        {
            get => _smallHoleCircleDiameter;
            set
            {
                if (value >= MinSmallHoleCircleDiameter &&
                    value <= MaxSmallHoleCircleDiameter)
                {
                    _smallHoleCircleDiameter = value;
                    return;
                }

                string parameterName = "Small Hole Circle Diameter";

                ExceptionCallText(parameterName, value,
                    MinSmallHoleCircleDiameter, MaxSmallHoleCircleDiameter);
            }
        }

        /// <summary>
        /// Возвращает и задаёт минимальный диаметр
        /// круга малых ступенчатых отверстий.
        /// </summary>
        public double MinSmallHoleCircleDiameter
        {
            get => _minSmallHoleCircleDiameter;
            set => _minSmallHoleCircleDiameter = value;
        }

        /// <summary>
        /// Возвращает и задаёт максимальный диаметр
        /// круга малых ступенчатых отверстий.
        /// </summary>
        public double MaxSmallHoleCircleDiameter
        {
            get => _maxSmallHoleCircleDiameter;
            set => _maxSmallHoleCircleDiameter = value;
        }

        /// <summary>
        /// Возвращает и задаёт kоличество малых отверстий.
        /// </summary>
        public int CountSmallHole { get; set; }

        /// <summary>
        /// Конструктор, задающий значения по умолчанию.
        /// </summary>
        public CoverParameter()
        {
            CoverDiameter = 270;
            OuterStepDiameter = 185;
            SmallHoleDiameter = 10;
            DiameterLargeSteppedCoverHole = 115;
            DiameterSmallSteppedHoleCover = 92;
            CoverThickness = 37;
            CoverStepHeight = 23;
            HeightInnerStepCover = 22;
            SmallHoleCircleDiameter = 227.5;
            CountSmallHole = 6;
        }

        /// <summary>
        /// Присваевает текст сообщению ошибки.
        /// </summary>
        /// <param name="parameterName">Название параметра.</param>
        /// <param name="value">Значение параметра.</param>
        /// <param name="minValue">Минимальное значение параметра.</param>
        /// <param name="maxValue">Максимальное значение параметра.</param>
        private void ExceptionCallText(string parameterName, 
            double value, double minValue, double maxValue)
        {
            throw new ArgumentException(
                $"Wrong {parameterName} = {value} mm.\n" +
                $"Range: {minValue} mm - {maxValue} mm!");
        }
    }
}
