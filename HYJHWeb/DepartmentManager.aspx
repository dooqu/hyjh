<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DepartmentManager.aspx.cs" Inherits="HYJHWeb.DepartmentManager" %>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <title>华远嘉禾</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1, user-scalable=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <!-- STYLESHEETS -->
    <!--[if lt IE 9]><script src="js/flot/excanvas.min.js"></script><script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script><script src="http://css3-mediaqueries-js.googlecode.com/svn/trunk/css3-mediaqueries.js"></script><![endif]-->
    <link rel="stylesheet" type="text/css" href="css/cloud-admin.css">
    <link rel="stylesheet" type="text/css" href="css/themes/default.css" id="skin-switcher">
    <link rel="stylesheet" type="text/css" href="css/responsive.css">

    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- DATE RANGE PICKER -->
    <link rel="stylesheet" type="text/css" href="js/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <!-- FONTS -->

    <script language="javascript">
        //更换角色的select时候，更新checkbox list的勾选
        function showAuth(e)
        {
            var authValue = parseInt(e.options[e.selectedIndex].id);

            var list = document.getElementById("authlist").getElementsByTagName("input");

            for (var i = 0; i < list.length; i++)
            {
                if ((authValue & parseInt(list[i].value)) > 0)
                {
                    list[i].checked = true;
                }
                else
                {
                    list[i].checked = false;
                }
            }
        }


        //更新权限
        function updateAuth()
        {
            var rolelist = document.getElementById("rolelist");

            if (rolelist.selectedIndex == -1)
            {
                alert("请选择一个角色");
                return;
            }

            var newAuthValue = 0;
            var list = document.getElementById("authlist").getElementsByTagName("input");

            for (var i = 0; i < list.length; i++)
            {
                if (list[i].checked)
                    newAuthValue += parseInt(list[i].value);
            }

            document.getElementById("method").value = "update";
            document.getElementById("authValue").value = newAuthValue;
            document.forms[0].submit();
        }


        //删除某个角色
        function deleteDepartment()
        {
            var departmentList = document.getElementById("departmentList");

            if (departmentList.selectedIndex == -1)
            {
                alert("请选择一个部门");
                return;
            }

            if (confirm("确定要删除部门[" + departmentList.options[departmentList.selectedIndex].text + "]？") == false)
                return;

            var id = departmentList.options[departmentList.selectedIndex].value;

            document.getElementById("method").value = "delete";
            document.forms[0].submit();
        }

        function createDepartment()
        {
            var departmentName = document.getElementById("departmentName").value;
            if (departmentName == null || departmentName == "")
            {
                alert("请输入角色名字");
                return;
            }

            if (departmentName.indexOf(" ") != -1)
            {
                alert("角色名字包含非法字符");
                return;
            }

            document.getElementById("method").value = "create";
            document.forms[0].submit();
        }

    </script>
