<%@ Page Title="" Language="C#" MasterPageFile="~/painel/MasterPage.master" AutoEventWireup="true" CodeFile="editar_usuario.aspx.cs" Inherits="painel_editar_usuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form">
        <h3>Novo usuários</h3>
        <br />
        <asp:HiddenField ID="hdfId" runat="server" />
        <label class="label">Nome</label>
        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox><br />
        <label class="label">E-mail</label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox><br />
        <label class="label">Login</label>
        <asp:TextBox ID="txtLogin" runat="server"></asp:TextBox><br />
        <label class="label">Senha</label>
        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox><br />
        <label class="label">Confirma senha</label>
        <asp:TextBox ID="txtConfirmaSenha" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:CheckBox ID="chkAtivo" runat="server" Text="Ativo" /><br />
        <div class="command">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" onclick="btnSalvar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" onclick="btnCancelar_Click" />
        </div>
    </div>
    <br />
</asp:Content>

