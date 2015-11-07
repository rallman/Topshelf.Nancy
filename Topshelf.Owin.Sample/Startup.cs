using Owin;

namespace Topshelf.Owin.Sample
{
   public class Startup
   {
      public void Configuration(IAppBuilder app)
      {
         app.UseNancy();
      }
   }
}
