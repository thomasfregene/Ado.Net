<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm10.aspx.cs" Inherits="Ado.NetIntro.AdoNetConcepts.WebForm10" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Button ID="btnLoadData" runat="server" Text="Load Data" OnClick="btnLoadData_Click" />
        <asp:Button ID="btnClearCache" runat="server" Text="Clear Cache" /> <br /> <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label> <br /> <br />
        <asp:GridView ID="gvProducts" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399"></FooterStyle>

            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF"></HeaderStyle>

            <PagerStyle HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC"></PagerStyle>

            <RowStyle BackColor="White" ForeColor="#003399"></RowStyle>

            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#EDF6F6"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#0D4AC4"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#D6DFDF"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#002876"></SortedDescendingHeaderStyle>
        </asp:GridView>
        <div>
        </div>
    </form>
</body>
</html>
