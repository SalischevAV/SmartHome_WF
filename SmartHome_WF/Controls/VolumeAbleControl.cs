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
        public VolumeAbleControl(string deviceName, Device sameDevice) : base(deviceName, sameDevice)
        {
            DrowSetVolume();
        }


        private Button volumeIncrButton;
        private Button volumeDecrButton;



        private TextBox volumelValueBox;

        private void DrowSetVolume()
        {
            Controls.Add(Span("Volume set: <br />"));
            volumeIncrButton = new Button { ID = "volumelIncr" + DeviceGetID(), Text = "+", CssClass = "volume+" };
            volumelValueBox = new TextBox { ID = "volumelValue" + DeviceGetID(), CssClass = "volumelValue", Text = ((IVolumeable)sameDevice).Volume.ToString() };
            volumeDecrButton = new Button { ID = "volumeDecr" + DeviceGetID(), Text = "-", CssClass = "volume-" };
            Controls.Add(volumeIncrButton);
            Controls.Add(volumelValueBox);
            Controls.Add(volumeDecrButton);
            Controls.Add(Span(" <br />"));
            volumeIncrButton.Click += VolumeIncrButton_Click;
            volumeDecrButton.Click += VolumeDecrButton_Click;
        }

        private void VolumeDecrButton_Click(object sender, EventArgs e)
        {
            ((IVolumeable)sameDevice).SetVolume(false);
            volumelValueBox.Text = ((IVolumeable)sameDevice).Volume.ToString();
        }

        private void VolumeIncrButton_Click(object sender, EventArgs e)
        {
            ((IVolumeable)sameDevice).SetVolume(true);
            volumelValueBox.Text = ((IVolumeable)sameDevice).Volume.ToString();
        }
    }
}