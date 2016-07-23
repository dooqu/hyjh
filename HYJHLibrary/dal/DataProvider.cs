using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;
using HYJHLibrary.modal;

namespace HYJHLibrary.dal
{
    public class DataProvider
    {
        static string connection_string;

        static DataProvider()
        {
            connection_string = System.Configuration.ConfigurationManager.ConnectionStrings["HYJH"].ConnectionString;
        }

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
            List<HouseInfo> houses = new List<HouseInfo>();

            SqlParameter spPageTotal = new SqlParameter("@PageTotal", SqlDbType.Int);
            spPageTotal.Direction = ParameterDirection.Output;
            spPageTotal.Value = 0;
            SqlParameter spType = new SqlParameter("@Type", SqlDbType.Int);
            spType.Value = type;

            SqlParameter spJoinType = new SqlParameter("@JoinType", SqlDbType.Int);
            spJoinType.Value = joinType;

            SqlParameter spTitle = new SqlParameter("@Title", SqlDbType.NVarChar, 90);
            spTitle.Value = title;

            SqlParameter spBuildingName = new SqlParameter("@BuildingName", SqlDbType.NVarChar, 90);
            spBuildingName.Value = buildingName;

            SqlParameter spAddress = new SqlParameter("@Address", SqlDbType.NVarChar, 600);
            spAddress.Value = address;

            SqlParameter spZoneId = new SqlParameter("@ZoneId", SqlDbType.Int);
            spZoneId.Value = zoneId;

            SqlParameter spAspectId = new SqlParameter("@AspectId", SqlDbType.Int);
            spAspectId.Value = aspectId;

            SqlParameter spStructId = new SqlParameter("@StructId", SqlDbType.Int);
            spStructId.Value = structId;

            SqlParameter spDecorationId = new SqlParameter("@DecorationId", SqlDbType.Int);
            spDecorationId.Value = decorationId;

            SqlParameter spAreaSizeMin = new SqlParameter("@AreaSizeMin", SqlDbType.Int);
            spAreaSizeMin.Value = areaSizeMin;

            SqlParameter spAreaSizeMax = new SqlParameter("@AreaSizeMax", SqlDbType.Int);
            spAreaSizeMax.Value = areaSizeMax;

            SqlParameter spPriceMin = new SqlParameter("@PriceMin", SqlDbType.Int);
            spPriceMin.Value = priceMin;

            SqlParameter spPriceMax = new SqlParameter("@PriceMax", SqlDbType.Int);
            spPriceMax.Value = priceMax;

            SqlParameter spCompleteStatus = new SqlParameter("@CompleteStatus", SqlDbType.Int);
            spCompleteStatus.Value = completeStatus;

            SqlParameter spErrorStatus = new SqlParameter("@ErrorStatus", SqlDbType.Int);
            spErrorStatus.Value = errorStatus;

            SqlParameter spCustomName = new SqlParameter("@CustomName", SqlDbType.NVarChar, 30);
            spCustomName.Value = customName;

            SqlParameter spCustomTel = new SqlParameter("@CustomTel", SqlDbType.VarChar, 20);
            spCustomTel.Value = customTel;

            SqlParameter spOrderBy = new SqlParameter("@OrderBy", SqlDbType.VarChar, 20);
            spOrderBy.Value = orderBy;

            SqlParameter spDesc = new SqlParameter("@DESC", SqlDbType.Bit);
            spDesc.Value = desc;

            SqlParameter spPageSize = new SqlParameter("@PageSize", SqlDbType.Int);
            spPageSize.Value = pageSize;

