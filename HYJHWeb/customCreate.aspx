<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customCreate.aspx.cs" Inherits="HYJHWeb.customCreate" %>

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
                                    <h2>添加新的客源信息</h2>
                                </div>
                            </div>
                        </div>
                        <!-- 表头结束-->
                        <!-- 查询选项 -->
                        <div class="row">
                            <div class="col-sm-12">
                                <form name="form_house"  method="post">
                                    <input type="hidden" name="method" id="method" value="custom_create" />
                                    <div class="box border lite">
                                        <div class="box-title">
                                            <h5>
                                                <i class="fa fa-bars"></i>
                                                客源信息
                                            </h5>
                                        </div>
                                        <div class="box-body big">
                                            <div style="display:none;">
                                                需求标题：<input type="text" name="title" id="title" value="" class="form-control" />
                                            </div>

                                                                                        <div>
                                                客户姓名：<input type="text" name="customName" id="customName" value="" class="form-control" />
                                            </div>

                                            <div>
                                                客户联系电话：<input type="text" name="customTel" id="customTel" value="" class="form-control" />
                                            </div>
                                            <div>
                                                价格：<input type="text" name="monthPrice" id="monthPrice" value="" class="form-control" />
                                            </div>

                                           <div>
                                                区域：
                                            <select id="zoneId" name="zoneId" class="form-control">
                                                <asp:Repeater ID="zoneOptionList" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                            </div>
<%--                                            <div>
                                                合同号：<input type="text" name="contractCode" id="contractCode" value="" class="form-control" />
                                            </div>--%>
                                            <div>
                                                小区名：<input type="text" name="buildingName" id="buildingName" value="" class="form-control" />
                                            </div>
                                            <div style="display:none">
                                                详细地址：<input type="text" name="address" id="address" value="" class="form-control" />
                                            </div>
                                            <div>
                                                面积要求：<input type="text" name="areaSize" id="areaSize" value="" class="form-control" />
                                            </div>
                                            <div>
                                                楼层要求：<input type="text" name="floorNum" id="floorNum" value="" class="form-control" />
                                            </div>
<%--                                            <div>
                                                楼层：<input type="text" name="floorTotal" id="floorTotal" value="" class="form-control" />
                                            </div>--%>
<%--                                            <div>
                                                类型：
                                            <select id="houseType" name="houseType" class="form-control">
                                                <option value="0">代理</option>
                                                <option value="1">业主</option>
                                                <option value="2">合作</option>
                                            </select>
                                            </div>--%>




                                            <div>
                                                结构：
                                            <select id="structId" name="structId" class="form-control">
                                                <asp:Repeater ID="structOptionList" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                            </div>


                                            <div>
                                                朝向：
                                            <select id="aspectId" name="aspectId" class="form-control">
                                                <asp:Repeater ID="aspectOptionList" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                            </div>


                                            <div>
                                                装修：
                                            <select id="decorationId" name="decorationId" class="form-control">
                                                <asp:Repeater ID="decorationOptionList" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                            </div>



<%--                                                                                        <div>
                                                希望入住时间： <br />
                                                <input type="text" name="year" id="year" value="<%=DateTime.Now.ToString("yyyy") %>" style="with:50px;" />年
                                                <input type="text" name="month" id="month" value="<%=DateTime.Now.ToString("MM") %>" style="with:50px;"  />月
                                                <input type="text" name="day" id="day" value="<%=DateTime.Now.ToString("dd") %>" style="with:50px;"  />日
                                            </div>--%>
                                            <br />
                                            <button  class="btn btn-success" onclick="javascript:{document.forms[0].submit();return false;}">确定添加</button>  <a href="javascript:{history.go(-1);};" class="btn btn-warning">取消</a>
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
