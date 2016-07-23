using System;
using System.Collections.Generic;
using System.Text;
using HYJHLibrary.dal;

namespace HYJHLibrary.bll
{
    public class PayTypes
    {
        public static List<KeyValuePair<string, String>> GetList()
        {
            return DataProvider.GetAllPayTypes();
        }
    }
}
