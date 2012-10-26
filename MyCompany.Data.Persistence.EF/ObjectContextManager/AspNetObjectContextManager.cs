using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.EntityClient;
using System.Data.Objects;

namespace MyCompany.Data.Persistence.EF.ObjectContextManager
{
    public sealed class AspNetObjectContextManager
    {
        public AspNetObjectContextManager(string connectionString)
        {

            if (!System.Web.HttpContext.Current.Items.Contains("ObjectContext"))
            {
                // build the connection string
                EntityConnectionStringBuilder entityConnectionStringBuilder
                    = new EntityConnectionStringBuilder();
                entityConnectionStringBuilder.ConnectionString
                    = connectionString;
                entityConnectionStringBuilder.Metadata =
                    @"res://*/NorthwindDB.csdl|res://*/NorthwindDB.ssdl|res://*/NorthwindDB.msl";

                ObjectContext objectContext = new ObjectContext(
                    new EntityConnection(entityConnectionStringBuilder.ToString()));

                System.Web.HttpContext.Current.Items.
                    Add("ObjectContext", objectContext);

            }
        }

        public ObjectContext GetObjectContext()
        {
            if (System.Web.HttpContext.Current.Items.Contains("ObjectContext"))
            {
                return (ObjectContext)(System.Web.HttpContext.Current.Items["ObjectContext"]);
            }
            else
            {
                throw new Exception("Can not find Object context");
            }
        }


    }
}
