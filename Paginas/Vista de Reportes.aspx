<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vista de Reportes.aspx.cs" Inherits="Semana12.Paginas.Vista_de_Reportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView runat="server" ID="gvPersonas" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField HeaderText="ID"  DataField="Id"/>
                    <asp:BoundField HeaderText="Nombre"  DataField="Name"/>
                    <asp:BoundField HeaderText="Edad"  DataField="Age"/>
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnGenerarPDF" runat="server" OnClick="btnGenerarPDF_Click" Text="Genera PDF"/>
            <asp:Button ID="btnExcel" runat="server" OnClick="btnExcel_Click" Text="Generar Excel"/>
        </div>
    </form>
</body>
</html>
