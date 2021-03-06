﻿using System;
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
    public class loginHandler : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            string phoneNumber = context.Request.Form["phoneNumber"];
            string passwordMD5 = context.Request.Form["password"];

            UserInfo userinfo = Users.GetUserInfoByMobileAndPassword(phoneNumber, passwordMD5);

            //context.Response.Clear();
            context.Response.Headers.Add("Access-Control-Allow-Origin", "null");
            context.Response.AddHeader("Access-Control-Allow-Credentials", "true");

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