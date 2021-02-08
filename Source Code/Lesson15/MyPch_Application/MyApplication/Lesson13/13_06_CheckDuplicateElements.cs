
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
    public class _13_06_CheckDuplicateElements : IExternalCommand
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
                List<FailureMessage> listWarnings = doc.GetWarnings().ToList();
                List<string> list = new List<string>();
                Transaction tran = new Transaction(doc);

                tran.Start("Get dupilcate elements");
                List<ElementId> listIds = new List<ElementId>();
                foreach (FailureMessage fail in listWarnings)
                {
                    if (fail.GetSeverity() == FailureSeverity.Warning)
                    {
                        string text = fail.GetDescriptionText();
                        if (text.Contains("same place"))
                        {
                            listIds.AddRange(fail.GetFailingElements());

                        }
                    }
                }

                doc.ActiveView.IsolateElementsTemporary(listIds);
                tran.Commit();
                MessageBox.Show($"Found {listIds.Count / 2} pairs of elements duplicated.");
            }
            catch (Exception ex)
            {

            }
            return Result.Succeeded;
        }
    }
}
