using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

using Spring.Context;

using MyProduct;
using Spring.Context.Support;

namespace DotNetRemoting
{
    class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                TcpServerChannel channel = new TcpServerChannel(9999);
                ChannelServices.RegisterChannel(channel, false);
                RemotingConfiguration.RegisterWellKnownServiceType(typeof(ProductServer), "IProduct"
                , WellKnownObjectMode.SingleCall);

                Console.WriteLine($"server is running....{System.Threading.Thread.CurrentThread.ManagedThreadId.ToString()}" );
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
