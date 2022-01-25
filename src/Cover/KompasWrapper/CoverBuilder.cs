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

            for (int i = 0; i < parameters.CountSmallHole; i++)
            {
                double[] point = { 0, 0 };

                _kompasWrapper.PositionSmallHole(
                    ref point, parameters.SmallHoleCircleDiameter, 
                    i, parameters.CountSmallHole);

                _kompasWrapper.CreateCircle(parameters.SmallHoleDiameter,
                    point[0], point[1]);

                _kompasWrapper.CutExtrudeCircle(parameters.CoverThickness);
            }
        }
    }
}
