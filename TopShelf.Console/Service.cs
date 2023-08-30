using Microsoft.Win32;
using System;
using System.Timers;
using System.IO;
using System.Linq;

namespace TopShelf.Console
{
    internal class Service 
    {

        private readonly System.Timers.Timer _timer;
        public Service()
        {
            _timer = new System.Timers.Timer(2000) { AutoReset = true };
            _timer.Elapsed += ExecuteEvent;
        }
        public void Stop()
        {
            _timer.Stop();
        }
        public void Start()
        {
            _timer.Start();
        }

        private void ExecuteEvent(object sender, ElapsedEventArgs e)
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
                    sw.WriteLine("Service Running :" + DateTime.Now.ToString());
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine("Service Running :" + DateTime.Now.ToString());
                }
            }
        }
    }
}
