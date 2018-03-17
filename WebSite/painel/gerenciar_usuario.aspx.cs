using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class painel_gerenciar_usuario : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNovoUsuario_Click(object sender, EventArgs e)
    {
        Response.Redirect("editar_usuario.aspx");
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // Se for uma linha de registro
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Pega o Id do usuário na linha atual
            int IdRegistro;
            // Converte o registro atual para Integer
            int.TryParse(DataBinder.Eval(e.Row.DataItem, "Id", "{0}"), out IdRegistro);
            
            // Verifica se a sessão nap expirou
            if (Session["Usuario"] != null)
            {
                // Converte a sessão para a nossa classe Usuario
                WebSite.Entities.Usuarios usuario = (WebSite.Entities.Usuarios)Session["Usuario"];
                // Pega o Id do usuário logado e com o registro atual
                if (usuario.Id == IdRegistro)
                {
                    // Pesquisa o link excluir e converte para LinkButton
                    LinkButton lnkExcluir = (LinkButton)e.Row.FindControl("LinkButton1");
                    // Oculta o link
                    lnkExcluir.Visible = false;
                }
            }
        }
    }
}