using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class customEdit : HYJHLibrary.BasePage
    {
        protected HouseInfo custom;
        protected void Page_Load(object sender, EventArgs e)
        {

            int houseId;
            if (Int32.TryParse(Request.QueryString["houseId"], out houseId) == false)
            {
                throw new Exception("houseid参数未提供");
            }

            custom = Houses.GetHouseInfo(houseId);
            if (custom == null)
            {
                throw new Exception("客源信息未找到");
            }

            if ((CanDo(RoleBehavior.EditCustomInfo) == true ||
(CanDo(RoleBehavior.BrowseOrEditCustomInfoOfSelf) == true && HYJHLibrary.BasePage.GetSessionUser().UserId == custom.UserBelong.UserId)) == false)
            {
                throw new Exception("您没有权限编辑该客源信息");
            }

            List<KeyValuePair<string, string>> zones = Zones.GetList(true);
            zoneOptionList.DataSource = zones;

            List<KeyValuePair<string, string>> decorations = Decorations.GetList(true);
            decorationOptionList.DataSource = decorations;

            List<KeyValuePair<string, string>> aspects = Aspects.GetList(true);
            aspectOptionList.DataSource = aspects;

            List<KeyValuePair<string, string>> structs = RoomStucts.GetList(true);
            structOptionList.DataSource = structs;        

            Page.DataBind();
        }
    }
}