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
        public FridgeableControl(string deviceName, Device sameDevice) : base(deviceName, sameDevice)
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
            temperatureIncrButton = new Button { ID = "tempIncr" + DeviceGetID(), Text = "+", CssClass = "temp+" };
            temperatureValueBox = new TextBox { ID = "tempValue" + DeviceGetID(), CssClass = "templValue", Text = ((IFridgeable)sameDevice).Temp.ToString() };
            temperatureDecrButton = new Button { ID = "tempDecr" + DeviceGetID(), Text = "-", CssClass = "temp-" };
            Controls.Add(Span("<br />"));
            setTemperaturelButton = new Button { ID = "tempSet" + DeviceGetID(), Text = "Set", CssClass = "tempSet" };
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
                ((IFridgeable)sameDevice).SetTemp(Convert.ToInt32(temperatureValueBox.Text));
                temperatureValueBox.Text = ((IFridgeable)sameDevice).Temp.ToString();
            }
            catch (Exception exm)
            {
                temperatureValueBox.Text = exm.Message;
            }
        }

        private void TemperatureDecrButton_Click(object sender, EventArgs e)
        {
            ((IFridgeable)sameDevice).DecrTemp();
            temperatureValueBox.Text = ((IFridgeable)sameDevice).Temp.ToString();
        }

        private void TemperatureIncrButton_Click(object sender, EventArgs e)
        {
            ((IFridgeable)sameDevice).IncrTemp();
            temperatureValueBox.Text = ((IFridgeable)sameDevice).Temp.ToString();
        }

    }
}