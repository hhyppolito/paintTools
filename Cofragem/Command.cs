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
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //selecionar os elementos a pintar
            
            Selection selection = uidoc.Selection;
            ICollection<ElementId> selectedIds = selection.GetElementIds();
            FilteredElementCollector walls = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType();
            FilteredElementCollector floors = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsNotElementType();
            FilteredElementCollector beams = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType();
            FilteredElementCollector columns = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType();
            FilteredElementCollector genericmodels = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_GenericModel).WhereElementIsNotElementType();
            FilteredElementCollector foundations = new FilteredElementCollector(doc, selectedIds).OfCategory(BuiltInCategory.OST_StructuralFoundation).WhereElementIsNotElementType();


            Transaction curTrans = new Transaction(doc, "Cofragem");
            curTrans.Start();

            IList<double> areas = new List<double>();

            foreach (Element i in genericmodels)
            {
                GeometryElement geometryElement = i.get_Geometry(new Options());

                foreach (GeometryObject geoObject in geometryElement)
                {
                    GeometryInstance geomInst = geoObject as GeometryInstance;

                    if (null != geomInst)
                    {
                        GeometryElement transformedGeomElem = geomInst.GetInstanceGeometry(geomInst.Transform);

                        foreach (GeometryObject geotransObject in transformedGeomElem)
                        {
                            Solid solid2 = geotransObject as Solid;
                            foreach (Face face in solid2.Faces)
                            {
                                areas.Add(face.Area);
                            }
                        }

                    }
                }
            }

            JoinElement.Join(foundations,walls, columns, beams, floors, genericmodels, doc);

            curTrans.Commit();

            curTrans.Start();

            foreach (Element genericElement in genericmodels)
            {
                //GeometryElement geometryElement = columnElement.get_Geometry(new Options());
                Cofragem.GenericElements(genericElement, areas, app);
                doc.Delete(genericElement.Id);
            }

            curTrans.Commit();

            return Result.Succeeded;
        }
    }
}
