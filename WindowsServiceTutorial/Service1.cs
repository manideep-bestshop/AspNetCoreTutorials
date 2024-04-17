using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;


namespace WindowsServiceTutorial
{
    public partial class Service1 : ServiceBase
    {
        
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("Service started at Here.." + DateTime.Now);
        }

        protected override void OnStop()
        {
            WriteToFile("Service stopped at Here.. "+DateTime.Now);
        }
        private void OnElapsedTime(object source,ElapsedEventArgs e)
        {
            WriteToFile("Service recall at Here.." + DateTime.Now);
        }
        public void WriteToFile(string messsage)
        {
            string path = AppContext.BaseDirectory + "\\Logs";
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\SericeLog" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if(!File.Exists(filepath))
            {
                // create a file to write
                using(StreamWriter sw=File.CreateText(filepath))
                {
                    sw.WriteLine(messsage);
                }
             
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(messsage);
                }
            }
        }
    }
}
