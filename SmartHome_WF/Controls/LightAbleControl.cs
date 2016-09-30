using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class LightAbleControl:Panel
    {
        private ILightable lightableDevice;

        private Label brightnessText;

        private RadioButton rbOff;
        private RadioButton rbDim;
        private RadioButton rbMediumBright;
        private RadioButton rbBright;

        private Button setBrightnessBt;
        public LightAbleControl(ILightable lightableDevice)
        {
            this.lightableDevice = lightableDevice;
        }

        public void SetBrightnessMode()
        {
            brightnessText = new Label { Text = "Available modes: ", CssClass = "brighnessText"};
            rbOff = new RadioButton { GroupName = "brightness", ID = "rbOff", CssClass = "lightAbleRB", Text = "Brightness Off" };
            rbDim = new RadioButton { GroupName = "brightness", ID = "rbDim", CssClass = "lightAbleRB", Text = "Brightness Dim" };
            rbMediumBright = new RadioButton { GroupName = "brightness", ID = "rbMediumBright", CssClass = "lightAbleRB", Text = "Brightness MediumBright" };
            rbBright = new RadioButton { GroupName = "brightness", ID = "rbBright", CssClass = "lightAbleRB", Text = "Brightness Bright" };
            setBrightnessBt = new Button { Text = "Set Brightness", CssClass = "setButton", ID = "setBrightnessBt" };
            setBrightnessBt.Click += setBrightnessBt_Click;

            Controls.Add(brightnessText);
            Controls.Add(rbOff);
            Controls.Add(rbDim);
            Controls.Add(rbMediumBright);
            Controls.Add(rbBright);
            Controls.Add(setBrightnessBt);


        }



        protected void setBrightnessBt_Click(object sender, EventArgs e)
        {
            if (rbOff.Checked)
            { lightableDevice.LightBrightnes = LampMode.off; }
            if(rbDim.Checked)
            { lightableDevice.LightBrightnes = LampMode.dim; }
            if(rbMediumBright.Checked)
            { lightableDevice.LightBrightnes = LampMode.mediumbright; }
            if(rbBright.Checked)
            { lightableDevice.LightBrightnes = LampMode.bright; }
        }

    

    }
}