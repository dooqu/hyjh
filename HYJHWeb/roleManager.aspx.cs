using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class roleManager : HYJHLibrary.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(CanDo(RoleBehavior.ManageRole) == false)
            {
                throw new Exception("您没有权限使用功能");
            }
            if(Page.IsPostBack == false)
            {
                List<AuthorityInfo> auths = Roles.GetAllAuthorities();

                authRepeater.DataSource = auths;
                authRepeater.DataBind();
            }
            else
            {
                if(Request.Form["method"] == "update")
                {
                    int authValue = Convert.ToInt32(Request.Form["authValue"]);
                    int roleId = Convert.ToInt32(Request.Form["rolelist"]);

                    Roles.UpdateAuthValueOfRole(roleId, authValue);

                    Response.Redirect("roleManager.aspx?roleId=" + roleId.ToString());
                }
                else if(Request.Form["method"] == "delete")
                {
                    if(string.IsNullOrEmpty(Request.Form["rolelist"]) == false)
                    {
                        int roleid = Convert.ToInt32(Request.Form["rolelist"]);
                        Roles.DeleteRole(roleid);

                        Response.Redirect("roleManager.aspx");
                    }
                }
                else if(Request.Form["method"] == "create")
                {
                    if(string.IsNullOrEmpty(Request.Form["roleName"]) == false)
                    {
                        int roleId = Roles.CreateRole(Request.Form["roleName"], 0);
                        Response.Redirect("roleManager.aspx?roleId=" + roleId.ToString());
                    }
                }
            }

            List<RoleInfo> roles = Roles.GetAllRoles();
            rolesRepeater.DataSource = roles;
            rolesRepeater.DataBind();
        }


        protected int GetIntRequestFormValue(string val)
        {
            return Convert.ToInt32(Request.Form[val]);
        }
    }
}