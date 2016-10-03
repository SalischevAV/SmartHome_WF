namespace NewSmartHome.DeviceInterfaces
{

    public interface IDoorable
    {
        bool Door { set; get; } //надо убрать set
        string DoorManipulation();
    }
}
