<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmProducto.aspx.cs" Inherits="SitioWeb.FrmProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div>
                <h1>Mantenimiento de Productos</h1>
                <hr />
                <br />
                <br />
            </div>

            <div>
                <asp:Label ID="lblidProducto" Text="Id" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtIdProducto" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                Descripcion:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                <br />
                PrecioCompra:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <br />
                PrecioVenta:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <br />
                Gravado:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtGravado" runat="server"></asp:TextBox>
                <br />
            </div>
            <div>
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" />
            </div>
        </form>
    </div>
</body>
</html>
