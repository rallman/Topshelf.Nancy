using Nancy;

namespace Topshelf.Owin.Sample
{
   public class SampleNancyModule : NancyModule
   {
      public SampleNancyModule()
      {
         Get["/status"] = _ => "Owin is alive!";

         Get["/"] = _ => View["index.html"];
      }
   }
}