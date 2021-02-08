using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;
using System.Reflection;
using System.IO;

namespace Pch
{
    public partial class AutoSwitchJoin_UI : Form
    {
        UIDocument uidoc;
        Document doc;
        public AutoSwitchJoin_UI(UIApplication uiapp)
        {
            InitializeComponent();
            uidoc = uiapp.ActiveUIDocument;
            doc = uidoc.Document;

            //Su dung bien
            comboBox1.DataSource = listItemA;
            comboBox2.DataSource = listItemB;

           
        }
        //Khai bao bien
        string[] listItemA = { "Beam", "Column", "Deck" };
        string[] listItemB = { "Beam", "Column", "Deck" };


        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Code here
            string comboA = comboBox1.SelectedItem.ToString();
            string comboB = comboBox2.SelectedItem.ToString();

            if(comboA == comboB)
            {
                MessageBox.Show("Please select diffirent combo above");
                return;
            }
            bool checkJoin = radioButton1.Checked;
            bool checkUnJoin = radioButton2.Checked;
            bool checkSwitchJoin = radioButton3.Checked;

            // Get data for combo A,B
            List<Element> listA = new List<Element>();
            List<Element> listB = new List<Element>();

            FilteredElementCollector collectorA = new FilteredElementCollector(doc);
            switch (comboA)
            {
                case "Beam":
                    listA = collectorA.OfCategory(BuiltInCategory.OST_StructuralFraming)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
                case "Column":
                    listA = collectorA.OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
                case "Deck":
                    listA = collectorA.OfCategory(BuiltInCategory.OST_Floors)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
            }
            FilteredElementCollector collectorB = new FilteredElementCollector(doc);
            switch (comboB)
            {
                case "Beam":
                    listB = collectorB.OfCategory(BuiltInCategory.OST_StructuralFraming)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
                case "Column":
                    listB = collectorB.OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
                case "Deck":
                    listB = collectorB.OfCategory(BuiltInCategory.OST_Floors)
                    .WhereElementIsNotElementType().ToElements().ToList();
                    break;
            }

            if (checkJoin)
            {
                Transaction tran = new Transaction(doc);
                tran.Start($"Auto Join {comboA} to {comboB}");
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
                        catch (Exception ex)
                        {
                        }
                    }
                }
                tran.Commit();
                MessageBox.Show($"Auto join {count} pairs of {comboA} {comboB} done!");
            }
            else if (checkUnJoin)
            {
                Transaction tran = new Transaction(doc);
                tran.Start($"Auto UnJoin {comboA} to {comboB}");
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
                        catch (Exception ex)
                        {

                        }

                    }
                }
                tran.Commit();
                MessageBox.Show($"Auto Unjoin {count} pairs of {comboA} {comboB} done!");
            }
            else if (checkSwitchJoin)
            {
                Transaction tran = new Transaction(doc);
                tran.Start("Switch Beam PRT Column");
                int count = 0;
                foreach (Element a in listA)
                {
                    foreach (Element b in listB)
                    {
                        if (JoinGeometryUtils.AreElementsJoined(doc, a, b))
                        {
                            if (!JoinGeometryUtils.IsCuttingElementInJoin(doc, a, b))
                            {
                                JoinGeometryUtils.SwitchJoinOrder(doc, a, b);
                                count++;
                            }
                            else
                            {
                                JoinGeometryUtils.SwitchJoinOrder(doc, b, a);
                                count++;
                            }
                        }
                    }
                }

                tran.Commit();
                MessageBox.Show($"Auto switch {count} pairs of {comboA} {comboB} done!");
            }
            else
            {
                MessageBox.Show("Please select mode before run.");
            }
            
        }
    }
}
