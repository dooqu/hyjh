using HYJHLibrary.bll;
using HYJHLibrary.modal;
using System;
using System.Collections.Generic;
using System.Web;

namespace HYJHWeb.api
{
    /// <summary>
    /// recvUploadPicture 的摘要说明
    /// </summary>
    public class APIRecvUploadImage : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if (this.CurrentUser == null)
            {
                ResponseErrorJson(context, 0, "您的登录信息已经过期");
                return;
            }


            int houseId = 0;

            if (context.Request.Files["uploadimage"] == null)
            {
                ResponseErrorJson(context, -1, "没有指定上传的文件");
                return;
            }

            if (Int32.TryParse(context.Request.Form["houseid"], out houseId) == false)
            {
                ResponseErrorJson(context, -1, "没有确定的房产信息ID");
                return;
            }

            HouseInfo houseInfo = Houses.GetHouseInfo(houseId);

            if (houseInfo == null)
            {
                ResponseErrorJson(context, -1, "未找到指定的房产信息");
                return;
            }

            if ((CanDo(HYJHLibrary.modal.RoleBehavior.EditHouseInfo) == true || CanDo(RoleBehavior.CreateHouseInfo) == true ||
    (CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) && houseInfo.UserId == GetSessionUser().UserId)) == false)
            {
                ResponseErrorJson(context, -1, "您未被授权为房源信息添加照片");
                return;
            }

            HttpPostedFile uploadFile = context.Request.Files["uploadimage"];

            if(uploadFile == null)
            {
                ResponseErrorJson(context, -1, "没有指定上传的文件");
                return;
            }

            try
            {
                int picId = HYJHLibrary.HousePictureHelper.RecvHttpPostedFile(HttpContext.Current, houseInfo.HouseId, uploadFile);

                if(picId > 0)
                {
                    ResponseErrorJson(context, picId, picId.ToString());
                }
            }
            catch(Exception ex)
            {
                ResponseErrorJson(context, -99, ex.Message);
            }
        }


        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -98, ex.Message);
        }
    }
}

