using System;
using System.Collections.Generic;
using System.Web;

namespace HYJHLibrary.modal
{
    public enum HouseInfoType
    {
        Rent = 2,
        RentOut = 0,
        Buy = 3,
        Sale = 1
    }

    public class HousePicture
    {
        public int PicId
        {
            get; set;
        }

        public string Filename
        {
            get; set;
        }
    }



    public class HouseInfo
    {
        public UserInfo UserBelong
        {
            get; set;
        }

        public int UserId
        {
            get; set;
        }

        public int HouseId
        {
            get;
            set;
        }

        public string Title
        {
            get; set;
        }

        public string BuildingName
        {
            get; set;
        }

        public string Address
        {
            get; set;
        }

        public int ZoneId
        {
            get; set;
        }

        public string ZoneName
        {
            get; set;
        }

        public double AreaSize
        {
            get; set;
        }

        public string StructName
        {
            get; set;
        }

        public int StructId
        {
            get; set;
        }

        public int AspectId
        {
            get; set;
        }

        public string AspectName
        {
            get; set;
        }

        public int DecorationId
        {
            get; set;
        }

        public string DecorationName
        {
            get; set;
        }

        public int FloorNum
        {
            get; set;
        }

        public int FloorTotal
        {
            get; set;
        }

        public int Price
        {
            get; set;
        }

        public string CustomName
        {
            get; set;
        }

        public bool IsCustomTel
        {
            get; set;
        }

        public string CustomTel
        {
            get; set;
        }

        public string CustomAddr
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public DateTime CompleteDate
        {
            get; set;
        }

        public DateTime HopeDate
        {
            get; set;
        }

        public string BuildYear
        {
            get; set;
        }

        public string Comment
        {
            get; set;
        }

        public HouseInfoType Type
        {
            get; set;
        }

        public int JoinType
        {
            get; set;
        }

        public string ContractCode
        {
            get; set;
        }

        public string CoverUrl
        {
            get; set;
        }

        public List<HousePicture> ThumbPictures
        {
            get; set;
        }

        public List<HousePicture> Pictures
        {
            get; set;
        }

        public String SessionId
        {
            get; set;
        }

        public bool IsInError
        {
            get; set;
        }

        public bool IsCompleted
        {
            get; set;
        }

        public int PayTypeId
        {
            get; set;
        }

        public String PayTypeName
        {
            get; set;
        }

        public String ErrorMessage
        {
            get; set;
        }

        public String CompleteDateString
        {
            get
            {
                return this.CompleteDate.ToString("yyyy-MM-dd");
            }
        }

        public String CreateDateString
        {
            get
            {
                return this.CreateDate.ToString("yyyy-MM-dd");
            }
        }

        public int Rank
        {
            get; set;
        }

        public int MonthPrice
        {
            get; set;
        }

        public int ThreeMonthPrice
        {
            get; set;
        }

        public int HalfYearPrice
        {
            get; set;
        }

        public int YearPrice
        {
            get; set;
        }

        public string DaysLeft
        {
            get
            {
                try
                {
                    // 2016/7/20           2017/7/19
                    return GetDur(DateTime.Now, CompleteDate);                    
                }
                catch
                {
                    return "未知时间";
                }
            }
        }


        static string GetDur(DateTime t1, DateTime t2)
        {
            if (t2 <= t1)
                return "已经到期";

            int day2 = t2.Day;
            int mon2 = t2.Month;
            int year2 = t2.Year;


            int day1 = t1.Day;
            int mon1 = t1.Month;
            int year1 = t1.Year;

            int day = 0;

            if (day2 <= day1)
            {
                mon2 -= 1;
                day2 += 30;

                day = day2 - day1 + 1;
            }
            else if ((day2 == 31 || day2 == 30) && day1 == 1)
            {
                day2 = 1;
                mon2 += 1;

                day = 0;
            }
            else
            {
                day = day2 - day1 + 1;
            }



            if (mon2 < mon1)
            {
                if (year2 > year1)
                {
                    year2 -= 1;
                    mon2 += 12;
                }
            }

            int mon = mon2 - mon1;

            mon += (day / 30);

            day = (day % 30);


            int year = year2 - year1;

            year += (mon / 12);
            mon = (mon % 12);


            return string.Format("{0}{1}{2}", (year > 0) ? year + "年" : "", (mon > 0) ? mon + "个月" : "", (day > 0) ? day + "天" : "");

        }
    }
}