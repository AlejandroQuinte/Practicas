<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="MantenimientoMatricula.aspx.cs" Inherits="SitioWeb.Mantenimiento_formulario" %>


<asp:Content ID="ContenidoMainMantenimientoMatricula" ContentPlaceHolderID="ContenidoMain" runat="server">

    <form class="form-inline container" id="Formulario" runat="server">
        <div>
            <h1>Matricula</h1>
            <hr />
            <br />
        </div>


       <div class="row">
           <div class="col-sm">
                <asp:Label ID="lbl3" Text="ID_Matricula" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdMatricula" runat="server" ReadOnly="true"></asp:TextBox>

            </div>

            <div  class="col-sm">
                <asp:Label class="sr-only" ID="lbl2" Text="ID_Estudiantes" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdEstudiante" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Debe seleccionar un estudiante" ControlToValidate="txtIdEstudiante" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere seleccionar a un estudiante</asp:RequiredFieldValidator>
            </div>
           <div class="col-sm">
               <asp:Button class="btn btn-primary mb-2" ID="btnSelectEstudiante" runat="server" Text="Seleccionar" OnClick="btnSelectEstudiante_Click" />
           </div>
            
            <div class="col-sm">
                <asp:Label ID="lbl1" Text="ID_Curso" runat="server" />
                <asp:TextBox class="form-control" ID="txtIdCurso" runat="server" ReadOnly="True"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Debe seleccionar un Curso" ControlToValidate="txtIdCurso" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere seleccionar un Curso</asp:RequiredFieldValidator>
            </div>
           <div class="col-sm">
                <asp:Button class="btn btn-primary mb-2" ID="btnSelectCurso" runat="server" Text="Seleccionar" OnClick="btnSelectCurso_Click" />
            </div>
       </div>
            
            
            

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="lbl" Text="Nombre Curso" runat="server" />
                <asp:TextBox class="form-control" ID="txtNombreCurso" ReadOnly="True" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Llene el nombre del curso" ControlToValidate="txtNombreCurso" ForeColor="#CC0000" ValidationGroup="ValidarFormulario">Requiere llenar </asp:RequiredFieldValidator>
            </div>
            <div class="col-sm">
                <asp:DropDownList ID="DLIntensidad" runat="server" Width="305px" AutoPostBack="True" OnSelectedIndexChanged="DLIntensidad_SelectedIndexChanged">
                    <asp:ListItem Selected="True">1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label1" Text="Precio" runat="server" />
                <asp:TextBox class="form-control" ID="txtPrecio" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label2" Text="Cantidad de horas" runat="server" />
                <asp:TextBox class="form-control" ID="txtCantHoras" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Label ID="Label3" Text="Cant horas x dias" runat="server" />
                <asp:TextBox class="form-control" ID="txtCantHorasDias" ReadOnly="True" runat="server"></asp:TextBox>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label4" Text="Estado Pago" runat="server" />
                <asp:TextBox class="form-control" ID="txtEstadoPago" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="row">
            <div class="col-sm">
                <asp:Label ID="Label7" Text="Fecha Matricula" runat="server" />
                <asp:TextBox class="form-control" data-val-required="Fecha requerida" ReadOnly="True" ID="fechaMatricula" name="fechaMatricula" runat="server"></asp:TextBox>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label6" Text="Fecha de terminado" runat="server" />
                <asp:TextBox class="form-control" data-val-required="Fecha requerida" ReadOnly="True" ID="fechaFinal" name="fechaMatricula" runat="server"></asp:TextBox>

            </div>
            <div class="col-sm">
                <asp:Label ID="Label5" Text="Pago Total" runat="server" />
                <asp:TextBox class="form-control" ID="txtPagoTotal" runat="server"></asp:TextBox>
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
