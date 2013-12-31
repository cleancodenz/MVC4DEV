using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using System.ServiceModel;

namespace WCFReverseString
{
    public class WorkerRole : RoleEntryPoint
    {
        private ServiceHost serviceHost;

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("WCFReverseString entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            StartService(3);

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.
            RoleEnvironment.Changing += RoleEnvironmentChanging;


            return base.OnStart();

        }

        public override void OnStop()
        {
            StopService();

            base.OnStop();
        }
        private void StartService(int retries)
        {
            if (retries == 0)
            {
                RoleEnvironment.RequestRecycle();
                return;
            }

            Uri httpUri = new Uri(String.Format("http://{0}/{1}",
                                RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["HttpIn"].IPEndpoint.ToString(),
                                "ReverseString"));

            serviceHost = new ServiceHost(typeof(ReverseStringServiceimplement.
                ReverseStringServiceImplement), httpUri);

            serviceHost.Faulted += (sender, e) =>
            {
                Trace.TraceError("Host fault occured. Aborting and restarting the host. Retry count: {0}", retries);

                serviceHost.Abort();
                StartService(--retries);
            };

            try
            {
                Trace.TraceInformation("Trying to open service host");
                serviceHost.Open();
                Trace.TraceInformation("Service host started successfully.");

            }
            catch (TimeoutException timeoutException)
            {
                Trace.TraceError("The service operation time out. {0}",
                            timeoutException.Message);

            }
            catch (CommunicationException communicationException)
            {
                Trace.TraceError("Could not start service host. {0}",
                     communicationException.Message);
            }


        }

        private void StopService()
        {
            if (serviceHost != null)
            {
                try
                {
                    serviceHost.Close();
                }
                catch (TimeoutException timeoutException)
                {
                    Trace.TraceError("The service close time out. {0}",
                                timeoutException.Message);

                    serviceHost.Abort();
                }
                catch (CommunicationException communicationException)
                {
                    Trace.TraceError("Could not close service host. {0}",
                         communicationException.Message);

                    serviceHost.Abort();
                }
            }
        }

        private void RoleEnvironmentChanging(object sender, RoleEnvironmentChangingEventArgs e)
        {
            if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange))
            {
                e.Cancel = true;
            }
        }
    }
}
