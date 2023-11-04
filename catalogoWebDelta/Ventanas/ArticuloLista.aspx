<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="ArticuloLista.aspx.cs" Inherits="Ventanas.ArticuloLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <h1>tabla de Articulos</h1>
    <asp:GridView ID="DGVArticulos" runat="server"  CssClass="table table-striped "  AutoGenerateColumns="false"
          OnSelectedIndexChanged="DGVArticulos_SelectedIndexChanged"
         OnPageIndexChanging="DGVArticulos_PageIndexChanging"
         AllowPaging="true" PageSize="5" DataKeyNames="Id" >
        <Columns>
            <asp:BoundField  HeaderText="código" DataField="codigo"/>
             <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion1" />
            <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion1" />
             <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="✍" />

        </Columns>

    </asp:GridView>
     <a href="FormularioArticulo.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
