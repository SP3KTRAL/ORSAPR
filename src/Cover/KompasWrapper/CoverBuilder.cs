using Cover;

namespace KompasWrapper
{
     /// <summary>
     /// Класс для постройки модели.
     /// </summary>
    public class CoverBuilder
    {
        /// <summary>
        /// Ссылка на Компас.
        /// </summary>
        private KompasWrapper _kompasWrapper;

        /// <summary>
        /// Метод для построения модели.
        /// </summary>
        /// <param name="parameters">Параметры модели.</param>
        public void CreateModel(CoverParameter parameters)
        {
            _kompasWrapper = new KompasWrapper();

            _kompasWrapper.CreateCircle(parameters.CoverDiameter);
            _kompasWrapper.ExtrudeCircle(parameters.CoverThickness - 
                                         parameters.CoverStepHeight);

            _kompasWrapper.CreateCircle(parameters.OuterStepDiameter);
            _kompasWrapper.ExtrudeCircle(parameters.CoverThickness);

            _kompasWrapper.CreateCircle(parameters.DiameterLargeSteppedCoverHole);
            _kompasWrapper.CutExtrudeCircle(parameters.HeightInnerStepCover);

            _kompasWrapper.CreateCircle(parameters.DiameterSmallSteppedHoleCover);
            _kompasWrapper.CutExtrudeCircle(parameters.CoverThickness);

            double[,] points = {{0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}};

            _kompasWrapper.PositionSmallHole(ref points, parameters.SmallHoleCircleDiameter);

            for (int i = 0; i < 6; i++)
            {
                _kompasWrapper.CreateCircle(parameters.SmallHoleDiameter,
                    points[i,0], points[i,1]);
                _kompasWrapper.CutExtrudeCircle(parameters.CoverThickness);
            }
        }
    }
}
