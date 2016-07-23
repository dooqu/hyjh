using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;


namespace HYJHWeb.api
{
    /// <summary>
    /// APIDeleteHouseInfo 的摘要说明
    /// </summary>
    public class APIDeleteHouseInfo : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if (GetSessionUser() == null)
            {
                ResponseErrorJson(context, -9, "您的登录已经过期");
                return;
            }

            string method = context.Request.Params["method"];

            if(string.IsNullOrEmpty(method) || (method != "delete_house" && method != "delete_custom"))
            {
                ResponseErrorJson(context, -10, "method类型错误");
                return;
            }

            if(context.Request.Params["method"] == "delete_house" && CanDo(RoleBehavior.DeleteHouseInfo) == false ||
                context.Request.Params["method"] == "delete_custom" && CanDo(RoleBehavior.DeleteCustomInfo) == false)
            {
                throw new Exception("您未授权操作该功能");
            }

            int houseid;

            if(Int32.TryParse(context.Request.Params["houseid"], out houseid) == false)
            {
                throw new Exception("houseid参数错误");
            }


            List<HousePicture> pics = Houses.GetHousePictures(houseid);
            for (int i = 0; i < pics.Count; i++)
            {
                Houses.DeleteHousePicture(pics[i].PicId);
            }

            Houses.DeleteHouseInfo(houseid);
            ResponseErrorJson(context, houseid, "删除信息完成");
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);

            ResponseErrorJson(HttpContext.Current, -99, ex.Message);
        }
    }
}