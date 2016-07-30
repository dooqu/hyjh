using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using Newtonsoft.Json;

namespace HYJHWeb.api
{
    /// <summary>
    /// houses 的摘要说明
    /// </summary>
    public class APIHouseList : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);
            if (GetSessionUser() == null)
            {
                context.Response.Write("<div style='font-size:0.2rem;margin-top:0.5rem;width:100%;text-align:center' onclick='javascript:{ActivityManager.startActivity(\"huayuanjiahe.com\", \"huayuanjiahe.com.MainActivity\");}'>您的登录状态已经过期，请重新登录</div>");
                return;
            }

            if (CanDo(RoleBehavior.BrowseHouseList) == false)
            {
                context.Response.Write("<div style='font-size:0.2rem;margin-top:0.5rem;width:100%;text-align:center'>您没有权限浏览此功能</div>");
                return;
            }

            int joinType = Convert.ToInt32(context.Request.Form["joinType"]);
            int zoneId = Convert.ToInt32(context.Request.Form["zoneId"]);
            int aspectId = Convert.ToInt32(context.Request.Form["aspectId"]);
            int structId = Convert.ToInt32(context.Request.Form["structId"]);
            int decorationId = Convert.ToInt32(context.Request.Form["decorationId"]);
            int priceMin = Convert.ToInt32(context.Request.Form["priceMin"]);
            int priceMax = Convert.ToInt32(context.Request.Form["priceMax"]);
            int areaSizeMin = Convert.ToInt32(context.Request.Form["areaSizeMin"]);
            int areaSizeMax = Convert.ToInt32(context.Request.Form["areaSizeMax"]);
            int completeStatus = -1;
            int errorStatus = -1;

            if (Int32.TryParse(context.Request.Form["completeStatus"], out completeStatus) == false)
                completeStatus = -1;

            Int32.TryParse(context.Request.Form["errorStatus"], out errorStatus);

            string buildingKeyword = Convert.ToString(context.Request.Form["keyword"]);

            if (buildingKeyword != null && buildingKeyword.Trim() == string.Empty)
                buildingKeyword = null;

            int pageTotal;
            int pageIndex = 0;

            string caller = Convert.ToString(context.Request.Form["caller"]);
            Int32.TryParse(context.Request.Form["pageIndex"], out pageIndex);

            List<HouseInfo> houses = Houses.GetHouses(0, joinType, buildingKeyword, buildingKeyword, buildingKeyword, zoneId, aspectId, structId, decorationId, areaSizeMin, areaSizeMax, priceMin, priceMax, completeStatus, errorStatus, null, null, "HouseId", true, 20, pageIndex, out pageTotal);

            string hostUrl = "http://" + context.Request.Url.Host + ((context.Request.Url.Port != 80) ? ":" + context.Request.Url.Port.ToString() : "") + "/pic/thumb_";


            context.Response.Write("<script language='javascript'>");

            //如果总页次大于0，那么更新左上角的"当前页/总数"
            if(pageTotal > 0)
            {
                context.Response.Write(string.Format("updatePageInfo({0}, {1});\n",  pageIndex + 1, pageTotal));
            }

            //如果当前是最后一页，那么让客户端调用函数，显示已经全部加载，并且设定allPageLoaded,让scroll不再监控拖底的动作
            if((pageIndex + 1) >= pageTotal)
            {
                context.Response.Write(string.Format("{0}.setAllPageLoaded(true);\n",caller));
            }
            context.Response.Write("</script>");

            for (int i = 0;  i< houses.Count; i++)
            {
                string s = "<div style='{0}' class='houseinfo' onclick='javascript:showHouse(this, \"{1}\");'><img class='pic' src='{2}' id='housePic_{3}' onload='javascript:loadImage(\"{4}\", \"housePic_{5}\");'/><div class='houseinfo_middle'><p class='p1'>{6}</p><p class='p2'>{7}</p><p class='p3'><label class='label label-info'>{8}</label><label class='label label-warning'>{9}</label><label class='label label-success'>{10}</label></p></div><div class='houseinfo_price'><p class='price'>￥{11}<font style='color:#c0c0c0;font-weight:normal'>(月) </font></p><p class='price'>￥{12}<font style='color:#c0c0c0;font-weight:normal'>(季) </font></p></div></div>";
                HouseInfo houseinfo = houses[i];
                context.Response.Write(string.Format(s, (houseinfo.IsInError) ? "background-color:#FEF3F4" : "", houseinfo.HouseId.ToString(),"img/thumb_pic_loadding.jpg", houseinfo.HouseId.ToString(), hostUrl + (string.IsNullOrEmpty(houseinfo.CoverUrl)? "noinfo.jpg" : houseinfo.CoverUrl), houseinfo.HouseId.ToString(), houseinfo.Title, houseinfo.BuildingName.ToString(), houseinfo.StructName, houseinfo.DecorationName, houseinfo.AreaSize + "㎡", houseinfo.MonthPrice.ToString(), houseinfo.ThreeMonthPrice.ToString()));
            }
            context.Response.End();
        }
    }
}