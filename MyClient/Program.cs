using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using System.Diagnostics;

using MyProduct;


namespace MyClient
{
    class Program
    {
        static void Main(string[] args)
        {


            try
            {
                ChannelServices.RegisterChannel(new TcpChannel(), false);
                IProduct iProduct = (IProduct)(Activator.GetObject(typeof(IProduct),
                                    "tcp://localhost:9999/IProduct"));

              

                AssemblyContainer container = iProduct.GetAssembly();
                string assemblyName = container.AssemblyName;
               

                if (File.Exists(assemblyName))
                {
                    FileVersionInfo fileVersion = FileVersionInfo.GetVersionInfo(assemblyName);
                    if(fileVersion.FileVersion.Equals(container.Version)==false)
                    {
                        File.Delete(assemblyName);
                        File.WriteAllBytes(assemblyName, container.Bytes);
                    }
                }
                else
                {
                    File.WriteAllBytes(assemblyName, container.Bytes);
                }

                IAddPointBuild pontBuilder = iProduct.GetBuilder();

                int point = pontBuilder.CalculateAddPoint(10000, 3, 0.5m);
                Console.WriteLine($"Point : {point}");
                      
                Console.Read();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();

            }

        }
    }
}
