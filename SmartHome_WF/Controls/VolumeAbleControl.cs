using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewSmartHome.DeviceClasses;
using System.Web.UI.WebControls;
using NewSmartHome.DeviceInterfaces;

namespace SmartHome_WF.Controls
{
    public class VolumeAbleControl : SpanAndDivDrowControl
    {
        public VolumeAbleControl(Device sameDevice) : base(sameDevice)
        {
            DrowSetVolume();
        }


        private Button volumeIncrButton;
        private Button volumeDecrButton;



        private TextBox volumelValueBox;

        private void DrowSetVolume()
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
    }
}