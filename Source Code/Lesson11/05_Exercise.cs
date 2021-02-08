
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
    public class Exercise : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code here
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> listtuong = collector.OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType().ToElements().ToList();
            double sum = 0;
            foreach (Element el in listtuong) 
            {
                Parameter Area = el.LookupParameter("Area");        
                double area = Area.AsDouble();
                sum += area;
                              
            }
            MessageBox.Show($"Total area of all wall in this project is {sum * 0.092903}");        
            return Result.Succeeded;
        }
    }
}
