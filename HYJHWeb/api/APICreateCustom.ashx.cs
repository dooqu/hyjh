using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb.api
{
    /// <summary>
    /// createCustom 的摘要说明
    /// </summary>
    public class APICreateCustom : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if(GetSessionUser() == null)
            {
                throw new Exception("您的登录状态已经过期，请重新登录");
            }

            if(CanDo(HYJHLibrary.modal.RoleBehavior.CreateCustomInfo) == false)
            {
                throw new Exception("您未授权使用该功能");
            }

            try
            {


                int price, floorNum; double areasize;

                if (Double.TryParse(context.Request.Form["areaSize"], out areasize) == false)
                    areasize = 0;

                if (Int32.TryParse(context.Request.Form["floorNum"], out floorNum) == false)
                    floorNum = 0;

                if (Int32.TryParse(context.Request.Form["price"], out price) == false)
                    price = 0;

                HouseInfo custominfo = new HouseInfo();
                custominfo.Type = HouseInfoType.Rent;
                custominfo.Title = Convert.ToString(context.Request.Form["CustomName"]);
                custominfo.BuildingName = Convert.ToString(context.Request.Form["buildingName"]);
                custominfo.Address = context.Request.Form["buildingName"];
                custominfo.ZoneId = Convert.ToInt32(context.Request.Form["zoneId"]);
                custominfo.StructId = Convert.ToInt32(context.Request.Form["structId"]);
                custominfo.DecorationId = Convert.ToInt32(context.Request.Form["decorationId"]);
                custominfo.AspectId = Convert.ToInt32(context.Request.Form["aspectId"]);
                custominfo.AreaSize = areasize;
                custominfo.MonthPrice = price;
                custominfo.FloorNum = floorNum;
                custominfo.FloorTotal = floorNum;
                custominfo.JoinType = 0;
                custominfo.ContractCode = String.Empty;
                custominfo.CustomName = context.Request.Form["customName"];
                custominfo.CustomTel = Convert.ToString(context.Request.Form["customTel"]);
                custominfo.Comment = "";
                custominfo.IsInError = false;
                custominfo.UserBelong = GetSessionUser();

                int customId = Houses.CreateHouseInfo(custominfo);

                if(customId > 0)
                {
                    ResponseErrorJson(context, customId, "创建成功");
                }
                else if(customId <0)
                {
                    ResponseErrorJson(context, -1, "求租者的电话录入重复");
                }
                else
                {
                    ResponseErrorJson(context, -99, "创建失败");
                }
            }
            catch(Exception ex)
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