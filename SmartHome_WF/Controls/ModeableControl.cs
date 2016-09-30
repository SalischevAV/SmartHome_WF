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

        private List<RadioButton> listOfRadioButtonsForModes = new List<RadioButton>();
        private Label captionlabel = new Label();
        private Button setModeBt;
        private IModeable sameDevice;

        public ModeableControl(IModeable sameDevice)
        {
            this.sameDevice = sameDevice;
        }






        public void SetMode()
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
                //for (int i = 0; i < t2Fields.Length; i++)
                //{
                //    if (t2Fields[i].Name.Contains("_"))
                //    { Array.Clear(t2Fields, i, 1); }
                //}
                for (int i = 0; i < t2Fields.Length; i++)
                {
                    try
                    {
                        listOfRadioButtonsForModes[i] = new RadioButton { GroupName = "modeOfDevice", ID = "idRadioButton" + i, Text = t2Fields[i].Name, CssClass = "listOfRadioButtonsForMods" };
                        Controls.Add(listOfRadioButtonsForModes[i]);
                    }
                    catch
                    { }

                }
            }
            setModeBt = new Button { Text = "Set Mode", CssClass = "setButton", ID = "setModeBt" };
            setModeBt.Click += setModeBt_Click;

        }

        protected void setModeBt_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listOfRadioButtonsForModes)
            {
                if (rb.Checked)
                {
                    sameDevice.SetMode(rb.Text.ToLower());
                }
            }
        }

    }
}