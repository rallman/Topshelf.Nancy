using System;
using Topshelf.ServiceConfigurators;
using Topshelf.HostConfigurators;

namespace Topshelf.Owin
{
   public static class OwinServiceConfiguratorExtensions
   {
      public static ServiceConfigurator<T> WithOwinEndpoint<T>(this ServiceConfigurator<T> configurator,
         HostConfigurator hostconfigurator, Action<OwinServiceConfiguration> owinConfigurator) where T : class
      {
         var owinServiceConfiguration = new OwinServiceConfiguration();

         owinConfigurator(owinServiceConfiguration);

         var owinService = new OwinService();

         owinService.Configure(owinServiceConfiguration);

         configurator.AfterStartingService(t => owinService.Start());

         configurator.BeforeStoppingService(t => owinService.Stop());

         hostconfigurator.BeforeInstall(x => owinService.BeforeInstall());

         hostconfigurator.BeforeUninstall(owinService.BeforeUninstall);

         return configurator;
      }
   }
}