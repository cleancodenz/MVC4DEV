using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace ServiceContract
{
    [ServiceContract]
    public interface IRestService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "GetPerson/{personId}", Method = "GET")]
        //The url will be /root/prefix/GetPerson/1
        Person GetPerson(string personId);
    }
}