<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="HYJHWeb.detail" %>

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
        function goImage(filename, currLink)
        {
            document.getElementById("currHousePicture").src = "/pic/" + filename;
           
            var prNode = currLink.previousSibling;
            var preNodeCount = 0;
            while (prNode != null)
            {
                if (prNode.nodeName == "A")
                {
                    preNodeCount++;
                }
               
                prNode = prNode.previousSibling;
            }
            var list = document.getElementById("thumbs_list");

            var top = preNodeCount * 120 - list.scrollTop;

            if(top <= 0)
            {
                list.scrollTop -= 120;
                return;
            }

            var bottom = (preNodeCount + 1) * 120 - list.scrollTop;

            if(bottom >= 410)
            {
                list.scrollTop += 120;
                return;
            }
        }
    </script>
    <style>
        .info_col
        {
            width:100%;margin:10px;background-color:#efefef;border-radius:3px;border:1px solid #808080
        }

        .info_col div, .info_col .title
        {
            height:30px;font:16px;line-height:20px;
        }

        .title
        {
            color:orange;font-weight:bold;
        }
    </style>
    <script>
        function click_up()
        {
            var list = document.getElementById("thumbs_list");
            list.scrollTop -= 120;
        }

        function click_down()
        {
            var list = document.getElementById("thumbs_list");
            list.scrollTop += 120;
        }

        function click_enter()
        {
            var list = document.getElementById("thumbs_list");
        }


        function createVisit()
        {
            $.ajax({
                type: 'POST',
                cache: false,
                url: "/api/APIVisitHouseInfo.ashx",
                data: { houseid: '<%#house.HouseId%>' },
                success: function (data)
                {

                }
                  ,
                dataType: "html",
               
                error: function (xhr, err)
                {

                }
            });
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
                <div style="color: white; font-size: 16px; font-weight: bold;cursor:hand" onclick="javascript:{location.href='index.aspx';}">华远嘉禾房产信息管理</div>
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
        <br />
        <div style="border: 0px solid #c0c0c0; width: 1200px; margin-left: auto; margin-right: auto;">
            <div style="border: 1px solid #c0c0c0; width: 602px; height: 480px; float: left;vertical-align:middle;text-align:center;line-height:480px;background-color:white"><img style="width:600px;height:480px" id="currHousePicture" src="/pic/<%#FirstPictureUrl %>" /></div>
            <div style="border: 0px solid #808080; width: 180px; height: 480px; float: left; margin-left: 10px; position: relative">
                <div style="text-align:center;width: auto; height: 25px; background-color: #c0c0c0;color:white; position: relative; left: 0px; top: 0px" onclick="click_up()">↓</div>
                <div style="border: 0px solid #cccccc; height: 410px; margin-top: 10px; margin-bottom: 10px;overflow-y:hidden" id="thumbs_list">
                    <asp:Repeater ID="pictureList" runat="server">
                        <ItemTemplate>
                            <a href="#none" onclick="javascript:{goImage('<%#Eval("Filename") %>',this);}" style="display:block;width: auto; height: 120px;vertical-align:middle;text-align:center; border: 1px solid #c0c0c0">
                                <img style="height:118px;width:178px" src="/pic/thumb_<%#Eval("Filename") %>" />
                            </a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div style="text-align:center;width: auto; height: 25px; background-color: #c0c0c0;color:white; position: relative; left: 0px; top: 0px" onclick="click_down()">↑</div>
            </div>
            <div style="border:0px solid #808080; width: 395px; height: 480px; float: left; margin-left: 10px">
                <div class="jumbotron" style="padding-bottom:5px;padding-top:5px;margin-bottom:10px;">
                    <h2> <%#HouseTitle %></h2> 
                    <div><font style="font-weight:bold;font-size:25px;color:orange"><%--<%#HousePrice%> ￥ </font>（<%#house.PayTypeName %>） --%> <table><tr><td><select style="width:150px" class="form-control"><option><%#house.MonthPrice %>(月付)</option><option><%#house.ThreeMonthPrice %>(季付)</option><option><%#house.HalfYearPrice %>(半年付)</option><option><%#house.YearPrice %>(年付)</option></select></td><td><a href="houseEdit.aspx?houseid= <%#HouseId %>" class="btn btn-success">编辑</a>  <a href="#none"  onclick="javascript:{if(window.confirm('确定要删除该房源')) location.href='doEditOrDelete.aspx?houseid=<%#HouseId %>&method=delete_house';return false;}" class="btn btn-danger">删除</a></td></tr></table></div>
                </div>
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">小区： <%#HouseName %></div>
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">地址： <%#HouseAddress %></div>
                                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">类型： <%if(house.JoinType == 1) { %>代理<%}else if(house.JoinType == 2){ %>业主<%}else{ %>合作<%} %></div>
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">跟进： <%#house.UserBelong.Username %></div>
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">创建： <%#house.CreateDate %></div>

                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">户主： <%#house.CustomName %></div>                
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;">电话： <a href="#none" onclick="javascript:{this.innerHTML = '<%#HouseOwnerTel %>'; createVisit();}" class="btn btn-success">点击查看</a></div>
                <div class="btn btn-default tip" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;" data-original-title="<%#HouseAddress %>">是否完成： <%if(house.IsCompleted) { %>已租<%}else{ %>未租<%}%></div>
                <div class="btn btn-default" style="text-align:left;width:100%;padding-left:10px;margin-bottom:1px;height:60px;word-break:break-word;word-wrap:break-word;white-space:normal">备注： <%#house.Comment %></div>

            </div>
            <table style="width:100%" cellpadding="1" cellspacing="1" style="background-color:#cccccc">
                <tr><td></td><td></td><td></td><td></td></tr>
            </table>
            <div class="container">
                <div class="row" style="margin-top:30px"><br />
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">格局</div>
                            <div> <%#HouseStruct %></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">朝向</div>
                            <div><%#HouseAspect %></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">装修</div>
                            <div><%#HouseDecoration %></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">楼层</div>
                            <div><%#HouseFloorNum%></div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">区域</div>
                            <div><%#HouseZone%></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">合同号</div>
                            <div><%#house.ContractCode%></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">报修</div>
                            <div><%if(house.IsInError){%>报修中<%}else{ %>未报修<%} %></div>
                        </div>
                    </div>
                    <div class="col-md-3" style="text-align: center;" >
                        <div class="info_col">
                            <div class="title">面积</div>
                            <div><%#HouseSize %> ㎡</div>
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
        jQuery(document).ready(function () {
            App.setPage("widgets_box");  //Set current page
            App.init(); //Initialise plugins and elements
        });
    </script>
    <!-- /JAVASCRIPTS -->
</body>
</html>


