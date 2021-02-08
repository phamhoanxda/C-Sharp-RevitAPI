
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
    public class _11_04_FilteredSelectionCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Thống kê số lượng walls
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<ElementId> listWall = collector.OfClass(typeof(Wall)).ToElementIds().ToList();

            MessageBox.Show("Number of walls is: " + listWall.Count);

            // Thống kê số lượng roofs
            FilteredElementCollector collector2 = new FilteredElementCollector(doc);
            List<ElementId> listRoofs = collector2.OfCategory(BuiltInCategory.OST_Roofs).ToElementIds().ToList();

            MessageBox.Show("Number of roofs is: " + listRoofs.Count);

            // Thống kê số lượng roofs cach 2
            FilteredElementCollector collector3 = new FilteredElementCollector(doc);
            List<ElementId> listRoofs2 = collector.WherePasses(new ElementCategoryFilter(BuiltInCategory.OST_Roofs)).ToElementIds().ToList();

            return Result.Succeeded;
        }
    }
}
