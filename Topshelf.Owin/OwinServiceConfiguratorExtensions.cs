using System;
using Topshelf.ServiceConfigurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Nancy
{
    public static class OwinServiceConfiguratorExtensions
   {
        public static ServiceConfigurator<T> WithOwinEndpoint<T>(this ServiceConfigurator<T> configurator, HostConfigurator hostconfigurator, Action<OwinServiceConfiguration> owinConfigurator) where T : class
        {
            var nancyServiceConfiguration = new OwinServiceConfiguration();

            owinConfigurator(nancyServiceConfiguration);

            var nancyService = new OwinService();

            nancyService.Configure(nancyServiceConfiguration);

            configurator.AfterStartingService(t => nancyService.Start());

            configurator.BeforeStoppingService(t => nancyService.Stop());

            hostconfigurator.BeforeInstall(x => nancyService.BeforeInstall());

            hostconfigurator.BeforeUninstall(nancyService.BeforeUninstall);

            return configurator;
        }
    }
}