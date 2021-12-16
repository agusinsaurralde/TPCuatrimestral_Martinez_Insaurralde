<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">

        function checkOk() {
            swal("Ok!", "Los cambios fueron guardados :D!", "success");
            setTimeout(function () { window.location.href = "Turnos.aspx"; }, 1500); 
        }
 
    </script>



    <asp:UpdatePanel runat="server">
        <ContentTemplate>  
            <h3 style="margin-top:30px; margin-bottom:20px">Modificar turno</h3>
        <hr />

            <div class="row"> 
                <div class="col-md-3">
                    <h5>Datos</h5>
                </div>
                <div class="col-md-3 justify-content-center">
                    <asp:Label Text="N° TURNO: " Font-Size="Small" Font-Bold="true" runat="server" />
                     <asp:Label ID="lblNumeroTurno" class="form-label" runat="server" />  
                </div>
            </div>
            <div class="row justify-content-center" style="margin-bottom:7px">
                <div class="col-md-6">
                    <asp:Label Text="PACIENTE: " Font-Size="Small" Font-Bold="true" runat="server" />
                    <asp:Label ID="lblPaciente" Font-Size="15px" class="form-label" runat="server" />
                </div>
            </div>
            <div class="row justify-content-center" style="margin-bottom:7px">
                <div class="col-md-6">
                    <asp:Label Text="ESPECIALIDAD: " Font-Size="Small" Font-Bold="true" runat="server" />
                    <asp:Label ID="lblEspecialidad" Font-Size="15px" class="from-label" runat="server" />
                </div>
            </div>
            <div class="row justify-content-center">
                <div class="col-md-6">
                     <asp:Label Text="MÉDICO: " Font-Size="Small" Font-Bold="true" runat="server" />
                    <asp:Label Text="" ID="lblMedico" Font-Size="15px" CssClass="form-label" runat="server" />
                </div>
            </div>

      <hr />
  <div class="container" style="margin-top: 40px">
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-3"><h5>Horario</h5></div>
                     
                     <div class="col-md-3 justify-content-center">
                         <asp:Calendar  runat="server" ID="Calendario" OnDayRender="Calendario_DayRender" OnSelectionChanged="Calendario_SelectionChanged"></asp:Calendar>          
                      </div>
                     <div class="col-md-3 justify-content-center">
                         <asp:Label Text="HORARIO" ID="lblHora" Font-Size="Small" Font-Bold="true" CssClass="form-label" runat="server" />
                         <asp:DropDownList ID="ddlistHora"  class="form-select" OnSelectedIndexChanged="ddlistHora_SelectedIndexChanged" CssClass="form-select rounded-pill" SelectedIndexChanged="ddlistaHora_SelectedIndexChanged" AutoPostBack="true" runat="server" EnableViewState="True"></asp:DropDownList>
                     </div>
                </div>
        </ContentTemplate>
    </asp:UpdatePanel>
         
        <div class="row justify-content-center" style="margin-top:30PX">
             <div class="col-md-6">
                 <asp:Label ID="lblObservaciones" Text="OBSERVACIONES" Font-Size="Small" Font-Bold="true" class="from-label" runat="server" />
                 <asp:TextBox  CssClass="form-control" TextMode="MultiLine" Enabled="false" Rows="3" ID="txtObservaciones"  runat="server" />
             </div>
        </div>
    </div>
        <!--<div class="col-md-3">
            <label for="lblUsuarioLogueado" class="form-label">Recepcionista: </label>
            <asp:Label ID="lblUsuarioLogueado" Text="" class="for-label" runat="server"></asp:Label>
        </div>-->

            <div class="row justify-content-end" style="margin-top:60px">
                <div class="col-md-1">
                     <asp:Button ID="btnCancelar" CssClass="btn btn-outline-secondary rounded-pill" BorderStyle="none" Text="CANCELAR" Font-Size="Small" Font-Bold="true"  Onclick="btnCancelar_Click" runat="server" />
                </div>
                <div class="col-md-1">
                     <asp:Button ID="btnAceptar" CssClass="btn btn-primary rounded-pill" Text="ACEPTAR" Font-Size="Small" Font-Bold="true"  OnClientClick="return checkOk()" Onclick="btnAceptar_Click" runat ="server" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
        

</asp:Content>
