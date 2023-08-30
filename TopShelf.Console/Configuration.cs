using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelf.Console
{
    internal class Configuration
    {
        public static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<Service>();
                configure.SetStartTimeout(new TimeSpan(2000));
                configure.SetStopTimeout(new TimeSpan(4000));

                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("WinServiceWithTopshelf");
                configure.SetDisplayName("WinServiceWithTopshelf");
                configure.SetDescription("WinService With Topshelf");
            });
        }
    }
}
