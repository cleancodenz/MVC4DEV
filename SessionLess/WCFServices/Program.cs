using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace WCFServices
{
    class Program
    {
        static void Main(string[] args)
        {
          //  StartBasicHTTPService();
          //  StartWSHTTPService();
            StartWebHTTPService(); 
            Console.ReadLine();
        }

        // Creating a service
        //For each endpoint, you specify an address, a binding, and a contract. 

        /**
         * Binding Class Name	Transport	Message Encoding	Message Version	Security Mode	Reliable Messaging	Transaction Flow (disabled by default)
                BasicHttpBinding	HTTP	Text	SOAP 1.1	None	Not Supported	Not Supported
         * 
         * Security mode :Transport, Message, Mixed
         * 
         *   SOAP 
         **/

        private static void StartBasicHTTPService()
        {
            string strAdr = "http://localhost" + "/MathService";
            ServiceHost serviceHost; 
            try
            {
                Uri adrbase = new Uri(strAdr);

                serviceHost = new ServiceHost(typeof(MathService),adrbase);

                /**
                ServiceMetadataBehavior mBehave = new ServiceMetadataBehavior();
                m_svcHost.Description.Behaviors.Add(mBehave);
                m_svcHost.AddServiceEndpoint(typeof(IMetadataExchange),
                  MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                **/

                BasicHttpBinding httpBinding = new BasicHttpBinding();
                serviceHost.AddServiceEndpoint(typeof(IMathService), httpBinding, strAdr);
                serviceHost.Open();
                Console.WriteLine("\n\nService on BasicHttp Binding is Running as >> " + strAdr);
            
            }
            catch (Exception eX)
            {
                serviceHost = null;
                Console.WriteLine("Service can not be started as >> [" +
                  strAdr + "] \n\nError Message [" + eX.Message + "]");
            }
        }

        //WSHttpBinding	HTTP	Text	SOAP 1.2 WS-Addressing 1.0	Message	Disabled	WS-AtomicTransactions

        /**
         * Then there’s WSHttpBinding. This was also designed for interoperability while incorporating 
         * the richer Web services protocols for security, reliable messaging, and transactions. 
         * As a result, WSHttpBinding also uses HTTP for the transport and text for the message encoding, 
         * but it uses SOAP 1.2 along with WS-Addressing 1.0 for the message version—they are needed to 
         * carry the additional Web services protocol headers. The binding enables message-based security 
         * (via WS-Security and friends) and is capable of supporting WS-ReliableMessaging and 
         * WS-AtomicTransactions if you choose to enable them. WSHttpBinding produces a more sophisticated 
         * channel stack and will most likely be constrained to enterprise scenarios where integration 
         * across frameworks and platforms is required.
         * 
         * 
         *  Security mode :Transport, Message, Mixed
         *   SOAP 
         */
        private static void StartWSHTTPService()
        {
            string strAdr = "http://localhost" + "/MathService";
            ServiceHost serviceHost;
            try
            {
                Uri adrbase = new Uri(strAdr);

                serviceHost = new ServiceHost(typeof(MathService), adrbase);

                WSHttpBinding wsHttpBinding = new WSHttpBinding();
                serviceHost.AddServiceEndpoint(typeof(IMathService), wsHttpBinding, strAdr);
                serviceHost.Open();
                Console.WriteLine("\n\nService on WSHttpBinding is Running as >> " + strAdr);

            }
            catch (Exception eX)
            {
                serviceHost = null;
                Console.WriteLine("Service can not be started as >> [" +
                  strAdr + "] \n\nError Message [" + eX.Message + "]");
            }
        }

        // WebHttpBinding, REST based
        /**
         * If you do not add an endpoint, WebServiceHost automatically creates a default endpoint. WebServiceHost also adds WebHttpBehavior and disables the HTTP Help page and the Web Services Description Language (WSDL) GET functionality so the metadata endpoint does not interfere with the default HTTP endpoint.
         * Adding a non-SOAP endpoint with a URL of "" causes unexpected behavior when an attempt is made to call an operation on the endpoint. The reason for this is the listen URI of the endpoint is the same as the URI for the help page (the page that is displayed when you browse to the base address of a WCF service).
         * 
         * 
         * */

        private static void StartWebHTTPService()
        {
            string strAdr = "http://localhost" + "/MathService";
            WebServiceHost webServiceHost;
            try
            {
                Uri adrbase = new Uri(strAdr);

                webServiceHost = new WebServiceHost(typeof(MathService), adrbase);

                //To disable help page to avoid interference with normal http get
 
                ServiceDebugBehavior sdb = webServiceHost.Description.Behaviors.Find<ServiceDebugBehavior>();
                sdb.HttpHelpPageEnabled = false;

                WebHttpBinding webHttpBinding = new WebHttpBinding();
                webServiceHost.AddServiceEndpoint(typeof(IMathService), webHttpBinding, "");
                webServiceHost.Open();
                Console.WriteLine("\n\nService on WebHttpBinding is Running as >> " + strAdr);

            }
            catch (Exception eX)
            {
                webServiceHost = null;
                Console.WriteLine("Service can not be started as >> [" +
                  strAdr + "] \n\nError Message [" + eX.Message + "]");
            }
        }

    }
}
