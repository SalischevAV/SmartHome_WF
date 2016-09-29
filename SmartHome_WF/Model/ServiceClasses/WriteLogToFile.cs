using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewSmartHome.ServiceClasses
{
    public class WriteLogToFile
    {
        static public void WriteLog (string actWithDevice)
        {
            using (StreamWriter sr = new StreamWriter("log.txt", true, Encoding.Default))
            {
                sr.Write(DateTime.Now + ">>>" + actWithDevice + ";");
            }
        }
    }
}
