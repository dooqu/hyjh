using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HYJHLibrary.bll;
using HYJHLibrary.modal;

namespace HYJHWeb
{
    public partial class DepartmentManager : HYJHLibrary.BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(CanDo(RoleBehavior.ManagerDepartment) == false)
            {
                throw new Exception("您没有权限使用功能");
            }

            if(Page.IsPostBack == false)
            {

            }
            else
            {
                 if(Request.Form["method"] == "delete")
                {
                    if(string.IsNullOrEmpty(Request.Form["departmentList"]) == false)
                    {
                        int departmentId = Convert.ToInt32(Request.Form["departmentList"]);
                        Departments.DeleteDepartment(departmentId);

                        Response.Redirect("DepartmentManager.aspx");
                    }
                }
                else if(Request.Form["method"] == "create")
                {
                    if(string.IsNullOrEmpty(Request.Form["departmentName"]) == false)
                    {
                        int departmentId = Departments.CreateDepartment(Request.Form["departmentName"]);
                        Response.Redirect("DepartmentManager.aspx?departmentId=" + departmentId.ToString());
                    }
                }
            }

            List<DepartmentInfo> departmentList = Departments.GetList();
            departmentRepeater.DataSource = departmentList;
            departmentRepeater.DataBind();
        }


        protected int GetIntRequestFormValue(string val)
        {
            return Convert.ToInt32(Request.Form[val]);
        }
    }
}