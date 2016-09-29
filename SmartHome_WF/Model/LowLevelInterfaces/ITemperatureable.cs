using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.Interfaces
{
    public interface ITemperatureable
    {
        int Temp { set; get; }
        int SetTemp(int settingTemp);
        int IncrTemp();
        int DecrTemp();

    }
}
