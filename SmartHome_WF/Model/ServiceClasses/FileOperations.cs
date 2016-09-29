using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Xml.Serialization;
using System.IO;
using NewSmartHome.DeviceClasses;
using NewSmartHome.ServiceClasses;

namespace Refrigerator
{
    public class FileOperations
    {
        public static Dictionary<string, Device> smartHouseDevices { get; private set; }

        public static string SaveBinaryFormat(object smartHouse, string fileName)
        {
            BinaryFormatter myBin = new BinaryFormatter();
            using (Stream myFStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                myBin.Serialize(myFStream, smartHouse);
            }
            return "Smart house save in binary format";
            

        }

        public static Dictionary<string, Device> LoadFromBynaryFormat(string fileName)
        {
            BinaryFormatter myBin = new BinaryFormatter();
            using (Stream myFStream = File.OpenRead(fileName))
            {
                Dictionary<string, Device>smartHouseDevices = (Dictionary<string, Device>)myBin.Deserialize(myFStream);
            }
            return smartHouseDevices;
        }

      
        
        public string SaveXMLFormat(List<Device> listDevice, string fileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Device>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, listDevice);
            }
            return "Smart house save in XML format";
        }
        public string SaveXMLFormat(string keysPath, string devicesPath, Dictionary<string, Device> dict)
        {
            SerializerDictionaryXML xml = new SerializerDictionaryXML(keysPath, devicesPath);
            xml.Serialaze(dict);
            return "Smart house save in XML format";

        }

        public string LoadFromXMLFormat(string fileName, List<Device> listDevice)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Device>));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                listDevice = (List<Device>)xmlSerializer.Deserialize(fs);
            }
                return "Smart house load from XML format";
        }

        public string LoadFromXMLFormat (string keysPath, string devicesPath, Dictionary<string, Device> dict)

        {
            SerializerDictionaryXML xml = new SerializerDictionaryXML(keysPath, devicesPath);
            xml.Deserialaze();
            dict = xml.deserialazeDict;
            return "Smart house load from XML format";
        }
    }
}
