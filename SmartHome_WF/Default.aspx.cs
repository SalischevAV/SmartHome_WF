using NewSmartHome.DeviceClasses;
using NewSmartHome.Interfaces;
using SmartHome_WF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHome_WF
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RadioLamp rl = new RadioLamp();
            Lamp l1 = new Lamp();
            ColdGenerator cg = new ColdGenerator();
            Fridge fr = new Fridge(l1, cg);

            LightAbleControl lc = new LightAbleControl(rl);
            ModeableControl mc = new ModeableControl(fr);
            lc.SetBrightnessMode();
            mc.SetMode();
        }
    }
}