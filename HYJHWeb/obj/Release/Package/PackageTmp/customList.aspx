<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customList.aspx.cs" Inherits="HYJHWeb.customList" %>


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

        <!-- TEAM STATUS -->
        <!-- /TEAM STATUS -->
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
                <!-- SIDEBAR MENU -->
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
                                <div class="page-header" style="font-family: 'Helvetica Neue', Helvetica, Arial, sans-serif; color: #808080; font-size: 25px; padding: 0px 20px; min-height: 60px; line-height: 60px">
                                    <h3>客源信息查询</h3>
                                </div>
                            </div>
                        </div>
                        <!-- 表头结束-->
                        <!-- 查询选项 -->
                        <div class="row">
                            <div class="col-sm-12">
                                <script language="javascript">
                                    function searchText(fieldText)
                                    {

                                    }

                                    function changeFieldValue(fieldName, value)
                                    {
                                        document.forms[0][fieldName].value = value;
                                        document.forms[0]["currPageIndex"].value = 0;
                                        document.forms[0].submit();
                                    }

                                    function changeAreaSize(sizeMin, sizeMax)
                                    {
                                        document.forms[0]["currAreaSizeMin"].value = sizeMin;
                                        document.forms[0]["currAreaSizeMax"].value = sizeMax;
                                        document.forms[0]["currPageIndex"].value = 0;
                                        document.forms[0].submit();
                                    }

                                    function changePrice(priceMin, priceMax)
                                    {
                                        document.forms[0]["currPriceMin"].value = priceMin;
                                        document.forms[0]["currPriceMax"].value = priceMax;
                                        document.forms[0]["currPriceMinUsr"].value = 0;
                                        document.forms[0]["currPriceMaxUsr"].value = 0;
                                        document.forms[0]["currPageIndex"].value = 0;
                                        document.forms[0].submit();
                                    }

                                    function changePriceEx(priceMin, priceMax)
                                    {
                                        if (isNaN(parseInt(priceMin)) || isNaN(parseInt(priceMax)))
                                        {
                                            alert("填写错误");
                                            return;
                                        }

                                        if (priceMin >= priceMax)
                                        {
                                            alert("填写错误:" + priceMin + ":" + priceMax);
                                            return;
                                        }

                                        document.forms[0]["currPriceMin"].value = 0;
                                        document.forms[0]["currPriceMax"].value = 0;
                                        document.forms[0]["currPriceMinUsr"].value = priceMin;
                                        document.forms[0]["currPriceMaxUsr"].value = priceMax;
                                        document.forms[0]["currPageIndex"].value = 0;
                                        document.forms[0].submit();
                                    }

                                    function goPage(pageIndex, enable)
                                    {
                                        if (enable == false)
                                            return;

                                        document.forms[0]["currPageIndex"].value = pageIndex;
                                        document.forms[0].submit();
                                    }
                                </script>
                                <form id="dataForm" name="dataForm" method="post">
                                    <input type="hidden" name="currAspect" value="<%=GetRequestFieldValue("currAspect") %>" />
                                    <input type="hidden" name="currDecoration" value="<%=GetRequestFieldValue("currDecoration") %>" />
                                    <input type="hidden" name="currZone" value="<%=GetRequestFieldValue("currZone") %>" />
                                    <input type="hidden" name="currPriceMin" value="<%=GetRequestFieldValue("currPriceMin") %>" />
                                    <input type="hidden" name="currPriceMax" value="<%=GetRequestFieldValue("currPriceMax") %>" />
                                    <input type="hidden" name="currAreaSizeMin" value="<%=GetRequestFieldValue("currAreaSizeMin") %>" />
                                    <input type="hidden" name="currAreaSizeMax" value="<%=GetRequestFieldValue("currAreaSizeMax") %>" />
                                    <input type="hidden" name="currJoinType" value="<%=GetRequestFieldValue("currJoinType") %>" />
                                    <input type="hidden" name="currRoomStruct" value="<%=GetRequestFieldValue("currRoomStruct") %>" />
                                    <input type="hidden" name="currPriceMinUsr" value="<%=GetRequestFieldValue("currPriceMinUsr") %>" />
                                    <input type="hidden" name="currPriceMaxUsr" value="<%=GetRequestFieldValue("currPriceMaxUsr") %>" />
                                    <input type="hidden" name="currPageIndex" value="<%=GetRequestFieldValue("currPageIndex") %>" />

                                    <table cellspacing="1" cellpading="1" border="0" id="option_list" width="100%">
                                        <tr style="display: none">
                                            <td colspan="2">
                                                <div style="width: 100%; display: none">
                                                    <input class="form-control" placeholder="房源查询" type="text" style="width: 80%">
                                                    <button class="btn btn-success" style="width: 60px; position: relative; display: table-cell">查询</button>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080; display: none">
                                            <td style="width: 80px">业务类型：
                                            </td>
                                            <td>
                                                <a class="<%= GetClassNameByFieldNameAndValue("currJoinType", "0")%>" href="javascript:changeFieldValue('currJoinType', '0');">不限</a>
                                                <a class="<%= GetClassNameByFieldNameAndValue("currJoinType", "1")%>" href="javascript:changeFieldValue('currJoinType', '1');">代理</a>
                                                <a class="<%= GetClassNameByFieldNameAndValue("currJoinType", "2")%>" href="javascript:changeFieldValue('currJoinType', '2');">业主</a>
                                                <a class="<%= GetClassNameByFieldNameAndValue("currJoinType", "3")%>" href="javascript:changeFieldValue('currJoinType', '3');">合作</a>
                                            </td>
                                        </tr>

                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>区域选择：</td>
                                            <td>
                                                <asp:Repeater ID="zoneRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <a class="<%# GetClassNameByFieldNameAndValue("currZone", Eval("Key"))%>" href="javascript:changeFieldValue('currZone', '<%#Eval("Key") %>');"><%#Eval("Value") %></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>朝向选择：</td>
                                            <td>
                                                <asp:Repeater ID="aspectRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <a class="<%# GetClassNameByFieldNameAndValue("currAspect", Eval("Key"))%>" href="javascript:changeFieldValue('currAspect', '<%#Eval("Key") %>');"><%#Eval("Value") %></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>装修等级：</td>
                                            <td>
                                                <asp:Repeater ID="decorationRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <a class="<%# GetClassNameByFieldNameAndValue("currDecoration", Eval("Key"))%>" href="javascript:changeFieldValue('currDecoration', '<%#Eval("Key") %>');"><%#Eval("Value") %></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>房屋结构：</td>
                                            <td>
                                                <asp:Repeater ID="structRepeater" runat="server">
                                                    <ItemTemplate>
                                                        <a class="<%# GetClassNameByFieldNameAndValue("currRoomStruct", Eval("Key"))%>" href="javascript:changeFieldValue('currRoomStruct', '<%#Eval("Key") %>');"><%#Eval("Value") %></a>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>面积选择：</td>
                                            <td>
                                                <a href="javascript:changeAreaSize('0', '0');" class="<%=GetClassNameByCurrAreaSize("0", "0") %>">不限</a>
                                                <a href="javascript:changeAreaSize('0', '10');" class="<%=GetClassNameByCurrAreaSize("0", "10") %>">10㎡以下</a>
                                                <a href="javascript:changeAreaSize('10', '30');" class="<%=GetClassNameByCurrAreaSize("10", "30") %>">10㎡~30㎡</a>
                                                <a href="javascript:changeAreaSize('30', '50');" class="<%=GetClassNameByCurrAreaSize("30", "50") %>">30㎡~50㎡</a>
                                                <a href="javascript:changeAreaSize('50', '70');" class="<%=GetClassNameByCurrAreaSize("50", "70") %>">50㎡~70㎡</a>
                                                <a href="javascript:changeAreaSize('70', '90');" class="<%=GetClassNameByCurrAreaSize("70", "90") %>">70㎡~90㎡</a>
                                                <a href="javascript:changeAreaSize('90', '0');" class="<%=GetClassNameByCurrAreaSize("90", "0") %>">90㎡以上</a>
                                            </td>
                                        </tr>
                                        <tr style="border-bottom: 1px dotted #808080">
                                            <td>价格区间：</td>
                                            <td>
                                                <a href="javascript:changePrice(0, 0);" class="<%=GetClassNameByCurrPrice("0", "0") %>">不限</a>
                                                <a href="javascript:changePrice(0, 1500);" class="<%=GetClassNameByCurrPrice("0", "1500") %>">1500以下</a>
                                                <a href="javascript:changePrice(1500, 2000);" class="<%=GetClassNameByCurrPrice("1500", "2000") %>">1500~2000</a>
                                                <a href="javascript:changePrice(2000, 3000);" class="<%=GetClassNameByCurrPrice("2000", "3000") %>">2000~3000</a>
                                                <a href="javascript:changePrice(3000, 5000);" class="<%=GetClassNameByCurrPrice("3000", "5000") %>">3000~5000</a>
                                                <a href="javascript:changePrice(5000, 6500);" class="<%=GetClassNameByCurrPrice("5000", "6500") %>">5000~6500</a>
                                                <a href="javascript:changePrice(6500, 8000);" class="<%=GetClassNameByCurrPrice("6500", "8000") %>">6500~8000</a>
                                                <a href="javascript:changePrice(8000, 0);" class="<%=GetClassNameByCurrPrice("8000", "0") %>">8000以上</a>
                                                <a href="#none" class="<%=GetClassNameByCurrPriceEx() %>">其他</a> :
                                                <input type="text" id="usrPriceMin" class="form-control" style="display: inline; width: 70px;" value="<%=GetPriceUsrValue("currPriceMinUsr") %>" />~<input id="usrPriceMax" type="text" class="form-control" style="width: 70px; display: inline" value="<%=GetPriceUsrValue("currPriceMaxUsr") %>" />
                                                <a href="javascript:changePriceEx(document.getElementById('usrPriceMin').value, document.getElementById('usrPriceMax').value);" class="btn btn-xs btn-default">确定</a>
                                            </td>
                                        </tr>
                                    </table>

                                </form>
                            </div>
                        </div>
                        <!-- //查询选项 -->
                        <br />
                        <div class="row">
                            <div class="col-sm-12">


                                <div class="box border blue">
                                    <div class="box-title">
                                        <h4><i class="fa fa-hand-o-up"></i></h4>
                                        全部客源信息
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

                                        <!-- 内部的用户列表-->
                                        <table class="table table-hover">
                                            <thead>
                                                <tr>
                                                    <th>客户ID</th>
                                                    <th>客户名</th>
                                                    <th>区域</th>
                                                    <th>小区</th>
                                                    <th>居室</th>
                                                    <th>楼层</th>
                                                    <th>装修</th>
                                                    <th>朝向</th>
                                                    <th>装填</th>
                                                    <th>电话</th>
                                                    <th>状态</th>
                                                    <th>操作</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:Repeater ID="houseList" runat="server">
                                                    <ItemTemplate>
                                                        <tr style="border-bottom: 1px dotted #808080">
                                                            <td><%#Eval("HouseId") %></td>
                                                            <td><%#Eval("CustomName") %></td>
                                                            <td><%#Eval("ZoneName") %></td>
                                                            <td><%#Eval("BuildingName") %></td>
                                                            <td><%#Eval("StructName") %></td>
                                                            <td><%#Eval("FloorNum") %></td>
                                                            <td><%#Eval("DecorationName") %></td>
                                                            <td><%#Eval("AspectName") %></td>
                                                            <td><%#GetStatus(Eval("IsCompleted"))%></td>
                                                            <td><%#Eval("CustomTel") %></td>
                                                            <td><%#(Convert.ToBoolean(Eval("IsCompleted")))? "已租" : "未租"%></td>
                                                            <td><a href="customEdit.aspx?houseid=<%#Eval("HouseId") %>" class="btn btn-xs btn-warning">编辑</a> <a href="void(0)"  onclick="javascript:{if(window.confirm('确定要删除该客源')) location.href='doEditOrDelete.aspx?houseid=<%#Eval("HouseId").ToString() %>&method=delete_custom';return false;}" class="btn btn-xs btn-danger">删除</a> </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </tbody>
                                        </table>
                                        <!-- 内部的用户列表结束-->

                                    </div>


                                    <div id="nodataShow" style="text-align: center; display: none" runat="server">
                                        <img src="img/nodata.jpg" style="display: block; margin-left: auto; margin-right: auto;" />
                                        <div>很遗憾，没有您要搜索的数据，换个条件试试吧</div>
                                    </div>
                                    <!-- box body 结束 -->
                                </div>




                            </div>
                        </div>

                        <br />

                        <div class="row">
                            <div class="col-sm-12" style="text-align: center">
                                <asp:Repeater ID="pageList" runat="server">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <a style="font-size: 15px;" class="btn btn-xs <%#((Eval("Enabled").ToString() == "False")? "btn-grey" : "btn-warning")%>" href="javascript:goPage(<%#Eval("PageIndex")%>, <%#((Eval("Enabled").ToString() == "False")? "false" : "true")%>)"><%#Eval("PageText") %></a>
                                    </ItemTemplate>
                                    <FooterTemplate></FooterTemplate>
                                </asp:Repeater>


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



