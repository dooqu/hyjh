﻿using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.dal;

namespace HYJHLibrary.bll
{
    public class Zones
    {
        public static List<KeyValuePair<string, string>> GetList(bool noNoLimit = false)
        {
            List<KeyValuePair<string, string>> list = DataProvider.GetZones();

            if(noNoLimit)
            {
                list.RemoveAt(0);
            }

            return list;
        }
    }
}