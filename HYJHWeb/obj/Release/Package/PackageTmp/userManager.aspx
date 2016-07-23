<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userManager.aspx.cs" Inherits="HYJHWeb.userManager" %>

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

    <script language="javascript">
        function updateRoleOfUser(userid, roleid)
        {
            var container = document.getElementById("container_" + userid);

            var objSel = container.getElementsByTagName("select")[0];
            
            document.getElementById("method").value = "update_role";
            document.getElementById("userId").value = userid;
            document.getElementById("roleId").value = objSel.options[objSel.selectedIndex].value;;
            document.forms[0].submit();
        }


        function updateDepartmentOfUser(userid, departmentId)
        {
            var container = document.getElementById("departmentInfo_" + userid);

            var objSel = container.getElementsByTagName("select")[0];

            document.getElementById("method").value = "update_department";
            document.getElementById("userId").value = userid;
            document.getElementById("departmentId").value = objSel.options[objSel.selectedIndex].value;;
            document.forms[0].submit();
        }

        function createUser()
        {
            document.getElementById("method").value = "create_user";

            if (document.getElementById("username").value == "")
            {
                alert("用户名不能为空");
                return;
            }

            if (document.getElementById("password").value == "")
            {
                alert("密码不能为空");
                return;
            }

            if (document.getElementById("mobile").value == "")
            {
                alert("手机ID不能为空");
                return;
            }
            document.forms[0].submit();
        }

        function deleteUser(userId, username)
        {
            if(confirm("确定要删除" + username + "?"))
            {
                document.getElementById("method").value = "delete_user";
                document.getElementById("userId").value = userId;
                document.forms[0].submit();
            }
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
                <!-- SEARCH BAR -->

                <!-- /SEARCH BAR -->
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
                                    <h2>用户与角色管理</h2>
                                </div>
                            </div>
                        </div>
                        <!-- 表头结束-->
                        <!-- 查询选项 -->
                        <div class="row">
                            <div class="col-sm-12">
                                <asp:Repeater ID="roleRepeater" runat="server">
                                    <HeaderTemplate>
                                        <div id="rolelist" style="display: none">
                                            <select>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <option value="<%#Eval("RoleId") %>"><%#Eval("RoleName") %></option>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </select>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>

                                <asp:Repeater ID="departmentRepeater" runat="server">
                                    <HeaderTemplate>
                                        <div id="departmentlist" style="display: none">
                                            <select>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <option value="<%#Eval("DepartmentId") %>"><%#Eval("DepartmentName") %></option>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </select>
                                        </div>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <script>
                                    function fillRoleOption(container, roleid)
                                    {
                                        var optionHTML = document.getElementById("rolelist").innerHTML;
                                        document.getElementById(container).innerHTML = optionHTML;
                                        var objSel = document.getElementById(container).getElementsByTagName("select")[0];
                                        var opts = objSel.options;

                                        for (var i = 0; i < opts.length; i++)
                                        {
                                            if (opts[i].value == roleid)
                                            {
                                                opts[i].selected = true;
                                                break;
                                            }
                                        }
                                    }

                                    function fillDepartmentOption(container, departmentId)
                                    {
                                        var optionHTML = document.getElementById("departmentlist").innerHTML;
                                        document.getElementById(container).innerHTML = optionHTML;
                                        var objSel = document.getElementById(container).getElementsByTagName("select")[0];
                                        var opts = objSel.options;

                                        for (var i = 0; i < opts.length; i++)
                                        {
                                            if (opts[i].value == departmentId)
                                            {
                                                opts[i].selected = true;
                                                break;
                                            }
                                        }
                                    }
                                </script>
                                <form name="roleForm" method="post" runat="server">
                                    <!--这个hidden的目的是存储post所需要调用的方法-->
                                    <input type="hidden" name="method" id="method" />
                                    <input type="hidden" name="userId" id="userId" />
                                    <input type="hidden" name="roleId" id="roleId" />
                                    <input type="hidden" name="departmentId" id="departmentId" />


                                    <div class="box border blue">
                                        <div class="box-title">
                                            <h4><i class="fa fa-hand-o-up"></i></h4>
                                            全部系统用户
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
                                            <!-- 添加用户的区域 -->
                                            <div class="jumbotron" style="padding: 10px">
                                                <table style="font-size: 13px;">
                                                    <tr>
                                                        <td>名字:</td>
                                                        <td>
                                                            <input type="text" style="width: 120px" id="username" name="username" class="form-control" /></td>
                                                        <td>　手机:</td>
                                                        <td>
                                                             <input type="text" style="width: 120px" id="mobile" name="mobile" class="form-control" /></td>
                                                        <td>　密码:</td>
                                                        <td>
                                                            <input type="password" style="width: 120px" id="password" name="password" class="form-control" /></td>
                                                        <td>　 所属角色:</td>
                                                        <td>
                                                            <asp:Repeater ID="roleRepeater2" runat="server">
                                                                <HeaderTemplate>
                                                                    <select class="form-control" id="newRoleOfUser" name="newRoleOfUser">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <option value="<%#Eval("RoleId") %>"><%#Eval("RoleName") %></option>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </select>                                     
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                        <td>所属部门:</td>
                                                        <td>
                                                            <asp:Repeater ID="departmentRepeater2" runat="server">
                                                                <HeaderTemplate>
                                                                    <select class="form-control" id="newDepartmentOfUser" name="newDepartmentOfUser">
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <option value="<%#Eval("DepartmentId") %>"><%#Eval("DepartmentName") %></option>
                                                                </ItemTemplate>
                                                                <FooterTemplate>
                                                                    </select>                                     
                                                                </FooterTemplate>
                                                            </asp:Repeater>
                                                        </td>
                                                        <td>　<a href="javascript:{createUser();}" class="btn btn-success">添加用户</a></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <!-- 添加新用户结束 -->

                                            <!-- 内部的用户列表-->
                                            <table class="table table-hover">
                                                <thead>
                                                    <tr>
                                                        <th>用户ID</th>
                                                        <th>用户</th>
                                                        <th>手机ID</th>
                                                        <th>创建时间</th>
                                                        <th>登录时间</th>
                                                        <th>角色组</th>
                                                        <th>所属部门</th>
                                                        <th>操作</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <asp:Repeater ID="usersRepeater" runat="server">
                                                        <ItemTemplate>
                                                            <tr style="vertical-align: middle">
                                                                <td><%#Eval("UserId") %></td>
                                                                <td><%#Eval("Username") %></td>
                                                                <td><%#Eval("Mobile") %></td>
                                                                <td><%#Eval("CreateDate") %></td>
                                                                <td><%#Eval("LastLoginDate") %></td>
                                                                <td>
                                                                    <div id="container_<%#Eval("UserId") %>" style="float: left"></div>
                                                                    <script>fillRoleOption('container_<%#Eval("UserId") %>', '<%#Eval("RoleId") %>');</script>
                                                                    <a class="btn btn-xs btn-success" style="float: left; margin-left: 10px" href="javascript:{updateRoleOfUser('<%#Eval("UserId") %>', '<%#Eval("RoleId") %>');}">修改</a>

                                                                </td>
                                                                <td>
                                                                    <div id="departmentInfo_<%#Eval("UserId") %>" style="float: left"></div>
                                                                    <script>fillDepartmentOption('departmentInfo_<%#Eval("UserId") %>', '<%#Eval("DepartmentId") %>');</script>
                                                                    <a class="btn btn-xs btn-success" style="float: left; margin-left: 10px" href="javascript:{updateDepartmentOfUser('<%#Eval("UserId") %>', '<%#Eval("DepartmentId") %>');}">修改</a>

                                                                </td>
                                                                <td><a href="javascript:{deleteUser('<%#Eval("UserId") %>', '<%#Eval("Username") %>');}" class="btn btn-xs btn-danger">删除</a></td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                            <!-- 内部的用户列表结束-->

                                        </div>
                                        <!-- box body 结束 -->

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
