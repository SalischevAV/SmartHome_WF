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
    public class DeviceControl : SpanAndDivDrowControl
    {
        public DeviceControl(IDictionary<string, Device> smartHoseDevicesDictionary) : base(smartHoseDevicesDictionary)
        {
            DrowSmartHome();
        }

        private CheckBox powerState;
       

        
       
        private Button volumeIncrButton;
        private Button volumeDecrButton;

        
        
        private TextBox volumelValueBox;

        private LightAbleControl lC;
        private ModeableControl mC;

        protected void DrowSmartHome()//подавать id?
        {
            CssClass = "smartDeviceDrow";
            Controls.Add(Span("Device: " + smartHoseDevicesDictionary.ElementAt(id).Key + " - " + smartHoseDevicesDictionary.ElementAt(id).Value.GetType().Name + "<br />"));

            powerState = new CheckBox { ID = "powerState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Power", CssClass = "powerState" };
            powerState.CheckedChanged += PowerState_CheckedChanged;
            Controls.Add(powerState);
            Controls.Add(Span(" <br />"));


            if (smartHoseDevicesDictionary.ElementAt(id).Value is IChannelable)
            {
                Controls.Add(Span("Сhannel selection: <br />"));
                channelIncrButton = new Button { ID = "channelIncr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "+", CssClass = "channel+" };
                channelValueBox = new TextBox { ID = "channelValue" + smartHoseDevicesDictionary.ElementAt(id).Key, CssClass = "channelValue" };
                channelDecrButton = new Button { ID = "channelDecr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "-", CssClass = "channel-" };
                Controls.Add(Span("<br />"));
                setChannelButton = new Button { ID = "channelSet" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Set", CssClass = "channelSet" };
                Controls.Add(channelIncrButton);
                Controls.Add(channelValueBox);
                Controls.Add(channelDecrButton);
                Controls.Add(setChannelButton);
                Controls.Add(Span(" <br />"));
                channelIncrButton.Click += ChannelIncrButton_Click;
                channelDecrButton.Click += ChannelDecrButton_Click;
                setChannelButton.Click += SetChannelButton_Click;
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IDoorable)
                //{
                //    Controls.Add(Span("Door state: <br />"));
                //    doorState = new CheckBox { ID = "doorState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Door", CssClass = "doorState", Checked = false };
                //    doorState.CheckedChanged += DoorState_CheckedChanged;
                //    Controls.Add(doorState);
                //    Controls.Add(Span(" <br />"));
                //}

                if (smartHoseDevicesDictionary.ElementAt(id).Value is IVolumeable)
                {
                    Controls.Add(Span("Volume set: <br />"));
                    volumeIncrButton = new Button { ID = "volumelIncr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "+", CssClass = "volume+" };
                    volumelValueBox = new TextBox { ID = "volumelValue" + smartHoseDevicesDictionary.ElementAt(id).Key, CssClass = "volumelValue", Text = "0" };
                    volumeDecrButton = new Button { ID = "volumeDecr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "-", CssClass = "volume-" };
                    Controls.Add(volumeIncrButton);
                    Controls.Add(volumelValueBox);
                    Controls.Add(volumeDecrButton);
                    Controls.Add(Span(" <br />"));
                    volumeIncrButton.Click += VolumeIncrButton_Click;
                    volumeDecrButton.Click += VolumeDecrButton_Click;
                }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IFridgeable)
            {
               
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is ILightable)
            {
                lC = new LightAbleControl((ILightable)smartHoseDevicesDictionary.ElementAt(id).Value);
                Controls.Add(lC);
                Controls.Add(Span(" <br />"));

            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IModeable)
            {
                mC = new ModeableControl((IModeable)smartHoseDevicesDictionary.ElementAt(id).Value);
                Controls.Add(mC);
                Controls.Add(Span(" <br />"));
            }

        }

    

       

        private void VolumeDecrButton_Click(object sender, EventArgs e)
        {
            ((IVolumeable)smartHoseDevicesDictionary.ElementAt(id).Value).SetVolume(false);
            volumelValueBox.Text = ((IVolumeable)smartHoseDevicesDictionary.ElementAt(id).Value).Volume.ToString();
        }

        private void VolumeIncrButton_Click(object sender, EventArgs e)
        {
            ((IVolumeable)smartHoseDevicesDictionary.ElementAt(id).Value).SetVolume(true);
            volumelValueBox.Text = ((IVolumeable)smartHoseDevicesDictionary.ElementAt(id).Value).Volume.ToString();
        }

        private void PowerState_CheckedChanged(object sender, EventArgs e)
        {
            if (powerState.Checked == true)
            {
                smartHoseDevicesDictionary.ElementAt(id).Value.State = true;
            }
            else
            {
                smartHoseDevicesDictionary.ElementAt(id).Value.State = true;
            }
        }

        


    }
}