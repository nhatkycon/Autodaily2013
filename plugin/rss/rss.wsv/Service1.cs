using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace rss.wsv
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            System.Timers.Timer time = new System.Timers.Timer();
            time.Start();
            time.Interval = 60000;
            //time.Enabled
        }

        protected override void OnStop()
        {

        }
    }
}
