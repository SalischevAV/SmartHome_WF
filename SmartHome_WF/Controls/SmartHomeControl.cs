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
        public SmartHomeControl(Device sameDevice) : base(sameDevice)
        {
            DrowSmartHome();
        }

        private Button powerState;


        private ChannellableControl chC;
        private DoorAbleControl dC;
        private FridgeableControl fC;
        private LightAbleControl lC;
        private ModeableControl mC;
        private VolumeAbleControl vC;

        protected void DrowSmartHome()//подавать id?
        {
            CssClass = "smartDeviceDrow";
            Controls.Add(Span("Device: " + sameDevice.GetType().Name +  "<br />"));//имя из словаря придется совать в дефаулт

            powerState = new Button { ID = "powerState" + DeviceGetID(), Text = "Power", CssClass = "powerState" };
            powerState.Click += PowerState_Click;
            Controls.Add(powerState);
            Controls.Add(Span(" <br />"));


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
            if(sameDevice.State == true)
            { powerState.Text = "Power on"; }
            else { powerState.Text = "Power off"; }
        }

                


    }
}