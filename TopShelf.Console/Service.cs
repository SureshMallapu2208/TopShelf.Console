using System.ServiceProcess;
using Topshelf;
using TopShelf.Console;

namespace TopShelf.Console
{
    internal class Service : ServiceControl
    {

        public bool Start(HostControl hostControl)
        {
            WriteToFile("Service started. Timestamp " + DateTime.Now);
            return true; 
        }

        public bool Stop(HostControl hostControl)
        {
            WriteToFile("Service stopped. Timestamp " + DateTime.Now);
            return true;
        }

        public void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\LocalLog\\Log_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.   
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}

//.ConstructUsing(s => new Service());
//service.WhenStarted(s => s.Start());
//service.WhenStopped(s => s.Stop());
