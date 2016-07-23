using System;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using Newtonsoft.Json;

namespace HuaYuanJiaHe.api
{
    public class BaseHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {
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
            return HttpContext.Current.Session["USER"] as UserInfo;
        }

        protected string GetUsername()
        {
            if (CurrentUser == null)
                return "";

            else
                return CurrentUser.Username;
        }



        public static bool CanUserDo(UserInfo userinfo, RoleBehavior behavior)
        {
            if (userinfo == null)
                return false;

            if (userinfo.Username.ToString() == System.Configuration.ConfigurationManager.AppSettings.Get("rootUser"))
            {
                return true;
            }

            return ((userinfo.AuthValue & (int)behavior) > 0);

            //if ((behavior & RoleBehavior.BrowseCustomInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseCustomInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseCustomList) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseCustomList) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseHouseInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseHouseInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseHouseInfoAndCustomTel) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseHouseInfoAndCustomTel) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseHouseList) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseHouseList) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseRentOutCustomTe) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseRentOutCustomTe) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.CreateCustomInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.CreateCustomInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.CreateHouseInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.CreateHouseInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.DeleteCustomInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.DeleteCustomInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.EditCustomInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.EditCustomInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.EditHouseInfo) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.EditHouseInfo) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.ManageRole) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.ManageRole) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.ManageUser) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.ManageUser) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.ManagerDepartment) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.ManagerDepartment) == 0)
            //        return false;
            //}

            //if ((behavior & RoleBehavior.BrowseSameDepartmentCustomTel) > 0)
            //{
            //    if ((userinfo.AuthValue & (int)RoleBehavior.BrowseSameDepartmentCustomTel) == 0)
            //        return false;
            //}

            //return true;
        }



        protected bool CanDo(RoleBehavior behavior)
        {
            return CanUserDo(CurrentUser, behavior);
        }
    }
}
