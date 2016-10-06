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
            //if (IsPostBack)
            //{
            //    Button1.Click += Button1_Click1;
            //}


            foreach (var res in smartHoseDevicesDictionary)
            {
                Panel1.Controls.Add(new SmartHomeControl(res.Key, res.Value));
            }



        }

        //private void Button1_Click1(object sender, EventArgs e)
        //{
        //    DeviceCreator dc = new DeviceCreator();
        //    switch (CreateDeviceList.SelectedIndex)
        //    {
        //        default:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("conditioner"));
        //            break;
        //        case 1:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("fridge"));
        //            break;
        //        case 2:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("mwoven"));
        //            break;
        //        case 3:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("oven"));
        //            break;
        //        case 4:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("radio"));
        //            dc.CreateDevice("radio");
        //            break;
        //        case 5:
        //            smartHoseDevicesDictionary.Add(TextBox1.Text, dc.CreateDevice("radiolamp"));
        //            break;
        //    }
        //}

        
    }
}
