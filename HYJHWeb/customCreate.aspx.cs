using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HYJHLibrary;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class customCreate : BasePage
    {
        protected string opMessage;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(Request.Form["method"]))
            {
                List<KeyValuePair<string, string>> zones = Zones.GetList();
                zoneOptionList.DataSource = zones;

                List<KeyValuePair<string, string>> decorations = Decorations.GetList();
                decorationOptionList.DataSource = decorations;

                List<KeyValuePair<string, string>> aspects = Aspects.GetList();
                aspectOptionList.DataSource = aspects;

                List<KeyValuePair<string, string>> structs = RoomStucts.GetList();
                structOptionList.DataSource = structs;

                Page.DataBind();
            }
            else
            {
                if (CanDo(RoleBehavior.CreateCustomInfo) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                try
                {
                    HouseInfo house = new HouseInfo();

                    do
                    {
                        if (string.IsNullOrEmpty(Request.Form["customName"]))
                        {
                            opMessage = "求租者信息不能为空";
                            throw new Exception("求租者信息不能为空");
                            break;
                        }


                        if (string.IsNullOrEmpty(Request.Form["customTel"]))
                        {
                            opMessage = "求租者联系方式不能为空";
                            throw new Exception("求租者联系方式不能为空");
                            break;
                        }


                        int price, floorNum; double areasize;

                        if (Double.TryParse(Request.Form["areaSize"], out areasize) == false)
                            areasize = 0;

                        if (Int32.TryParse(Request.Form["floorNum"], out floorNum) == false)
                            floorNum = 0;

                        if (Int32.TryParse(Request.Form["monthPrice"], out price) == false)
                            price = 0;

                        HouseInfo custominfo = new HouseInfo();
                        custominfo.Type = HouseInfoType.Rent;
                        custominfo.Title = Convert.ToString(Request.Form["customName"]);
                        custominfo.BuildingName = Convert.ToString(Request.Form["buildingName"]);
                        custominfo.Address = Request.Form["buildingName"];
                        custominfo.ZoneId = Convert.ToInt32(Request.Form["zoneId"]);
                        custominfo.StructId = Convert.ToInt32(Request.Form["structId"]);
                        custominfo.DecorationId = Convert.ToInt32(Request.Form["decorationId"]);
                        custominfo.AspectId = Convert.ToInt32(Request.Form["aspectId"]);
                        custominfo.AreaSize = areasize;
                        custominfo.MonthPrice = price;
                        custominfo.FloorNum = floorNum;
                        custominfo.FloorTotal = floorNum;
                        custominfo.JoinType = 2;
                        custominfo.ContractCode = String.Empty;
                        custominfo.CustomName = Request.Form["customName"];
                        custominfo.CustomTel = Convert.ToString(Request.Form["customTel"]);
                        custominfo.Comment = "";
                        custominfo.IsInError = false;
                        custominfo.ErrorMessage = string.Empty;
                        custominfo.CompleteDate = DateTime.Now;
                        custominfo.UserBelong = GetSessionUser();
                       // custominfo.HopeDate = Convert.ToDateTime(String.Format("{0}-{1}-{2}", Request.Form["year"], Request.Form["month"], Request.Form["day"]));

                        int houseId = Houses.CreateHouseInfo(custominfo);

                        if (houseId > 0)
                        {
                            Response.Redirect("customList.aspx", true);
                            opMessage = "添加客源信息成功";
                        }
                        else
                        {
                            opMessage = "录入的客源电话已经存在";
                            throw new Exception("录入的客源电话已经存在");
                        }

                        break;
                    }
                    while (true);
                }
                catch (Exception ex)
                {
                    opMessage = "添加失败:" + ex.Message;
                    throw new Exception(ex.Message);
                }
            }

        }
    }
}