using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class houseCreate : HYJHLibrary.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CanDo(RoleBehavior.CreateHouseInfo) == false)
                throw new Exception("您没有权限查看该页面");

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

            Page.DataBind();
        }
    }
}