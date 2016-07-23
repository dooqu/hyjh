using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHWeb;
using HYJHLibrary.modal;

namespace HYJHWeb.api
{
    /// <summary>
    /// APIGetVisitList 的摘要说明
    /// </summary>
    public class APIGetVisitList : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            int houseid;

            if(Int32.TryParse(context.Request.Params["houseid"], out houseid) == false)
            {
                ResponseErrorJson(context, -99, "houseid 参数错误");
                return;
            }

            List<UserInfo> users = Houses.GetVisitList(houseid);

            for(int i = 0; i < users.Count; i++)
            {
                String rowContent = "<div class='user_row'><label style='float:left'>{0}</label><label style='float:right'>{1}</label></div>";
                context.Response.Write(string.Format(rowContent, users[i].Username, users[i].CreateDate.ToString("yyyy年MM月dd日 HH:mm")));
            }
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
        }
    }
}