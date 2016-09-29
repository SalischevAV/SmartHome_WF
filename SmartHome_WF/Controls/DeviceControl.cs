using NewSmartHome.DeviceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class DeviceControl: WebControl
    {
        private int id; 
        private IDictionary<int, Device> figuresDictionary; 

        private CheckBox powerState { set; get; }
        private CheckBox doorState { set; get; }


        private Button channelIncrButton { set; get; }
        private Button channelDecrButton { set; get; }
        private Button temperatureIncrButton { set; get; }
        private Button temperatureDecrButton { set; get; }
        private Button volumeIncrButton { set; get; }
        private Button volumeDecrButton { set; get; }


        private TextBox channelValueBox { set; get; }
        private TextBox temperaturelValueBox { set; get; }


        private Label volumeValueLabel { set; get; }
    }
}