</head>
<body>
    <!-- HEADER -->
    <header class="navbar clearfix" id="header">
        <div class="container">
            <div class="navbar-brand">
                <!-- COMPANY LOGO -->
                <a href="index.html" style="display: none">
                    <img src="img/logo/logo.png" alt="Cloud Admin Logo" class="img-responsive" height="30" width="120">
                </a>
                <div style="color: white; font-size: 16px; font-weight: bold">华远嘉禾房产信息管理</div>
                <!-- /COMPANY LOGO -->
                <!-- TEAM STATUS FOR MOBILE -->
                <div class="visible-xs">
                    <a href="#" class="team-status-toggle switcher btn dropdown-toggle">
                        <i class="fa fa-users"></i>
                    </a>
                </div>
                <!-- /TEAM STATUS FOR MOBILE -->
                <!-- SIDEBAR COLLAPSE -->
                <!--貌似没用-->
                <div id="sidebar-collapse" class="sidebar-collapse btn" style="display: none">
                    <i class="fa fa-bars"
                        data-icon1="fa fa-bars"
                        data-icon2="fa fa-bars"></i>
                </div>
                <!-- /SIDEBAR COLLAPSE -->
            </div>
            <!-- NAVBAR LEFT -->
            <!-- /NAVBAR LEFT -->

            <!-- BEGIN TOP NAVIGATION MENU -->
            <ul class="nav navbar-nav pull-right" style="">
                <!-- BEGIN NOTIFICATION DROPDOWN -->

                <!-- END NOTIFICATION DROPDOWN -->
                <!-- BEGIN INBOX DROPDOWN -->

                <!-- END INBOX DROPDOWN -->
                <!-- BEGIN TODO DROPDOWN -->

                <!-- END TODO DROPDOWN -->
                <!-- BEGIN USER LOGIN DROPDOWN -->
                <li class="dropdown user" id="header-user" style="float: right">
                    <a href="#" class="dropdown-toggle" style="float: left; font-size: 15px">
                        <span class="username">您好，<%=GetUsername() %></span>

                    </a>
                    <a href="logoff.aspx" class="dropdown-toggle" style="float: right; margin-right: 20px; font-size: 15px">
                        <span class="username">登出</span>
                    </a>

                </li>
                <!-- END USER LOGIN DROPDOWN -->
            </ul>
            <!-- END TOP NAVIGATION MENU -->
        </div>

    </header>
    <!--/HEADER -->

    <!-- PAGE -->
    <section id="page">
        <!-- SIDEBAR -->
        <div id="sidebar" class="sidebar">
            <div class="sidebar-menu nav-collapse">
                <div class="divide-20"></div>
                <ul>
                    <li>
                        <a href="index.aspx">
                            <i class="fa fa-tachometer fa-fw"></i><span class="menu-text;" style="font-size: 16px; font-weight: normal">房源信息查询</span>
                        </a>
                    </li>

                    <li><a class="" href="customList.aspx"><i class="fa fa-desktop fa-fw"></i><span class="menu-text" style="font-size: 16px; font-weight: normal">客源信息查询</span></a></li>
                    <li><a class="" href="houseCreate.aspx"><i class="fa fa-envelope-o fa-fw"></i><span class="menu-text" style="font-size: 16px; font-weight: normal">房源信息录入</span></a></li>
                    <li><a class="" href="customCreate.aspx"><i class="fa fa-envelope-o fa-fw"></i><span class="menu-text" style="font-size: 16px; font-weight: normal">客源信息录入</span></a></li>
                    <li><a class="" href="roleManager.aspx"><i class="fa fa-calendar fa-fw"></i>
                        <span class="menu-text" style="font-size: 16px; font-weight: normal">角色管理</span>
                    </a>
                    </li>
                    <li><a class="" href="DepartmentManager.aspx"><i class="fa fa-calendar fa-fw"></i>
                        <span class="menu-text" style="font-size: 16px; font-weight: normal">部门管理</span>
                    </a>
                    </li>
                    <li>
                        <a class="" href="userManager.aspx">
                            <i class="fa fa-calendar fa-fw"></i>
                            <span class="menu-text" style="font-size: 16px; font-weight: normal">用户管理</span>
                        </a>
                    </li>

                </ul>
                <!-- /SIDEBAR MENU -->
            </div>
        </div>
        <!-- /SIDEBAR -->
        <div id="main-content">
            <div class="container">
                <div class="row">
                    <div id="content" class="col-lg-12">
                        <!-- PAGE HEADER-->
                        <div class="row" style="height: 30px">
                            <div class="col-sm-12">
                                <div class="page-header" style="border: 0px solid red; line-height: 30px; height: 30px; padding-bottom: 0px">
                                    <h2>部门管理</h2>
                                </div>
                            </div>
                        </div>
                        <!-- 表头结束-->
                        <!-- 查询选项 -->
                        <div class="row">
                            <div class="col-sm-12">
      
                                <form name="roleForm" method="post" runat="server">
                                    <input type="hidden" name="method" id="method" />
                                    <input type="hidden" name="authValue" id="authValue" value="0" />
                                    <div class="box border blue">
                                        <div class="box-title">
                                            <h4><i class="fa fa-hand-o-up"></i>全部部门信息</h4>
                                            
                                                <div class="tools">
                                                    <a class="config" href="#box-config" data-toggle="modal">
                                                        <i class="fa fa-cog"></i>
                                                    </a>
                                                    <a class="reload" href="javascript:;">
                                                        <i class="fa fa-refresh"></i>
                                                    </a>
                                                    <a class="collapse" href="javascript:;">
                                                        <i class="fa fa-chevron-up"></i>
                                                    </a>
                                                    <a class="remove" href="javascript:;">
                                                        <i class="fa fa-times"></i>
                                                    </a>
                                                </div>
                                        </div>
                                        <div class="box-body">
                                            <p>部门列表</p>
                                            <select id="departmentList" name="departmentList" multiple  class="form-control" style=" height: 150px;">
                                                <asp:Repeater ID="departmentRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <option style="font-size: 16px" value="<%#Eval("DepartmentId") %>" ><%#Eval("DepartmentName") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>

                                            <p>
                                                <button class="btn btn-danger" onclick="javascript:{deleteDepartment();return false;}">删除部门</button>
                                            </p>

                                        </div>
                                    </div>
                                    <div id="authlist" class="jumbotron" style="overflow: hidden; padding: 10px;">
                                        <p>创建新的部门</p>
                                        <input type="text" id="departmentName" name="departmentName" class="form-control" />
                                        <button class="btn btn-success" onclick="javascript:{createDepartment();return false;}">增加部门</button>
                                    </div>
                                    <!-- end box -->
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!--/PAGE -->
    <!-- JAVASCRIPTS -->
    <!-- Placed at the end of the document so the pages load faster -->
    <!-- JQUERY -->
    <script src="js/jquery/jquery-2.0.3.min.js"></script>
    <!-- JQUERY UI-->
    <script src="js/jquery-ui-1.10.3.custom/js/jquery-ui-1.10.3.custom.min.js"></script>
    <!-- BOOTSTRAP -->
    <script src="bootstrap-dist/js/bootstrap.min.js"></script>
    <!-- DATE RANGE PICKER -->
    <script src="js/bootstrap-daterangepicker/moment.min.js"></script>
    <script src="js/bootstrap-daterangepicker/daterangepicker.min.js"></script>
    <!-- SLIMSCROLL -->
    <script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/slimScrollHorizontal.min.js"></script>
    <!-- COOKIE -->
    <script type="text/javascript" src="js/jQuery-Cookie/jquery.cookie.min.js"></script>
    <!-- CUSTOM SCRIPT -->
    <script src="js/script.js"></script>
    <script>
        jQuery(document).ready(function ()
        {
            App.setPage("widgets_box");  //Set current page
            App.init(); //Initialise plugins and elements
        });
    </script>
    <!-- /JAVASCRIPTS -->
</body>
</html>

