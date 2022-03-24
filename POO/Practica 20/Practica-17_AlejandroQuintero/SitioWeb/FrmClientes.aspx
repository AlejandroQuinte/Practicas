<%@ Page Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="FrmClientes.aspx.cs" Inherits="SitioWeb.FrmClientes" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContenidoMainClientes" ContentPlaceHolderID="ContenidoMain" runat="server">
        <div class="container">
        <form id="FormularioClientes" runat="server">
            <div>
                <h1>Mantenimiento de clientes</h1>
                <hr />
                <br />
            </div>

            <div>
                <asp:Label ID="lblid" Text="Id" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtId" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <label>Nombre:</label> <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Requiere llenar" ControlToValidate="txtNombre" ValidationGroup="ValidarFormulario">Requiere colocar el nombre</asp:RequiredFieldValidator>
                <br />
                <label>Telefono:</label><asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Rellen el cuadro" ControlToValidate="txtTelefono" ValidationGroup="ValidarFormulario">Requiere telefono</asp:RequiredFieldValidator>
                <br />
                <label>Dirección:</label><asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Requiere llenar el cuadro" ControlToValidate="txtDireccion" ValidationGroup="ValidarFormulario">Requiere la direccion</asp:RequiredFieldValidator>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ValidationGroup="ValidarFormulario" />
                <br />
            </div>
            <div>
                <asp:Button class="btn" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="ValidarFormulario" />
                <asp:Button class="btn" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
        </form>
    </div>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>Todos nuestros productos son de alta calidad, Garantizado!</p>
</asp:Content>
