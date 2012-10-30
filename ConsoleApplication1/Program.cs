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
            List<string> backup_paths = new List<string>();
            //Break this into a separate function
            SelectQuery query = new SelectQuery("Win32_UserAccount");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            
            //Break this into a separate function
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
                    {
                        backup_paths.Add(item.FullName);
                        Console.WriteLine(item.FullName);
                        //Console.WriteLine(backup_paths[0]);
                        foreach (FileInfo f in item.GetFiles())
                        {
                            Console.WriteLine(f.FullName);
                        }

                    }

                }
                 Console.ReadKey(true);

            }
        }
    }
}
