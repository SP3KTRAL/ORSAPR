using System;
using System.Runtime.InteropServices;
using Kompas6API5;
using Kompas6Constants3D;

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
                _document2D.ksMovePoint(ref points[i, 0], ref points[i, 1],
                    60 * i, diameter / 2);
            }
        }

        public KompasObject Kompas { get; }

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

        private bool CreateOpenKompas(out KompasObject kompasObject)
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
            _document3D.Create();
            _document2D = (ksDocument2D)Kompas.Document2D();
            _part = (ksPart)_document3D.GetPart((int)Part_Type.pTop_Part);
        }

        public KompasWrapper()
        {
            Kompas = OpenKompas();
            CreateDocument();
        }
    }
}
