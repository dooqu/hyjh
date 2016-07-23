using System;
using System.Collections.Generic;
using System.Web;

namespace HYJHLibrary.modal
{
    public class UserInfo
    {
        public int UserId
        {
            get; set;
        }

        public string Username
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string Mobile
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }

        public string RoleName
        {
            get; set;
        }

        public int DepartmentId
        {
            get; set;
        }

        public string DepartmentName
        {
            get; set;
        }

        public string Profile
        {
            get; set;
        }

        public DateTime LastLoginDate
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public int AuthValue
        {
            get; set;
        }
    }
}