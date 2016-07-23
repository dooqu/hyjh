using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HYJHLibrary.modal;
using HYJHLibrary.bll;

namespace HYJHWeb
{
    public partial class index : HYJHLibrary.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CanDo(RoleBehavior.BrowseHouseList) == false)
                throw new Exception("您无权查看此页面");

            zoneRepeater.DataSource = Zones.GetList();
            zoneRepeater.DataBind();

            aspectRepeater.DataSource = Aspects.GetList();
            aspectRepeater.DataBind();

            decorationRepeater.DataSource = Decorations.GetList();
            decorationRepeater.DataBind();

            structRepeater.DataSource = RoomStucts.GetList();
            structRepeater.DataBind();


            BindHouseList();
        }

        protected void BindSearchHouses()
        {
            string buildingName = Request.Params["buildingName"];
            string address = Request.Params["address"];

            int pageSize = 10;
            int pageIndex = Convert.ToInt32(GetRequestFieldValue("currPageIndex"));
            int pageTotal = 0;
            List<HouseInfo> houses = SearchHouses(0, 0, buildingName, address, pageSize, 0, out pageTotal);
            houseList.DataSource = houses;
            houseList.DataBind();


            if (pageTotal <= 0)
            {
                nodataShow.Attributes.CssStyle.Add("display", "");
                return;
            }
            else
            {
                nodataShow.Attributes.CssStyle.Add("display", "none");
            }

            //最大的页次数量
            int maxPageNum = 11;
            int startIndex = ((pageIndex - maxPageNum / 2) < 0) ? 0 : pageIndex - maxPageNum / 2;

            int endIndex = ((startIndex + maxPageNum) > pageTotal) ? pageTotal - 1 : (startIndex + maxPageNum - 1);


            int frontAdd = maxPageNum / 2 - (endIndex - pageIndex);

            if (frontAdd > 0 && frontAdd <= maxPageNum / 2)
            {
                //如果结尾的不够5个， 那么尝试吧这个余额加载前面
                for (int i = 0; i < frontAdd; i++)
                {
                    if ((startIndex - 1) >= 0)
                        startIndex -= 1;
                }
            }

            List<PageNumber> pageNums = new List<PageNumber>();

            PageNumber firstNumber = new PageNumber();
            firstNumber.PageText = "首页";
            firstNumber.PageIndex = 0;
            firstNumber.Enabled = pageIndex != 0;
            pageNums.Add(firstNumber);

            for (int i = startIndex; i <= endIndex; i++)
            {
                PageNumber number = new PageNumber();
                number.PageIndex = i;
                number.PageText = (i + 1).ToString();
                number.Enabled = (i != pageIndex);
                pageNums.Add(number);
            }

            PageNumber lastPage = new PageNumber();
            lastPage.PageText = "末页";
            lastPage.PageIndex = (pageTotal - 1);
            lastPage.Enabled = pageIndex < (pageTotal - 1);
            pageNums.Add(lastPage);

            pageList.DataSource = pageNums;
            pageList.DataBind();

        }


        protected void BindHouseList()
        {
            int joinType = Convert.ToInt32(GetRequestFieldValue("currJoinType"));
            int zoneId = Convert.ToInt32(GetRequestFieldValue("currZone"));
            int aspectId = Convert.ToInt32(GetRequestFieldValue("currAspect"));
            int structId = Convert.ToInt32(GetRequestFieldValue("currRoomStruct"));
            int decorationId = Convert.ToInt32(GetRequestFieldValue("currDecoration"));
            int priceMin = Convert.ToInt32(GetRequestFieldValue("currPriceMin"));
            int priceMax = Convert.ToInt32(GetRequestFieldValue("currPriceMax"));
            int areaSizeMin = Convert.ToInt32(GetRequestFieldValue("currAreaSizeMin"));
            int areaSizeMax = Convert.ToInt32(GetRequestFieldValue("currAreaSizeMax"));
            int currPriceMinUsr = Convert.ToInt32(GetRequestFieldValue("currPriceMinUsr"));
            int currPriceMaxUsr = Convert.ToInt32(GetRequestFieldValue("currPriceMaxUsr"));
            int pageSize = 10;
            int pageIndex = Convert.ToInt32(GetRequestFieldValue("currPageIndex"));
            int pageTotal = 0;

            if (currPriceMinUsr != 0 || currPriceMaxUsr != 0)
            {
                priceMin = currPriceMinUsr;
                priceMax = currPriceMaxUsr;
            }

            string buildingKeyword = Convert.ToString(Request.Form["keyword"]);
            if (buildingKeyword == string.Empty)
                buildingKeyword = null;

            List<HouseInfo> housesdata = Houses.GetHouses(0, joinType, buildingKeyword, buildingKeyword, buildingKeyword, zoneId, aspectId, structId, decorationId, areaSizeMin, areaSizeMax, priceMin, priceMax, -1, -1, null, null, "HouseId", true, pageSize, pageIndex, out pageTotal);
            houseList.DataSource = housesdata;
            houseList.DataBind();

            if (pageTotal <= 0)
            {
                nodataShow.Attributes.CssStyle.Add("display", "");
                return;
            }
            else
            {
                nodataShow.Attributes.CssStyle.Add("display", "none");
            }



            //最大的页次数量
            int maxPageNum = 11;
            int startIndex = ((pageIndex - maxPageNum / 2) < 0) ? 0 : pageIndex - maxPageNum / 2;

            int endIndex = ((startIndex + maxPageNum) > pageTotal) ? pageTotal - 1 : (startIndex + maxPageNum - 1);


            int frontAdd = maxPageNum / 2 - (endIndex - pageIndex);

            if (frontAdd > 0 && frontAdd <= maxPageNum / 2)
            {
                //如果结尾的不够5个， 那么尝试吧这个余额加载前面
                for (int i = 0; i < frontAdd; i++)
                {
                    if ((startIndex - 1) >= 0)
                        startIndex -= 1;
                }
            }

            List<PageNumber> pageNums = new List<PageNumber>();

            PageNumber firstNumber = new PageNumber();
            firstNumber.PageText = "首页";
            firstNumber.PageIndex = 0;
            firstNumber.Enabled = pageIndex != 0;
            pageNums.Add(firstNumber);

            for (int i = startIndex; i <= endIndex; i++)
            {
                PageNumber number = new PageNumber();
                number.PageIndex = i;
                number.PageText = (i + 1).ToString();
                number.Enabled = (i != pageIndex);
                pageNums.Add(number);
            }

            PageNumber lastPage = new PageNumber();
            lastPage.PageText = "末页";
            lastPage.PageIndex = (pageTotal - 1);
            lastPage.Enabled = pageIndex < (pageTotal - 1);
            pageNums.Add(lastPage);

            pageList.DataSource = pageNums;
            pageList.DataBind();

        }

        protected void OnZoneButtonClick(object sender, EventArgs e)
        {
            Response.Write((sender as LinkButton).CommandArgument);
        }

        protected string GetRequestFieldValue(string fieldName)
        {
            if (Request.Params[fieldName] == null || Request.Params[fieldName] == string.Empty)
            {
                return "0";
            }

            int fieldValue = 0;

            if (Int32.TryParse(Request.Params[fieldName], out fieldValue) == true)
            {
                return fieldValue.ToString();
            }
            else
            {
                return "0";
            }
        }

        protected string GetClassNameByFieldNameAndValue(string fieldName, object fieldValue)
        {
            if (Convert.ToString(fieldValue) == GetRequestFieldValue(fieldName))
            {
                return "btn btn-xs btn-warning";
            }

            return "btn btn-xs";
        }

        protected string GetClassNameByCurrAreaSize(string sizeMin, string sizeMax)
        {
            if (GetRequestFieldValue("currAreaSizeMin") == sizeMin && GetRequestFieldValue("currAreaSizeMax") == sizeMax)
            {
                return "btn btn-xs btn-warning";
            }

            return "btn btn-xs";
        }

        protected string GetClassNameByCurrPrice(string sizeMin, string sizeMax)
        {
            //如果request的min和max正好等于传递值
            if (GetRequestFieldValue("currPriceMin") == sizeMin && GetRequestFieldValue("currPriceMax") == sizeMax)
            {
                if (GetRequestFieldValue("currPriceMinUsr") == "0" && GetRequestFieldValue("currPriceMaxUsr") == "0")
                {
                    return "btn btn-xs btn-warning";
                }
            }

            return "btn btn-xs";
        }


        protected string GetClassNameByCurrPriceEx()
        {
            if (GetRequestFieldValue("currPriceMinUsr") != "0" || GetRequestFieldValue("currPriceMaxUsr") != "0")
            {
                return "btn btn-xs btn-warning";
            }

            return "btn btn-xs";
        }

        protected string GetPriceUsrValue(string key)
        {
            string min = GetRequestFieldValue("currPriceMinUsr");
            string max = GetRequestFieldValue("currPriceMaxUsr");

            if (min != "0" || max != "0")
            {
                return GetRequestFieldValue(key);
            }

            return "";
        }

        protected List<HouseInfo> SearchHouses(int type, int joinType, string buildname, string address, int pageSize, int pageIndex, out int pageTotal)
        {
            return Houses.GetHouses(type, joinType, null, buildname, address, 0, 0, 0, 0, 0, 0, 0, 0, -1, -1, null, null, null, true, pageSize, pageIndex, out pageTotal);
        }
    }
}