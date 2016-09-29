using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.DeviceClasses
{
    [Serializable]
    public class ColdGenerator: ITemperatureable
    {
        public int Temp { set; get; }

        public int SetTemp (int settingTemp)
        {
            Temp = settingTemp;
            return Temp;
        }

        public int IncrTemp()
        {
            Temp++;
            return Temp;
        }

        public int DecrTemp()
        {
            Temp--;
            return Temp;
        }
    }
}
