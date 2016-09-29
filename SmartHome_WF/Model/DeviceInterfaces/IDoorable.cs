namespace NewSmartHome.DeviceInterfaces
{

    public interface IDoorable
    {
        bool Door { set; get; }
        string DoorManipulation();
    }
}
