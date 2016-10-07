using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Interfaces;
using SmartHome_WF.Model.Delegates;
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
        public SmartHomeControl(string deviceName, Device sameDevice) : base(deviceName, sameDevice)
        {
            DrowSmartHome();
        }

        public event DeleteDevice deleter;

        private Button powerState;
        private Button delButton;
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
                chC = new ChannellableControl(deviceName, sameDevice);
                Controls.Add(chC);
                Controls.Add(Span(" <br />"));

            }

            if (sameDevice is IDoorable)
            {
                dC = new DoorAbleControl(deviceName, sameDevice);
                Controls.Add(dC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is IVolumeable)
            {
                vC = new VolumeAbleControl(deviceName, sameDevice);
                Controls.Add(vC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is IFridgeable)
            {
                fC = new FridgeableControl(deviceName, sameDevice);
                Controls.Add(fC);
                Controls.Add(Span(" <br />"));
            }

            if (sameDevice is ILightable)
            {
                lC = new LightAbleControl(deviceName, sameDevice);
                Controls.Add(lC);
                Controls.Add(Span(" <br />"));

            }

            if (sameDevice is IModeable)
            {
                mC = new ModeableControl(deviceName, sameDevice);
                Controls.Add(mC);
                Controls.Add(Span(" <br />"));
            }

            delButton = new Button { ID = "delButton" + DeviceGetID(), Text = "Delete", CssClass = "delButton" };
            Controls.Add(delButton);
            delButton.Click += DelButton_Click;

        }

        private void DelButton_Click(object sender, EventArgs e)
        {
            if (deleter != null)
            {
                deleter.Invoke(deviceName);
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