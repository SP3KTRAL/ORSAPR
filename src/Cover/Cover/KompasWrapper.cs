using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;
using KompasAPI7;

namespace Cover
{
    public class KompasWrapper
    {
        private ksDocument3D _document3D;
        private ksDocument2D _document2D;
        private ksPart _part;
        private ksEntity _sketch;
        private ksSketchDefinition _sketchDefinition;
        private ksEntity _currentPlan;

        public void Small(ref double[,] points, double diameter)
        {
            for (int i = 0; i < 6; i++)
            {
                _document2D.ksMovePoint(ref points[i, 0], ref points[i, 1], 60 * i, diameter / 2);
            }
        }

        public KompasObject Kompas { get; }

        public void CutExtrudeCircle(double depth)
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksCutExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short) Direction_Type.dtNormal;

            entityExtrudeDefinition.SetSketch(_sketch);
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = -depth;
            entityExtrude.Create();
        }

        public void ExtrudeCircle(double depth, bool thin = true, double wallThikness = 0)
        {
            var entityExtrude = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
            // интерфейс базовой операции выдавливания
            var entityExtrudeDefinition = (ksBossExtrusionDefinition)entityExtrude.GetDefinition();
            // интерфейс структуры параметров выдавливания
            ksExtrusionParam extrudeParameters = (ksExtrusionParam)entityExtrudeDefinition.ExtrusionParam();
            extrudeParameters.direction = (short)Direction_Type.dtNormal;
            // интерфейс структуры параметров тонкой стенки
            ksThinParam thinParam = (ksThinParam)entityExtrudeDefinition.ThinParam();

            entityExtrudeDefinition.SetSketch(_sketch);
            // тип выдавливания (строго на глубину)
            extrudeParameters.typeNormal = (short)End_Type.etBlind;
            // глубина выдавливания
            extrudeParameters.depthNormal = depth;
            // тонкая стенка в два направления
            //thinParam.thin = thin;
            //Толщина стенки в обратном направлении
            //thinParam.reverseThickness = wallThikness;

            //Направление формирования тонкой стенки
            //thinParam.thinType = (short)Direction_Type.dtReverse;

            entityExtrude.Create();
        }

        public void CreateCircle(double diameter, double xc = 0, double yc = 0)
        {
            _currentPlan = (ksEntity)_part.GetDefaultEntity((short)1);
            _sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
            _sketchDefinition = (ksSketchDefinition)_sketch.GetDefinition();
            _sketchDefinition.SetPlane(_currentPlan);
            _sketch.Create();
            _document2D = (ksDocument2D)_sketchDefinition.BeginEdit();

            _document2D.ksCircle(xc, yc, diameter / 2, 1);

            _sketchDefinition.EndEdit();
        }

        private KompasObject OpenKompas()
        {
            if (!GetActiveKompass(out var kompas))
            {
                CreateActiveKompas(out kompas);
            }

            kompas.Visible = true;
            kompas.ActivateControllerAPI();
            return kompas;
        }

        private bool GetActiveKompass(out KompasObject kompasObject)
        {
            try
            {
                kompasObject = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
                return true;
            }
            catch (COMException)
            {
                kompasObject = null;
                return false;
            }
        }

        private bool CreateActiveKompas(out KompasObject kompasObject)
        {
            try
            {
                Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                kompasObject = (KompasObject)Activator.CreateInstance(type);
                return true;
            }
            catch (COMException)
            {
                throw new COMException("Failed to open Kompas");
            }
        }

        private void CreateDocument()
        {
            _document3D = (ksDocument3D)Kompas.Document3D();
            _document3D.Create(false, true);
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part); // новый компонент
        }

        public KompasWrapper()
        {
            Kompas = OpenKompas();
            CreateDocument();
        }
    }
}
