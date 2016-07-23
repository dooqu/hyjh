using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using HYJHWeb;

namespace HYJHWeb.api
{
    /// <summary>
    /// APIUpdateUserPassword 的摘要说明
    /// </summary>
    public class APIUpdateUserPassword : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if(GetSessionUser() == null)
            {
                ResponseErrorJson(context, -99, "您的登录状态已经过期，请重新登录");
                return;
            }

  
            if(String.IsNullOrEmpty(context.Request.Form["userId"]) == false &&
                String.IsNullOrEmpty(context.Request.Form["oldPassword"]) == false &&
                String.IsNullOrEmpty(context.Request.Form["newPassword"]) == false)
            {
                int userid;

                if(Int32.TryParse(context.Request.Form["userId"], out userid))
                {
                    if(Users.UpdateUserPassword(userid, context.Request.Form["oldPassword"], context.Request.Form["newPassword"]))
                    {
                        ResponseErrorJson(context, userid, "修改密码成功");
                    }
                    else
                    {
                        ResponseErrorJson(context, -1, "修改失败，请重试");
                    }
                    return;
                }
                else
                {
                    ResponseErrorJson(context, -97, "houseid应为整型");
                }               
            }
            else
            {
                ResponseErrorJson(context, -2, "参数错误");
            }            
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -9, ex.Message);
        }
    }
}