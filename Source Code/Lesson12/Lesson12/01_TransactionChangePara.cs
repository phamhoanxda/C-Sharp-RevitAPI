
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
    public class _01_Transaction : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code here
            Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
            Element element = doc.GetElement(reference.ElementId);

            //Parameter 
            Parameter paraMark = element.LookupParameter("Mark");
            string value = paraMark.AsString();

            Transaction tran = new Transaction(doc);
            tran.Start("Change para");

            string newMark = "PCH_NEWMARK";
            paraMark.Set(newMark);

            tran.Commit();
            
            MessageBox.Show("Mark before is: " + value + "\n Mark after is: " + newMark );

            return Result.Succeeded;
        }
    }
}
