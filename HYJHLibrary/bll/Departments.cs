using System;
using System.Collections.Generic;
using System.Text;
using HYJHLibrary.modal;
using HYJHLibrary.dal;

namespace HYJHLibrary.bll
{
    public class Departments
    {
        public static List<DepartmentInfo> GetList()
        {
            return DataProvider.GetDepartments();
        }


        public static void DeleteDepartment(int departmentId)
        {
            DataProvider.DeleteDepartment(departmentId);
        }

        public static int CreateDepartment(string departmentName)
        {
            return DataProvider.CreateDepartment(departmentName);
        }
    }
}
