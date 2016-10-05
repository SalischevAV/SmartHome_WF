using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class DoorAbleControl : SpanAndDivDrowControl
    {
        private Button doorState;

        private CheckBox doorLamp;

        public DoorAbleControl(Device sameDevice) : base(sameDevice)
        {
            DrowSetDoor();   
        }

        protected void DrowSetDoor()
        {
            Controls.Add(Span("Door state: <br />"));
            doorState = new Button { ID = "doorState" + DeviceGetID(), Text = "Door close", CssClass = "doorState"};
            doorState.Click += DoorState_Click;
            Controls.Add(doorState);
            Controls.Add(Span("   "));
            doorLamp = new CheckBox { ID = "doorLamp" + DeviceGetID(), Text = "Door Lamp Off", CssClass = "doorLamp", BackColor=System.Drawing.Color.Red };
            Controls.Add(doorLamp);
            Controls.Add(Span(" <br />"));
        }

        private void DoorState_Click(object sender, EventArgs e)
        {
            ((IDoorable)sameDevice).DoorManipulation();///как вытащить лампочку?
            if (((IDoorable)sameDevice).Door==true)
            {
                doorState.Text = "Door open";
                doorLamp.Checked = true;
                doorLamp.Text = "Door Lamp On";
                doorLamp.BackColor = System.Drawing.Color.Red;
            }
            else {
                doorState.Text = "Door close";
                doorLamp.Checked = false;
                doorLamp.Text = "Door Lamp Off";
                doorLamp.BackColor = System.Drawing.Color.Green;
            }

        }

        
    }
}