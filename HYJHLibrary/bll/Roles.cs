using System;
using System.Collections.Generic;
using System.Text;

using HYJHLibrary.modal;
using HYJHLibrary.dal;

namespace HYJHLibrary.bll
{
    public class Roles
    {
        public static List<RoleInfo> GetAllRoles()
        {
            return DataProvider.GetAllRoles();
        }

        public static List<AuthorityInfo> GetAllAuthorities()
        {
            return DataProvider.GetAllAuthorities();
        }

        public static void UpdateAuthValueOfRole(int roleId, int authValue)
        {
            DataProvider.UpdateAuthValueOfRole(roleId, authValue);
        }

        public static void DeleteRole(int roleId)
        {
            DataProvider.DeleteRole(roleId);
        }

        public static int CreateRole(string roleName, int authValue)
        {
            return DataProvider.CreateRole(roleName, authValue);
        }

        public static bool CanUserDo(UserInfo userinfo, RoleBehavior behavior)
        {
            if (userinfo == null)
                return false;

            if (String.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings.Get("rootUser")) == false && userinfo.Username.Trim().ToString() == System.Configuration.ConfigurationManager.AppSettings.Get("rootUser"))
            {
                return true;
            }

            return ((userinfo.AuthValue & (int)behavior) > 0);
        }
    }
}
