using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            foreach (ManagementObject envVar in searcher.Get())
            {
                 Console.WriteLine("Username : {0}", envVar["Name"]);
                String dirname = "C:\\Users\\"+ envVar["Name"] +"\\AppData\\Roaming\\Apple Computer\\MobileSync\\Backup";
                if (Directory.Exists(dirname))
                {
                    Console.WriteLine("{0} has iPhone backups", envVar["Name"]);
                    DirectoryInfo di = new DirectoryInfo(dirname);
                    DirectoryInfo[] dirinfo = di.GetDirectories();
                    foreach (DirectoryInfo item in dirinfo)

                        Console.WriteLine(item.FullName);
                    

                }
                 Console.ReadKey(true);

            }
        }
    }
}
