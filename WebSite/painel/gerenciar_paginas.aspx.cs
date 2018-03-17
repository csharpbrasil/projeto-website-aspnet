using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class painel_gerenciar_paginas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnNovaPagina_Click(object sender, EventArgs e)
    {
        Response.Redirect("editar_pagina.aspx");
    }
}