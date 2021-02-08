
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
    public class _04_FilteredSelection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code here
            //VD01:
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> listElements = collector.OfClass(typeof(Wall)).ToElements().ToList();
            //List<Element> listElements = collector.OfClass(typeof(Roofs)).ToElements().ToList();

            //VD02:
            FilteredElementCollector collector2 = new FilteredElementCollector(doc);
            List<Element> listRoof = collector2.OfCategory(BuiltInCategory.OST_Roofs).ToElements().ToList();
           
            //VD03:


            int count = listElements.Count;
            MessageBox.Show("Numner of wall is: " + count);
            return Result.Succeeded;


        }
    }
}
