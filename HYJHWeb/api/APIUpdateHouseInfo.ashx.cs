using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;


namespace HYJHWeb.api
{
    /// <summary>
    /// saveHouseInfo 的摘要说明
    /// </summary>
    public class APIUpdateHouseInfo : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if(GetSessionUser() == null)
            {
                ResponseErrorJson(context, -99, "您的登录状态已经过期，请重新登录");
                return;
            }



            int houseId;
            if (Int32.TryParse(context.Request.Form["houseid"], out houseId) == false)
            {
                throw new Exception("houseid参数错误");
            }

            HouseInfo house = Houses.GetHouseInfo(houseId);

            if (house == null)
            {
                throw new Exception("所指定的房源未找到");
            }

            if(house.Type == HouseInfoType.RentOut)
            {
                if ((CanDo(RoleBehavior.EditHouseInfo) == true ||
        (CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) == true && GetSessionUser().UserId == house.UserBelong.UserId)) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }
            }
            else if(house.Type == HouseInfoType.Rent)
            {
                if ((CanDo( RoleBehavior.EditCustomInfo) == true ||
        (CanDo(RoleBehavior.BrowseOrEditCustomInfoOfSelf) == true && GetSessionUser().UserId == house.UserBelong.UserId)) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }
            }

            try
            {
                int monthPrice, threeMonthPrice, halfYearPrice, yearPrice;

                if (int.TryParse(context.Request.Form["monthPrice"], out monthPrice) == false)
                    throw new Exception("月租金填写错误");

                if (int.TryParse(context.Request.Form["threeMonthPrice"], out threeMonthPrice) == false)
                    throw new Exception("季租金填写错误");

                if (int.TryParse(context.Request.Form["halfYearPrice"], out halfYearPrice) == false)
                    throw new Exception("半年租金填写错误");

                if (int.TryParse(context.Request.Form["yearPrice"], out yearPrice) == false)
                    throw new Exception("年租金填写错误");

                house.Title = Convert.ToString(context.Request.Form["title"]);
                house.BuildingName = Convert.ToString(context.Request.Form["buildingName"]);
                house.Address = context.Request.Form["address"];
                house.ZoneId = Convert.ToInt32(context.Request.Form["zoneId"]);
                house.StructId = Convert.ToInt32(context.Request.Form["structId"]);
                house.DecorationId = Convert.ToInt32(context.Request.Form["decorationId"]);
                house.AspectId = Convert.ToInt32(context.Request.Form["aspectId"]);
                house.AreaSize = Convert.ToDouble(context.Request.Form["areaSize"]);
                house.MonthPrice = monthPrice;
                house.ThreeMonthPrice = threeMonthPrice;
                house.HalfYearPrice = halfYearPrice;
                house.YearPrice = yearPrice;
                house.FloorNum = Convert.ToInt32(context.Request.Form["floorNum"]);
                house.FloorTotal = Convert.ToInt32(context.Request.Form["floorTotal"]);
                house.JoinType = Convert.ToInt32(context.Request.Form["joinType"]);
                house.ContractCode = context.Request.Form["contractCode"];
                house.Rank = Convert.ToInt32(context.Request.Form["rank"]);
                house.CustomName = context.Request.Form["customName"];
                house.IsInError = Convert.ToBoolean(context.Request.Form["isInError"]);
                house.IsCustomTel = Convert.ToBoolean(context.Request.Form["isCustomTel"]);
                house.CustomTel = Convert.ToString(context.Request.Form["customTel"]);
                house.Comment = Convert.ToString(context.Request.Form["comment"]);
                house.IsCompleted = Convert.ToBoolean(context.Request.Form["isCompleted"]);
                house.ErrorMessage = Convert.ToString(context.Request.Form["errorMessage"]);
                house.CompleteDate = Convert.ToDateTime(context.Request.Form["completeDate"]);
                
                int result = Houses.UpdateHouseInfo(house);

                if(result == -1)
                {
                    ResponseErrorJson(context, -1, "房主电话已经存在");
                    return;
                }

                ResponseErrorJson(context, house.HouseId, "房产信息编辑完成");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -99, ex.Message);
        }
    }
}