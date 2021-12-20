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
    public partial class AltaCobertura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CoberturaDB coberturaDB = new CoberturaDB();
            List<Cobertura> lista = coberturaDB.listaInactiva();
            Cobertura cobertura = lista.Find(x => x.Id == int.Parse(txtCobertura.Text));

            if(cobertura != null)
            {
                Session.Add("cobertura", cobertura);
                lblCobertura.ForeColor = System.Drawing.Color.Green;
                lblCobertura.Text = "Cobertura: " + cobertura.Nombre;
               
            }
            else
            {
                lblCobertura.ForeColor = System.Drawing.Color.Red;
                lblCobertura.Text = "*No se encontraron resultados";
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                CoberturaDB coberturaDB = new CoberturaDB();
                Cobertura cobertura = new Cobertura();

                if ((Cobertura)Session["cobertura"] != null)
                {
                    cobertura.Id = ((Cobertura)Session["cobertura"]).Id;
                    cobertura.Estado = true;
                    cobertura.Nombre = ((Cobertura)Session["cobertura"]).Nombre;
                    coberturaDB.ModificarCobertura(cobertura);
                    lblTituloAlertModal.Text = "Alta de cobertura";
                    lblVerificacion.Text = "La cobertura fue dada de alta exitosamente.";
                    verificacion_Modal.Show();
                }

            }
            catch (Exception)
            {

                lblTituloAlertModal.Text = "Error";
                lblVerificacion.Text = "Hubo un problema al dar el alta de la cobertura.";
                verificacion_Modal.Show(); ;
            }
            
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Coberturas.aspx");
        }
    }
}