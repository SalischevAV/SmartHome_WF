using NewSmartHome.DeviceClasses;
using NewSmartHome.Interfaces;
using NewSmartHome.ServiceClasses;
using SmartHome_WF.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHome_WF
{
    public partial class WebForm1 : Page
    {
        private int id;
        private Dictionary<string, Device> smartHoseDevicesDictionary = new Dictionary<string, Device>();
        protected void Page_Init(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
            }
            else
            {
                DeviceCreator myDCreator = new DeviceCreator();

                smartHoseDevicesDictionary.Add("nord", myDCreator.CreateDevice("fridge"));

                //smartHoseDevicesDictionary.Add("mitsubishi", myDCreator.CreateDevice("conditioner"));

                //smartHoseDevicesDictionary.Add("spidola", myDCreator.CreateDevice("radio"));

                //smartHoseDevicesDictionary.Add("indesit", myDCreator.CreateDevice("oven"));

                //smartHoseDevicesDictionary.Add("siemens", myDCreator.CreateDevice("mwoven"));

                //smartHoseDevicesDictionary.Add("seiko", myDCreator.CreateDevice("radiolamp"));

                Session["Devices"] = smartHoseDevicesDictionary;
                Session["NextId"] = 6;
            }
        }






        protected void Page_Load(object sender, EventArgs e)
        {
            RadioLamp rl = new RadioLamp();
            Lamp l1 = new Lamp();
            ColdGenerator cg = new ColdGenerator();
            Fridge fr = new Fridge(l1, cg);

            LightAbleControl lc = new LightAbleControl(rl);
            ModeableControl mc = new ModeableControl(fr);
            //DeviceControl dc = new DeviceControl(smartHoseDevicesDictionary);

            foreach(Device devid in smartHoseDevicesDictionary.Values) // что сюда подавать????
            {
                Panel1.Controls.Add(new SmartHomeControl(fr));
            }

            
            lc.DrowSetBrightnessMode();
            mc.DrowSetMode();
        }
    }
}
