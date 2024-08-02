#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;

#endregion

namespace Cofragem
{
    public class Cofragem
    {


        public static void FrameWall(Element wall, Application app, string material)
        {
            Document doc = wall.Document;
            Wall newWall = wall as Wall;
            GeometryElement geometryElement = newWall.get_Geometry(new Options());

            foreach (GeometryObject geoObject in geometryElement)
            {
                if (geoObject is Solid)
                {
                    Solid solid = geoObject as Solid;
                    foreach (Face face in solid.Faces)
                    {
                        if (face.ComputeNormal(new UV(0.5, 0.5)).Z == 0)
                        {
                            PaintFace.paintFace(wall, face, doc, material);
                        }
                    }
                }
            }


        }
        // paint floor
        public static void FrameFloor(Element floor, Application app, string material)
        {
            Document doc = floor.Document;
            //GeometryElement geometryElement = floor.get_Geometry(new Options());
            Floor newFloor = floor as Floor;
            //IList<Reference> infFace = HostObjectUtils.GetBottomFaces(newFloor);
            GeometryElement geometryElement = newFloor.get_Geometry(new Options());

            foreach (GeometryObject geoObject in geometryElement)
            {
                if (geoObject is Solid)
                {
                    Solid solid = geoObject as Solid;
                    foreach (Face face in solid.Faces)
                    {
                        if (face.ComputeNormal(new UV(0.5, 0.5)).Z != 1)
                        {
                            PaintFace.paintFace(floor, face, doc, material);
                        }
                    }
                }
            }

        }
        //paint beams
        public static void FrameBeam(Element beam, Application app, string material)
        {
            Document doc = beam.Document;
            GeometryElement geometryElement = beam.get_Geometry(new Options());

            foreach (GeometryObject geoObject in geometryElement)
            {
                if (geoObject is Solid)
                {
                    Solid solid = geoObject as Solid;
                    List<double> facesAreas = new List<double>();
                    foreach (Face face in solid.Faces)
                    {
                        if ((face.ComputeNormal(new UV(0.5, 0.5)).Z == 0))
                        {
                            facesAreas.Add(face.Area);
                        }
                    }
                    facesAreas.Sort();
                    if (facesAreas.Count > 0)
                    {
                        double largestFaceArea = facesAreas[facesAreas.Count - 1];
                        XYZ normalVector = null;
                        //double vectorAngle = null;
                        foreach (Face face in solid.Faces)
                        {
                            if (face.Area == largestFaceArea)
                            {
                                normalVector = face.ComputeNormal(new UV(0.5, 0.5));
                            }
                        }

                        foreach (Face face in solid.Faces)
                        {
                            if ((normalVector.AngleTo(face.ComputeNormal(new UV(0.5, 0.5))) == 0 | normalVector.AngleTo(face.ComputeNormal(new UV(0.5, 0.5))) == Math.PI) & face.Area >= largestFaceArea * 0.2 | face.ComputeNormal(new UV(0.5, 0.5)).Z < 0)
                            {
                                PaintFace.paintFace(beam, face, doc, material);
                            }
                        }
                    }
                }
            }
        }


        //Paint Columns
        public static void FrameColumn(Element columns, Application app, string material)
        {
            Document doc = columns.Document;
            GeometryElement geometryElement = columns.get_Geometry(new Options());

            foreach (GeometryObject geoObject in geometryElement)
            {
                if (geoObject is Solid)
                {
                    Solid solid = geoObject as Solid;
                    foreach (Face face in solid.Faces)
                    {
                        if (face.ComputeNormal(new UV(0.5, 0.5)).Z == 0)
                        {
                            PaintFace.paintFace(columns, face, doc, material);
                        }
                    }
                }
            }
        }
        public static void FrameFoundation(Element foundation, Application app, string material)
        {
            Document doc = foundation.Document;
            GeometryElement geometryElement = foundation.get_Geometry(new Options());

            foreach (GeometryObject geoObject in geometryElement)
            {
                if (geoObject is Solid)
                {
                    Solid solid = geoObject as Solid;
                    foreach (Face face in solid.Faces)
                    {
                        if (face.ComputeNormal(new UV(0.5, 0.5)).Z == 0)
                        {
                            PaintFace.paintFace(foundation, face, doc, material);
                        }
                    }
                }
            }
        }
    }
}

