using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PaginasBO = WebSite.Business.Paginas;
using Paginas = WebSite.Entities.Paginas;

public partial class painel_editar_pagina : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                int Id;
                int.TryParse(Request.QueryString["id"], out Id);

                PaginasBO paginasBO = new PaginasBO();
                Paginas pagina = paginasBO.ListaPaginas(new Paginas(Id)).FirstOrDefault();

                hdfId.Value = pagina.Id.ToString();
                txtTitulo.Text = pagina.Titulo;
                txtTexto.Text = pagina.Texto;
                chkAtivo.Checked = pagina.Ativo;
            }
        }
    }
    protected void btnSalvar_Click(object sender, EventArgs e)
    {
        int Id;
        int.TryParse(hdfId.Value, out Id);
        string Titulo = txtTitulo.Text;
        string Texto = txtTexto.Text;
        bool Ativo = chkAtivo.Checked;

        Paginas pagina = new Paginas();
        pagina.Id = Id;
        pagina.Titulo = Titulo;
        pagina.Texto = Texto;
        pagina.Ativo = Ativo;

        PaginasBO paginasBO = new PaginasBO();
        bool Salvou = paginasBO.SalvaPagina(pagina);

        if (Salvou)
        {
            Response.Redirect("gerenciar_paginas.aspx");
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("gerenciar_paginas.aspx");
    }
}