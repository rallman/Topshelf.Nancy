using Microsoft.Owin.Hosting;
using Topshelf.Nancy;
using Topshelf.Owin;

namespace Topshelf.Owin.Sample
{
    class Program
    {
        static void Main()
        {
           //var webApp = WebApp.Start<Startup>("http://+:8080");
            var host = HostFactory.New(x =>
            {
                x.UseNLog();
                
                x.Service<SampleService>(s =>
                {
                    s.ConstructUsing(settings => new SampleService());
                    s.WhenStarted(service => service.Start());
                    s.WhenStopped(service => service.Stop());
                    s.WithOwinEndpoint(x, c =>
                    {
                       c.WithStartup(typeof (Startup));
                       c.AddHost();
                       
                       //c.WithStartup<Startup>();
                       //c.Url("http://+:8080");
                       //c.AddHost(port: 8080);
                       //c.AddHost(port: 8081);
                       //c.CreateUrlReservationsOnInstall();
                       //c.OpenFirewallPortsOnInstall(firewallRuleName: "topshelf.owin.sampleservice");
                    });
                });
                x.StartAutomatically();
                x.SetServiceName("topshelf.owin.sampleservice");
                x.SetDisplayName("Topshelf.Owin.SampleService");
                x.SetDescription("Sample Service for the Topshelf.Owin project");
                x.RunAsNetworkService();
            });

            host.Run();
        }
    }
}
