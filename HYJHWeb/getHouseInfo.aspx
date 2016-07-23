<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getHouseInfo.aspx.cs" Inherits="HYJHWeb.getHouseInfo" %>

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
    <style type="text/css">
        #option_list tr {
            height: 39px;
        }

        #option_list * {
            font-size: 15px;
        }
    </style>
    <script language="javascript">
        function show_m(picid)
        {
            document.getElementById("m_" + picid).style.display = "";
        }

        function hidden_m(picid)
        {
            document.getElementById("m_" + picid).style.display = "none";
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
                                    <h2>添加新的房产信息</h2>
                                </div>
                            </div>
                        </div>
                        <!-- 表头结束-->
                        <!-- 查询选项 -->
                        <div class="row">
                            <div class="col-sm-12">
                                <form name="form_house" action="customCreate.aspx" method="post">
                                    <input type="hidden" name="method" id="method" value="house_create" />
                                    <div class="box">
                                        <div style="border: 1px solid red; float:left;width:100%; margin-left: auto; margin-right: auto;">
                                            <div style="border: 1px solid #c0c0c0; width: 700px; height: 500px; float: left; vertical-align: middle; text-align: center; line-height: 480px; background-color: white">
                                                <img style="width: 700px; height: 500px" id="currHousePicture" src="/pic/<%#FirstPictureUrl %>" /></div>
                                            <div style="border: 0px solid #808080; width: 180px; height: 480px; float: left; margin-left: 10px; position: relative">
                                                <div style="text-align: center; width: auto; height: 25px; background-color: #c0c0c0; color: white; position: relative; left: 0px; top: 0px">↓</div>
                                                <div style="border: 0px solid #cccccc; height: 410px; margin-top: 10px; margin-bottom: 10px; overflow-y: hidden">
                                                    <asp:Repeater ID="pictureList" runat="server">
                                                        <ItemTemplate>
                                                            <a href="javascript:{goImage('<%#Eval("Filename") %>',this);}" style="display: block; width: auto; height: 120px; vertical-align: middle; text-align: center; border: 1px solid #c0c0c0">
                                                                <img style="height: 118px; width: 178px" src="/pic/thumb_<%#Eval("Filename") %>" />
                                                            </a>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                                <div style="text-align: center; width: auto; height: 25px; background-color: #c0c0c0; color: white; position: relative; left: 0px; top: 0px">↑</div>
                                            </div>
                                            <div style="border: 0px solid #808080; width: 395px; height: 480px; float: left;clear:left; margin-left: 10px">
                                                <div class="jumbotron" style="padding-bottom: 10px; padding-top: 10px">
                                                    <h2><%#HouseTitle %></h2>
                                                    <div><font style="font-weight: bold; font-size: 25px; color: orange"><%#HousePrice%> ￥ </font>（每月）  <a href="houseEdit.aspx?houseid= <%#HouseId %>" class="btn btn-success">编辑</a>  <a href="edithouse.aspx?id=" class="btn btn-danger">删除</a></div>
                                                </div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">小区： <%#HouseName %></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">面积： <%#HouseSize %> ㎡</div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">朝向： <%#HouseAspect %></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">户型： <%#HouseStruct %></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">楼层： <%#HouseFloorNum%></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">装修： <%#HouseDecoration %></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">户主： <%#HouseOwner %></div>
                                                <div class="btn btn-default tip" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;" data-original-title="<%#HouseAddress %>">地址： <%#HouseAddress %></div>
                                                <div class="btn btn-default" style="text-align: left; width: 100%; padding-left: 10px; margin-bottom: 1px;">电话： <%#HouseOwnerTel %></div>
                                            </div>
                                        </div>


                                    </div>
                                </form>

                            </div>
                        </div>
                        <!-- /end row -->
                    </div>
                    <!-- /end content -->
                </div>
                <!-- //end row -->
            </div>
            <!-- / end container -->
        </div>
        <!-- /end main content -->
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
