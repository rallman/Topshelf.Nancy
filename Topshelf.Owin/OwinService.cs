using System;
using System.Linq;
using Microsoft.Owin.Hosting;
using Nancy;
//using Nancy.Hosting.Self;
using Topshelf.Logging;

namespace Topshelf.Nancy
{
    internal class OwinService
   {
        //private NancyHost NancyHost { get; set; }

        //private HostConfiguration NancyHostConfiguration { get; set; }

        private OwinServiceConfiguration OwinConfiguration { get; set; }
       private IDisposable webApp;

        private static readonly LogWriter Logger = HostLogger.Get(typeof(OwinService));
        //private UrlReservationsHelper _urlReservationsHelper;

        //public NancyHost Configure(OwinServiceConfiguration nancyServiceConfiguration)
        //{

        //    var nancyHostConfiguration = new HostConfiguration();

        //    if (nancyServiceConfiguration.NancyHostConfigurator != null)
        //    {
        //        nancyServiceConfiguration.NancyHostConfigurator(nancyHostConfiguration);
        //    }

        //    NancyServiceConfiguration = nancyServiceConfiguration;
        //    NancyHostConfiguration = nancyHostConfiguration;

        //    _urlReservationsHelper = new UrlReservationsHelper(NancyServiceConfiguration.Uris, NancyHostConfiguration);

        //    if (NancyServiceConfiguration.Bootstrapper != null) {
        //        NancyHost = new NancyHost(NancyServiceConfiguration.Bootstrapper, NancyHostConfiguration, NancyServiceConfiguration.Uris.ToArray());
        //    } else {
        //        NancyHost = new NancyHost(NancyHostConfiguration, NancyServiceConfiguration.Uris.ToArray());
        //    }

        //    return NancyHost;
        //}

        public void Start()
        {
            Logger.Info("[Topshelf.Nancy] Starting NancyHost");
           var url = "http://+:8080"; //OwinConfiguration.Uris.First().ToString();
           webApp = WebApp.Start(url);
        //    NancyHost.Start();
            Logger.Info("[Topshelf.Nancy] NancyHost started");
        }

        public void Stop()
        {
            Logger.Info("[Topshelf.Nancy] Stopping NancyHost");
        //    NancyHost.Stop();
           webApp?.Dispose();
           Logger.Info("[Topshelf.Nancy] NancyHost stopped");
        }

        public void BeforeInstall()
        {
        //    if (NancyServiceConfiguration.ShouldCreateUrlReservationsOnInstall)
        //    {
        //        _urlReservationsHelper.TryDeleteUrlReservations();
        //        if (NancyServiceConfiguration.ShouldOpenFirewallPorts)
        //        {
        //            var ports = NancyServiceConfiguration.Uris.Select(x => x.Port).ToList();
        //            _urlReservationsHelper.OpenFirewallPorts(ports, NancyServiceConfiguration.FirewallRuleName);
        //        }
        //        _urlReservationsHelper.AddUrlReservations();
        //    }
        }

        public void BeforeUninstall()
        {
        //    if (NancyServiceConfiguration.ShouldDeleteReservationsOnUnInstall)
        //    {
        //        _urlReservationsHelper.TryDeleteUrlReservations();
        //    }
        }

       public void Configure(OwinServiceConfiguration nancyServiceConfiguration)
       {
          OwinConfiguration = nancyServiceConfiguration;
       }
   }
}
