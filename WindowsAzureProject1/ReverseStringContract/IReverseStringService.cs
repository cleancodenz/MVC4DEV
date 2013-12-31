using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringContract
{
    [ServiceContract]
    public interface IReverseStringService
    {
        [OperationContract]
        string ReverseString(string s);
    }
}
