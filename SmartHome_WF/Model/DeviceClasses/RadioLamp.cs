using NewSmartHome.DeviceInterfaces;
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
    public class RadioLamp: Radio, ILightable
    {
        public IBrightnesable RLamp { set; get; }
        public LampMode LightBrightnes { set; get; }

        public RadioLamp()
        {
                
        }
        public RadioLamp(IBrightnesable rlamp)
        {
            RLamp = rlamp; 
        }
        public string SetBrightnes ( string settingBrightness)
        {
            if (State)
            {
                switch (settingBrightness)
                {

                    case "dim":
                        LightBrightnes = RLamp.SetBrightness("dim");
                        return "radioLamp brightness set: " + LightBrightnes;
                    case "medium":
                        LightBrightnes = RLamp.SetBrightness("medium");
                        return "radioLamp brightness set: " + LightBrightnes;
                    case "hight":
                        LightBrightnes = RLamp.SetBrightness("hight");
                        return "radioLamp brightness set: " + LightBrightnes;
                    case "off":
                    default:
                        LightBrightnes = RLamp.SetBrightness("off");
                        return "radioLamp brightness set: " + LightBrightnes;


                }
            }
            else return "radioLamp is OFF";
        }

        public override string ToString()
        {
            return base.ToString() + ", lamp brightness: " + RLamp.Brightness + ".";
        }
    }
}
