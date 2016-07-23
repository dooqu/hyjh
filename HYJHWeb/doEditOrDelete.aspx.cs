using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class doEditOrDelete : HYJHLibrary.BasePage
    {
        protected string redirectUrl;
        protected string opMessage;

        protected override void OnError(EventArgs e)
        {
            Response.Clear();
            Response.Write(string.Format("<pre style='font-size:14px;font-familay:arial,tahoma;border:1px solid #c0c0c0;padding:20px;'>{0}</pre> <a href='javascript:history.go(-1)'>返回</a>", Server.GetLastError().Message));
            Response.End();

            base.OnError(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int houseId;
            redirectUrl = "";
            opMessage = "";

            if (Convert.ToString(Request.QueryString["method"]) == "delete_house")
            {
                if (HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.DeleteHouseInfo) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                if (Int32.TryParse(Convert.ToString(Request.QueryString["houseid"]), out houseId) == false)
                {
                    throw new Exception("houseid错误");
                }

                List<HousePicture> pics = Houses.GetHousePictures(houseId);

                for (int i = 0; i < pics.Count; i++)
                {
                    Houses.DeleteHousePicture(pics[i].PicId);
                }

                Houses.DeleteHouseInfo(houseId);

                opMessage = "删除房源信息成功";

                redirectUrl = "index.aspx";

            }
            else if (Convert.ToString(Request.QueryString["method"]) == "delete_custom")
            {
                if (HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.DeleteCustomInfo) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                if (Int32.TryParse(Convert.ToString(Request.QueryString["houseid"]), out houseId) == false)
                {
                    throw new Exception("houseid错误");
                }

                Houses.DeleteHouseInfo(houseId);

                opMessage = "删除客源信息成功";

                redirectUrl = "customList.aspx";

            }
            else if (Request.Form["method"] == "delete_picture")
            {
                int picid;

                if (Int32.TryParse(Request.Form["picid"], out picid) == false)
                {
                    throw new Exception("picid错误");
                }

                if (Int32.TryParse(Request.Form["houseid"], out houseId) == false)
                {
                    throw new Exception("houseid参数错误");
                }

                int houseid = Houses.GetHouseIdByPicId(picid);

                if (houseid < 0)
                    throw new Exception("所属房源信息未找到");

                HouseInfo houseinfo = Houses.GetHouseInfo(houseid);

                if (houseinfo == null)
                    throw new Exception("所属的房源信息未找到");

                if((Roles.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.EditHouseInfo) ||
                    (Roles.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.BrowseOrEditHouseInfoOfSelf) && houseinfo.UserBelong.UserId == GetSessionUser().UserId)) == false)
                {
                    throw new Exception("您没有权限删除该房源的照片");
                }

                string filename = Houses.GetPictureFilenameByPicId(picid);

                string filenameThumb = "thumb_" + filename;

                try
                {
                    System.IO.File.Delete(Server.MapPath("/pic/" + filename));
                    System.IO.File.Delete(Server.MapPath("/pic/" + filenameThumb));
                }
                catch (Exception ex)
                {
                    opMessage = "删除失败,图片文件删除时出错:" + ex.Message;
                }

                try
                {
                    Houses.DeleteHousePicture(picid);
                }
                catch (Exception ex)
                {
                    opMessage += "删除失败：" + ex.Message;
                }

                opMessage = "图片删除操作成功";
                redirectUrl = ("houseEdit.aspx?houseid=" + houseId.ToString());
            }
            else if (Request.Form["method"] == "edit")
            {
                if (HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.EditHouseInfo) == false && HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.BrowseOrEditHouseInfoOfSelf) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                if (Int32.TryParse(Request.Form["houseid"], out houseId) == false)
                {
                    throw new Exception("houseid参数错误");
                }

                HouseInfo house = Houses.GetHouseInfo(houseId);

                if (house == null)
                {
                    throw new Exception("所指定的房源未找到");
                }

                if ((HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.EditHouseInfo) == true ||
(HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.BrowseOrEditHouseInfoOfSelf) == true && HYJHLibrary.BasePage.GetSessionUser().UserId == house.UserBelong.UserId)) == false)
                {
                    throw new Exception("您没有权限编辑该房源");
                }

                if(String.IsNullOrEmpty(Request.Form["title"]))
                {
                    throw new Exception("房源信息的标题没有填写");
                }

                if(String.IsNullOrEmpty(Request.Form["address"]))
                {
                    throw new Exception("房源信息的详细地址没有填写");
                }

                if(String.IsNullOrEmpty(Request.Form["CustomTel"]))
                {
                    throw new Exception("房源的联系电话号码没有填写");
                }

                if(String.IsNullOrEmpty(Request.Form["customName"]))
                {
                    throw new Exception("房主的姓名没有填写");
                }

                int monthPrice, threeMonthPrice, halfYearPrice, yearPrice;

                if (Int32.TryParse(Request.Form["monthPrice"], out monthPrice) == false)
                    throw new Exception("月租金填写错误");

                if (Int32.TryParse(Request.Form["threeMonthPrice"], out threeMonthPrice) == false)
                    throw new Exception("季租金填写错误");

                if (Int32.TryParse(Request.Form["halfYearPrice"], out halfYearPrice) == false)
                    throw new Exception("半年租金填写错误");

                if (Int32.TryParse(Request.Form["yearPrice"], out yearPrice) == false)
                    throw new Exception("年租金填写错误");

                int rank;

                if(Int32.TryParse(Request.Form["rank"], out rank) == false)
                {
                    throw new Exception("房源的积分格式不正确");
                }

                

                try
                {
                    Convert.ToDateTime(Request.Form["completeDate"]);
                }
                catch
                {
                    throw new Exception("房源到期时间格式不正确");
                }

                try
                {
                    house.Title = Request.Form["title"];
                    house.BuildingName = Request.Form["buildingName"];
                    house.Address = Request.Form["address"];
                    house.ZoneId = Convert.ToInt32(Request.Form["zoneId"]);
                    house.StructId = Convert.ToInt32(Request.Form["structId"]);
                    house.DecorationId = Convert.ToInt32(Request.Form["decorationId"]);
                    house.AspectId = Convert.ToInt32(Request.Form["aspectId"]);
                    house.AreaSize = Convert.ToDouble(Request.Form["areaSize"]);
                    house.PayTypeId = Convert.ToInt32(Request.Form["payTypeId"]);
                    house.MonthPrice = monthPrice;
                    house.ThreeMonthPrice = threeMonthPrice;
                    house.HalfYearPrice = halfYearPrice;
                    house.YearPrice = yearPrice;
                    house.FloorNum = Convert.ToInt32(Request.Form["floorNum"]);
                    house.FloorTotal = Convert.ToInt32(Request.Form["floorTotal"]);
                    house.JoinType = Convert.ToInt32(Request.Form["joinType"]);
                    house.ContractCode = Request.Form["contractCode"];
                    house.Rank = rank;
                    house.CompleteDate = Convert.ToDateTime(Request.Form["completeDate"]);
                    house.CustomName = Request.Form["customName"];
                    house.IsCustomTel = Convert.ToBoolean(Request.Form["isCustomTel"]);
                    house.CustomTel = Request.Form["customTel"];
                    house.Comment = Request.Form["comment"];
                    house.IsCompleted = Convert.ToBoolean(Request.Form["isCompleted"]);
                    house.IsInError = Convert.ToBoolean(Request.Form["isInError"]);
                    house.ErrorMessage = Convert.ToString(Request.Form["errorMessage"]);

                    int result = Houses.UpdateHouseInfo(house);

                    if (result > 0)
                    {
                        redirectUrl = ("detail.aspx?houseid=" + house.HouseId.ToString());
                        opMessage = "编辑成功";
                    }
                    else if (result == -1)
                    {
                        redirectUrl = ("houseEdit.aspx?houseid=" + house.HouseId.ToString());
                        opMessage = "编辑失败:房主的电话号码已经使用过";
                    }

                }
                catch (Exception ex)
                {
                    redirectUrl = ("houseEdit.aspx?houseid=" + house.HouseId.ToString());
                    opMessage = "编辑失败:" + ex.Message;
                }
            }

            else if (Request.Form["method"] == "edit_custom")
            {
                if (Int32.TryParse(Request.Form["houseid"], out houseId) == false)
                {
                    throw new Exception("houseid参数错误");
                }

                HouseInfo house = Houses.GetHouseInfo(houseId);

                if (house == null)
                {
                    throw new Exception("所指定的房源未找到");
                }

                if ((HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.EditCustomInfo) == true ||
(HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.BrowseOrEditCustomInfoOfSelf) == true && HYJHLibrary.BasePage.GetSessionUser().UserId == house.UserBelong.UserId)) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                int price;

                if (Int32.TryParse(Request.Form["monthPrice"], out price) == false)
                    throw new Exception("租金填写错误");


                try
                {
                    house.Type = HouseInfoType.Rent;
                    house.Title = Request.Form["title"];
                    house.BuildingName = Request.Form["buildingName"];
                    house.Address = Request.Form["address"];
                    house.ZoneId = Convert.ToInt32(Request.Form["zoneId"]);
                    house.StructId = Convert.ToInt32(Request.Form["structId"]);
                    house.DecorationId = Convert.ToInt32(Request.Form["decorationId"]);
                    house.AspectId = Convert.ToInt32(Request.Form["aspectId"]);
                    house.AreaSize = Convert.ToDouble(Request.Form["areaSize"]);
                    house.MonthPrice = price;
                    house.FloorNum = Convert.ToInt32(Request.Form["floorNum"]);
                    house.FloorTotal = house.FloorNum;
                    house.JoinType = 2;
                    house.ContractCode = "";
                    house.CustomName = Request.Form["customName"];
                    house.CustomTel = Request.Form["customTel"];
                    house.Comment = "";
                    house.IsCompleted = Convert.ToBoolean(Request.Form["isCompleted"]);
                    house.CompleteDate = DateTime.Now;



                    Houses.UpdateHouseInfo(house);

                    redirectUrl = ("customList.aspx");
                    opMessage = "编辑客源成功";
                }
                catch (Exception ex)
                {
                    redirectUrl = ("houseEdit.aspx?houseid=" + house.HouseId.ToString());
                    opMessage = "编辑失败:" + ex.Message;
                }
            }
            else if (Request.Form["method"] == "house_create")
            {
                if (HYJHLibrary.BasePage.CanUserDo(HYJHLibrary.BasePage.GetSessionUser(), RoleBehavior.CreateHouseInfo) == false)
                {
                    throw new Exception("您没有被授权使用该功能");
                }

                try
                {
                    HouseInfo house = new HouseInfo();

                    do
                    {
                        if (string.IsNullOrEmpty(Request.Form["title"]))
                        {
                            opMessage = "标题不能为空";
                            break;
                        }
                        house.Title = Request.Form["title"];

                        if (string.IsNullOrEmpty(Request.Form["buildingName"]))
                        {
                            opMessage = "小区名不能为空";
                            break;
                        }
                        house.BuildingName = Request.Form["buildingName"];

                        if (string.IsNullOrEmpty(Request.Form["address"]))
                        {
                            opMessage = "详细地址不能为空";
                            break;
                        }

                        if(String.IsNullOrEmpty(Request.Form["customName"]))
                        {
                            opMessage = "房主姓名不能为空";
                            break;
                        }

                        if(String.IsNullOrEmpty(Request.Form["customTel"]))
                        {
                            opMessage = "联系电话不能为空";
                            break;
                        }

                        int rank;

                        if(Int32.TryParse(Request.Form["rank"], out rank) == false)
                        {
                            opMessage = "积分格式不正确";
                            break;
                        }


                        int monthPrice, threeMonthPrice, halfYearPrice, yearPrice;

                        if (Int32.TryParse(Request.Form["monthPrice"], out monthPrice) == false)
                            throw new Exception("月租金填写错误");

                        if (Int32.TryParse(Request.Form["threeMonthPrice"], out threeMonthPrice) == false)
                            throw new Exception("季租金填写错误");

                        if (Int32.TryParse(Request.Form["halfYearPrice"], out halfYearPrice) == false)
                            throw new Exception("半年租金填写错误");

                        if (Int32.TryParse(Request.Form["yearPrice"], out yearPrice) == false)
                            throw new Exception("年租金填写错误");





                        try
                        {
                            Convert.ToDateTime(Request.Form["completeDate"]);
                        }
                        catch
                        {
                            throw new Exception("房源到期时间格式不正确");
                        }

                        house.Address = Request.Form["address"];

                        house.ZoneId = Convert.ToInt32(Request.Form["zoneId"]);

                        house.StructId = Convert.ToInt32(Request.Form["structId"]);

                        house.DecorationId = Convert.ToInt32(Request.Form["decorationId"]);

                        house.AspectId = Convert.ToInt32(Request.Form["aspectId"]);

                        house.AreaSize = Convert.ToDouble(Request.Form["areaSize"]);

                        house.PayTypeId = Convert.ToInt32(Request.Form["payTypeId"]);

                        house.MonthPrice = monthPrice;
                        house.ThreeMonthPrice = threeMonthPrice;
                        house.HalfYearPrice = halfYearPrice;
                        house.YearPrice = yearPrice;

                        house.FloorNum = Convert.ToInt32(Request.Form["floorNum"]);

                        house.FloorTotal = Convert.ToInt32(Request.Form["floorTotal"]);

                        house.CoverUrl = "noinfo.jpg";
                        house.JoinType = Convert.ToInt32(Request.Form["joinType"]);

                        house.ContractCode = Request.Form["contractCode"];

                        house.CustomName = Request.Form["customName"];

                        house.IsCustomTel = Convert.ToBoolean(Request.Form["isCustomTel"]);

                        house.CustomTel = Request.Form["customTel"];

                        house.CustomAddr = Request.Form["customAddress"];

                        house.Comment = Convert.ToString(Request.Form["comment"]); ;

                        house.UserBelong = HYJHLibrary.BasePage.GetSessionUser();

                        house.CompleteDate = Convert.ToDateTime(Request.Form["completeDate"]);

                        house.Rank = rank;

                        house.IsInError = Convert.ToBoolean(Request.Form["isInError"]);

                        house.ErrorMessage = Convert.ToString(Request.Form["errorMessage"]);

                        houseId = Houses.CreateHouseInfo(house);

                        if (houseId > 0)
                        {
                            redirectUrl = ("detail.aspx?houseid=" + houseId.ToString());
                            opMessage = "添加房产信息成功";
                        }
                        else if (houseId == -1)
                        {
                            redirectUrl = "";
                            opMessage = "客户电话已经存在";
                        }
                        else
                        {
                            opMessage = "添加失败";
                            redirectUrl = "";
                        }
                        break;
                    }
                    while (true);
                }
                catch (Exception ex)
                {
                    redirectUrl = ("");
                    opMessage = "添加失败:" + ex.Message;
                }
            }

            Page.DataBind();
        }
    }
}