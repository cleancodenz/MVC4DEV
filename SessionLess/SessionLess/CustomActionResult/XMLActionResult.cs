using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionLess.CustomActionResult
{
    public class XMLActionResult :
        ActionResult
    {
        // no need to register
        public override void ExecuteResult(ControllerContext context)
        {
            /**
          context.HttpContext.Response.ContentType = "text/xml"; 
          context.HttpContext.Response.AddHeader("content-disposition", 
            string.Format("attachment; filename={0}", FileName));
           
        
            context.HttpContext.Response.BinaryWrite(
                  System.Text.UTF8Encoding.Default.GetBytes(xmldoc.OuterXml));           
        
         context.HttpContext.Response.End();
             **/
        }
    }
}