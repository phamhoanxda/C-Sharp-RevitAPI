
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
    public class _11_05_Exercise: IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Total Area of wall in project
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> listwall =  collector.OfClass(typeof(Wall)).ToElements().ToList();
            double total = 0;
            foreach(Element el in listwall)
            {
                Wall wall = el as Wall;
                if(wall != null)
                {
                    total += wall.LookupParameter("Area").AsDouble();
                }
            }
            MessageBox.Show("Total area of walls is: " + total);
            return Result.Succeeded;
        }
    }
}
