
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
    public class _11_02_GetElementName : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            //Task 01  Get element name.
            Reference refernce = uidoc.Selection.PickObject(ObjectType.Element);
            if (refernce != null)
            {
                //Get Id
                ElementId id = refernce.ElementId;
                Element element = doc.GetElement(id);

                MessageBox.Show("Element ID:" + id);
                MessageBox.Show("Element Name:" + element.Name);

                MessageBox.Show($"Category: {element.Category.Name}");
            }
            return Result.Succeeded;
        }
    }
}
