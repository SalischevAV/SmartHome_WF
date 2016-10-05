using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewSmartHome.DeviceClasses;
using System.Web.UI.WebControls;
using NewSmartHome.DeviceInterfaces;

namespace SmartHome_WF.Controls
{
    public class FridgeableControl : SpanAndDivDrowControl
    {
        public FridgeableControl(Device sameDevice) : base(sameDevice)
        {
            DrowSetFridgeable();
        }

        private Button temperatureIncrButton;
        private Button temperatureDecrButton;
        private Button setTemperaturelButton;

        private TextBox temperatureValueBox;

        public void DrowSetFridgeable()
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
            Controls.Add(Span(" <br />"));
            temperatureIncrButton.Click += TemperatureIncrButton_Click;
            temperatureDecrButton.Click += TemperatureDecrButton_Click;
            setTemperaturelButton.Click += SetTemperaturelButton_Click;
        }

        private void SetTemperaturelButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).SetTemp(Convert.ToInt32(temperatureValueBox.Text));
                temperatureValueBox.Text = ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).Temp.ToString();
            }
            catch (Exception exm)
            {
                temperatureValueBox.Text = exm.Message;
            }
        }

        private void TemperatureDecrButton_Click(object sender, EventArgs e)
        {
            ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).DecrTemp();
            temperatureValueBox.Text = ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).Temp.ToString();
        }

        private void TemperatureIncrButton_Click(object sender, EventArgs e)
        {
            ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).IncrTemp();
            temperatureValueBox.Text = ((IFridgeable)smartHoseDevicesDictionary.ElementAt(id).Value).Temp.ToString();
        }

    }
}