using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace WCFContract
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        //WebGet only relevant to webhttpBinding 
        [WebGet]
        double AddNumber(double dblX, double dblY);
        [OperationContract]
        [WebGet]
        double SubtractNumber(double dblX, double dblY);
        [OperationContract]
        [WebGet]
        double MultiplyNumber(double dblX, double dblY);
        [OperationContract]
        //This is post
        [WebGet]
        double DivideNumber(double dblX, double dblY);
    }
}
