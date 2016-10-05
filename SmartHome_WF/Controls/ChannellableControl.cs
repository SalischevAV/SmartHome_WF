﻿using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class ChannellableControl : SpanAndDivDrowControl
    {
        public ChannellableControl(Device sameDevice) : base(sameDevice)
        {
            DrowSetChannel();
        }

        private Button channelIncrButton;
        private Button channelDecrButton;
        private Button setChannelButton;

        private TextBox channelValueBox;

        protected void DrowSetChannel()
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
    }
}