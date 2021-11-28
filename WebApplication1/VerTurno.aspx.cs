﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            TurnoDB turno = new TurnoDB();
            Grilla.DataSource = turno.listarTurno();
            Grilla.DataBind();
        }
        protected void Click_ModificarTurno(object sender, EventArgs e)
        {
            Response.Redirect("ModificarTurno.aspx", false);
        }
        protected void Click_AgregarObservacion(object sender, EventArgs e)
        {
            Response.Redirect("AgregarObservacion.aspx", false);
        }
    }


}