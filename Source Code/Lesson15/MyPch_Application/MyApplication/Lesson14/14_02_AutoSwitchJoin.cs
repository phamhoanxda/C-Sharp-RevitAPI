
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
    public class _14_02_AutoSwitchJoin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            AutoSwitchJoin_UI autoSwitchJoin = new AutoSwitchJoin_UI(commandData.Application);
            autoSwitchJoin.ShowDialog();
            return Result.Succeeded;
        }
    }
}
