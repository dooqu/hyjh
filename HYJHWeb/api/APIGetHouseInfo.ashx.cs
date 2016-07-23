using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.modal;
using HYJHLibrary.bll;
using Newtonsoft.Json;

namespace HYJHWeb.api
{
    /// <summary>
    /// detail 的摘要说明
    /// </summary>
    public class APIGetHouseInfo : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            int houseId;

            if (Int32.TryParse(context.Request.Params["houseid"], out houseId) == false)
            {
                ResponseErrorJson(context, 100, "houseid参数错误");
                return;
            }

            if (GetSessionUser() == null)
            {
                ResponseErrorJson(context, -99, "您的登录状态已经过期，请重新登录");
                return;
            }


            HouseInfo houseInfo = Houses.GetHouseInfo(houseId);

            if (houseInfo == null)
            {
                throw new Exception("访问的房源信息未找到，可能已经被删除");
            }

            if (houseInfo.Type == HouseInfoType.RentOut)
            {
                if(String.IsNullOrEmpty(context.Request.Params["edit"]) == false)
                {
                    if ((CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) == true && GetSessionUser().UserId == houseInfo.UserBelong.UserId
                        || CanDo(RoleBehavior.EditHouseInfo) == true) == false)
                    {
                        ResponseErrorJson(context, -95, "您没有权限编辑该房源信息");
                        return;
                    }
                }
                //如果能浏览房源信息
                //如果能编辑房源信息
                //如果能浏览或者编辑自己的房源信息
                //以上三条能满足一条即可
                if ((CanDo(RoleBehavior.BrowseHouseInfo) == true || (CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) == true && GetSessionUser().UserId == houseInfo.UserBelong.UserId)
                    || CanDo(RoleBehavior.EditHouseInfo) == true) == false)
                {
                    ResponseErrorJson(context, -97, "您没有权限浏览该房源信息");
                    return;
                }
            }
            else if (houseInfo.Type == HouseInfoType.Rent)
            {
                //如果能浏览客源信息
                //如果能编辑客源信息
                //如果能浏览或者编辑自己的客源信息
                //以上三条能满足一条即可
                if (((CanDo(RoleBehavior.BrowseOrEditCustomInfoOfSelf) == true && GetSessionUser().UserId == houseInfo.UserBelong.UserId)
                    || CanDo(RoleBehavior.EditCustomInfo) == true) == false)
                {
                    ResponseErrorJson(context, -95, "您没有权限编辑该客源信息");
                    return;
                }
            }


            List<HousePicture> pictures = new List<HousePicture>();
            List<HousePicture> thumb_pictures = new List<HousePicture>();

            String hostUrl = "http://" + context.Request.Url.Host + ((context.Request.Url.Port != 80) ? ":" + context.Request.Url.Port.ToString() : "") + "/pic/";
            Houses.GetHousePictures(houseId, ref pictures, ref thumb_pictures);

            houseInfo.Pictures = pictures;
            houseInfo.ThumbPictures = thumb_pictures;

            if (houseInfo.Pictures.Count == 0)
            {
                HousePicture pic = new HousePicture();
                pic.PicId = 0;
                pic.Filename = "noinfo.jpg";
                houseInfo.Pictures.Add(pic);
            }

            if (houseInfo.ThumbPictures.Count == 0)
            {
                HousePicture tpic = new HousePicture();
                tpic.PicId = 0;
                tpic.Filename = "thumb_noinfo.jpg";
                houseInfo.ThumbPictures.Add(tpic);
            }

            for (int i = 0; i < pictures.Count; i++)
            {
                pictures[i].Filename = hostUrl + pictures[i].Filename;
            }

            for (int i = 0; i < thumb_pictures.Count; i++)
            {
                thumb_pictures[i].Filename = hostUrl + thumb_pictures[i].Filename;
            }

            //如果当前这个api是在浏览模式下被调用， 那要判定下房源的电话是否能看到， 客源没有详情页，所以不需此步骤;对于编辑模式，那就可以是否有编辑权限，有编辑权限，就能看到电话
            //1用户拥有查看电话的权限
            //2用户可以查看同部门的，代理模式的电话
            //3用户可以看到自己跟进的房源电话
            if (String.IsNullOrEmpty(context.Request.Params["edit"]) == true &&
                (CanDo(RoleBehavior.BrowseHouseInfoAndCustomTel) == true ||
                (CanDo(RoleBehavior.BrowseSameDepartmentCustomTel) == true && houseInfo.UserBelong.DepartmentId == GetSessionUser().DepartmentId && houseInfo.JoinType == 1) ||
                CanDo(RoleBehavior.EditHouseInfo) ||
                (CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) && houseInfo.UserBelong.UserId == GetSessionUser().UserId)) == false)
            {
                houseInfo.CustomTel = "未被授权查看电话";
            }

            if (context.Session != null)
            {
                houseInfo.SessionId = context.Session.SessionID;
            }
            else
            {
                houseInfo.SessionId = "";
            }

            context.Response.Write(JsonConvert.SerializeObject(houseInfo));
        }
    }
}
