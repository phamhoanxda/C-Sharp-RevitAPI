
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
    public class _12_04_CreationFoundation : IExternalCommand
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
            List<Element> listFoundations = collector.WhereElementIsElementType().OfCategory(BuiltInCategory.OST_StructuralFoundation).ToElements().ToList();

            Element elFamily = null; 
            foreach (var element in listFoundations)
            {
                if (element.Name == "600 x 600 x 900mm")
                {
                    elFamily = element;
                    break;
                }
            }

            FamilySymbol familySymbol = elFamily as FamilySymbol;

            FilteredElementCollector collection = new FilteredElementCollector(doc);
            Level level1 = collection.OfClass(typeof(Level)).First() as Level;

            Transaction tran = new Transaction(doc);
            tran.Start("Create foundation element");
            XYZ point = uidoc.Selection.PickPoint("Please pick one point");

            doc.Create.NewFamilyInstance(point, familySymbol, level1, Autodesk.Revit.DB.Structure.StructuralType.Footing);
            tran.Commit();

            MessageBox.Show("Create foundation done!");
            return Result.Succeeded;
        }
    }
}
