using System;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using Newtonsoft.Json;

namespace HYJHWeb.api
{
    public class BaseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
        public class ErrorResponse
        {
            public int errorCode
            {
                get; set;
            }

            public String errorMsg
            {
                get; set;
            }
        }
        protected UserInfo CurrentUser;
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.Headers.Add("Access-Control-Allow-Origin", "null");
            //context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            CurrentUser = GetSessionUser();

            try
            {
                this.OnLoad(context);
            }
            catch (Exception ex)
            {
                OnError(ex);
            }
        }

        public virtual void OnLoad(HttpContext context)
        {

        }

        public virtual void OnError(Exception ex)
        {
        }

        #endregion

        public static UserInfo GetSessionUser()
        {
            UserInfo userinfo = HttpContext.Current.Session["USER"] as UserInfo;

            if(userinfo == null && (String.IsNullOrEmpty(HttpContext.Current.Request.Headers["Mobile"]) == false && String.IsNullOrEmpty(HttpContext.Current.Request.Headers["PasswordMD5"]) == false))
            {
                userinfo = Users.GetUserInfoByMobileAndPassword(HttpContext.Current.Request.Headers["Mobile"], HttpContext.Current.Request.Headers["PasswordMD5"]);

                if (userinfo != null)
                    HttpContext.Current.Session["USER"] = userinfo;
            }

            return userinfo;
        }

        protected string GetUsername()
        {
            if (CurrentUser == null)
                return String.Empty;

            else
                return CurrentUser.Username;
        }

        public void ResponseErrorJson(HttpContext context, int errorCode, string errorMsg)
        {
            ErrorResponse errResp = new ErrorResponse();
            errResp.errorCode = errorCode;
            errResp.errorMsg = errorMsg;

            ResponseErrorJson(context, errResp);
        }

        public void ResponseErrorJson(HttpContext context, ErrorResponse errResp)
        {
            context.Response.Write(JsonConvert.SerializeObject(errResp));
        }

        public void ResponseErrorScript(HttpContext context, int errorCode, string errorMsg)
        {
            context.Response.Write("<script language='javascript'>");
            context.Response.Write(string.Format("errorResponse({0}, '{1}');", errorCode, errorMsg));
            context.Response.Write("</script>");
        }


        public static bool CanUserDo(UserInfo userinfo, RoleBehavior behavior)
        {
            return Roles.CanUserDo(userinfo, behavior);
        }


        protected bool CanDo(RoleBehavior behavior)
        {
            return CanUserDo(CurrentUser, behavior);
        }
    }
}
