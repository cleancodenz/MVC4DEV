using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Connection
{
    // This provides ObjectContext management mechanism for different type of applications
    // For Winform/WPF application
    //where the ObjectContext can be made global instances shareable for the entire lifespan of the application especially in the single threaded application 
    //The StaticObjectContextLifetimeManager caches the ObjectContext instances for the entire lifespan of the application. This means the same ObjectContext instance will be shared by the entire application until the application unloads or terminates

    // For ASP.NET
    // AspNetObjectContextLifetimeManager will ensure that the ObjectContext instances lifespan long enough to serve each Http user request and they are immediately disposed once the session of the user request ends in order to conserve web resources
    // Per ObjectContext per session or per request?
    
}
