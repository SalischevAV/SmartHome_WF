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
    public class DeviceControl : Panel
    {
        public DeviceControl(IDictionary<string, Device> smartHoseDevicesDictionary)
        {
            this.smartHoseDevicesDictionary = smartHoseDevicesDictionary;
            DrowSmartHome();
        }

        private int id;
        private IDictionary<string, Device> smartHoseDevicesDictionary;

        private CheckBox powerState;
        private CheckBox doorState;

        private Button channelIncrButton;
        private Button channelDecrButton;
        private Button setChannelButton;
        private Button temperatureIncrButton;
        private Button temperatureDecrButton;
        private Button setTemperaturelButton;
        private Button volumeIncrButton;
        private Button volumeDecrButton;

        private TextBox channelValueBox;
        private TextBox temperatureValueBox;
        private TextBox volumelValueBox;

        private LightAbleControl lC;
        private ModeableControl mC;

        protected void DrowSmartHome()//подавать id?
        {
            CssClass = "smartDeviceDrow";
            Controls.Add(Span("Device: " + smartHoseDevicesDictionary.ElementAt(id).Key + " - " + smartHoseDevicesDictionary.ElementAt(id).Value.GetType().ToString() + "<br />"));

            powerState = new CheckBox { ID = "powerState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Power", CssClass = "powerState" };
            powerState.CheckedChanged += PowerState_CheckedChanged;

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
                channelIncrButton.Click += ChannelIncrButton_Click;
                channelDecrButton.Click += ChannelDecrButton_Click;
                setChannelButton.Click += SetChannelButton_Click;
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IDoorable)
            {
                Controls.Add(Span("Door state: <br />"));
                doorState = new CheckBox { ID = "doorState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Door", CssClass = "doorState", Checked = false };
                doorState.CheckedChanged += DoorState_CheckedChanged;
                Controls.Add(doorState);
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IVolumeable)
            {
                Controls.Add(Span("Volume set: <br />"));
                volumeIncrButton = new Button { ID = "volumelIncr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "+", CssClass = "volume+" };
                volumelValueBox = new TextBox { ID = "volumelValue" + smartHoseDevicesDictionary.ElementAt(id).Key, CssClass = "volumelValue", Text = "0" };
                volumeDecrButton = new Button { ID = "volumeDecr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "-", CssClass = "volume-" };
                Controls.Add(volumeIncrButton);
                Controls.Add(volumelValueBox);
                Controls.Add(volumeDecrButton);
                volumeIncrButton.Click += VolumeIncrButton_Click;
                volumeDecrButton.Click += VolumeDecrButton_Click;
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IFridgeable)
            {
                Controls.Add(Span("Temperature set: <br />"));
                temperatureIncrButton = new Button { ID = "tempIncr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "+", CssClass = "temp+" };
                temperatureValueBox = new TextBox { ID = "tempValue" + smartHoseDevicesDictionary.ElementAt(id).Key, CssClass = "templValue" };
                temperatureDecrButton = new Button { ID = "tempDecr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "-", CssClass = "temp-" };
                Controls.Add(Span("<br />"));
                setTemperaturelButton = new Button { ID = "tempSet" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Set", CssClass = "tempSet" };
                Controls.Add(temperatureIncrButton);
                Controls.Add(temperatureValueBox);
                Controls.Add(temperatureDecrButton);
                Controls.Add(setTemperaturelButton);
                temperatureIncrButton.Click += TemperatureIncrButton_Click;
                temperatureDecrButton.Click += TemperatureDecrButton_Click;
                setTemperaturelButton.Click += SetTemperaturelButton_Click;
            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is ILightable)
            {
                lC = new LightAbleControl((ILightable)smartHoseDevicesDictionary.ElementAt(id).Value);
                Controls.Add(lC);

            }

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IModeable)
            {
                mC = new ModeableControl((IModeable)smartHoseDevicesDictionary.ElementAt(id).Value);
                Controls.Add(mC);
            }

        }

        private void SetTemperaturelButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void TemperatureDecrButton_Click(object sender, EventArgs e)
        {
            ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).DecrTemp();
            temperatureValueBox.Text = ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).Temp.ToString();
        }

        private void TemperatureIncrButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void DoorState_CheckedChanged(object sender, EventArgs e)
        {
            ((IDoorable)smartHoseDevicesDictionary.ElementAt(id).Value).DoorManipulation();///как вытащить лампочку?
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

        private void SetChannelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).SetChannel(Convert.ToInt32(channelValueBox.Text));
                channelValueBox.Text = ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).Channel.ToString();
            }
            catch (Exception exm)
            {
                channelValueBox.Text = exm.Message;
            }
        }

        private void ChannelDecrButton_Click(object sender, EventArgs e)
        {
            ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).AdjustChannel(true);
            channelValueBox.Text = ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).Channel.ToString();
        }

        private void ChannelIncrButton_Click(object sender, EventArgs e)
        {
            ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).AdjustChannel(false);
            channelValueBox.Text = ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).Channel.ToString();
        }

        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

    }
}