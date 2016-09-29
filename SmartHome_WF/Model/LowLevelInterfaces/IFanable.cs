using NewSmartHome.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.LowLevelInterfaces
{
    public interface IFanable
    {
        FanMode SpeedFan { set; get; }
        FanMode SetSpeedFan(string setting);

    }
}
