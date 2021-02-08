
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
    public class _02_Selection : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // Selection
            try
            {
                List<Reference> listRef = uidoc.Selection.PickObjects(ObjectType.Element).ToList();
                
                int count = listRef.Count;
                string outputText = "";

                foreach (Reference rf in listRef)
                {
                    Element el = doc.GetElement(rf.ElementId);
                    string name = el.Name;
                    string Cate = el.Category.Name;

                    outputText += $"Name: {name}, Category: {Cate}.\n";
                }
                MessageBox.Show("Number of Elements: " + count + $"\n{outputText}");
               
                /*
                Reference reference = uidoc.Selection.PickObject(ObjectType.Element);
                if (reference != null)
                {
                    ElementId id = reference.ElementId;
                    Element element = doc.GetElement(id);


                    string nameCate = element.Category.Name;

                    string nameElement = element.Name;

                    MessageBox.Show($"Category of element: {nameCate}.\n"
                        + $"Name of element is: {nameElement}."
                        , "PCH Inform",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                */
            }
            catch(Exception ex)
            {
                MessageBox.Show("You have cancled! ");
            }


            //
            /*
            Reference rFace =  uidoc.Selection.PickObject(ObjectType.Face);
            Reference rEdge =  uidoc.Selection.PickObject(ObjectType.Edge);
            */
                
            



            return Result.Succeeded;
            
        }
    }
}
