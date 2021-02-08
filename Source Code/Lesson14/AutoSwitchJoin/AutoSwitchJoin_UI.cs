#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;

#endregion

namespace Pch
{
    public partial class AutoSwitchJoin_UI : System.Windows.Forms.Form
    {
        UIDocument uidoc;
        Document doc;
        public AutoSwitchJoin_UI(UIApplication application)
        {
            InitializeComponent();
            uidoc = application.ActiveUIDocument;
            doc = uidoc.Document;

            //Su dung bien.
            comboBoxA.DataSource = listA;
            comboBoxB.DataSource = listB;
        }

        // Khai bao bien su dung
        string[] listA = { "Beam", "Floor", "Column" };
        string[] listB = { "Beam", "Floor", "Column" };


        //---//
        private void button1_Click(object sender, EventArgs e)
        {
            //code here
                string chooseA = comboBoxA.SelectedItem.ToString();
                string chooseB = comboBoxB.SelectedItem.ToString();

                List<Element> listA = GetElementByKey(chooseA);
                List<Element> listB = GetElementByKey(chooseB);

            //Code

            if (AutoJoin.Checked)
            {
                //join
                try
                {
                    Transaction tran = new Transaction(doc);
                    tran.Start($"Join {chooseA} to {chooseB}");
                    int count = 0;
                    foreach (Element a in listA)
                    {
                        foreach (Element b in listB)
                        {
                            try
                            {
                                JoinGeometryUtils.JoinGeometry(doc, a, b);
                                count++;
                            }
                            catch (Exception exx)
                            {

                            }
                        }
                    }
                    tran.Commit();
                    MessageBox.Show($"Auto Join {count} pairs of {chooseA} {chooseB} done!");
                }
                catch (Exception ex)
                {

                }
            }
            else if (AutoUnJoin.Checked)
            {
                //Unjoin
                try
                {
                    Transaction tran = new Transaction(doc);
                    tran.Start($"UnJoin {chooseA} to {chooseB}");
                    int count = 0;
                    foreach (Element a in listA)
                    {
                        foreach (Element b in listB)
                        {
                            try
                            {
                                JoinGeometryUtils.UnjoinGeometry(doc, a, b);
                                count++;
                            }
                            catch (Exception exx)
                            {

                            }
                        }
                    }
                    tran.Commit();
                    MessageBox.Show($"Auto UnJoin {count} pairs of {chooseA} {chooseB} done!");
                }
                catch (Exception ex)
                {

                }
            }
            else if (SwitchJoin.Checked)
            {
                // Switch join
                try
                {
                    Transaction tran = new Transaction(doc);
                    tran.Start($"Switch {chooseA} PRT {chooseB}");
                    int count = 0;
                    foreach (Element a in listA)
                    {
                        foreach (Element b in listB)
                        {
                            if (JoinGeometryUtils.AreElementsJoined(doc, a, b))
                            {
                                if (!JoinGeometryUtils.IsCuttingElementInJoin(doc, b, a))
                                {
                                    JoinGeometryUtils.SwitchJoinOrder(doc, b, a);
                                    count++;
                                }
                            }
                        }
                    }
                    tran.Commit();
                    MessageBox.Show($"Auto switchjoin {count} pairs of {chooseA} {chooseB} done!");
                }
                catch (Exception ex)
                {

                }
                
            }
            else
            {
                MessageBox.Show("Please choose one option!");
            }
            Close();
        }
            
        //method get elements by key
        List<Element> GetElementByKey(string key)
        {
            //collector
            FilteredElementCollector colector = new FilteredElementCollector(doc);
            List<Element> list = new List<Element>();

            switch (key)
            {
                case "Beam":
                    list = colector.OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsElementType().ToElements().ToList();
                    break;

                case "Floor":
                    list = colector.OfCategory(BuiltInCategory.OST_Floors).WhereElementIsNotElementType().ToElements().ToList();
                    break;

                case "Column":
                    list = colector.OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType().ToElements().ToList();
                    break;
            }
            return list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
