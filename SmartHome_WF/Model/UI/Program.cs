using NewSmartHome.DeviceClasses;
using NewSmartHome.DeviceInterfaces;
using NewSmartHome.Interfaces;
using NewSmartHome.ServiceClasses;
using NewSmartHome.UI;
using Refrigerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome
{
    class Program
    {


        static void Main(string[] args)
        {
            DeviceCreator myDCreator = new DeviceCreator();
            ConsoleUIDevice myUI = new ConsoleUIDevice();
            FileOperations fOp = new FileOperations();


            Dictionary<string, Device> smartHoseDevices = new Dictionary<string, Device>();

            smartHoseDevices.Add("nord", myDCreator.CreateDevice("fridge"));

            smartHoseDevices.Add("mitsubishi", myDCreator.CreateDevice("conditioner"));

            smartHoseDevices.Add("spidola", myDCreator.CreateDevice("radio"));

            smartHoseDevices.Add("indesit", myDCreator.CreateDevice("oven"));

            smartHoseDevices.Add("siemens", myDCreator.CreateDevice("mwoven"));

            smartHoseDevices.Add("seiko", myDCreator.CreateDevice("radiolamp"));

            while (true)
            {//while (true)
                Console.WriteLine("Манипуляции с выключенными устройствами НЕВОЗМОЖНЫ!\nПроверяйте статус устройства.");
                foreach (var s in smartHoseDevices)
                {
                    Console.WriteLine(s.Key + "-" + s.Value);

                }
                Console.WriteLine();
                Console.Write("Enter command: ");

                string[] commands = Console.ReadLine().ToLower().Split(' ');


                switch (commands[0])
                {

                    case "file":
                        SaveLoadMenu(smartHoseDevices);
                        break;

                    case "exit":

                        return;

                    case "add":
                        try
                        {
                            smartHoseDevices.Add(commands[1], myDCreator.CreateDevice(commands[2]));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey();
                        }
                        break;
                    case "del":
                        smartHoseDevices.Remove(commands[1]);
                        break;

                    case "power":
                        var res = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res)
                        { device.Value.Power(); }
                        break;

                    case "modework":
                        var res1 = smartHoseDevices.Where(s => s.Key == commands[1] && s.Value is IModeable);
                        foreach (var device in res1)
                        {
                            myUI.ControlWithModeable((IModeable)device.Value);

                        }//тут неясно как сообщить о несуществующем интерфейсе
                        break;

                    case "controlvolume":
                        var res2 = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res2)
                        {
                            if (device.Value is IVolumeable)
                            {
                                myUI.ControlWithVolumeable((IVolumeable)device.Value);
                            }
                            else
                            {
                                Console.WriteLine("Device does not have such a function!\nPress any key");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "controlchannel":
                        var res3 = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res3)
                        {
                            if (device.Value is IChannelable)
                            {
                                myUI.ControlWithIChannelable((IChannelable)device.Value);
                            }
                            else
                            {
                                Console.WriteLine("Device does not have such a function!\nPress any key");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "controltemp":
                        var res4 = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res4)
                        {
                            if (device.Value is IFridgeable)
                            {
                                myUI.ControlWithFridgeable((IFridgeable)device.Value);
                            }
                            else
                            {
                                Console.WriteLine("Device does not have such a function!\nPress any key");
                                Console.ReadKey();
                            }
                        }
                        break;

                    case "controlbrightness":
                        var res5 = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res5)
                        {
                            if (device.Value is ILightable)
                            {
                                myUI.ControlWithLightable((ILightable)device.Value);
                            }
                            else
                            {
                                Console.WriteLine("Device does not have such a function!\nPress any key");
                                Console.ReadKey();
                            }
                        }
                        break;


                    case "door":
                        var res6 = smartHoseDevices.Where(s => s.Key == commands[1]);
                        foreach (var device in res6)
                        {
                            if (device.Value is IDoorable)
                            {
                                myUI.ControlWithIDoorable((IDoorable)device.Value);
                            }
                            else
                            {
                                Console.WriteLine("Device does not have such a function!\nPress any key");
                                Console.ReadKey();
                            }
                        }
                        break;




                    default:
                        Help();
                        break;

                }


            }//while (true)
        }
        private static void Help()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Доступные типы устройств:");
            Console.WriteLine("fridge, conditioner, radio, radiolamp, oven, mwoven");
            Console.WriteLine("**********************");
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tAdd NameOfDevice TypeOfDevice");
            Console.WriteLine("\tDel NameOfDevice");
            Console.WriteLine("\tPower NameOfDevice");

            Console.WriteLine("\tModeWork NameOfDevice");
            Console.WriteLine("\tControlVolume NameOfDevice");
            Console.WriteLine("\tControlChannel NameOfDevice");
            Console.WriteLine("\tControlTemp NameOfDevice");
            Console.WriteLine("\tControlBrightness NameOfDevice");
            Console.WriteLine("\tDoor NameOfDevice");

            Console.WriteLine("\tFile(save or load)");
            Console.WriteLine("\tExit");
            Console.WriteLine("Press any key for continue");
            Console.ReadKey();
        }

        static void SaveLoadMenu(Dictionary<string, Device> myDict)
        {
            Console.Clear();
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter command: ");
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "save":
                        FileOperations.SaveBinaryFormat(myDict, "SmartHouse.dat");
                        return;
                    case "load":
                        FileOperations.LoadFromBynaryFormat("SmartHouse.dat");
                        foreach (var r in myDict)
                        {
                            Console.WriteLine(r);
                        }
                        return;
                    case "exit":
                        return;
                    default:
                        SaveLoadHelp();
                        break;
                }
            }

        }
        private static void SaveLoadHelp()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\tSave Binary");
            Console.WriteLine("\tLoad Bimary");
            Console.WriteLine("\tSOAP - в разработке");
            Console.WriteLine("\tXML - в разработке");
            Console.WriteLine("\texit");
            Console.WriteLine("Press any key for continue");
            Console.ReadKey();

        }



    }

}

