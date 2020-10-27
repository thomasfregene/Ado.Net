<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Ado.NetIntro.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="GridView1" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510"></FooterStyle>

            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510"></PagerStyle>

            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510"></RowStyle>

            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#FFF1D4"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#B95C30"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#F1E5CE"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#93451F"></SortedDescendingHeaderStyle>
        </asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
