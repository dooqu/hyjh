using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;
using System.Web.Security;

namespace HYJHWeb
{
    public partial class userManager : HYJHLibrary.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CanDo(RoleBehavior.ManageUser) == false)
                throw new Exception("您没有权限管理用户和角色");

            if(string.IsNullOrEmpty(Request.Form["method"]) == false)
            {
                if(Request.Form["method"] == "update_role")
                {
                    int userId = Convert.ToInt32(Request.Form["userId"]);
                    int roleId = Convert.ToInt32(Request.Form["roleId"]);

                    Users.UpdateRoleOfUser(userId, roleId);
                    Response.Redirect("userManager.aspx");
                }
                else if(Request.Form["method"] == "update_department")
                {
                    int userId = Convert.ToInt32(Request.Form["userId"]);
                    int departmentId = Convert.ToInt32(Request.Form["departmentId"]);

                    Users.UpdateDepartmentOfUser(userId, departmentId);
                    Response.Redirect("userManager.aspx");
                }
                else if(Request.Form["method"] == "create_user")
                {

                    string username = Request.Form["username"];
                    string password = FormsAuthentication.HashPasswordForStoringInConfigFile(Request.Form["password"], "MD5");
                    string mobile = Request.Form["mobile"];
                    int roleId = Convert.ToInt32(Request.Form["newRoleOfUser"]);
                    int departmentId = Convert.ToInt32(Request.Form["newDepartmentOfUser"]);

                    UserInfo userinfo = new UserInfo();
                    userinfo.Username = username;
                    userinfo.Mobile = mobile;
                    userinfo.Password = password;
                    userinfo.RoleId = roleId;
                    userinfo.DepartmentId = departmentId;
                    userinfo.Profile = "";

                    try
                    {
                        Users.CreateUser(userinfo);
                    }
                    catch(Exception ex)
                    {

                    }                    

                    Response.Redirect("userManager.aspx");
                }
                else if(Request.Form["method"] == "delete_user")
                {
                    int userId = Convert.ToInt32(Request.Form["userId"]);

                    UserInfo userinfo = Users.GetUserInfo(userId);

                    if(userinfo.Username.Trim() != System.Configuration.ConfigurationManager.AppSettings.Get("rootUser"))
                    {
                        Users.DeleteUser(userId);
                    }                   

                    Response.Redirect("userManager.aspx");
                }
            }

            //绑定所有的用户列表
            List<UserInfo> users = Users.GetAllUsers();
            usersRepeater.DataSource = users;
            usersRepeater.DataBind();

            //绑定所有的角色列表
            List<RoleInfo> roles = HYJHLibrary.bll.Roles.GetAllRoles();
            roleRepeater.DataSource = roles;
            roleRepeater.DataBind();
            roleRepeater2.DataSource = roles;
            roleRepeater2.DataBind();

            List<DepartmentInfo> departmentList = HYJHLibrary.bll.Departments.GetList();

            departmentRepeater.DataSource = departmentList;
            departmentRepeater.DataBind();
            departmentRepeater2.DataSource = departmentList;
            departmentRepeater2.DataBind();
        }
    }
}