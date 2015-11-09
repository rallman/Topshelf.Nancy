using System;
using Microsoft.Owin.Hosting;
using Topshelf.Logging;

namespace Topshelf.Owin
{
   internal class OwinService
   {
      //todo:wire in reservations and firewall rules
      //private NancyHost NancyHost { get; set; }
      //private HostConfiguration NancyHostConfiguration { get; set; }

      private OwinServiceConfiguration OwinConfiguration { get; set; }
      private IDisposable webApp;

      private static readonly LogWriter Logger = HostLogger.Get(typeof (OwinService));
      //private UrlReservationsHelper _urlReservationsHelper;

      public void Configure(OwinServiceConfiguration nancyServiceConfiguration)
      {
         OwinConfiguration = nancyServiceConfiguration;
      }
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
         //todo:use configuration for url(s?)
         //todo:figure out how to specify the "Startup" in WebApp.Start<Startup>(url)
         Logger.Info("[Topshelf.Owin] Starting OWIN");
         var url = "http://+:8080"; //OwinConfiguration.Uris.First().ToString();
         webApp = WebApp.Start(url);
         Logger.Info("[Topshelf.Owin] OWIN started");
      }

      public void Stop()
      {
         Logger.Info("[Topshelf.Owin] Stopping OWIN");
         webApp?.Dispose();
         Logger.Info("[Topshelf.Owin] OWIN stopped");
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
   }
}
