using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace HYJHWeb.api
{
    /// <summary>
    /// getTicket 的摘要说明
    /// </summary>
    public class TicketHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "null");
            context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

            context.Response.ContentType = "text/plain";
            HttpCookieCollection cookieVals = context.Request.Cookies;

            HttpCookie sessionCookie = cookieVals.Get("ASP.NET_SessionId");

            if(sessionCookie != null)
            {
                context.Response.Write("ASP.NET_SessionId=" + sessionCookie.Value);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}