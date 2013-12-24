using ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFClientAndServer.Services
{
    
    public class RestService :IRestService
    {
       public Person GetPerson(string personId)
        {
            return new Person
            {
                ID = personId
            };
        }
    }
}