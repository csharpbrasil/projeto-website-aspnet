using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MenuControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Instancia da classe de Negocio
        WebSite.Business.Paginas paginasBO = new WebSite.Business.Paginas();
        // Chamada ao metodo que lista todas as paginas que irá gerar um array das mesmas
        WebSite.Entities.Paginas[] paginas = paginasBO.ListaPaginas();

        // Realizando um laço de repetição no array para ler cada registro
        foreach (WebSite.Entities.Paginas pagina in paginas)
        {
            if (pagina.Ativo)
            {
                // Formatando a string para que seja gerado uma saida conforme exemplo
                // <li><a href="pagina.aspx?id=3">Titulo Pagina</a></li>
                string mnu = string.Format("<li><a href=\"pagina.aspx?id={0}\">{1}</a></li>", pagina.Id, pagina.Titulo);
                // Atribuindo o texto gerado no Server Control Literal
                ltlItensMenu.Text += mnu;
            }
        }
    }
}