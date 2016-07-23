using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.modal;
using HYJHLibrary.bll;

namespace HYJHWeb.api
{
    /// <summary>
    /// createHouseInfo 的摘要说明
    /// </summary>
    public class APICreateHouseInfo : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            if (GetSessionUser() == null)
                throw new Exception("您的登录状态已经过期，请重新登录");

            if(CanDo(HYJHLibrary.modal.RoleBehavior.CreateHouseInfo) == false)
                throw new Exception("您未获得使用该功能的授权");
            

            HouseInfo house = new HouseInfo();

            if (String.IsNullOrEmpty((context.Request.Form["title"])))
                throw new Exception("标题不能为空");

            if (String.IsNullOrEmpty(context.Request.Form["buildingName"]))
                throw new Exception("小区名不能为空");

            if(String.IsNullOrEmpty(context.Request.Form["address"]))
                throw new Exception("房源的详细地址不能为空");

            if (String.IsNullOrEmpty(context.Request.Form["customName"]))
                throw new Exception("房主的姓名不能为空");

            if (String.IsNullOrEmpty(context.Request.Form["customTel"]))
                throw new Exception("房源的联系电话不能为空");

            int monthPrice,threeMonthPrice, halfYearPrice, yearPrice, areasize, structId, aspectId, floorNum, floorTotal, zoneId, decorationId;

            if (int.TryParse(context.Request.Form["monthPrice"], out monthPrice) == false)
                throw new Exception("月租金填写错误");

            if (int.TryParse(context.Request.Form["threeMonthPrice"], out threeMonthPrice) == false)
                throw new Exception("季租金填写错误");

            if (int.TryParse(context.Request.Form["halfYearPrice"], out halfYearPrice) == false)
                throw new Exception("半年租金填写错误");

            if (int.TryParse(context.Request.Form["yearPrice"], out yearPrice) == false)
                throw new Exception("年租金填写错误");

            if (int.TryParse(context.Request.Form["areaSize"], out areasize) == false)
                throw new Exception("面积写错误");

            if (int.TryParse(context.Request.Form["floorNum"], out floorNum) == false)
                throw new Exception("楼层填写错误");

            if (int.TryParse(context.Request.Form["floorTotal"], out floorTotal) == false)
                throw new Exception("总楼层填写错误");

            house.Type = HouseInfoType.RentOut;
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
            house.IsCustomTel = Convert.ToBoolean(context.Request.Form["isCustomTel"]);
            house.CustomTel = Convert.ToString(context.Request.Form["customTel"]);
            house.Comment = Convert.ToString(context.Request.Form["comment"]);
            house.IsInError = Convert.ToBoolean(context.Request.Form["isInError"]);
            house.ErrorMessage = Convert.ToString(context.Request.Form["errorMessage"]);
            house.CompleteDate = Convert.ToDateTime(context.Request.Form["completeDate"]);

            house.UserBelong = GetSessionUser();
            int houseid = Houses.CreateHouseInfo(house);

            if(houseid > 0)
            {
                ResponseErrorJson(context, houseid, "房源信息创建成功");
            }
            else if(houseid == -1)
            {
                ResponseErrorJson(context, -99, "创建失败，客户电话已经存在");
            }
        }


        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            ResponseErrorJson(HttpContext.Current, -99, ex.Message);
        }
    }
}