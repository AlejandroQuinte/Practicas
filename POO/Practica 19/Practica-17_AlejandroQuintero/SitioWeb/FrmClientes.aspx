<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmClientes.aspx.cs" Inherits="SitioWeb.FrmClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <script type="text/javascript">
        function mostrarMensaje(mensaje) {
            alert(mensaje);
        }
    </script>

</head>
<body>
    <div class="container">
        <form id="form1" runat="server">
            <div>
                <h1>Mantenimiento de clientes</h1>
                <hr />
                <br />
                <br />
            </div>

            <div>
                <asp:Label ID="lblid" Text="Id" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                Nombre:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <br />
                Telefono:&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                <br />
                Dirección:&nbsp;&nbsp; <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
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
