using NewSmartHome.Delegates;
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
    public class Fridge : Device, IModeable, IFridgeable, IDoorable
    {
        public bool Door { set; get; }
        public override bool State
        {
            get
            {
                return base.State;
            }

            set
            {
                base.State = value;
            }
        }
        public IBrightnesable FridgeLamp { set; get; }
        public FridgeMode Mode { set; get; }
        public ITemperatureable Compressor { set; get; }
        private int temp;
        public int Temp
        {
            set
            {
                if ((Mode == FridgeMode.extracold) && (value <= -10 && value > -20))
                { temp = value; }
                else if ((Mode == FridgeMode.cold) && (value <= -5 && value >= -9))
                { temp = value; }
                else if ((Mode == FridgeMode.defrost) && (value > -5 && value <= 0))
                { temp = value; }
            }
            get
            {
                return temp;
            }
        }
        public Fridge()
        {
            
        }
        public Fridge(IBrightnesable lamp, ITemperatureable compressor)
        {
            FridgeLamp = lamp;
            Compressor = compressor;
        }
        public string SetMode(string setting)
        {
            if (State)
            {
                switch (setting)
                {
                    case "extracold":
                        Mode = FridgeMode.extracold;
                        return "fridge mode set EXTRACOLD";
                    case "cold":
                        Mode = FridgeMode.cold;
                        return "fridge mode set COLD";
                    case "defrost":
                    default:
                        Mode = FridgeMode.defrost;
                        return "fridge mode set DEFROST";
                }
            }
            else return "Can't change mode - fridge is POWER OFF";
        }

        public string SetTemp(int settingTemp)
        {
            if (State)
            {
                Temp = Compressor.SetTemp(settingTemp);
                return "Temperature set: " + Temp;
            }
            else return "fridge is POWER OFF";
        }

        public string IncrTemp()
        {
            if (State)
            {
                Temp = Compressor.IncrTemp();
                return "Temperature set: " + Temp;
            }
            else return "fridge is POWER OFF";
        }

        public string DecrTemp()
        {
            if (State)
            {
                Temp = Compressor.DecrTemp();
                return "Temperature set: " + Temp;
            }
            else return "fridge is POWER OFF";
        }

        public string DoorManipulation()
        {
            Door = !Door;
            if (State)
            {
                if (Door) { FridgeLamp.SetBrightness("medium"); }
                else { FridgeLamp.SetBrightness("off"); }
            }
            return "Door: " + Door;
        }

        public override string ToString()
        {
            return base.ToString() + " Mode of work: " + Mode + ", temperature: " + Temp + ", door open is: " + Door + ", fridge lamp: " + FridgeLamp.Brightness + ".";
        }


    }
}
