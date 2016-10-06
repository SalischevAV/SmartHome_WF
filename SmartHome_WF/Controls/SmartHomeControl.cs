using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class SmartHomeControl : SpanAndDivDrowControl
    {
        public SmartHomeControl(string deviceName, Device sameDevice) : base(sameDevice)
        {
            this.deviceName = deviceName;
            DrowSmartHome();
        }
        protected string deviceName;

        private Button powerState;
        private Label devNameLb;


        private ChannellableControl chC;
        private DoorAbleControl dC;
        private FridgeableControl fC;
        private LightAbleControl lC;
        private ModeableControl mC;
        private VolumeAbleControl vC;

        protected void DrowSmartHome()
        {
            CssClass = "smartDeviceDrow";
            devNameLb = new Label { Text = deviceName, CssClass = "devNameLb" };
            Controls.Add(devNameLb);
            Controls.Add(Span(" <br />"));
            Controls.Add(Span("Device: " + sameDevice.GetType().Name + "<br />"));

            powerState = new Button { ID = "powerState" + DeviceGetID(), Text = "Power", CssClass = "powerState" };
            Controls.Add(powerState);
            Controls.Add(Span(" <br />"));
            powerState.Click += PowerState_Click;


            if (sameDevice is IChannelable)
            {
                chC = new ChannellableControl(sameDevice);
                Controls.Add(chC);
                Controls.Add(Span(" <br />"));

            }

            if (sameDevice is IDoorable)
            {
                dC = new DoorAbleControl(sameDevice);
                Controls.Add(dC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is IVolumeable)
            {
                vC = new VolumeAbleControl(sameDevice);
                Controls.Add(vC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is IFridgeable)
            {
                fC = new FridgeableControl(sameDevice);
                Controls.Add(fC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is ILightable)
            {
                lC = new LightAbleControl(sameDevice);
                Controls.Add(lC);
                Controls.Add(Span(" <br />"));

            }

            if (sameDevice is IModeable)
            {
                mC = new ModeableControl(sameDevice);
                Controls.Add(mC);
                Controls.Add(Span(" <br />"));
            }

        }

        private void PowerState_Click(object sender, EventArgs e)
        {
            sameDevice.Power();
            if (sameDevice.State == true)
            { powerState.Text = "Power on"; }
            else { powerState.Text = "Power off"; }
        }




    }
}