
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
    public class _04_Creation : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code here 600 x 600 x 900mm
            try
            {
                //Safe
                // Pick point 
                XYZ point = uidoc.Selection.PickPoint("Please! Pick one point");
                if (point != null)
                {
                    //Get family by name: 600 x 600 x 900mm
                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    List<Element> listFoundation = 
                        collector.OfCategory(BuiltInCategory.OST_StructuralFoundation)
                        .WhereElementIsElementType()
                        .ToElements().ToList();

                    FamilySymbol family = null;

                    foreach(Element item in listFoundation)
                    {
                        if(item.Name == "600 x 600 x 900mm")
                        {
                            family = item as FamilySymbol;
                            break;
                        }
                    }

                    if(family != null)
                    {
                        //Place element
                        FilteredElementCollector collectorLevel = new FilteredElementCollector(doc);
                        Element element =  collectorLevel.OfClass(typeof(Level)).First();

                        Level level1 = element as Level;
                        Transaction tran = new Transaction(doc);
                        tran.Start("Place foundation");
                        doc.Create.NewFamilyInstance(point, family, level1,
                            Autodesk.Revit.DB.Structure.StructuralType.Footing);
                        tran.Commit();
                    }
                    else
                    {
                        MessageBox.Show("There is no family in project");
                    }

                   

                }
            }
            catch (Exception ex)
            {
            }


            return Result.Succeeded;
        }
    }
}
