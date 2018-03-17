using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class pagina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Recebe o ID da página por QueryString e pelo fato de o parametro ser String, realizamos a conversão para Integer
        int IdPagina;
        int.TryParse(Request.QueryString["id"], out IdPagina);

        // Caso não tenha sido passado o ID dá pagina, redireciona para a pagina padrão (default.aspx)
        if (IdPagina == 0) Response.Redirect("default.aspx");

        // Instancia da classe de Negocio
        WebSite.Business.Paginas paginasBO = new WebSite.Business.Paginas();
        // Chamada ao metodo que lista todas as paginas passando o ID da página e retornando o primeiro registro
        WebSite.Entities.Paginas pagina = paginasBO.ListaPaginas(new WebSite.Entities.Paginas(IdPagina)).FirstOrDefault();

        // Atribuido os dados nos Literais
        this.Title = pagina.Titulo;
        ltlTitulo.Text = pagina.Titulo;
        ltlConteudo.Text = pagina.Texto;
    }
}