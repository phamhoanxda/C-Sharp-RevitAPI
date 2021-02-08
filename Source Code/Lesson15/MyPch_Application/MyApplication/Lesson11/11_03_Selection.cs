
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
    public class _11_03_Selection : IExternalCommand
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
                /*
                #region PickObject
                Reference rfElement = uidoc.Selection.PickObject(ObjectType.Element);
                Reference rfFace = uidoc.Selection.PickObject(ObjectType.Face);
                Reference rfEdge = uidoc.Selection.PickObject(ObjectType.Edge);


                List<Reference> rfElements = uidoc.Selection.PickObjects(ObjectType.Element).ToList();
                List<Reference> rfFaces = uidoc.Selection.PickObjects(ObjectType.Face).ToList();
                List<Reference> rfEdges = uidoc.Selection.PickObjects(ObjectType.Edge).ToList();

                #endregion
                */
                //Pick object and get number of element.


                // Task 01: Get paramterValue
                Reference elementRef = uidoc.Selection.PickObject(ObjectType.Element);
                if (elementRef != null)
                {
                    Element element = doc.GetElement(elementRef.ElementId);
                    Parameter paraMark = element.LookupParameter("Mark");

                    MessageBox.Show(paraMark.AsString());



                    /*
                    Element elementType = doc.GetElement(element.GetTypeId());
                    Parameter typeMark = elementType.LookupParameter("Type Mark");

                    MessageBox.Show(typeMark.AsString());
                    */


                }


                //Task 02: Select multi Faces - Cal area.
                
                List<Reference> referenceFaces = uidoc.Selection.PickObjects(ObjectType.Face).ToList();
                double total = 0;
                foreach(var rFace in referenceFaces)
                {
                    Element element = doc.GetElement(rFace.ElementId);
                    GeometryObject geo = element.GetGeometryObjectFromReference(rFace);
                    PlanarFace face = geo as PlanarFace;
                    total += face.Area;
                }
                MessageBox.Show("Total area is:" + total);
                
               

            }
            catch(Exception ex)
            {
            }
           
            return Result.Succeeded;
        }
    }
}
