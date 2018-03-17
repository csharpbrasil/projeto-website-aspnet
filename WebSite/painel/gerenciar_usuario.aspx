<%@ Page Title="" Language="C#" MasterPageFile="~/painel/MasterPage.master" AutoEventWireup="true" CodeFile="gerenciar_usuario.aspx.cs" Inherits="painel_gerenciar_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h3>Gerenciar usuários</h3>
    <br />
    <asp:Button ID="btnNovoUsuario" runat="server" Text="Novo usuário" 
        onclick="btnNovoUsuario_Click" />    
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" DataKeyNames="Id" 
        DataSourceID="ObjectDataSource1" EnableModelValidation="True" ForeColor="Black" 
        GridLines="Vertical" onrowdatabound="GridView1_RowDataBound">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="Id" 
                DataNavigateUrlFormatString="editar_usuario.aspx?id={0}" Text="Editar" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Delete" 
                        onclientclick="if(confirm('Deseja excluir esse usuário?')){ return true; }else{ return false; }" 
                        Text="Excluir"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
            <asp:BoundField DataField="Senha" HeaderText="Senha" SortExpression="Senha" />
            <asp:CheckBoxField DataField="Ativo" HeaderText="Ativo" 
                SortExpression="Ativo" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        SelectMethod="ListaUsuarios" TypeName="WebSite.Business.Usuarios" 
        DeleteMethod="ExcluiUsuario">
        <DeleteParameters>
            <asp:Parameter Name="Id" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    <br />
    <br />
    <br />
</asp:Content>

