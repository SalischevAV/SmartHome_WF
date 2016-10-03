namespace NewSmartHome.DeviceInterfaces
{
    public interface IVolumeable
    {
        int Volume { set; get; }
        string SetVolume(bool increase);
    }
}
