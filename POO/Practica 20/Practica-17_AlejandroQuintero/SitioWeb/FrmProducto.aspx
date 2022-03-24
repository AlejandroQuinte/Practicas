<%@ Page Language="C#" MasterPageFile="Site1.Master" AutoEventWireup="true" CodeBehind="FrmProducto.aspx.cs" Inherits="SitioWeb.FrmProducto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="ContenidoMainProducto" ContentPlaceHolderID="ContenidoMain" runat="server">
        <form id="FormularioProductos" runat="server">
            <div>
                <h1>Mantenimiento de Productos</h1>
                <hr />
                <br />
                <br />
            </div>

            <div>
                <asp:Label ID="lblidProducto" Text="Id" runat="server" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp; &nbsp; <asp:TextBox ID="txtIdProducto" runat="server" ReadOnly="True"></asp:TextBox>
                <br />
                <label>Descripcion:</label><asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Requiere llenar" ValidationGroup="ValildarFormulario">Llene la descripcion del producto</asp:RequiredFieldValidator>
                <br />
                <label>PrecioCompra:</label><asp:TextBox ID="txtPrecioCompra" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrecioCompra" ErrorMessage="Digite el precio de compra" ValidationGroup="ValildarFormulario">Digite el precio de compra</asp:RequiredFieldValidator>
                <br />
                <label>PrecioVenta:</label> <asp:TextBox ID="txtPrecioVenta" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrecioVenta" ErrorMessage="Digite el precio de venta" ValidationGroup="ValildarFormulario">Digite el precio de venta</asp:RequiredFieldValidator>
                <br />
                <label>Gravado:</label><asp:TextBox ID="txtGravado" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtGravado" ErrorMessage="Digite el gravado &quot;SI&quot;-&quot;NO&quot;" ValidationGroup="ValildarFormulario">Llene el cuadro de gravado</asp:RequiredFieldValidator>
                <br />
            </div>
            <div>
                <asp:Button class="btn" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="ValildarFormulario" />
                <asp:Button class="btn" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ValildarFormulario" ForeColor="Red" />
            </div>
        </form>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
 
