using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UsuariosBO = WebSite.Business.Usuarios;
using Usuarios = WebSite.Entities.Usuarios;

public partial class painel_editar_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int Id;
                int.TryParse(Request.QueryString["id"], out Id);

                UsuariosBO usuariosBO = new UsuariosBO();
                Usuarios usuario = usuariosBO.ListaUsuarios(new Usuarios(Id)).FirstOrDefault();

                hdfId.Value = usuario.Id.ToString();
                txtNome.Text = usuario.Nome;
                txtEmail.Text = usuario.Email;
                txtLogin.Text = usuario.Login;
                txtSenha.Text = usuario.Senha;
                txtConfirmaSenha.Text = usuario.Senha;
                chkAtivo.Checked = usuario.Ativo;

                txtLogin.Enabled = false;
                txtSenha.Enabled = false;
                txtConfirmaSenha.Enabled = false;
            }
        }
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        int Id;
        int.TryParse(hdfId.Value, out Id);
        string Nome = txtNome.Text;
        string Email = txtEmail.Text;
        string Login = txtLogin.Text;
        string Senha = txtSenha.Text;
        bool Ativo = chkAtivo.Checked;

        Usuarios usuario = new Usuarios();
        usuario.Id = Id;
        usuario.Nome = Nome;
        usuario.Email = Email;
        usuario.Login = Login;
        usuario.Senha = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "MD5");
        usuario.Ativo = Ativo;

        UsuariosBO usuariosBO = new UsuariosBO();
        bool Salvou = usuariosBO.SalvaUsuario(usuario);

        if (Salvou)
        {
            Response.Redirect("gerenciar_usuario.aspx");
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("gerenciar_usuario.aspx");
    }
}