            SqlParameter spPageIndex = new SqlParameter("@PageIndex", SqlDbType.Int);
            spPageIndex.Value = pageIndex;


            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("GetHouses", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(spType);
                cmd.Parameters.Add(spJoinType);
                cmd.Parameters.Add(spTitle);
                cmd.Parameters.Add(spBuildingName);
                cmd.Parameters.Add(spAddress);
                cmd.Parameters.Add(spZoneId);
                cmd.Parameters.Add(spAspectId);
                cmd.Parameters.Add(spStructId);
                cmd.Parameters.Add(spDecorationId);
                cmd.Parameters.Add(spAreaSizeMin);
                cmd.Parameters.Add(spAreaSizeMax);
                cmd.Parameters.Add(spPriceMin);
                cmd.Parameters.Add(spPriceMax);
                cmd.Parameters.Add(spCompleteStatus);
                cmd.Parameters.Add(spErrorStatus);
                cmd.Parameters.Add(spCustomName);
                cmd.Parameters.Add(spCustomTel);
                cmd.Parameters.Add(spOrderBy);
                cmd.Parameters.Add(spDesc);
                cmd.Parameters.Add(spPageSize);
                cmd.Parameters.Add(spPageIndex);
                cmd.Parameters.Add(spPageTotal);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HouseInfo house = new HouseInfo();
                        house.HouseId = Convert.ToInt32(reader["HouseId"]);
                        house.Title = Convert.ToString(reader["Title"]);
                        house.BuildingName = Convert.ToString(reader["BuildingName"]);
                        house.Address = Convert.ToString(reader["Address"]);
                        house.FloorNum = Convert.ToInt32(reader["FloorNum"]);
                        house.DecorationId = Convert.ToInt32(reader["DecorationId"]);
                        house.DecorationName = Convert.ToString(reader["DecorationName"]).TrimEnd();
                        house.FloorTotal = Convert.ToInt32(reader["FloorTotal"]);
                        house.MonthPrice = Convert.ToInt32(reader["MonthPrice"]);
                        house.ThreeMonthPrice = Convert.ToInt32(reader["ThreeMonthPrice"]);
                        house.HalfYearPrice = Convert.ToInt32(reader["HalfYearPrice"]);
                        house.YearPrice = Convert.ToInt32(reader["YearPrice"]);
                        house.AreaSize = Convert.ToDouble(reader["AreaSize"]);
                        house.AspectId = Convert.ToInt32(reader["AspectId"]);
                        house.AspectName = Convert.ToString(reader["AspectName"]).TrimEnd();
                        house.StructId = Convert.ToInt32(reader["StructId"]);
                        house.StructName = Convert.ToString(reader["StructName"]).TrimEnd();
                        house.ZoneId = Convert.ToInt32(reader["ZoneId"]);
                        house.ZoneName = Convert.ToString(reader["ZoneName"]).TrimEnd();
                        house.CustomName = Convert.ToString(reader["CustomName"]);
                        house.IsCustomTel = Convert.ToBoolean(reader["IsCustomTel"]);
                        house.CustomTel = Convert.ToString(reader["CustomTel"]);
                        house.CustomAddr = Convert.ToString(reader["CustomAddr"]);
                        house.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                        house.CoverUrl = Convert.ToString(reader["CoverUrl"]);
                        house.IsInError = Convert.ToBoolean(reader["IsInError"]);
                        house.ErrorMessage = Convert.ToString(reader["ErrorMsg"]);
                        house.Comment = String.Empty;
                        house.PayTypeId = Convert.ToInt32(reader["PayTypeId"]);
                        house.PayTypeName = Convert.ToString(reader["PayTypeName"]).TrimEnd();
                        house.Rank = Convert.ToInt32(reader["Rank"]);

                        if (reader["CompleteDate"] == DBNull.Value)
                        {
                            house.CompleteDate = DateTime.Now;
                        }
                        else
                            house.CompleteDate = Convert.ToDateTime(reader["CompleteDate"]);

                        if (reader["HopeDate"] == DBNull.Value)
                        {
                            house.HopeDate = DateTime.Now;
                        }
                        else
                            house.HopeDate = Convert.ToDateTime(reader["HopeDate"]);

                        house.ContractCode = Convert.ToString(reader["ContractCode"]);
                        house.JoinType = Convert.ToInt32(reader["JoinType"]);
                        house.Type = (HouseInfoType)Convert.ToInt32(reader["Type"]);
                        house.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);

                        house.UserBelong = new UserInfo();
                        house.UserBelong.UserId = Convert.ToInt32(reader["UserId"]);
                        house.UserBelong.Username = Convert.ToString(reader["Username"]);

