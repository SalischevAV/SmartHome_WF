using NewSmartHome.DeviceClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SmartHome_WF.Controls
{
    public class SpanAndDivDrowControl : Panel
    {
        protected static int id;
        protected IDictionary<string, Device> smartHoseDevicesDictionary;
        protected Device sameDevice;
        protected string deviceName;

        public SpanAndDivDrowControl(string deviceName, Device sameDevice)
        {
            this.sameDevice = sameDevice;
            this.deviceName = deviceName;
        }
        protected HtmlGenericControl Span(string innerHTML)
        {
            HtmlGenericControl span = new HtmlGenericControl("span");
            span.InnerHtml = innerHTML;
            return span;
        }

        protected HtmlGenericControl Div(string innerHTML)
        {
            HtmlGenericControl div = new HtmlGenericControl("div");
            div.InnerHtml = innerHTML;
            return div;
        }

        public string DeviceGetID()
        {
            
            return deviceName;
            
        }
    }
}