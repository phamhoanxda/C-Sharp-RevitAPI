
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

/* Mục đích: 
 * Cách dùng: 
 */
namespace Pch
{
    [Transaction(TransactionMode.Manual)]
    public class _13_04_AutoSwitchColumn_PRT_Beam : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;

            // code
            try
            {

                FilteredElementCollector collectorColums = new FilteredElementCollector(doc);
                List<Element> listColumns = collectorColums.OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .WhereElementIsNotElementType().ToElements().ToList();

                FilteredElementCollector collectorBeams = new FilteredElementCollector(doc);
                List<Element> listBeams = collectorBeams.OfCategory(BuiltInCategory.OST_StructuralFraming)
                    .WhereElementIsNotElementType().ToElements().ToList();

                Transaction tran = new Transaction(doc);
                tran.Start("Switch Column PRT Beam");
                int count = 0;
                foreach (Element column in listColumns)
                {
                    foreach (Element beam in listBeams)
                    {
                        if (JoinGeometryUtils.AreElementsJoined(doc, column, beam))
                        {
                            if (!JoinGeometryUtils.IsCuttingElementInJoin(doc, column, beam))
                            {
                                JoinGeometryUtils.SwitchJoinOrder(doc, column, beam);
                                count++;
                            }
                        }
                    }
                }

                tran.Commit();
                MessageBox.Show($"Auto switch {count} pairs of column beam done!");
            }
            catch (Exception ex)
            {

            }

            return Result.Succeeded;
        }
    }
}
