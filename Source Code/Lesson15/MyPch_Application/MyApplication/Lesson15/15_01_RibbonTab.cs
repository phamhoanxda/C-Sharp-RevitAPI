
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
using System.Windows.Media.Imaging;
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
    public class _15_01_RibbonTab : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string nameTab = "PCH_APP";
            string imageSource = @"C:\Users\admin\Desktop\Revit API Basic Class\MyApplication\MyApplication\Images\";
            application.CreateRibbonTab(nameTab);

            RibbonPanel panel = application.CreateRibbonPanel(nameTab, "Management");

            string path = Assembly.GetExecutingAssembly().Location;
            PushButtonData buttonCheckDuplicate = new PushButtonData("button01", "Dup-Check", path, "Pch._13_06_CheckDuplicateElements");
            PushButtonData buttonJoinBeamDeck = new PushButtonData("button02", "Join B/D", path, "Pch._13_01_AutoJoinBeamDeck");
            PushButtonData buttonSheetName = new PushButtonData("button03", "SheetName", path, "Pch._14_01_SheetManagementCmd");
            PushButtonData buttonSwitchJoin = new PushButtonData("button04", "Switch OD", path, "Pch._14_02_AutoSwitchJoin");

            PushButton btDuplicate = panel.AddItem(buttonCheckDuplicate) as PushButton;
            btDuplicate.LargeImage = CreateBitmapImage(imageSource + "Duplicate.png");

            PushButton btAutoJoin = panel.AddItem(buttonJoinBeamDeck) as PushButton;
            btAutoJoin.LargeImage = CreateBitmapImage(imageSource + "AutoJoin.png");

            PushButton btSheetName = panel.AddItem(buttonSheetName) as PushButton;
            btSheetName.LargeImage = CreateBitmapImage(imageSource + "RenameSheet.png");
            btSheetName.ToolTipImage = CreateBitmapImage(imageSource + "RenameSheetTooltip.png");

            PushButton btSwitchJoin = panel.AddItem(buttonSwitchJoin) as PushButton;
            btSwitchJoin.LargeImage = CreateBitmapImage(imageSource + "SwitchJoin.png");

            return Result.Succeeded;
        }

        public BitmapImage CreateBitmapImage(string imagePath)
        {
            Uri iconUri = new Uri(imagePath, UriKind.Absolute);
            return new BitmapImage(iconUri);
        }

       
    }

}
