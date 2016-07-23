using System;
using System.Collections.Generic;
using System.Text;

namespace HYJHLibrary.modal
{
    [Flags]
    public enum RoleBehavior
    {
        BrowseHouseList = 1,
        BrowseCustomList = 2,
        EditHouseInfo = 4,
        EditCustomInfo = 8,
        DeleteHouseInfo = 16,
        DeleteCustomInfo = 32,
        CreateHouseInfo = 64,
        CreateCustomInfo = 128,
        BrowseHouseInfo = 256,
        BrowseHouseInfoAndCustomTel = 512,
        BrowseCustomInfo = 1024,
        BrowseRentOutCustomTe = 2048,
        ManageRole = 4096,
        ManageUser = 8192,
        ManagerDepartment = 16384,
        BrowseSameDepartmentCustomTel = 16384 * 2,
        BrowseOrEditHouseInfoOfSelf = 16384 * 4,
        BrowseOrEditCustomInfoOfSelf = 16384 * 8
    }

    public class AuthorityInfo
    {
        public int AuthorityId
        {
            get; set;
        }

        public string AuthorityName
        {
            get; set;
        }
    }


    public class RoleInfo
    {
        public string RoleName
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }

        public int AuthValue
        {
            get; set;
        }
    }
}
