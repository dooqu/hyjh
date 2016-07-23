<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="doEditOrDelete.aspx.cs" Inherits="HYJHWeb.doEditOrDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="op_message" runat="server"><%#opMessage %></div>
    <script language="javascript">
        var redirectUrl = "<%# redirectUrl%>";
        function rUrl()
        {
            if (redirectUrl != "")
                location.href = redirectUrl;
            else
                history.go(-1);
        }
        
        setTimeout(rUrl, 3000);
    </script>
    </form>
</body>
</html>
