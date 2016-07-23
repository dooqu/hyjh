using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.modal;
using HYJHLibrary.bll;
using Newtonsoft.Json;

namespace HYJHWeb.api
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class APILogin : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            string phoneNumber = context.Request.Form["phoneNumber"];
            string passwordMD5 = context.Request.Form["password"];

            UserInfo userinfo = Users.GetUserInfoByMobileAndPassword(phoneNumber, passwordMD5);

            if (userinfo != null)
            {
                context.Session.Add("USER", userinfo);
                context.Response.HeaderEncoding = System.Text.Encoding.UTF8;
                context.Response.Write(JsonConvert.SerializeObject(userinfo));                
            }
            else
            {
                context.Response.Write("{}");
            }

            context.Response.End();
        }
    }
}