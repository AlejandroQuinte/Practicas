<%@ Page Language="C#" MasterPageFile="PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="Matricula.aspx.cs" Inherits="SitioWeb.Matricula" %>



<asp:Content ID="ContenidoHeaderDefault" ContentPlaceHolderID="ContenidoHeader" runat="server">
    <!--Codigo para el header-->

</asp:Content>

<asp:Content ID="ContenidoMainDefault" ContentPlaceHolderID="ContenidoMain" runat="server">


    <form id="form1" runat="server">
        <div>
            <h1>Listado de Matricula</h1>
            <hr />
        </div>
        <div>
            ID-Matricula<asp:TextBox ID="txtBuscarMatricula" runat="server" class=""></asp:TextBox>
            <asp:Button class="btn" ID="btnBuscarCliente" runat="server" Text="Buscar" OnClick="btnBuscarProducto_Click" />
            <asp:Button class="btn btn-info" ID="btnAgregarMatricula" runat="server" Text="Agregar Nuevo" OnClick="btnAgregar_Click" />
            <br />
        </div>
        <div class="formulario">
            <asp:GridView ID="grdListaMatricula" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No existen registros para mostrar" Width="100%" OnPageIndexChanging="grdListaProducto_PageIndexChanging" PageSize="8" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_Matricula").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_Matricula").ToString() %>' CommandName="Eliminar" OnCommand="lnkEliminar_Command1">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID_Matricula" HeaderText="ID-Matricula" />
                    <asp:BoundField DataField="ID_Estudiantes" HeaderText="ID-Estudiantes" />
                    <asp:BoundField DataField="ID_Curso" HeaderText="ID-Curso" />
                    <asp:BoundField DataField="Intensidad" HeaderText="Intensidad" />
                    <asp:BoundField DataField="FechaMatricula" HeaderText="Fecha Matricula" />
                    <asp:BoundField DataField="TotalPago" HeaderText="Total Pago" />
                    <asp:BoundField DataField="EstadoPago" HeaderText="Estado Pago" />
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
