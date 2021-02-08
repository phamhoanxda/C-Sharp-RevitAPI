#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

#endregion

namespace Pch
{
    [Transaction(TransactionMode.Manual)]
    public class AutoSwitchJoin : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,
            ref string message, ElementSet elements)
        {
            AutoSwitchJoin_UI form = new AutoSwitchJoin_UI(commandData.Application);
            form.ShowDialog();
            return Result.Succeeded;

        }
    }
}
