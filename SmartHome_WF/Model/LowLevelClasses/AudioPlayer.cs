using NewSmartHome.LowLevelInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.LowLevelClasses
{
    [Serializable]
    class AudioPlayer: ILowLevelVolumeable
    {
        private int volLevel;
         public int VolLevel
        {
            set
            {
                if (value >= 0 && value <= 100)
                {
                    volLevel = value;
                }

            }
            get
            {
                return volLevel;
            }
        }

        public int AdjustVolume(bool increase)
        {
            if (increase == true)
            {
                ++VolLevel;
                return VolLevel;
            }
            else
            {
                --VolLevel;
                return VolLevel;
            }
        }

       
    }
}
