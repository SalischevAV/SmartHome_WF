using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Enums;
using NewSmartHome.Interfaces;
using NewSmartHome.LowLevelClasses;
using NewSmartHome.LowLevelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.DeviceClasses
{
    [Serializable]
    public class Conditioner : Device, IFridgeable, IModeable
    {
        public ITemperatureable Compressor { set; get; }
        public IFanable ColdFan { set; get; }
        private int temp;

        public int Temp
        {
            set
            {
                if (value <= 30 && value >= 16) { temp = value; }
            }
            get { return temp; }
        }
        public FanMode Mode { set; get; }

        public Conditioner()
        {
                
        }
        public Conditioner(ITemperatureable compressor, IFanable coldFan)
        {
            Compressor = compressor;
            ColdFan = coldFan;  
        }
       
        public string SetMode (string setting)
        {
            if (State)
            {
                switch (setting)
                {
                    
                    case "slow":
                        Mode = ColdFan.SetSpeedFan("slow");
                        return "conditioner fan speed set: " + Mode;
                    case "medium":
                        Mode = ColdFan.SetSpeedFan("medium");
                        return "conditioner fan speed set: " + Mode;
                    case "hight":
                        Mode = ColdFan.SetSpeedFan("hight");
                        return "conditioner fan speed set: " + Mode;
                }
            }
            Mode = ColdFan.SetSpeedFan("off");
            return "conditioner fan speed set: " + Mode;
        }

        public string SetTemp(int settingTemp)
        {
            Temp = Compressor.SetTemp(settingTemp);
            return "conditioner temperature set: " + Temp;
        }

        public string IncrTemp()
        {
            Temp++;
            return "conditioner temperature set: " + Temp;

        }

        public string DecrTemp()
        {
            Temp--;
            return "conditioner temperature set: " + Temp;
        }

        public override string ToString()
        {
            return base.ToString() + " Fan mode: " + Mode + ", temperature: " + Temp + ".";
        }
    }
}
