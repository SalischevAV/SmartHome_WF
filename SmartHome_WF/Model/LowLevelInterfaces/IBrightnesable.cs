using NewSmartHome.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.Interfaces
{
    public interface IBrightnesable
    {
        LampMode Brightness { set; get; }
        LampMode SetBrightness(string setting);
    }
}
