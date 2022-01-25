using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

namespace KompasWrapper
{
    /// <summary>
    /// Класс для связи с Компасом.
    /// </summary>
    public class KompasWrapper
    {
        /// <summary>
        /// Поле 3D документа.
        /// </summary>
        private ksDocument3D _document3D;

        /// <summary>
        /// Поле 2D документа.
        /// </summary>
        private ksDocument2D _document2D;

        /// <summary>
        /// Интерфейс детали.
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Поле с текущим эскизом.
        /// </summary>
        private ksEntity _sketch;

        /// <summary>
        /// Интерфейс свойств эскиза.
        /// </summary>
        private ksSketchDefinition _sketchDefinition;

        /// <summary>
        /// Поле текущего плана.
        /// </summary>
        private ksEntity _currentPlan;

        /// <summary>
        /// Расставляет расположение малого отверстия по его индексу.
        /// </summary>
        /// <param name="point">Координаты центра малого отверстия.</param>
        /// <param name="diameter">Диаметр малого отверстия.</param>
        /// <param name="smallHoleNumber">Индекс малого отверстия.</param>
        /// <param name="count">Общее количество малых отверстий.</param>
        public void PositionSmallHole(ref double[] point, 
            double diameter, int smallHoleNumber, int count)
        {
            _document2D.ksMovePoint(ref point[0], ref point[1],
                360 / count * smallHoleNumber, diameter / 2);
        }

        /// <summary>
        /// Главный инерфейс.
        /// </summary>
        public KompasObject Kompas { get; }

        /// <summary>
        /// Вырезание по окружности выдавливанием.
        /// </summary>
        /// <param name="depth">Глубина выдавливания.</param>
        public void CutExtrudeCircle(double depth)
        {
            var entityExtrude = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);

            var entityExtrudeDefinition = 
                (ksCutExtrusionDefinition)entityExtrude.GetDefinition();

            ksExtrusionParam extrudeParameters = 
                (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();

            extrudeParameters.direction = (short) Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            extrudeParameters.depthNormal = -depth;
            entityExtrude.Create();
        }

        /// <summary>
        /// Выдавливание по окружности.
        /// </summary>
        /// <param name="depth">Глубина выдавливания.</param>
        public void ExtrudeCircle(double depth)
        {
            var entityExtrude = 
                (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            var entityExtrudeDefinition = 
                (ksBossExtrusionDefinition)entityExtrude.GetDefinition();

            ksExtrusionParam extrudeParameters = 
                (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();

            extrudeParameters.direction = (short)Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            extrudeParameters.depthNormal = depth;

            entityExtrude.Create();
        }

        /// <summary>
        /// Построение окружности.
        /// </summary>
        /// <param name="diameter">Диаметр окуружности.</param>
        /// <param name="xc">Координата центра окружности по x.</param>
        /// <param name="yc">Координата центра окружности по y.</param>
        public void CreateCircle(double diameter, double xc = 0, double yc = 0)
        {
            _currentPlan = (ksEntity)_part.GetDefaultEntity(1);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            _document2D.ksCircle(xc, yc, diameter / 2, 1);

            _sketchDefinition.EndEdit();
        }

        /// <summary>
        /// Открытие Компас.
        /// </summary>
        /// <returns>Указатель на Компас.</returns>
        private KompasObject OpenKompas()
        {
            if (!IsOpenKompass(out var kompas))
            {
                CreateOpenKompas(out kompas);
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            return kompas;
        }

        /// <summary>
        /// Получение открытого Компаса.
        /// </summary>
        /// <param name="kompasObject">Объект Компаса.</param>
        /// <returns>Открыт или закрыт Компас.</returns>
        private bool IsOpenKompass(out KompasObject kompasObject)
        {
            try
            {
                kompasObject = (KompasObject)Marshal.
                    GetActiveObject("KOMPAS.Application.5");

                return true;
            }
            catch (COMException)
            {
                kompasObject = null;
                return false;
            }
        }

        /// <summary>
        /// Открытие Компас.
        /// </summary>
        /// <param name="kompasObject">Объект Компас.</param>
        private void CreateOpenKompas(out KompasObject kompasObject)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompasObject = (KompasObject)Activator.CreateInstance(type);
            }
            catch (COMException)
            {
                throw new COMException("Failed to open Kompas");
            }
        }

        /// <summary>
        /// Создание локумента.
        /// </summary>
        private void CreateDocument()
        {
            _document3D = (ksDocument3D)Kompas.Document3D();
            _document3D.Create();
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public KompasWrapper()
        {
            Kompas = OpenKompas();
            CreateDocument();
        }
    }
}
