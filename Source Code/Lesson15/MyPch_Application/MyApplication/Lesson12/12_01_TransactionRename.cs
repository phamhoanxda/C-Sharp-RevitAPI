
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
    public class _12_01_Transaction : IExternalCommand
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
                Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
                Element element = doc.GetElement(reference.ElementId);

                Element el = doc.GetElement(element.GetTypeId());


                //Khong dung Transaction
                //string oldName = el.Name;
                //string newName = oldName + "_Modified_2601";
                //el.Name = newName;


                
                Transaction tran = new Transaction(doc);
                tran.Start("Change element name");
                string oldName = el.Name;
                string newName = oldName + "_Modified_2601";
                el.Name = newName;
                tran.Commit();
                //tran.RollBack();
                MessageBox.Show("Rename done!");
                
            }
            catch (Exception ex)
            {
                
            }
            return Result.Succeeded;
        }
    }
}
