<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MantenimientoEstudiante.aspx.cs" Inherits="SitioWeb.MantenimientoEstudiante" %>


<asp:Content ID="ContenidoMainMantenimientoEstudiante" ContentPlaceHolderID="ContenidoMain" runat="server">

    <form id="Formulario" runat="server">
        <div>
            <h1>Estudiante</h1>
            <hr />
            <br />
        </div>

                <div class="row">
                    <div class="col-sm">
                        <asp:Label ID="lbl3" Text="ID-Estudiante" runat="server" />
                        <asp:TextBox class="form-control" ID="txtIdEstudiante" runat="server" ReadOnly="true"></asp:TextBox>
                        
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="lbl2" Text="Nombre" runat="server" />
                        <asp:TextBox class="form-control" ID="txtNombre" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Escribir el nombre" ControlToValidate="txtNombre" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el nombre</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label8" Text="I Apellido" runat="server" />
                        <asp:TextBox class="form-control" ID="txtApellido1" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Escribir el apellido" ControlToValidate="txtApellido1" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el Apellido</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label9" Text="II Apellido" runat="server" />
                        <asp:TextBox class="form-control" ID="txtApellido2" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe Escribir el apellido" ControlToValidate="txtApellido2" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el Apellido II</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm">
                        <asp:Label ID="Label1" Text="Correo Electronico" runat="server" />
                        <asp:TextBox class="form-control" ID="txtCorreo" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Requiere escribir el Correo correctamente" ForeColor="#990033" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ValidarFormulario">Requiere escribir el Correo correctamente</asp:RegularExpressionValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label2" Text="Telefono" runat="server" />
                        <asp:TextBox class="form-control" ID="txtTelefono" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Escribir el telefono" ControlToValidate="txtTelefono" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el Telefono</asp:RequiredFieldValidator>
                    </div>
                </div>

            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="#CC0000" ValidationGroup="ValidarFormulario" />
            <br />
        <div>
            <asp:Button class="btn btn-dark" ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" ValidationGroup="ValidarFormulario" />
            <asp:Button class="btn btn-dark" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </form>


</asp:Content>
