<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SmartHome_WF.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Smart Home</title>
    <style>
            .smartDeviceDrow{
            border: 1px solid black;
            float: left;
            margin: 3px;
            padding: 3px;
            height: 300px;
            width: 300px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server"></asp:Panel>
        </div>
    </form>
</body>
</html>
