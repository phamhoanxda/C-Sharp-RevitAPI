#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Collections;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Documents;
using Microsoft.Win32;
using Application = Autodesk.Revit.ApplicationServices.Application;
using Form = System.Windows.Forms.Form;
#endregion
namespace Pch
{
    public partial class SheetManagement : Form
    {
        UIDocument uidoc;
        Document doc;
        public SheetManagement(UIApplication uiapp)
        {
            InitializeComponent();
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string prefixNumber = textBox1.Text;
            string prefixSheetName = textBox2.Text;
            string subfixSheetName = textBox3.Text;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<Element> listViewSheet = collector.OfClass(typeof(ViewSheet))
                .WhereElementIsNotElementType()
                .ToElements().ToList();

            Transaction tran = new Transaction(doc);
            tran.Start("Change Sheet Name and Number");
            int i = 1;
            foreach (Element elView in listViewSheet)
            {
                ViewSheet viewSheet = elView as ViewSheet;
                string sheetNumber = prefixNumber + i.ToString("00");
                viewSheet.SheetNumber = sheetNumber;

                Parameter sheetNamePara = viewSheet.LookupParameter("Sheet Name");
                string oldSheetName = sheetNamePara.AsString();
                string newSheetName = prefixSheetName + oldSheetName + subfixSheetName;
                sheetNamePara.Set(newSheetName);

                i++;
            }

            tran.Commit();
            Close();
        }
    }
}
