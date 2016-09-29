using NewSmartHome.Delegates;
using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.UI
{
    public class ConsoleUIDevice
    {
        public event WriteLogDelegate actWithDevice;
        public string Message { set; get; }
        public void ControlWithIChannelable(IChannelable sameDevice)
        {
            Console.WriteLine("Switching channels. \n\nAvailable commands: \n-Set. \n-Increase. \n-Decrease. \n\nEnter your command:");
            Message = Console.ReadLine().ToLower();
            if (Message.Contains("set"))
            {
                Console.WriteLine("Enter channel number (1-100): ");
                int setChannel;
                if (Int32.TryParse(Console.ReadLine(), out setChannel)) ;
                sameDevice.SetChannel(setChannel);
                if (actWithDevice != null)
                {
                    actWithDevice.Invoke((sameDevice.SetChannel(setChannel))); // можно как-то проще?
                }
            }
            else if (Message.Contains("increase"))
            {
                sameDevice.AdjustChannel(true);
                if (actWithDevice != null)
                {
                    actWithDevice.Invoke(sameDevice.AdjustChannel(true));
                }
            }
            else if (Message.Contains("decrease"))
            {
                sameDevice.AdjustChannel(false);
                if (actWithDevice != null)
                {
                    actWithDevice.Invoke(sameDevice.AdjustChannel(true));
                }
            }
            else
            {
                Console.WriteLine("Nonexistent command");
                if (actWithDevice != null)
                {
                    actWithDevice.Invoke("Nonexistent command");
                }
            }
        }
        public void ControlWithIDoorable(IDoorable sameDevice)
        {
            Console.WriteLine("Operation with door. \n\nOpen or Close. \n\nPress any key.");
            Console.ReadLine();
            {
                sameDevice.DoorManipulation();
                if (actWithDevice != null)
                {
                    actWithDevice.Invoke(sameDevice.DoorManipulation()); // можно как-то проще?
                }
            }
        }
        public void ControlWithFridgeable(IFridgeable sameDevice)
        {
            Console.WriteLine("Manipulation with temperature. \n\nAvailable commands: \n-Set. \n-Increase. \n-Decrease. \n\nEnter your command:");
            Message = Console.ReadLine().ToLower();
            if (Message.Contains("set"))
            {
                Console.WriteLine("Enter temperature value: ");
                int setTemp;
                if (Int32.TryParse(Console.ReadLine(), out setTemp)) ;
                sameDevice.SetTemp(setTemp);
            }
            else if (Message.Contains("increase")) { sameDevice.IncrTemp(); }
            else if (Message.Contains("decrease")) { sameDevice.DecrTemp(); }
            else { Console.WriteLine("Nonexistent command"); }
        }
        public void ControlWithLightable(ILightable samedevice)
        {
            Console.WriteLine("Setting brightness. \n\nAvailable commands: \n-Din. \n-Medium. \n-Bright. \n\nEnter your command:");
            Message = Console.ReadLine().ToLower();
            switch (Message)
            {
                case "dim":
                    samedevice.SetBrightnes("dim");
                    break;
                case "medium":
                    samedevice.SetBrightnes("medium");
                    break;
                case "bright":
                    samedevice.SetBrightnes("bright");
                    break;
                default:
                    samedevice.SetBrightnes("off");
                    break;

            }
        }
        public void ControlWithVolumeable(IVolumeable sameDevice)
        {
            bool adjVol = true;
            while (adjVol)
            {
                Console.WriteLine("Увеличить звук нажмите - 1, уменьшить нажмите - 2, выход - любая клавиша");
                char keySound = Console.ReadKey().KeyChar;
                switch (keySound)
                {
                    case '1':
                        sameDevice.SetVolume(true);
                        Console.WriteLine("\nЗвук увеличен на 1");
                        break;
                    case '2':
                        sameDevice.SetVolume(false);
                        Console.WriteLine("\nЗвук уменьшен на 1");
                        break;
                    default:
                        adjVol = false;
                        break;
                }
            }
        }

        public void GetListOfAvailableModes(IModeable sameDevice)
        {
            Type t = sameDevice.GetType();
            PropertyInfo[] pI = t.GetProperties();
            Type t2 = t;
            foreach (PropertyInfo p in pI)
            {
                if ((Convert.ToString(p.PropertyType)).ToLower().Contains("mode"))
                { t2 = p.PropertyType; }

            }
            if (t2 != t)
            {
                FieldInfo[] t2Fields = t2.GetFields();
                Console.WriteLine("list of available modes: ");
                foreach (MemberInfo m in t2Fields)
                {
                    if (!m.Name.Contains("__"))
                        Console.WriteLine(m.Name);
                }
            }

        }

        public void ControlWithModeable(IModeable sameDevice)
        {
            Console.WriteLine("Mode setting.");
            GetListOfAvailableModes(sameDevice);
            string settingMode = Console.ReadLine().ToLower();
            try
            {
                sameDevice.SetMode(settingMode);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            if (actWithDevice != null)
            {
                actWithDevice.Invoke(sameDevice.SetMode(settingMode));
            }

        }
    }
}
