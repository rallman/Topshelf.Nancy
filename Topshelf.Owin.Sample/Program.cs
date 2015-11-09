using Microsoft.Owin.Hosting;
using Topshelf.Owin;

namespace Topshelf.Owin.Sample
{
    class Program
    {
        static void Main()
        {
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
