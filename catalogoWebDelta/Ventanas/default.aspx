<%@ Page Title="" Language="C#" MasterPageFile="~/MiMasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Ventanas._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <h1>Hola!</h1>
    <p>Llegaste al catalogo Web...</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" id="repRepetidor">
            <ItemTemplate>
                <div class="col">
                <div class="card">
                    <img src="<%#Eval("ImagenUrl") %>" class="card-img-top" >
                    <div class="card-body">
                        <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        <p class="card-text"><%#Eval("Descripcion") %></p>
                        <a href="FormularioArticulo.aspx?id=<%#Eval("Id") %>">Ver Detalle</a>
                        <asp:button text="Ejemplo" cssclass="btn btn-primary" runat="server" id="btnEjemplo" CommandArgument='<%#Eval("Id") %>' CommandName="PokemonId" OnClick="btnEjemplo_Click"/>
                    </div>
                </div>
            </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
