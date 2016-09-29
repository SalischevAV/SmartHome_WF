using NewSmartHome.DeviceClasses;
using NewSmartHome.Interfaces;
using NewSmartHome.LowLevelClasses;
using NewSmartHome.LowLevelInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.ServiceClasses
{
    public class DeviceCreator
    {
        public string Path { set; get; }

        public string[] deviceClasses { set; get; }
        public Device NewDevice { set; get; }
        //public DeviceCreator(string path)
        //{
        //    Path = path;
        //}
        public void GetavAilableClasses()
        {

            deviceClasses = Directory.GetFiles(Path);
            for (int i = 0; i < deviceClasses.Length; i++)
            {
                deviceClasses[i] = deviceClasses[i].TrimStart(Path.ToCharArray());
                deviceClasses[i] = deviceClasses[i].TrimEnd(".cs".ToCharArray());
            }
            deviceClasses.OrderBy(dCl => dCl);
        }


        public Device CreateDevice(string TypeOfDevice)
        {
            IBrightnesable lamp = new Lamp();
            IFanable fan = new Fan();
            ILowLevelVolumeable soundController = new AudioPlayer();
            ITemperatureable compressor = new ColdGenerator();

            switch (TypeOfDevice)
            {
                case ("fridge"):
                    NewDevice = new Fridge(lamp, compressor);
                    //NewDevice.deviceNotificator += ServiceMessages.Message;
                    return NewDevice;
                case ("conditioner"):
                    NewDevice = new Conditioner(compressor, fan);
                    return NewDevice;
                case ("oven"):
                    NewDevice = new Oven(lamp);
                    return NewDevice;
                case ("mwoven"):
                    NewDevice = new MWOven(lamp);
                    return NewDevice;
                case ("radiolamp"):
                    NewDevice = new RadioLamp(lamp);
                    return NewDevice;
                case ("radio"):
                    NewDevice = new Radio(soundController);
                    return NewDevice;
                default:
                    throw new Exception("non-existent type of device");
            }
        }
    }
}

