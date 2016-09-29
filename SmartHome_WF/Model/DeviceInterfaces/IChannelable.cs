namespace NewSmartHome.DeviceInterfaces
{
    public interface IChannelable
    {
        int Channel { set; get; }
        string SetChannel(int settingChannel);
        string AdjustChannel(bool increase);
}
}
