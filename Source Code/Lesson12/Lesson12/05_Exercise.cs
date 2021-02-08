
#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Forms;
using Microsoft.Win32;
using Application = Autodesk.Revit.ApplicationServices.Application;
#endregion

namespace Pch
{
    [Transaction(TransactionMode.Manual)]
    public class _05_Exercise : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Delete all walls
            FilteredElementCollector collection = new FilteredElementCollector(doc);
            List<ElementId> listElements = collection.OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .ToElementIds().ToList();

            Transaction tran = new Transaction(doc);
            tran.Start("Delete all walls");
            doc.Delete(listElements);
            tran.Commit();

            //Mark all beams in project "05TC_D_Length"
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> list = collector.OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType()
                .ToElements().ToList();

            Transaction tr = new Transaction(doc);
            tr.Start("Change parameters");
            foreach(var beam in list)
            {
                Parameter paraLength = beam.LookupParameter("Length");
                double length = Math.Round(paraLength.AsDouble() * 304.8,0);
                string paraName = "05TC_D_" + length.ToString();

                Parameter paraMark = beam.LookupParameter("Mark");
                paraMark.Set(paraName);
            }
            tr.Commit();

            return Result.Succeeded;
        }
    }
}
