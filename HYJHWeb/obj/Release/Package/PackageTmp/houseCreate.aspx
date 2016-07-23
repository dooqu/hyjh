<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="houseCreate.aspx.cs" Inherits="HYJHWeb.houseCreate" %>

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
        <link rel="stylesheet" href="/js/jquery-ui-1.10.3.custom/css/custom-theme/jquery-ui-1.10.3.custom.min.css" />
    <!-- DATE RANGE PICKER -->
<%--    <link rel="stylesheet" type="text/css" href="js/bootstrap-daterangepicker/daterangepicker-bs3.css" />--%>
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
                                <form name="form_house" action="doEditOrDelete.aspx" method="post">
                                    <input type="hidden" name="method" id="method" value="house_create" />
                                    <div class="box border lite">
                                        <div class="box-title">
                                            <h5>
                                                <i class="fa fa-bars"></i>
                                                不动产信息
                                            </h5>
                                        </div>
                                        <div class="box-body big">
                                            <div>
                                                房产标题：<input type="text" name="title" id="title" value="" class="form-control" />
                                            </div>
                                            <div>
                                                价格：
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <select id="payTypeId" name="payTypeId" style="display:none;width: 150px" class="form-control">
                                                                <asp:Repeater runat="server" ID="payTypeList">
                                                                    <ItemTemplate>
                                                                        <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </select></td>
                                                                                <td>
                                                            <table><tr><td>月付：</td><td><input type="text" name="monthPrice" id="monthPrice" placeholder="月租金" class="form-control" style="width: 150px;" /></td></tr></table>
                                                        </td>
                                                        <td>
                                                            <table><tr><td>季付：</td><td><input type="text" name="threeMonthPrice" id="threeMonthPrice" placeholder="季租金" class="form-control" style="width: 150px;" /></td></tr></table>
                                                        </td>
                                                                                                                <td>
                                                            <table><tr><td>半年付：</td><td><input type="text" name="halfYearPrice" id="halfYearPrice"  placeholder="半年租金" class="form-control" style="width: 150px;" /></td></tr></table>
                                                        </td>
                                                                                                                <td>
                                                            <table><tr><td>年付：</td><td><input type="text" name="yearPrice" id="yearPrice" placeholder="年租金" class="form-control" style="width: 150px;" /></td></tr></table>
                                                        </td>
                                                    </tr>
                                                </table>


                                            </div>
                                            <div>
                                                合同号：<input type="text" name="contractCode" id="contractCode" value="" class="form-control" />
                                            </div>
                                            <div>
                                                小区名：<input type="text" name="buildingName" id="buildingName" value="" class="form-control" />
                                            </div>
                                            <div>
                                                详细地址：<input type="text" name="address" id="address" value="" class="form-control" />
                                            </div>
                                            <div>
                                                面积：<input type="text" name="areaSize" id="areaSize" value="" class="form-control" />
                                            </div>
                                            <div>
                                                楼层：<input type="text" name="floorNum" id="floorNum" value="" class="form-control" />
                                            </div>
                                            <div>
                                                楼层：<input type="text" name="floorTotal" id="floorTotal" value="" class="form-control" />
                                            </div>
                                            <div>
                                                类型：
                                            <select id="joinType" name="joinType" class="form-control">
                                                <option value="1">代理</option>
                                                <option value="2">业主</option>
                                                <option value="3">合作</option>
                                            </select>
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

                                            <div>
                                                积分：<input type="number" name="rank" id="rank" value="" class="form-control" />
                                            </div>
                                            <div>
                                                结束日期：<input type="text" name="completeDate" id="completeDate" value="<%=DateTime.Now.AddMonths(1).ToString("yyyy/MM/dd") %>" class="form-control" />
                                            </div>
                                            <div>
                                                房主姓名：<input type="text" name="customName" id="customName" value="" class="form-control" />
                                            </div>

                                            <div>
                                                联系电话：<table>
                                                    <tr>
                                                        <td>
                                                            <input type="text" name="customTel" style="width: 200px" id="customTel" value="" class="form-control" /></td>
                                                        <td>
                                                            <select class="form-control" style="width: 100px" id="isCustomTel" name="isCustomTel">
                                                                <option value="true">房主</option>
                                                                <option value="false">业务员</option>
                                                            </select></td>
                                                    </tr>
                                                </table>
                                            </div>



                                            <div>
                                                备注：<textarea id="comment" name="comment" class="form-control"></textarea>
                                            </div>

                                             <div>
                                                报修状态: <input type="checkbox" id="isInError" name="isInError"  value="true" onchange="javascript:{document.getElementById('divErrorMessage').style.display = ((this.checked)? '' : 'none');}"/><label for="isInError">报修</label>
                                            </div>

                                            <div id="divErrorMessage" style="display:none">
                                                报修内容：<textarea id="errorMessage" name="errorMessage" class="form-control"></textarea>
                                            </div>
                                            <br />
                                            <a href="javascript:{document.forms[0].submit();}" class="btn btn-success">确定添加</a>  <a href="javascript:{history.go(-1);};" class="btn btn-warning">取消</a>
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
<%--    <script src="js/bootstrap-daterangepicker/moment.min.js"></script>
    <script src="js/bootstrap-daterangepicker/daterangepicker.min.js"></script>--%>
    <!-- SLIMSCROLL -->
<%--    <script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/jquery.slimscroll.min.js"></script>
    <script type="text/javascript" src="js/jQuery-slimScroll-1.3.0/slimScrollHorizontal.min.js"></script>--%>
    <!-- COOKIE -->
    <script type="text/javascript" src="js/jQuery-Cookie/jquery.cookie.min.js"></script>
    <!-- CUSTOM SCRIPT -->
    <script src="js/script.js"></script>
    <script>
        jQuery(document).ready(function ()
        {
            $.datepicker.regional["zh-CN"] = { closeText: "关闭", prevText: "上月", nextText: "下月;", currentText: "今天", monthNames: ["一月", "二月", "三月", "四月", "五月", "六月", "七月", "八月", "九月", "十月", "十一月", "十二月"], monthNamesShort: ["一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二"], dayNames: ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"], dayNamesShort: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"], dayNamesMin: ["日", "一", "二", "三", "四", "五", "六"], weekHeader: "周", dateFormat: "yy/mm/dd", firstDay: 1, isRTL: !1, showMonthAfterYear: !0, yearSuffix: "年" }



            $.datepicker.setDefaults($.datepicker.regional["zh-CN"]);

            $("#completeDate").datepicker({
                dateFormat: 'yy/mm/dd',
                changeMonth: true,
                changeYear: true
            });
        });
    </script>
    <!-- /JAVASCRIPTS -->
</body>
</html>
