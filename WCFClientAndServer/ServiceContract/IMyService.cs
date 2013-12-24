using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContract
{
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        //The url will be /root/prefix/GetPerson/1
        Person GetPerson(string personId);
    }
}
