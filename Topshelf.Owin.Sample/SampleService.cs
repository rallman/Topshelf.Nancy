using System;
using System.Threading;
using Microsoft.AspNet.SignalR;

namespace Topshelf.Owin.Sample
{
    public class SampleService
    {
       private Timer _timer;
        public bool Start()
        {
           if (_timer == null)
           {
              _timer = new Timer(tick, null, 1000, 1000);
           }
            return true;
        }

        public bool Stop()
        {
           _timer?.Dispose();
           return true;
        }

       private void tick(object state)
       {
          GlobalHost.ConnectionManager.GetHubContext<ClockHub>().Clients.All.Tick(DateTime.Now.ToString("s"));
       }
    }
}