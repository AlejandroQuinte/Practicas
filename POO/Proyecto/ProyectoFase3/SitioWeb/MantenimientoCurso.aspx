<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MantenimientoCurso.aspx.cs" Inherits="SitioWeb.MantenimientoCurso" %>

<asp:Content ID="ContenidoMainMantenimiento" ContentPlaceHolderID="ContenidoMain" runat="server">

    <form id="Formulario" runat="server">
        <div>
            <h1>Curso</h1>
            <hr />
            <br />
        </div>

                <div class="row">
                    <div class="col-sm">
                        <asp:Label ID="lbl3" Text="ID-Curso" runat="server" />
                        <asp:TextBox class="form-control" ID="txtIdCurso" runat="server"></asp:TextBox>

                    </div>
                    <div class="col-sm">
                        <asp:Label ID="lbl2" Text="ID-Nota" runat="server" />
                        <asp:TextBox class="form-control" ID="txtIdNota" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe Escribir el nombre" ControlToValidate="txtIdNota" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el id-Nota</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label8" Text="ID-Idioma" runat="server" />
                        <asp:TextBox class="form-control" ID="txtIdIdioma" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe Escribir Id-Idioma" ControlToValidate="txtIdIdioma" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el id-Idioma</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label9" Text="Nombre Curso" runat="server" />
                        <asp:TextBox class="form-control" ID="txtNombreCurso" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe Escribir el Nombre del curso" ControlToValidate="txtNombreCurso" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el Nombre</asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm">
                        <asp:Label ID="Label1" Text="Cantidad de Cursos" runat="server" />
                        <asp:TextBox class="form-control" ID="txtCantCursos" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe Escribir La cantidad" ControlToValidate="txtCantCursos" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir la cantidad</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label2" Text="Horas Curso" runat="server" />
                        <asp:TextBox class="form-control" ID="txtHorasCurso" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Escribir La cantidad" ControlToValidate="txtHorasCurso" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir la cantidad</asp:RequiredFieldValidator>
                    </div>
                    <div class="col-sm">
                        <asp:Label ID="Label4" Text="Precio" runat="server" />
                        <asp:TextBox class="form-control" ID="txtPrecio" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe Escribir el precio" ControlToValidate="txtPrecio" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir el precio</asp:RequiredFieldValidator>
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

