<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MantenimientoClaseSincronica.aspx.cs" Inherits="SitioWeb.MantenimientoClaseSincronica" %>

<asp:Content ID="ContenidoMainMantenimientoEstudiante" ContentPlaceHolderID="ContenidoMain" runat="server">

    <form id="Formulario" runat="server">
        <div>
            <h1>Estudiante</h1>
            <hr />
            <br />
        </div>

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="lbl3" Text="ID_ClaseSincronica" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdClaseSinc" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            <div  class="col-sm">
                <asp:Label class="sr-only" ID="lbl2" Text="ID_Estudiantes" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdEstudiante" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe seleccionar un estudiante" ControlToValidate="txtIdEstudiante" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere seleccionar a un estudiante</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label3" Text="ID_Prodesor" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdProfesor" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Debe seleccionar un Profesor" ControlToValidate="txtIdProfesor" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere seleccionar un Profesor</asp:RequiredFieldValidator>
            </div>
            <div class="col-sm">
                <asp:Label ID="lbl1" Text="ID_Curso" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdCurso" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe seleccionar un Curso" ControlToValidate="txtIdCurso" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere seleccionar un Curso</asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label1" Text="Fecha de Clase" runat="server" />
                <asp:TextBox class="form-control" ID="txtFechaClase" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Debe Seleccionar la fecha" ControlToValidate="txtFechaClase" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir La fecha</asp:RequiredFieldValidator>
                <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label2" Text="Hora inicio" runat="server" />
                <asp:TextBox class="form-control" ID="txtHoraInicio" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Debe Seleccionar la Hora" ControlToValidate="txtHoraInicio" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir La hora inicio</asp:RequiredFieldValidator>
                <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label4" Text="Hora Final" runat="server" />
                <asp:TextBox class="form-control" ID="txtHoraFinal" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Debe Seleccionar la Hora" ControlToValidate="txtHoraFinal" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere Escribir La hora Final</asp:RequiredFieldValidator>
                <asp:Calendar ID="Calendar3" runat="server"></asp:Calendar>
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
