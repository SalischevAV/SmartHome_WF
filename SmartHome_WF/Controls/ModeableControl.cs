using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class ModeableControl : Panel
    {
        
        private List<RadioButton> listOfRadioButtonsForMods = new List<RadioButton>();
        private Label captionlabel = new Label();
        






        public void GetListOfAvailableModes(IModeable sameDevice)
        {
            captionlabel.Text = "List of aviable mods: ";
            Controls.Add(captionlabel);

            Type t = sameDevice.GetType();
            PropertyInfo[] pI = t.GetProperties();
            Type t2 = t;
            foreach (PropertyInfo p in pI)
            {
                if ((Convert.ToString(p.PropertyType)).ToLower().Contains("mode"))
                { t2 = p.PropertyType; }

            }
            if (t2 != t)
            {
                FieldInfo[] t2Fields = t2.GetFields();
                for (int i = 0; i <= t2Fields.Length; i++)
                {
                    if (!t2Fields[i].Name.Contains("_"))
                    {
                        listOfRadioButtonsForMods[i] = new RadioButton();
                        listOfRadioButtonsForMods[i].GroupName = "modeOfDevice";
                        listOfRadioButtonsForMods[i].ID = "idRadioButton" + i;
                        listOfRadioButtonsForMods[i].Text = t2Fields[i].Name;
                        listOfRadioButtonsForMods[i].CssClass = "listOfRadioButtonsForMods";
                        Controls.Add(listOfRadioButtonsForMods[i]);
                    }
                }
            }

        }

        public void ControlWithModeable(IModeable sameDevice)
        {
            Console.WriteLine("Mode setting.");
            GetListOfAvailableModes(sameDevice);
            string settingMode = Console.ReadLine().ToLower();
            try
            {
                sameDevice.SetMode(settingMode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            if (actWithDevice != null)
            {
                actWithDevice.Invoke(sameDevice.SetMode(settingMode));
            }

        }
    }
}