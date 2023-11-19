<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebForm._Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form runat="server">
        <div>
            <asp:TextBox runat="server" ID="x"></asp:TextBox>
            <asp:TextBox runat="server" ID="y"></asp:TextBox>
            <asp:Button runat="server" ID="ADD_btn" OnClick="Add_btn_Click" Text ="SEND ADD"/>
            <asp:TextBox runat="server" ID="AddResult"></asp:TextBox>
        </div>
    <br/>
        <div>
            <asp:TextBox runat="server" ID="xAddS"></asp:TextBox>
            <asp:TextBox runat="server" ID="yAddS"></asp:TextBox>
            <asp:Button runat="server" ID="ADDS_btn" OnClick="AddS_btn_Click" Text="SEND ADDS" />
            <asp:TextBox runat="server" ID="AddSResult"></asp:TextBox>
        </div>
    <br/>
        <div>
            <asp:TextBox runat="server" ID="s"></asp:TextBox>
            <asp:TextBox runat="server" ID="d"></asp:TextBox>
            <asp:Button runat="server" ID="Concat_btn" OnClick="Concat_btn_Click" Text="SEND CONCAT" />
            <asp:TextBox runat="server" ID="ConcatResult"></asp:TextBox>
        </div>
    <br/>
        <div>
            <asp:TextBox runat="server" ID="s1"></asp:TextBox>
            <asp:TextBox runat="server" ID="k1"></asp:TextBox>
            <asp:TextBox runat="server" ID="f1"></asp:TextBox>
            <br/>
            <asp:TextBox runat="server" ID="s2"></asp:TextBox>
            <asp:TextBox runat="server" ID="k2"></asp:TextBox>
            <asp:TextBox runat="server" ID="f2"></asp:TextBox>
            <br/>
            <asp:Button runat="server" ID="SumBtn" OnClick="Sum_btn_Click" Text="SEND CONCAT" />
            <br/>
            <asp:TextBox runat="server" ID="s3"></asp:TextBox>
            <asp:TextBox runat="server" ID="k3"></asp:TextBox>
            <asp:TextBox runat="server" ID="f3"></asp:TextBox>
        </div>
    </form>
</body>
</html>
