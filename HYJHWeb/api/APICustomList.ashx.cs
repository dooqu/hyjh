using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb.api
{
    /// <summary>
    /// customs 的摘要说明
    /// </summary>
    public class APICustomList : BaseHandler
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
            int pageTotal;
            int pageIndex = 0;
            Int32.TryParse(context.Request.Form["pageIndex"], out pageIndex);
            string caller = Convert.ToString(context.Request.Form["caller"]);

            List<HouseInfo> houses = Houses.GetHouses(2, 0, null, null, null, zoneId, aspectId, structId, decorationId, areaSizeMin, areaSizeMax, priceMin, priceMax, -1, -1, null, null, "HouseId", true, 20, pageIndex, out pageTotal);
            
            context.Response.Write("<script language='javascript'>");

            //如果总页次大于0，那么更新左上角的"当前页/总数"
            if (pageTotal > 0)
            {
                context.Response.Write(string.Format("updatePageInfo({0}, {1});\n", pageIndex + 1, pageTotal));
            }

            //如果当前是最后一页，那么让客户端调用函数，显示已经全部加载，并且设定allPageLoaded,让scroll不再监控拖底的动作
            if ((pageIndex + 1) >= pageTotal)
            {
                context.Response.Write(caller + ".setAllPageLoaded(true);\n");
            }
            context.Response.Write("</script>");

            

            for (int i = 0; i < houses.Count; i++)
            {
                bool canReadCustomTel = CanDo(RoleBehavior.BrowseRentOutCustomTe) || (CanDo(RoleBehavior.BrowseOrEditCustomInfoOfSelf) && houses[i].UserBelong.UserId == GetSessionUser().UserId) || CanDo(RoleBehavior.EditCustomInfo);

                String customTel = (canReadCustomTel) ? (string.IsNullOrEmpty(houses[i].CustomTel) ? "未登记" : houses[i].CustomTel) : "未授权查看";
                context.Response.Write(string.Format("<div onclick='javascript:{{selectCustom(this);}}' id='custom_{0}' class=\"custominfo\"><p> 客户:{1} <a href='#none' onclick='javascript:{{this.innerHTML=\"{2}\";}}' class='btn btn-xs btn-success'>查看联系方式</a><a href='#none' onclick='javascript:deleteCustom(\"{3}\");' class='btn btn-xs btn-danger tools' style='float:right;margin-left:0.1rem;'>删除</a><a href='#none' onclick='javascript:editCustom(\"{4}\");' class='btn btn-xs btn-warning tools' style='float:right;margin-left:0.1rem;'>编辑</a></p>", houses[i].HouseId.ToString(), houses[i].CustomName, customTel, houses[i].HouseId.ToString(), houses[i].HouseId.ToString()));
                List<string> customNeeds = new List<string>();


                if (houses[i].ZoneId != 0)
                {
                    customNeeds.Add(houses[i].ZoneName);
                }

                if (string.IsNullOrEmpty(houses[i].BuildingName) == false)
                {
                    customNeeds.Add(houses[i].BuildingName);
                }

                if (houses[i].FloorNum > 0)
                {
                    customNeeds.Add(houses[i].FloorNum + "层");
                }

                if (houses[i].AreaSize != 0)
                {
                    customNeeds.Add(houses[i].AreaSize + "㎡");
                }

                if (houses[i].StructId != 0)
                {
                    customNeeds.Add(houses[i].StructName);
                }

                if (houses[i].AspectId != 0)
                {
                    customNeeds.Add(houses[i].AspectName);
                }

                if (houses[i].DecorationId != 0)
                {
                    customNeeds.Add(houses[i].DecorationName);
                }

                if (houses[i].MonthPrice != 0)
                {
                    customNeeds.Add("￥" + houses[i].MonthPrice + "每月");
                }

                context.Response.Write("<p>");

                for (int n = 0; n < customNeeds.Count; n++)
                {
                    context.Response.Write("<div class='custom_need'>" + customNeeds[n] + "</div>");
                }

                if (houses[i].IsCompleted)
                {
                    context.Response.Write("<div class='custom_need' style='background-color:orange;color:white'>已租</div>");
                }

                context.Response.Write("</p>");
                context.Response.Write(String.Format("<p style='clear:both'>跟进：{0}</p>", houses[i].UserBelong.Username));
                context.Response.Write("</div>");
                
            }
            context.Response.Flush();
        }


        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write(String.Format("<div style='color:red'>{0}</div>", ex.Message));
            HttpContext.Current.Response.End();
        }
    }
}