using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {   
           CallMyService(); 
        }

        private static void CallRestService()
        {
            //Connect to api/RestService 

            Uri baseAddress = new Uri("http://localhost:58788/api/RestService");
            //WebChannelFactory  WebHttpBehavior,  WebHttpBinding
            WebChannelFactory<IRestService> cf = new WebChannelFactory<IRestService>(baseAddress);
            IRestService service = cf.CreateChannel();
            Person person = service.GetPerson("1");
        }

        private static void CallMyService()
        {
            //Connect to api/MyService 

             BasicHttpBinding myBinding = new BasicHttpBinding();

             EndpointAddress myEndpoint = new EndpointAddress("http://localhost:58788/api/MyService");
            //ChannelFactory  basicHttpBinding
            ChannelFactory<IMyService> cf = new ChannelFactory<IMyService>(
              myBinding, myEndpoint);

            IMyService service = cf.CreateChannel();
            Person person = service.GetPerson("1");
        }
    }
}
