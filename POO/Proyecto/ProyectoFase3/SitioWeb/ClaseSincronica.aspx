<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PaginaMaestra.Master" CodeBehind="ClaseSincronica.aspx.cs" Inherits="SitioWeb.ClaseSincronica" %>


<asp:Content ID="ContenidoHeaderDefault" ContentPlaceHolderID="ContenidoHeader" runat="server">
    <!--Codigo para el header-->

</asp:Content>

<asp:Content ID="ContenidoMainDefault" ContentPlaceHolderID="ContenidoMain" runat="server">


    <form id="form1" runat="server">
        <div>
            <h1>Listado de Clase Sincronica</h1>
            <hr />
        </div>
        <div>
            ID_ClaseSincronica<asp:TextBox ID="txtBuscarClaseSincronica" runat="server" class=""></asp:TextBox>
            <asp:Button class="btn" ID="btnBuscarClase" runat="server" Text="Buscar" OnClick="btnBuscarclase_Click" />
            <asp:Button class="btn btn-info" ID="btnAgregarMatricula" runat="server" Text="Agregar Nuevo" OnClick="btnAgregar_Click" />
            <br />
        </div>
        <div class="formulario">
            <asp:GridView ID="grdListaClaseS" runat="server" AutoGenerateColumns="False" AllowPaging="True" EmptyDataText="No existen registros para mostrar" Width="100%" OnPageIndexChanging="grdListaClaseS_PageIndexChanging" PageSize="8" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" runat="server" CommandArgument='<%# Eval("ID_ClaseSincronica").ToString() %>' CommandName="Modificar" OnCommand="lnkModificar_Command">Modificar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("ID_ClaseSincronica").ToString() %>' CommandName="Eliminar" OnCommand="lnkEliminar_Command1">Eliminar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID_ClaseSincronica" HeaderText="ID_ClaseSincronica" />
                    <asp:BoundField DataField="ID_Estudiante" HeaderText="ID_Estudiante" />
                    <asp:BoundField DataField="ID_Profesor" HeaderText="ID_Profesor" />
                    <asp:BoundField DataField="ID_Curso" HeaderText="ID_Curso" />
                    <asp:BoundField DataField="FechaClase" HeaderText="FechaClase" />
                    <asp:BoundField DataField="HoraInicio" HeaderText="HoraInicio" />
                    <asp:BoundField DataField="HoraFinal" HeaderText="HoraFinal" />
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
