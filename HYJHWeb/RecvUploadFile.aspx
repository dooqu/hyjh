<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recvUploadFile.aspx.cs" Inherits="HYJHWeb.RecvUpdateFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <div id="op_message" runat="server">
       <%#opMessage %>
    </div>
    <script language="javascript">
        function rUrl()
        {
            window.location.href = "<%#redirectUrl%>";
        }
        
        setTimeout(rUrl, 3000);
    </script>
    </form>
</body>
</html>
