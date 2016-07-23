using System;
using System.Collections.Generic;
using System.Web;
using HYJHLibrary.dal;
using HYJHLibrary.modal;

namespace HYJHLibrary.bll
{
    public class Users
    {
        public static int GetUserAuthValue(int userId)
        {
            return DataProvider.GetUserAuthValue(userId);
        }

        public static UserInfo GetUserInfo(int userId)
        {
            return DataProvider.GetUserInfo(userId);
        }

        public static List<UserInfo> GetAllUsers()
        {
            return DataProvider.GetAllUsers();
        }

        public static int CreateUser(UserInfo userinfo)
        {
            return DataProvider.CreateUser(userinfo);
        }

        public static void UpdateUserInfo(UserInfo userinfo)
        {
            DataProvider.UpdateUserInfo(userinfo);
        }

        public static void DeleteUser(int userId)
        {
            DataProvider.DeleteUser(userId);
        }

        public static UserInfo GetUserInfoByMobileAndPassword(string mobile, string passwordMD5)
        {
            return DataProvider.GetUserInfoByMobileAndPassword(mobile, passwordMD5);
        }

        public static void UpdateRoleOfUser(int userId, int roleId)
        {
            DataProvider.UpdateRoleOfUser(userId, roleId);
        }

        public static void UpdateDepartmentOfUser(int userId, int departmentId)
        {
            DataProvider.UpdateDepartmentOfUser(userId, departmentId);
        }

        public static bool UpdateUserPassword(int userId, string oldPassword, string newPassword)
        {
            return DataProvider.UpdateUserPassword(userId, oldPassword, newPassword);
        }
    }
}