using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace SessionLess
{
    public class HelloWorldModule :IHttpModule
    {
        public String ModuleName
        {
            get { return "HelloWorldModule"; }
        }    

        public void Dispose()
        {
            
        }

        public void Init(HttpApplication context)
        {
            /**
            using context.AddOnAcquireRequestStateAsync() to add async processing of httpmodule
             * 
             * EventHandlerTaskAsyncHelper helper =
new EventHandlerTaskAsyncHelper(ScrapePage);
context.AddOnPostAuthorizeRequestAsync(
helper.BeginEventHandler, helper.EndEventHandler);
             * 
             **/

            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
            context.EndRequest += (new EventHandler(this.Application_EndRequest));    
        }

        // Your BeginRequest event handler.
        private void Application_BeginRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<h1><font color=red>HelloWorldModule: Beginning of Request</font></h1><hr>");
        }

        // Your EndRequest event handler.
        private void Application_EndRequest(Object source, EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;
            context.Response.Write("<hr><h1><font color=red>HelloWorldModule: End of Request</font></h1>");
        }

        private async Task ScrapePage(object caller, EventArgs e)
        {
            WebClient webClient = new WebClient();
            var downloadresult = await webClient.DownloadStringTaskAsync("http://www.msn.com");
        }

    }
}