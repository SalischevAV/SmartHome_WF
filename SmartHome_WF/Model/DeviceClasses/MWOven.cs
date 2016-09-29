using NewSmartHome.Enums;
using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.DeviceClasses
{
    [Serializable]
    public class MWOven : Oven, IModeable
    {

        public MWOvenMode MWMode { set; get; }
        public string SetMode(string setting)
        {
            switch (setting)
            {
                case "defrost":
                    MWMode = MWOvenMode.defrost;
                    return "mw-oven mode set: " + MWMode;
                case "easy":
                    MWMode = MWOvenMode.easy;
                    return "mw-oven mode set: " + MWMode;
                case "grill":
                    MWMode = MWOvenMode.grill;
                    return "mw-oven mode set: " + MWMode;
                case "normal":
                default:
                    MWMode = MWOvenMode.normal;
                    return "mw-oven mode set: " + MWMode;
            }
        }
        public MWOven()
        {
                
        }
        public MWOven(IBrightnesable lamp):base(lamp)
        {
                
        }
        public override string ToString()
        {
            return base.ToString() + ", mode work: " + MWMode + ".";
        }
    }
}
