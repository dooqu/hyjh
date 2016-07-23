using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.modal;
using HYJHLibrary.bll;
namespace HYJHWeb
{
    public partial class getHouseInfo : HYJHLibrary.BasePage
    {
        protected string HouseId;
        protected string HouseTitle;
        protected string HouseName;
        protected string HouseAddress;
        protected string HouseAspect;
        protected string HouseDecoration;
        protected string HouseStruct;
        protected string HouseFloorNum;
        protected string HouseSize;
        protected string HouseOwner;
        protected string HouseOwnerTel;
        protected string HouseZone;
        protected string HousePrice;
        protected string FirstPictureUrl;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (CanDo(RoleBehavior.BrowseHouseInfo) == false)
                throw new Exception("您没有权限使用功能");

            int houseid;

            if (Int32.TryParse(Request.QueryString["houseid"], out houseid) == false)
            {
                throw new Exception("houseid参数错误");
            }

            HouseInfo house = Houses.GetHouseInfo(houseid);

            if (house == null)
            {
                throw new Exception("指定房产信息未找到");
            }

            List<HousePicture> pictures = new List<HousePicture>();
            List<HousePicture> picturesThumb = new List<HousePicture>();
            Houses.GetHousePictures(houseid, ref pictures, ref picturesThumb);

            if (pictures.Count == 0)
            {
                HousePicture p = new HousePicture();
                p.PicId = 0;
                p.Filename = "noinfo.jpg";
                pictures.Add(p);
            }

            if (picturesThumb.Count == 0)
            {
                HousePicture p = new HousePicture();
                p.PicId = 0;
                p.Filename = "noinfo.jpg";

                picturesThumb.Add(p);
            }

            if (pictures.Count > 0)
            {
                pictureList.DataSource = pictures;
            }

            FirstPictureUrl = (pictures.Count > 0) ? pictures[0].Filename : "noinfo.jpg";
            HouseId = house.HouseId.ToString();
            HouseTitle = house.Title;
            HouseAddress = house.Address;
            HouseAspect = house.AspectName;
            HouseDecoration = house.DecorationName;
            HouseFloorNum = house.FloorNum.ToString() + " / " + house.FloorTotal.ToString() + "层";
            HouseSize = house.AreaSize.ToString();
            HouseOwner = house.CustomName;
            HouseOwnerTel = (CanDo(RoleBehavior.BrowseHouseInfoAndCustomTel)) ? house.CustomTel : "没有授权查看";
            HouseZone = house.ZoneName;
            HousePrice = house.Price.ToString();
            HouseStruct = house.StructName;
            HouseName = house.BuildingName;

            Page.DataBind();
            // pictureList.DataBind();
        }
    }
}