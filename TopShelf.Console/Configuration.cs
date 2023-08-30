using System;
using Topshelf;

namespace TopShelf.Console
{
    internal static class Configuration
    {
        public static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<Service>(service =>
                {
                    service.ConstructUsing(s => new Service());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName("WinServiceWithTopshelf");
                configure.SetDisplayName("WinServiceWithTopshelf");
                configure.SetDescription("WinService With Topshelf");
                configure.EnableServiceRecovery(r => r.RestartService(TimeSpan.FromSeconds(10)));
                configure.StartAutomatically();
            });
        }
    }
}
