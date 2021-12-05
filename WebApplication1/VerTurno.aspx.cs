using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using DBClinica;

namespace WebApplication1
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        TurnoDB turnoBD = new TurnoDB();
        Turno turnito = new Turno();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Grilla.DataSource = turnoBD.listarTurno();
            Grilla.DataBind();
        }

        protected void Grilla_editar(object sender, GridViewEditEventArgs e)
        {
            turnito.Numero = (int)Grilla.DataKeys[e.NewEditIndex].Values[0];
            Session.Add("editarTurno", turnoBD.buscarTurno(turnito.Numero));
            Response.Redirect("ModificarTurno.aspx");
        }

        protected void Click_Agregar(object sender, EventArgs e)
        {

            Response.Redirect("AsignarTurno.aspx");

        }
    }


}