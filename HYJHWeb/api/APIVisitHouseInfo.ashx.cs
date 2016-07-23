using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary;
using HYJHLibrary.bll;

namespace HYJHWeb.api
{
    /// <summary>
    /// APIVisitHouseInfo 的摘要说明
    /// </summary>
    public class APIVisitHouseInfo : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            int userId, houseId;

            if(Int32.TryParse(context.Request.Params["houseid"], out houseId) == false)
            {
                ResponseErrorJson(context, -9, "houseid错误");
                return;
            }

            if (GetSessionUser() == null)
                return;

            Houses.CreateVisit(GetSessionUser().UserId, houseId);

            ResponseErrorJson(context, houseId, "OK");
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -10, ex.Message);
        }
    }
}