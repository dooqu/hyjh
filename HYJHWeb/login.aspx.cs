using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.Form["userMobile"]) == false ||
                string.IsNullOrEmpty(Request.Form["userPassword"]) == false)
            {
                string mobile = Request.Form["userMobile"];
                string passwordMD5 = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["userPassword"], "MD5");

                UserInfo userinfo = Users.GetUserInfoByMobileAndPassword(mobile, passwordMD5);
               
                if(userinfo != null)
                {
                    Session.Add("USER", userinfo);
                    Response.Redirect("index.aspx");
                }
                else
                {
                    loginMessage.InnerText = "用户名或者密码错误";
                }
            }
        }
    }
}