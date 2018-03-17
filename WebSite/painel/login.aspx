<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="painel_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        @import url('css/login.css');
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="geral">
        <fieldset>
            <h2>Painel de controle</h2>
            <div id="content_login">
                <label>Usuário</label>
                <asp:TextBox ID="txtUsuario" runat="server" />
                <label>Senha</label>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" />
                <br /><br />
                <asp:Button ID="btnAutenticar" Text="Autenticar" runat="server" 
                    onclick="btnAutenticar_Click" />    
            </div>
        </fieldset>
    </div>
    </form>
</body>
</html>
