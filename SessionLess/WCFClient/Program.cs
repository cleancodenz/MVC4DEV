using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using WCFContract;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to consume service...");
            Console.ReadLine();
            // ConsumeBasicHTTPService();
            // ConsumeWSTTPService();
            // ConsumeWebHTTPService();
            // ConsumeIISWSTTPService();
            ConsumeSecuredIISWSTTPService();
            Console.ReadLine();
        }

        private static void ConsumeBasicHTTPService()
        {
            ChannelFactory<IMathService>
                channelFactory = null;
            EndpointAddress ep = null;

            string strAdr = "http://localhost" + "/MathService";

            try
            {
                BasicHttpBinding httpb = new BasicHttpBinding();
                channelFactory = new ChannelFactory<IMathService>(httpb);

                // Create End Point
                ep = new EndpointAddress(strAdr);

                // Create Channel
                IMathService mathService = channelFactory.CreateChannel(ep);

                double dblResult = 0;
                double dblVal1 = 1.2f;
                double dblVal2 = 2.3f;

                dblResult = mathService.AddNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));
                channelFactory.Close();
            }
            catch (Exception eX)
            {
                // Something unexpected happended .. 
                Console.WriteLine("Error while performing operation [" +
                  eX.Message + "] \n\n Inner Exception [" + eX.InnerException + "]");
            }
        }

        private static void ConsumeWSTTPService()
        {
            ChannelFactory<IMathService>
                channelFactory = null;
            EndpointAddress ep = null;

            string strAdr = "http://localhost" + "/MathService";

            try
            {
                WSHttpBinding httpb = new WSHttpBinding();
                channelFactory = new ChannelFactory<IMathService>(httpb);

                // Create End Point
                ep = new EndpointAddress(strAdr);

                // Create Channel
                IMathService mathService = channelFactory.CreateChannel(ep);

                double dblResult = 0;
                double dblVal1 = 1.2f;
                double dblVal2 = 2.3f;

                dblResult = mathService.AddNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));
                channelFactory.Close();
            }
            catch (Exception eX)
            {
                // Something unexpected happended .. 
                Console.WriteLine("Error while performing operation [" +
                  eX.Message + "] \n\n Inner Exception [" + eX.InnerException + "]");
            }
        }

        private static void ConsumeWebHTTPService()
        {
            ChannelFactory<IMathService>
                channelFactory = null;
            EndpointAddress ep = null;

            string strAdr = "http://localhost" + "/MathService";

            try
            {
                WebHttpBinding httpb = new WebHttpBinding();
                channelFactory = new ChannelFactory<IMathService>(httpb, strAdr);

                //this must be added for webhttpbinding client
                channelFactory.Endpoint.Behaviors.Add(new WebHttpBehavior());
                // Create End Point

                // Create Channel
                IMathService mathService = channelFactory.CreateChannel();

                double dblResult = 0;
                double dblVal1 = 1.2f;
                double dblVal2 = 2.3f;

                dblResult = mathService.AddNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));

                Console.WriteLine("This can also be accomplished by navigating to");
                Console.WriteLine("http://localhost/mathservice/addnumber?dblVal1=1.2f&dblVal1=2.3f");

                dblResult = mathService.DivideNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));

                Console.WriteLine("This can also be accomplished by navigating to");
                Console.WriteLine("Post http://localhost/mathservice/addnumber?dblVal1=1.2f&dblVal1=2.3f");

                channelFactory.Close();
            }
            catch (Exception eX)
            {
                // Something unexpected happended .. 
                Console.WriteLine("Error while performing operation [" +
                  eX.Message + "] \n\n Inner Exception [" + eX.InnerException + "]");
            }
        }

        private static void ConsumeIISWSTTPService()
        {
            ChannelFactory<IMathService>
                channelFactory = null;
            EndpointAddress ep = null;

            string strAdr = "http://localhost:62760/api" + "/Math1Service";

            try
            {
                WSHttpBinding httpb = new WSHttpBinding();
                channelFactory = new ChannelFactory<IMathService>(httpb);

                // Create End Point
                ep = new EndpointAddress(strAdr);

                // Create Channel
                IMathService mathService = channelFactory.CreateChannel(ep);

                double dblResult = 0;
                double dblVal1 = 1.2f;
                double dblVal2 = 2.3f;

                dblResult = mathService.AddNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));
                channelFactory.Close();
            }
            catch (Exception eX)
            {
                // Something unexpected happended .. 
                Console.WriteLine("Error while performing operation [" +
                  eX.Message + "] \n\n Inner Exception [" + eX.InnerException + "]");
            }
        }

        private static void ConsumeSecuredIISWSTTPService()
        {
            ChannelFactory<IMathService>
                channelFactory = null;
            EndpointAddress ep = null;

           // string strAdr = "http://localhost:50625/api/Math2Service";
            string strAdr = "https://localhost:44301/api/Math2Service";
            try
            {
                WSHttpBinding httpb = new WSHttpBinding();
                httpb.Security.Mode = SecurityMode.Message;
                httpb.Security.Message.ClientCredentialType =
                   MessageCredentialType.UserName;

                channelFactory = new ChannelFactory<IMathService>(httpb);
                //  channelFactory.Credentials.UserName = "johnson";

                // step one - find and remove default endpoint behavior 
                var defaultCredentials = channelFactory.
                    Endpoint.Behaviors.Find<ClientCredentials>();
                channelFactory.Endpoint.
                    Behaviors.Remove(defaultCredentials);


                // step two - instantiate your credentials
                ClientCredentials loginCredentials = new ClientCredentials();
                loginCredentials.UserName.UserName = "johnson";
                loginCredentials.UserName.Password = "1234";


                // step three - set that as new endpoint behavior on factory
                channelFactory.Endpoint.Behaviors.Add(loginCredentials); //add required ones
                // Create End Point
                ep = new EndpointAddress(strAdr);

                // Create Channel
                IMathService mathService = channelFactory.CreateChannel(ep);

                double dblResult = 0;
                double dblVal1 = 1.2f;
                double dblVal2 = 2.3f;

                dblResult = mathService.AddNumber(dblVal1, dblVal2);


                //  Display Results.
                Console.WriteLine("Operation {0} ", strAdr);
                Console.WriteLine("Operand 1 {0} ", dblVal1.ToString("F2"));
                Console.WriteLine("Operand 2 {0} ", dblVal2.ToString("F2"));
                Console.WriteLine("Result {0} ", dblResult.ToString("F2"));
                channelFactory.Close();
            }
            catch (Exception eX)
            {
                // Something unexpected happended .. 
                Console.WriteLine("Error while performing operation [" +
                  eX.Message + "] \n\n Inner Exception [" + eX.InnerException + "]");
            }
        }
    }
}
