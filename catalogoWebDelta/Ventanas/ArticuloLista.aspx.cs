using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;


namespace Ventanas
{
    public partial class ArticuloLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloNegocio negocio = new ArticuloNegocio();
                Session.Add("listaArticulos", negocio.listar());
                DGVArticulos.DataSource = Session["listaArticulos"];
                DGVArticulos.DataBind();
            }
        }

        protected void DGVArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = DGVArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioArticulo.aspx?id=" + id);
        }

        protected void DGVArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DGVArticulos.DataSource = Session["listaArticulos"];
            DGVArticulos.PageIndex = e.NewPageIndex;
            DGVArticulos.DataBind();
        }
    }
}