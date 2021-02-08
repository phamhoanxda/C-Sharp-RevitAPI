
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
    public class _13_01_AutoJoinBeamDeck : IExternalCommand
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
                FilteredElementCollector collectorBeam = new FilteredElementCollector(doc);
                List<Element> listBeams = collectorBeam.OfCategory(BuiltInCategory.OST_StructuralFraming)
                    .WhereElementIsNotElementType().ToElements().ToList();

                FilteredElementCollector collectorDeck = new FilteredElementCollector(doc);
                List<Element> listDecks = collectorDeck.OfCategory(BuiltInCategory.OST_Floors)
                    .WhereElementIsNotElementType().ToElements().ToList();

                Transaction tran = new Transaction(doc);
                tran.Start("Join beam to deck");
                int count = 0;
                foreach (Element deck in listDecks)
                {
                    foreach (Element beam in listBeams)
                    {
                        try
                        {
                            JoinGeometryUtils.JoinGeometry(doc, beam, deck);
                            count++;
                        }
                        catch (Exception ex)
                        {

                        }

                    }
                }
                tran.Commit();
                MessageBox.Show($"Auto join {count} pairs of beam deck done!");
            }
            catch (Exception ex)
            {

            }
            return Result.Succeeded;
        }
    }
}
