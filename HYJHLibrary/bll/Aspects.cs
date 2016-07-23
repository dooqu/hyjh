using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.dal;


namespace HYJHLibrary.bll
{
    public class Aspects
    {
        public static List<KeyValuePair<string, string>> GetList(bool noNoLimit = false)
        {
            //List<KeyValuePair<string, string>> list = HttpContext.Current.Cache.Get("ASPECTS_LIST") as List<KeyValuePair<string, string>>;
            List<KeyValuePair<string, string>>  list = DataProvider.GetAspects();

            if (noNoLimit == true)
                list.RemoveAt(0);

            return list;
        }
    }
}