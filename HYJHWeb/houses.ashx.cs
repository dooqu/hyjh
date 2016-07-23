using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using Newtonsoft.Json;

namespace HuaYuanJiaHe.api
{
    /// <summary>
    /// houses 的摘要说明
    /// </summary>
    public class houses : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            int pageTotal;
            List<HouseInfo> houses = Houses.GetHouses(0, 0, null, null, null, 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, true, 20, 0, out pageTotal);
            context.Response.Headers.Add("Access-Control-Allow-Origin", "null");
            context.Response.AddHeader("Access-Control-Allow-Credentials", "true");
            for (int i = 0;  i< houses.Count; i++)
            {
                string s = @"<div class='houseinfo'>
            <img class='pic' src='{0}'/>
            <div class='msgcontainer'>
                <p>{1}</p>
                <p>{2}</p>
                <p>{3}</p>
            </div>
            <div class='price'>
                <p>{4}$</p>
                <p class='mt'>(每月)</p>
            </div>
        </div>";
                HouseInfo houseinfo = houses[i];
                context.Response.Write(string.Format(s, houses[i].ThumbPictures[0].Filename, houses[i].Title, houses[i].AreaSize.ToString(), houseinfo.DecorationName));

            }
            context.Response.End();
        }
    }
}