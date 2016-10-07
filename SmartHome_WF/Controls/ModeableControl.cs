using NewSmartHome.DeviceClasses;
using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class ModeableControl : SpanAndDivDrowControl
    {

        private List<RadioButton> listOfRadioButtonsForModes = new List<RadioButton>();
        private List<FieldInfo> listAviableMods = new List<FieldInfo>();
        private Label captionlabel = new Label();
        private Button setModeBt;


        public ModeableControl(string deviceName, Device sameDevice) : base(deviceName, sameDevice)
        {
            DrowSetMode();
        }

        public void DrowSetMode()
        {
            captionlabel.Text = "List of aviable mods: ";
            Controls.Add(captionlabel);
            Controls.Add(Span("<br />"));

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
                listAviableMods.AddRange(t2Fields);
                int i = 1;
                    foreach(var res in listAviableMods)
                {
                    if (!res.Name.Contains("value__"))
                    {
                        i++;   
                        listOfRadioButtonsForModes.Add(new RadioButton { GroupName = "modeOfDevice", ID = "idRadioButton" + DeviceGetID()+i, Text = res.Name, CssClass = "listOfRadioButtonsForMods" });
                    }

                }
                foreach (var res in listOfRadioButtonsForModes)
                {
                    Controls.Add(res);
                    Controls.Add(Span("<br />"));
                }
            }
            setModeBt = new Button { Text = "Set Mode", CssClass = "setButton", ID = "setModeBt" + DeviceGetID() };
            setModeBt.Click += setModeBt_Click;


            Controls.Add(setModeBt);
            Controls.Add(Span("<br />"));

        }

        protected void setModeBt_Click(object sender, EventArgs e)
        {
            foreach (RadioButton rb in listOfRadioButtonsForModes)
            {
                if (rb.Checked)
                {
                    ((IModeable)sameDevice).SetMode(rb.Text.ToLower());
                }
            }
        }

    }
}