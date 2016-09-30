using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class DeviceControl : WebControl
    {
        private int id;
        private IDictionary<string, Device> smartHoseDevicesDictionary;

        private CheckBox powerState;
        private CheckBox doorState;


        private Button channelIncrButton;
        private Button channelDecrButton;
        private Button setChannelButton;
        private Button temperatureIncrButton;
        private Button temperatureDecrButton;
        private Button volumeIncrButton;
        private Button volumeDecrButton;

        private TextBox channelValueBox;
        private TextBox temperaturelValueBox;

        private LightAbleControl lightControl;
        private ModeableControl modeControl; 

        protected void DrowSmartHome()//подавать id?
        {
            Controls.Add(Span("Device: " + smartHoseDevicesDictionary.ElementAt(id).Key + " - " + smartHoseDevicesDictionary.ElementAt(id).Value.GetType().ToString() + "<br />"));

            powerState = new CheckBox { ID = "powerState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Power", CssClass = "powerState" };

            if (smartHoseDevicesDictionary.ElementAt(id).Value is IChannelable)
            {
                Controls.Add(Span("Сhannel selection: <br />"));
                channelIncrButton = new Button { ID = "channelIncr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "+", CssClass = "channel+" };
                channelValueBox = new TextBox { ID = "channelValue" + smartHoseDevicesDictionary.ElementAt(id).Key, CssClass = "channelValue" };
                setChannelButton = new Button { ID = "channelSet" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Set", CssClass = "channelSet" };
                channelDecrButton = new Button { ID = "channelDecr" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "-", CssClass = "channel-" };
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
                doorState = new CheckBox { ID = "doorState" + smartHoseDevicesDictionary.ElementAt(id).Key, Text = "Door", CssClass = "doorState" };
                Controls.Add(doorState);
            }

        }

        private void SetChannelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((IChannelable)smartHoseDevicesDictionary.ElementAt(id).Value).SetChannel(Convert.ToInt32(channelValueBox.Text));
            }
            catch(Exception exm)
            {
                channelValueBox.Text = exm.Message;
            }
        }

        private void ChannelDecrButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChannelIncrButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

    }
}