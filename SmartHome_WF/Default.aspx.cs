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
        private Dictionary<string, Device> smartHoseDevicesDictionary = new Dictionary<string, Device>();
        protected void Page_Init(object sender, EventArgs e)
        {


            if (IsPostBack)
            {
                smartHoseDevicesDictionary = (Dictionary<string, Device>)Session["Devices"];
                foreach (var res in Controls)
                {
                    if (res is SmartHomeControl)
                    {
                        ((SmartHomeControl)res).deleter += DelDevice;
                    }
                }


            }
            else
            {
                DeviceCreator myDCreator = new DeviceCreator();

                smartHoseDevicesDictionary.Add("nord", myDCreator.CreateDevice("fridge"));

                smartHoseDevicesDictionary.Add("mitsubishi", myDCreator.CreateDevice("conditioner"));

                smartHoseDevicesDictionary.Add("spidola", myDCreator.CreateDevice("radio"));

                smartHoseDevicesDictionary.Add("indesit", myDCreator.CreateDevice("oven"));

                smartHoseDevicesDictionary.Add("siemens", myDCreator.CreateDevice("mwoven"));

                smartHoseDevicesDictionary.Add("seiko", myDCreator.CreateDevice("radiolamp"));


                Session["Devices"] = smartHoseDevicesDictionary;

            }
        }






        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (var res in smartHoseDevicesDictionary)
            {
                Panel1.Controls.Add(new SmartHomeControl(res.Key, res.Value));

            }
           
        }

        public void DelDevice(string deviceName)
        {
            smartHoseDevicesDictionary.Remove(deviceName);
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            DeviceCreator dc = new DeviceCreator();
            try
            {
                switch (CreateDeviceList.SelectedIndex)
                {
                    default:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("conditioner"));
                        break;
                    case 1:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("fridge"));
                        break;
                    case 2:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("mwoven"));
                        break;
                    case 3:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("oven"));
                        break;
                    case 4:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("radio"));
                        break;
                    case 5:
                        smartHoseDevicesDictionary.Add(DevNameBox.Text, dc.CreateDevice("radiolamp"));
                        break;

                }
            }
            catch (Exception ex)
            { InformationLabel.Text = ex.Message; }
        }
    }
}
