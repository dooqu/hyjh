using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHWeb;
using HYJHLibrary.modal;
using HYJHLibrary.dal;
using HYJHLibrary.bll;

namespace HYJHWeb
{
    public partial class houseEdit : HYJHLibrary.BasePage
    {
        protected int currHouseId;
        protected string title;
        protected string buildingName;
        protected string address;
        protected int zoneId;
        protected int structId;
        protected int aspectId;
        protected int decorationId;
        protected double areaSize;
        protected int payTypeId;
        protected int monthPrice;
        protected int threeMonthPrice;
        protected int halfYearPrice;
        protected int yearPrice;
        protected int floorNum;
        protected int floorTotal;
        protected int joinType;
        protected string contractCode;
        protected string customName;
        protected string customTel;
        protected string customAddress;
        protected string comment;
        protected bool isCustomTel;
        protected bool isInError;
        protected bool isCompleted;
        protected DateTime completeDate;
        protected int rank;
        protected string errorMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CanDo(RoleBehavior.EditHouseInfo) == false && CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) == false)
            {
                throw new Exception("您没有权限查看该页面");
            }
            int houseId;
            if (Int32.TryParse(Request.QueryString["houseId"], out houseId) == false)
            {
                throw new Exception("houseid参数未提供");
            }

            HouseInfo house = Houses.GetHouseInfo(houseId);
            if (house == null)
            {
                throw new Exception("房产信息未找到");
            }

            if ((HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.EditHouseInfo) == true ||
(CanDo(RoleBehavior.BrowseOrEditHouseInfoOfSelf) == true && GetSessionUser().UserId == house.UserBelong.UserId)) == false)
            {
                throw new Exception("您没有被授权使用该功能");
            }

            List<KeyValuePair<string, string>> zones = Zones.GetList(true);
            zoneOptionList.DataSource = zones;

            List<KeyValuePair<string, string>> decorations = Decorations.GetList(true);
            decorationOptionList.DataSource = decorations;

            List<KeyValuePair<string, string>> aspects = Aspects.GetList(true);
            aspectOptionList.DataSource = aspects;

            List<KeyValuePair<string, string>> structs = RoomStucts.GetList(true);
            structOptionList.DataSource = structs;

            List<KeyValuePair<string, string>> payTypes = PayTypes.GetList();
            payTypeList.DataSource = payTypes;


            currHouseId = house.HouseId;
            title = house.Title;
            buildingName = house.BuildingName;
            address = house.Address;
            zoneId = house.ZoneId;
            structId = house.StructId;
            decorationId = house.DecorationId;
            aspectId = house.AspectId;
            areaSize = house.AreaSize;
            payTypeId = house.PayTypeId;
            monthPrice = house.MonthPrice;
            threeMonthPrice = house.ThreeMonthPrice;
            halfYearPrice = house.HalfYearPrice;
            yearPrice = house.YearPrice;
            floorNum = house.FloorNum;
            floorTotal = house.FloorTotal;
            joinType = house.JoinType;
            contractCode = house.ContractCode;
            customName = house.CustomName;
            customTel = house.CustomTel;
            customAddress = house.CustomAddr;
            comment = house.Comment;
            isInError = house.IsInError;
            isCompleted = house.IsCompleted;
            isCustomTel = house.IsCustomTel;
            rank = house.Rank;
            completeDate = house.CompleteDate;
            errorMessage = house.ErrorMessage;


            List<HousePicture> pictures = new List<HousePicture>();
            List<HousePicture> picturesThumb = new List<HousePicture>();

            Houses.GetHousePictures(houseId, ref pictures, ref picturesThumb);

            pictureList.DataSource = pictures;

            Page.DataBind();
        }
    }
}