
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
    public class _03_GetParameter : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code here
            try
            {
                Reference refElement = uidoc.Selection.PickObject(ObjectType.Element);
                //Doi tuong trong project
                Element el = doc.GetElement(refElement.ElementId);

                //Parameter 
                Parameter Mark = el.LookupParameter("Mark");
                string mark = Mark.AsString();

                ElementId typeId = el.GetTypeId();
                //Family Type of doi tuong do'.
                Element elementType = doc.GetElement(typeId);
                Parameter TypeMark = elementType.LookupParameter("Type Mark");
                string markType = TypeMark.AsString();

                MessageBox.Show($"Mark: {mark}, MarkType: {markType}");
                

            }catch(Exception ex)
            {

            }

            return Result.Succeeded;
        }
    }
}
