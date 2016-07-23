using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb.api
{
    /// <summary>
    /// deletePicture 的摘要说明
    /// </summary>
    public class APIDeletePicture : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            int picid;

            if (Int32.TryParse(context.Request.Form["picid"], out picid) == false)
            {
                throw new Exception("picid错误");
            }

            if (GetSessionUser() == null)
                throw new Exception("您的登录状态已经过期，请重新登录");

            int houseid = Houses.GetHouseIdByPicId(picid);

            if (houseid < 0)
                throw new Exception("所属的房源信息未找到");


            HouseInfo houseinfo = Houses.GetHouseInfo(houseid);

            if(houseinfo == null)
            {
                throw new Exception("所属房源信息未找到");
            }

            if((CanDo(RoleBehavior.EditHouseInfo) == true 
                || (CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) && GetSessionUser().UserId == houseinfo.UserId)) == false)
            {
                throw new Exception("您没有权限删除房源照片");
            }


            try
            {
                Houses.DeleteHousePicture(picid);
                ResponseErrorJson(HttpContext.Current, picid, "操作成功");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -99, ex.Message);
        }
    }
}