
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
    public class _12_05_Exercise : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Delete all walls in projects
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<ElementId> listWalls = collector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElementIds().ToList();

            Transaction tran = new Transaction(doc);
            tran.Start("Delete all walss");
            doc.Delete(listWalls);
            tran.Commit();


            //Mark all beams in project by specific name: 
            // "MaDuAn_D_Length" vd: 05TC_D_5000

            FilteredElementCollector collectorBeams = new FilteredElementCollector(doc);
            List<Element> listBeams = collectorBeams.OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType().ToElements().ToList();
            Transaction tr = new Transaction(doc);
            tr.Start("Mark all beams");

            foreach (var item in listBeams)
            {
                //Get value
                Parameter paraLength = item.LookupParameter("Length");
                double valueLength = paraLength.AsDouble() * 304.8;
                double length = Math.Round(valueLength, 0);

                //Set mark
                Parameter paraMark = item.LookupParameter("Mark");
                string mark = "05TC_D_" + length;
                paraMark.Set(mark);
            }
            tr.Commit();

            MessageBox.Show("Done!");
            return Result.Succeeded;
        }
    }
}
