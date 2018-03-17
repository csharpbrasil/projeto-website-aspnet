<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="pagina.aspx.cs" Inherits="pagina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>
        <asp:Literal ID="ltlTitulo" runat="server" />
    </h2>
    <asp:Literal ID="ltlConteudo" runat="server" />
</asp:Content>

