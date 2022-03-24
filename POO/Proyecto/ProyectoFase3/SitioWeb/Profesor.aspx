<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Profesor.aspx.cs" Inherits="SitioWeb.Profesor" %>


<asp:Content ID="ContenidoHeaderProfesor" ContentPlaceHolderID="ContenidoHeader" runat="server">
    <!--Codigo para el header-->
</asp:Content>

<asp:Content ID="ContenidoMain" ContentPlaceHolderID="ContenidoMain" runat="server">
    <form id="form1" runat="server">

        <div>
            <h1>Listado de Profesores</h1>
            <hr />
        </div>
        <div class="row">
            <div class="col-sm">
                <label>Nombre</label> 
                <br />
                <asp:TextBox ID="txtBuscar" runat="server" class=""></asp:TextBox>
            </div>
            <div class="col-sm">
                <asp:Button class="btn" ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscarProducto_Click" />
                <asp:Button class="btn btn-info" ID="btnAgregar" runat="server" Text="Agregar Nuevo" OnClick="btnAgregar_Click" />
            </div>
            <br />
        </div>
        <div class="formulario">
            <asp:GridView ID="grdLista" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No existen registros para mostrar" Width="100%" OnPageIndexChanging="grdListaProducto_PageIndexChanging" PageSize="8" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_Profesor").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_Profesor").ToString() %>' CommandName="Eliminar" OnCommand="lnkEliminar_Command1">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID_Profesor" HeaderText="ID-Profesor" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido1" HeaderText="I Apellido" />
                    <asp:BoundField DataField="Apellido2" HeaderText="II Apellido" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                </Columns>
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
        </div>
    </form>
</asp:Content>


<asp:Content ID="ContenidoFooterDefault" ContentPlaceHolderID="ContenidoFooter" runat="server">
</asp:Content>
