<%@ Page Title="" Language="C#" MasterPageFile="~/painel/MasterPage.master" AutoEventWireup="true" CodeFile="editar_pagina.aspx.cs" Inherits="painel_editar_pagina" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form">
        <h3>Nova página</h3>
        <br />
        <asp:HiddenField ID="hdfId" runat="server" />
        <label class="label">Titulo</label>
        <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox><br />
        <label class="label">Texto</label>
        <ckeditor:ckeditorcontrol ID="txtTexto" runat="server" ToolbarFull="Cut|Copy|Paste|PasteText|PasteFromWord|-|Print|SpellChecker|Scayt|Undo|Redo|-|Find|Replace|-|SelectAll
/
Bold|Italic|Underline|Strike|-|Subscript|Superscript|NumberedList|BulletedList|-|Outdent|Indent|Blockquote|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|Link|Unlink|Anchor|Image|Table|HorizontalRule|Smiley|SpecialChar
/
Styles|Format|Font|FontSize|TextColor|BGColor|Maximize|Source"></ckeditor:ckeditorcontrol>
        <asp:CheckBox ID="chkAtivo" runat="server" Text="Ativo" /><br />
        <div class="command">
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" 
                onclick="btnSalvar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                onclick="btnCancelar_Click" />
        </div>
    </div>
    <br />
</asp:Content>

