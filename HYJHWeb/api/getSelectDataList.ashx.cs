using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.bll;
using HYJHLibrary.modal;


namespace HYJHWeb.api
{
    /// <summary>
    /// getSelectDataList 的摘要说明
    /// </summary>
    public class getSelectDataList : BaseHandler
    {
        public override void OnLoad(HttpContext context)
        {
            base.OnLoad(context);

            String method = context.Request.Params["method"];
            bool noLimit = Convert.ToBoolean(context.Request.Params["nolimit"]);

            if(method == "zonelist")
            {
                List<KeyValuePair<String, String>> zonelist = Zones.GetList(noLimit);
                ResponseDataList(context, zonelist);
            }
            else if(method == "aspectlist")
            {
                List<KeyValuePair<String, String>> aspectlist = Aspects.GetList(noLimit);
                ResponseDataList(context, aspectlist);
            }
            else if(method == "decorationlist")
            {
                List<KeyValuePair<string, string>> decorationlist = Decorations.GetList(noLimit);
                ResponseDataList(context, decorationlist);
            }
            else if(method == "structlist")
            {
                List<KeyValuePair<string, string>> structlist = RoomStucts.GetList(noLimit);
                ResponseDataList(context, structlist);
            }
            else if(method == "paytypelist")
            {
                List<KeyValuePair<string, string>> paytypelist = PayTypes.GetList();
                ResponseDataList(context, paytypelist);
            }
        }

        public void ResponseDataList(HttpContext context, List<KeyValuePair<string, string>> datalist)
        {
            for (int i = 0; i < datalist.Count; i++)
            {
                context.Response.Write(String.Format("<option value='{0}'>{1}</option>", datalist[i].Key, datalist[i].Value));
            }
        }

        public override void OnError(Exception ex)
        {
            base.OnError(ex);
            HttpContext.Current.Response.Write(String.Format("<option>0</option>", "数据错误"));
        }
    }
}