                        houses.Add(house);
                    }
                }

                pageTotal = Convert.ToInt32(spPageTotal.Value);
            }

            return houses;
        }

        public static HouseInfo GetHouseInfo(int houseId)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetHouseInfo", new SqlParameter("@HouseId", houseId)))
            {
                if (reader.Read())
                {
                    HouseInfo house = new HouseInfo();

                    house.HouseId = Convert.ToInt32(reader["HouseId"]);
                    house.BuildingName = Convert.ToString(reader["BuildingName"]);
                    house.Title = Convert.ToString(reader["Title"]);
                    house.Address = Convert.ToString(reader["Address"]);
                    house.ZoneId = Convert.ToInt32(reader["ZoneId"]);
                    house.AspectId = Convert.ToInt32(reader["AspectId"]);
                    house.DecorationId = Convert.ToInt32(reader["DecorationId"]);
                    house.StructId = Convert.ToInt32(reader["StructId"]);
                    house.FloorNum = Convert.ToInt32(reader["FloorNum"]);
                    house.FloorTotal = Convert.ToInt32(reader["FloorTotal"]);
                    house.DecorationName = Convert.ToString(reader["DecorationName"]).TrimEnd();
                    house.MonthPrice = Convert.ToInt32(reader["MonthPrice"]);
                    house.ThreeMonthPrice = Convert.ToInt32(reader["ThreeMonthPrice"]);
                    house.HalfYearPrice = Convert.ToInt32(reader["HalfYearPrice"]);
                    house.YearPrice = Convert.ToInt32(reader["YearPrice"]);
                    house.AreaSize = Convert.ToDouble(reader["AreaSize"]);
                    house.AspectName = Convert.ToString(reader["AspectName"]).TrimEnd();
                    house.StructName = Convert.ToString(reader["StructName"]).TrimEnd();
                    house.ZoneName = Convert.ToString(reader["ZoneName"]).TrimEnd();
                    house.CustomName = Convert.ToString(reader["CustomName"]).TrimEnd();
                    house.IsCustomTel = Convert.ToBoolean(reader["IsCustomTel"]);
                    house.CustomTel = Convert.ToString(reader["CustomTel"]);
                    house.CustomAddr = Convert.ToString(reader["CustomAddr"]);
                    house.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    house.Comment = Convert.ToString(reader["Comment"]);
                    house.IsInError = Convert.ToBoolean(reader["IsInError"]);
                    house.ErrorMessage = Convert.ToString(reader["ErrorMsg"]);
                    house.IsCompleted = Convert.ToBoolean(reader["IsCompleted"]);
                    house.PayTypeId = Convert.ToInt32(reader["PayTypeId"]);
                    house.PayTypeName = Convert.ToString(reader["PayTypeName"]).TrimEnd();
                    house.Rank = Convert.ToInt32(reader["Rank"]);


                    if (reader["CompleteDate"] == DBNull.Value)
                    {
                        house.CompleteDate = DateTime.Now;
                    }
                    else
                        house.CompleteDate = Convert.ToDateTime(reader["CompleteDate"]);

                    if (reader["HopeDate"] == DBNull.Value)
                    {
                        house.HopeDate = DateTime.Now;
                    }
                    else
                        house.HopeDate = Convert.ToDateTime(reader["HopeDate"]);

                    house.ContractCode = Convert.ToString(reader["ContractCode"]);
                    house.JoinType = Convert.ToInt32(reader["JoinType"]);
                    house.Type = (HouseInfoType)Convert.ToInt32(reader["Type"]);
                    house.CoverUrl = Convert.ToString(reader["CoverUrl"]);

                    house.UserBelong = new UserInfo();
                    house.UserBelong.UserId = (reader["UserId"]==DBNull.Value)? 0 : Convert.ToInt32(reader["UserId"]);
                    house.UserBelong.Username = Convert.ToString(reader["Username"]);
                    house.UserBelong.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    return house;
                }

                return null;
            }
        }

        public static void GetHousePictures(int houseId, ref List<HousePicture> pictures, ref List<HousePicture> thumpictures)
        {
            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(conn, CommandType.Text, "SELECT PicId,Filename FROM Pictures WHERE HouseId = @HouseId", new SqlParameter("@HouseId", houseId)))
                {
                    while (reader.Read())
                    {
                        if (pictures != null)
                        {
                            HousePicture pic = new HousePicture();
                            pic.PicId = Convert.ToInt32(reader["PicId"]);
                            pic.Filename = Convert.ToString(reader["Filename"]);
                            pictures.Add(pic);
                        }

                        if (thumpictures != null)
                        {
                            HousePicture pic = new HousePicture();
                            pic.PicId = Convert.ToInt32(reader["PicId"]);
                            pic.Filename = "thumb_" + Convert.ToString(reader["Filename"]);
                            thumpictures.Add(pic);
                        }
                    }
                }
            }
        }


        public static UserInfo GetUserInfo(int userId)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetUserInfo", new SqlParameter("@UserId", userId)))
            {
                if (reader.Read())
                {
                    UserInfo user = new UserInfo();
                    user.UserId = Convert.ToInt32(reader["UserId"]);
                    user.Username = Convert.ToString(reader["Username"]);
                    user.Mobile = Convert.ToString(reader["Mobile"]).Trim();
                    user.Profile = Convert.ToString(reader["Profile"]);
                    user.RoleId = Convert.ToInt32(reader["RoleId"]);
                    user.RoleName = Convert.ToString(reader["RoleName"]).Trim();
                    user.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    user.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    user.AuthValue = Convert.ToInt32(reader["AuthValue"]);
                    user.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    user.LastLoginDate = Convert.ToDateTime(reader["LoginDate"]);

                    return user;
                }
            }

            return null;
        }

        public static int GetUserAuthValue(int userId)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetUserAuthValue", new SqlParameter("@UserId", userId)))
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["AuthValue"]);
                }
            }

            return 0;
        }

        public static List<KeyValuePair<string, string>> GetZones()
        {
            List<KeyValuePair<string, string>> zones = new List<KeyValuePair<string, string>>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "select ZoneId, ZoneName from Zones"))
            {
                while (reader.Read())
                {
                    zones.Add(new KeyValuePair<string, string>(Convert.ToString(reader["ZoneId"]), Convert.ToString(reader["ZoneName"])));
                }
            }

            return zones;
        }


        public static List<KeyValuePair<string, string>> GetDecorations()
        {
            List<KeyValuePair<string, string>> decorations = new List<KeyValuePair<string, string>>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "select DecorationId, DecorationName from Decorations"))
            {
                while (reader.Read())
                {
                    decorations.Add(new KeyValuePair<string, string>(Convert.ToString(reader["DecorationId"]), Convert.ToString(reader["DecorationName"])));
                }
            }

            return decorations;
        }

        public static List<KeyValuePair<string, string>> GetAspects()
        {
            List<KeyValuePair<string, string>> aspects = new List<KeyValuePair<string, string>>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "select AspectId, AspectName from Aspects"))
            {
                while (reader.Read())
                {
                    aspects.Add(new KeyValuePair<string, string>(Convert.ToString(reader["AspectId"]), Convert.ToString(reader["AspectName"])));
                }
            }

            return aspects;
        }

        public static List<KeyValuePair<string, string>> GetRoomStructs()
        {
            List<KeyValuePair<string, string>> structs = new List<KeyValuePair<string, string>>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "select StructId, StructName from RoomStructs"))
            {
                while (reader.Read())
                {
                    structs.Add(new KeyValuePair<string, string>(Convert.ToString(reader["StructId"]), Convert.ToString(reader["StructName"])));
                }
            }

            return structs;
        }

        public static int CreateHousePicture(int houseId, string filename)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "CreateHousePicture", new SqlParameter("@HouseId", houseId), new SqlParameter("@Filename", filename)));
        }

        public static void DeleteHousePicture(int picId)
        {
            SqlHelper.ExecuteScalar(connection_string, "DeleteHousePicture", new SqlParameter("@HouseId", picId));
        }

        public static void DeleteHouseInfo(int houseId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, CommandType.Text, "DELETE FROM Houses WHERE HouseId = @HouseId", new SqlParameter("@HouseId", houseId));
        }

        public static string GetPictureFilenameByPicId(int picId)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "SELECT Filename FROM Pictures WHERE PicId = @PicId", new SqlParameter("@PicId", picId)))
            {
                if (reader.Read())
                {
                    return Convert.ToString(reader["Filename"]);
                }
            }

            return null;
        }

        public static int UpdateHouseInfo(HouseInfo houseinfo)
        {
            if (houseinfo == null)
                return 0;

            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "UpdateHouseInfo",
                new SqlParameter("@HouseId", houseinfo.HouseId),
                new SqlParameter("@Title", houseinfo.Title),
                new SqlParameter("@BuildingName", houseinfo.BuildingName),
                new SqlParameter("@Address", houseinfo.Address),
                new SqlParameter("@ZoneId", houseinfo.ZoneId),
                new SqlParameter("@AspectId", houseinfo.AspectId),
                new SqlParameter("@StructId", houseinfo.StructId),
                new SqlParameter("@DecorationId", houseinfo.DecorationId),
                new SqlParameter("@AreaSize", houseinfo.AreaSize),
                new SqlParameter("@PayTypeId", houseinfo.PayTypeId),
                new SqlParameter("@MonthPrice", houseinfo.MonthPrice),
                new SqlParameter("@ThreeMonthPrice", houseinfo.ThreeMonthPrice),
                new SqlParameter("@HalfYearPrice", houseinfo.HalfYearPrice),
                new SqlParameter("@YearPrice", houseinfo.YearPrice),
                new SqlParameter("@FloorNum", houseinfo.FloorNum),
                new SqlParameter("@FloorTotal", houseinfo.FloorTotal),
                new SqlParameter("@JoinType", houseinfo.JoinType),
                new SqlParameter("@ContractCode", houseinfo.ContractCode),  
                new SqlParameter("@Rank", houseinfo.Rank),
                new SqlParameter("@CompleteDate", houseinfo.CompleteDate),
                new SqlParameter("@CustomName", houseinfo.CustomName),
                new SqlParameter("@IsCustomTel", houseinfo.IsCustomTel),
                new SqlParameter("@CustomTel", houseinfo.CustomTel),
                new SqlParameter("@Comment", houseinfo.Comment),
                new SqlParameter("@IsInError", houseinfo.IsInError),
                new SqlParameter("@ErrorMessage", houseinfo.ErrorMessage),                
                new SqlParameter("@IsCompleted", houseinfo.IsCompleted)
                ));
        }

        public static int CreateHouseInfo(HouseInfo houseinfo)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "CreateHouseInfo",
                new SqlParameter("@Type", (int)houseinfo.Type),
                new SqlParameter("@Title", houseinfo.Title),
                new SqlParameter("@BuildingName", houseinfo.BuildingName),
                new SqlParameter("@Address", houseinfo.Address),
                new SqlParameter("@ZoneId", houseinfo.ZoneId),
                new SqlParameter("@AspectId", houseinfo.AspectId),
                new SqlParameter("@StructId", houseinfo.StructId),
                new SqlParameter("@DecorationId", houseinfo.DecorationId),
                new SqlParameter("@AreaSize", houseinfo.AreaSize),
                new SqlParameter("@PayTypeId", houseinfo.PayTypeId),
                new SqlParameter("@MonthPrice", houseinfo.MonthPrice),
                new SqlParameter("@ThreeMonthPrice", houseinfo.ThreeMonthPrice),
                new SqlParameter("@HalfYearPrice", houseinfo.HalfYearPrice),
                new SqlParameter("@YearPrice", houseinfo.YearPrice),
                new SqlParameter("@FloorNum", houseinfo.FloorNum),
                new SqlParameter("@FloorTotal", houseinfo.FloorTotal),
                new SqlParameter("@CoverUrl", houseinfo.CoverUrl),
                new SqlParameter("@JoinType", houseinfo.JoinType),
                new SqlParameter("@ContractCode", houseinfo.ContractCode),
                new SqlParameter("@Rank", houseinfo.Rank),
                new SqlParameter("@CompleteDate", houseinfo.CompleteDate),
                new SqlParameter("@CustomName", houseinfo.CustomName),
                new SqlParameter("@IsCustomTel", houseinfo.IsCustomTel),
                new SqlParameter("@CustomTel", houseinfo.CustomTel),
                new SqlParameter("@CustomAddr", houseinfo.CustomAddr),
                new SqlParameter("@IsInError", houseinfo.IsInError),
                new SqlParameter("@ErrorMessage", houseinfo.ErrorMessage),
                new SqlParameter("@Comment", houseinfo.Comment),
                new SqlParameter("@UserId", houseinfo.UserBelong.UserId)))

            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["HouseId"]);
                }
            }

            return -1;
        }

        public static List<RoleInfo> GetAllRoles()
        {
            List<RoleInfo> roles = new List<RoleInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "SELECT RoleId, RoleName, AuthValue FROM Roles"))
            {
                while (reader.Read())
                {
                    RoleInfo role = new RoleInfo();

                    role.RoleId = Convert.ToInt32(reader["RoleId"]);
                    role.RoleName = Convert.ToString(reader["RoleName"]).TrimEnd();
                    role.AuthValue = Convert.ToInt32(reader["AuthValue"]);

                    roles.Add(role);
                }
            }

            return roles;
        }

        public static List<AuthorityInfo> GetAllAuthorities()
        {
            List<AuthorityInfo> authorities = new List<AuthorityInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "SELECT AuthorityId, AuthorityName FROM Authorities"))
            {
                while (reader.Read())
                {
                    AuthorityInfo auth = new AuthorityInfo();

                    auth.AuthorityId = Convert.ToInt32(reader["AuthorityId"]);
                    auth.AuthorityName = Convert.ToString(reader["AuthorityName"]).TrimEnd();

                    authorities.Add(auth);
                }
            }

            return authorities;
        }

        public static void UpdateAuthValueOfRole(int roleId, int authValue)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "UpdateAuthValueOfRole", new SqlParameter("@RoleId", roleId), new SqlParameter("@AuthValue", authValue));
        }

        public static void DeleteRole(int roleId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "DeleteRole", new SqlParameter("@RoleId", roleId));
        }

        public static int CreateRole(string roleName, int authValue)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "CreateRole", new SqlParameter("@RoleName", roleName), new SqlParameter("@AuthValue", authValue)));
        }


        public static List<UserInfo> GetAllUsers()
        {
            List<UserInfo> users = new List<UserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetAllUsers"))
            {
                while (reader.Read())
                {
                    UserInfo userinfo = new UserInfo();

                    userinfo.UserId = Convert.ToInt32(reader["UserId"]);
                    userinfo.Username = Convert.ToString(reader["Username"]).TrimEnd();
                    userinfo.RoleId = Convert.ToInt32(reader["RoleId"]);
                    userinfo.RoleName = Convert.ToString(reader["RoleName"]).TrimEnd();
                    userinfo.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    userinfo.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    userinfo.AuthValue = Convert.ToInt32(reader["AuthValue"]);
                    userinfo.Mobile = Convert.ToString(reader["Mobile"]).TrimEnd();
                    userinfo.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    userinfo.LastLoginDate = Convert.ToDateTime(reader["LoginDate"]);

                    users.Add(userinfo);
                }
            }

            return users;
        }

        public static int CreateUser(UserInfo userinfo)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "CreateUser", new SqlParameter("@Username", userinfo.Username),
                new SqlParameter("@Mobile", userinfo.Mobile),
                new SqlParameter("@Password", userinfo.Password),
                new SqlParameter("@RoleId", userinfo.RoleId),
                new SqlParameter("@DepartmentId", userinfo.DepartmentId),
                new SqlParameter("@Profile", userinfo.Profile)));
        }

        public static void DeleteUser(int userId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "DeleteUser", new SqlParameter("@UserId", userId));
        }

        public static void UpdateUserInfo(UserInfo userinfo)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "UpdateUserInfo", new SqlParameter("@UserId", userinfo.UserId),
                new SqlParameter("@PasswordMD5", userinfo.Password), new SqlParameter("@Profile", userinfo.Profile));
        }

        public static UserInfo GetUserInfoByMobileAndPassword(string mobile, string passwordMD5)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetUserInfoByMobileAndPassword",
                new SqlParameter("@Mobile", mobile), new SqlParameter("@PasswordMD5", passwordMD5)))
            {
                if (reader.Read())
                {
                    UserInfo userinfo = new UserInfo();

                    userinfo.UserId = Convert.ToInt32(reader["UserId"]);
                    userinfo.Username = Convert.ToString(reader["Username"]).TrimEnd();
                    userinfo.RoleId = Convert.ToInt32(reader["RoleId"]);
                    userinfo.RoleName = Convert.ToString(reader["RoleName"]).TrimEnd();
                    userinfo.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    userinfo.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                    userinfo.AuthValue = Convert.ToInt32(reader["AuthValue"]);
                    userinfo.Mobile = Convert.ToString(reader["Mobile"]).TrimEnd();
                    userinfo.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    userinfo.LastLoginDate = Convert.ToDateTime(reader["LoginDate"]);

                    return userinfo;
                }
            }

            return null;
        }

        public static void UpdateRoleOfUser(int userId, int roleId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "UpdateRoleOfUser", new SqlParameter("@UserId", userId),
                           new SqlParameter("@RoleId", roleId));
        }

        public static void UpdateDepartmentOfUser(int userId, int departmentId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "UpdateDepartmentOfUser", new SqlParameter("@UserId", userId),
                           new SqlParameter("@DepartmentId", departmentId));
        }

        public static List<DepartmentInfo> GetDepartments()
        {
            List<DepartmentInfo> departmentList = new List<DepartmentInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetDepartments"))
            {
                while (reader.Read())
                {
                    DepartmentInfo departmentInfo = new DepartmentInfo();

                    departmentInfo.DepartmentId = Convert.ToInt32(reader["DepartmentId"]);
                    departmentInfo.DepartmentName = Convert.ToString(reader["DepartmentName"]);

                    departmentList.Add(departmentInfo);
                }
            }

            return departmentList;
        }

        public static int CreateDepartment(string departmentName)
        {
            SqlParameter spDepartmentName = new SqlParameter("@DepartmentName", SqlDbType.NVarChar, 60);
            spDepartmentName.Value = departmentName;

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "CreateDepartment", spDepartmentName))
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["DepartmentId"]);
                }
            }

            return 0;
        }

        public static void DeleteDepartment(int departmentId)
        {
            SqlParameter spDepartmentId = new SqlParameter("@DepartmentId", SqlDbType.Int);
            spDepartmentId.Value = departmentId;

            SqlHelper.ExecuteNonQuery(connection_string, "DeleteDepartment", spDepartmentId);
        }


        public static bool UpdateUserPassword(int userId, string oldPassword, string newPassword)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "UpdateUserPassword", new SqlParameter("@UserId", userId),
                new SqlParameter("@OldPasswordMD5", oldPassword), new SqlParameter("@NewPasswordMD5", newPassword))) == 1;
        }

        public static void CreateVisit(int userId, int houseId)
        {
            SqlHelper.ExecuteNonQuery(connection_string, "CreateVisit", new SqlParameter("@UserId", userId), new SqlParameter("@HouseId", houseId));
        }

        public static List<UserInfo> GetVisitList(int houseId)
        {
            List<UserInfo> users = new List<UserInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, "GetVisitList", new SqlParameter("@HouseId", houseId)))
            {
                while(reader.Read())
                {
                    UserInfo userinfo = new UserInfo();
                    userinfo.UserId = Convert.ToInt32(reader["UserId"]);
                    userinfo.Username = Convert.ToString(reader["Username"]);
                    userinfo.CreateDate = Convert.ToDateTime(reader["VisitDate"]);

                    users.Add(userinfo);
                }
            }

            return users;
        }

        public static int GetHouseIdByPicId(int picId)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(connection_string, "GetHouseIdByPicId", new SqlParameter("@PicId", picId)));
        }

        public static List<KeyValuePair<string, string>> GetAllPayTypes()
        {
            List<KeyValuePair<string, string>> alltypes = new List<KeyValuePair<string, string>>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(connection_string, CommandType.Text, "SELECT PayTypeId, PayTypeName FROM PayTypes"))
            {
                while(reader.Read())
                {
                    alltypes.Add(new KeyValuePair<string, string>(Convert.ToString(reader["PayTypeId"]), Convert.ToString(reader["PayTypeName"])));
                }
            }

            return alltypes;
        }
    }
}