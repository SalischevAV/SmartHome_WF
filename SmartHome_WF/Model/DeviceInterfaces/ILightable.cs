using NewSmartHome.Enums;

namespace NewSmartHome.DeviceInterfaces
{
    public interface ILightable
    {
        LampMode LightBrightnes { set; get; }
        string SetBrightnes(string settingBrightness);
    }
}
