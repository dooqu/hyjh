using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.modal;
using HYJHLibrary.dal;

namespace HYJHLibrary.bll
{


    public class Houses
    {
        public static List<HouseInfo> GetHouses(
int type,
int joinType,
    string title,
    string buildingName,
    string address,
    int zoneId,
    int aspectId,
    int structId,
    int decorationId,
    int areaSizeMin,
    int areaSizeMax,
    int priceMin,
    int priceMax,
    int completeStatus,
    int errorStatus,
    string customName,
    string customTel,
    string orderBy,
    bool desc,
    int pageSize,
    int pageIndex,
    out int pageTotal
            )
        {
            return dal.DataProvider.GetHouses(
                type,
                joinType,
                title,
                buildingName,
                address,
                zoneId,
                aspectId,
                structId,
                decorationId,
                                areaSizeMin,
                areaSizeMax,
                priceMin,
                priceMax,
                completeStatus,
                errorStatus,
                customName,
                customTel,
                orderBy,
                desc, pageSize, pageIndex, out pageTotal);
        }

        public static HouseInfo GetHouseInfo(int houseId)
        {
            return DataProvider.GetHouseInfo(houseId);
        }


        public static void GetHousePictures(int houseId, ref List<HousePicture> pictures, ref List<HousePicture> thumbPictures)
        {
            DataProvider.GetHousePictures(houseId, ref pictures, ref thumbPictures);
        }

        public static int UpdateHouseInfo(HouseInfo house)
        {
            return DataProvider.UpdateHouseInfo(house);
        }

        public static List<HousePicture> GetHousePictures(int houseId)
        {
            List<HousePicture> pictures = new List<HousePicture>();

            List<HousePicture> thumb_pics = new List<HousePicture>();

            DataProvider.GetHousePictures(houseId, ref pictures, ref thumb_pics);

            return pictures;
        }

        public static int CreateHousePicture(int houseId, string filename)
        {
            return DataProvider.CreateHousePicture(houseId, filename);
        }

        public static void DeleteHousePicture(int picId)
        {
            string filename = Houses.GetPictureFilenameByPicId(picId);
            string filenameThumb = "thumb_" + filename;

            try
            {
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("/pic/" + filename));
                System.IO.File.Delete(HttpContext.Current.Server.MapPath("/pic/" + filenameThumb));
            }
            catch (Exception ex)
            {
            }

            DataProvider.DeleteHousePicture(picId);
        }

        public static void DeleteHouseInfo(int houseId)
        {
            DataProvider.DeleteHouseInfo(houseId);
        }

        public static string GetPictureFilenameByPicId(int picId)
        {
            return DataProvider.GetPictureFilenameByPicId(picId);
        }

        public static int CreateHouseInfo(HouseInfo houseinfo)
        {
            return DataProvider.CreateHouseInfo(houseinfo);
        }

        public static void CreateVisit(int userId, int houseId)
        {
            DataProvider.CreateVisit(userId, houseId);
        }

        public static List<UserInfo> GetVisitList(int houseId)
        {
            return DataProvider.GetVisitList(houseId);
        }

        public static int GetHouseIdByPicId(int picid)
        {
            return DataProvider.GetHouseIdByPicId(picid);
        }
    }
}