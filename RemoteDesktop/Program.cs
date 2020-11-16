using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteDesktop
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Console.WriteLine("arguments passed to main method are" +  args[0] +   " close connection" +  args[1]);
            RemoteDesktop remoteDesktop = new RemoteDesktop();
            remoteDesktop.RemoteDesktopMachines();
        }
    }
}
