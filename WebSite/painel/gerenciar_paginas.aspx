<%@ Page Title="" Language="C#" MasterPageFile="~/painel/MasterPage.master" AutoEventWireup="true" CodeFile="gerenciar_paginas.aspx.cs" Inherits="painel_gerenciar_paginas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Gerenciar páginas</h3>
    <br />
    <asp:Button ID="btnNovaPagina" runat="server" Text="Nova página" 
        onclick="btnNovaPagina_Click" />    
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" 
        DataSourceID="ObjectDataSource1" EnableModelValidation="True" ForeColor="Black" 
        GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" 
                DataNavigateUrlFormatString="editar_pagina.aspx?id={0}" Text="Editar" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" Text="Excluir" OnClientClick="if(confirm('Deseja excluir essa página?')) { return true; }else{ return false; }"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Titulo" HeaderText="Titulo" 
                SortExpression="Titulo" />
            <asp:BoundField DataField="Texto" HeaderText="Texto" SortExpression="Texto" />
            <asp:BoundField DataField="DataCriacao" HeaderText="DataCriacao" 
                SortExpression="DataCriacao" />
            <asp:CheckBoxField DataField="Ativo" HeaderText="Ativo" 
                SortExpression="Ativo" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="ExcluiPagina" SelectMethod="ListaPaginas" 
        TypeName="WebSite.Business.Paginas">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
</asp:Content>

