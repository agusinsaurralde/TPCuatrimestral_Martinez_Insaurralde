<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AsignarTurno.aspx.cs" Inherits="WebApplication1.prueba" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script>
        function validarDNI() {
            var dni = document.getElementById("<% = txtDNI.ClientID %>").value;

            if (dni === "") {
                $("#txtDNI").addClass("is-invalid");
                return false;
            }
            else {
                $("#txtDNI").removeClass("is-invalid");
            }
            return true;

        }
        function validarEspecialidadMedico() {
            var especialidad = document.getElementById("ddlistEspecialidad");
            var medico = document.getElementById("ddlistMedico");

            var indiceE = especialidad.options[especialidad.selectedIndex].index;
            var indiceM = medico.options[medico.selectedIndex].index;

            if (indiceE === 0) {
                $("#ddlistEspecialidad").addClass("is-invalid");
                return false;
            }
            else {
                $("#ddlistEspecialidad").removeClass("is-invalid");
            }

            if (indiceM === 0) {
                $("#ddlistMedico").addClass("is-invalid");
                return false;
            }
            else {
                $("#ddlistMedico").removeClass("is-invalid");
            }
            return true;
        }
    </script>
    
    
    <h3 style="margin-top:40px">Asignar Turno</h3>
    <br />
    <div class="row estilo" style="margin-top:40px">
        <div class="col"><asp:Label Text="1.PACIENTE" Font-Size="Small" ID="lblPaciente" runat="server" /></div>
        <div class="col"> <asp:Label Text="2.SERVICIO"  Font-Size="Small" ID="lblServicio" runat="server" /></div>
        <div class="col"><asp:Label Text="3.HORARIO"  Font-Size="Small" ID="lblHorario" runat="server" /></div>
    </div>
    <hr />

    <asp:MultiView ID="MultiView" runat="server">
        <asp:View ID="vistaPaciente" runat="server">

            <div class="row justify-content-center needs-validation" style="margin-top:40px">
                <div class="col-md-2 estilo" style="margin-right:110px">
                    <label for="txtDNI" class="form-label">DNI</label>
                </div>

            </div>
            <div class="row justify-content-center">
                <div class="col-md-2">
                   <asp:TextBox CssClass="form-control rounded-pill" ID="txtDNI"  runat="server" />
                    <div style="font-size:13px">
                          <asp:RequiredFieldValidator runat="server" ErrorMessage="*Debe completar el campo" ControlToValidate="txtDNI" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ErrorMessage="*Ingrese un DNI válido" ControlToValidate="txtDNI" Runat="server" Display="Dynamic" EnableClientScript="true" ValidationExpression="\d+" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                  </div>
               </div>
                <div class="col-md-1" style="margin-bottom:40px">
                     <asp:Button CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" Text="BUSCAR" OnClick="btnBuscar_Click" runat="server" />
                </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-2">
                    <asp:Label Text="" ID="txtPaciente" runat="server" />
                 </div>
            </div>

            <div class="row justify-content-center">
                <div class="col-md-2">
                    <asp:Label Text="" ID="txtCobertura" runat="server" />
                 </div>
            </div>
             

            <hr />
             <div class="row justify-content-end" style="margin-bottom:100px; margin-top:60px">
                  <div class="col-md-2">
                      <asp:Button Text="SIGUIENTE >" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" ID="btn0a1" runat="server" OnClick="btn0a1_Click" />
                  </div>
             </div>
        </asp:View>


         <asp:View ID="vistaMedico" runat="server">
             <asp:UpdatePanel runat="server">
                   <ContentTemplate>
                       <div class="row justify-content-center" style="margin:60px 0px 60px 0px">
                           <div class="col-md-3">
                                <asp:Label Text="ESPECIALIDAD" Font-Bold="true" Font-Size="Small" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                                <asp:DropDownList ID="ddlistEspecialidad" ClientIDMode="Static" Enabled = false CssClass="form-select rounded-pill" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
                                <div style="font-size:13px">
                                  <asp:CustomValidator ID="CustomValidatorEspecialidad" OnServerValidate="CustomValidatorEspecialidad_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*Debe seleccionar una especialidad" ControlToValidate="ddlistEspecialidad" Display="Dynamic"></asp:CustomValidator>
                               </div>
                            </div>
                           <div class="col-md-3">
                               <asp:Label Text="MÉDICO" Font-Bold="true" Font-Size="Small" ID="lblMedico"  CssClass="form-label" runat="server" />
                               <asp:DropDownList ID="ddlistMedico" ClientIDMode="Static" Enabled = false class="form-select" CssClass="form-select rounded-pill"  OnSelectedIndexChanged="ddlistMedico_SelectedIndexChanged" AutoPostBack="true" runat="server" EnableViewState="True" ></asp:DropDownList>
                                <div style="font-size:13px">
                                  <asp:CustomValidator ID="CustomValidatorMedico" OnServerValidate="CustomValidatorMedico_ServerValidate" runat="server" ForeColor="#CC0000" ErrorMessage="*Debe seleccionar un médico" ControlToValidate="ddlistMedico" Display="Dynamic"></asp:CustomValidator>
                               </div>
                           </div>
                       </div>

                   </ContentTemplate>
            </asp:UpdatePanel>  

             <hr />


             <div class="row justify-content-md-between" style="margin-bottom:100px; margin-top: 60px">
                 <div class="col-md-2" style="margin-left: 80px">
                     <asp:Button Text="< ANTERIOR" CssClass="btn btn-secondary rounded-pill" Font-Bold="true" Font-Size="Small" ID="btn1a0" runat="server" OnClick="btn1a0_Click"  />
                 </div>
                 <div class="col-md-2">
                     <asp:Button Text="SIGUIENTE >" CssClass="btn btn-primary rounded-pill" Font-Bold="true" Font-Size="Small" ID="btn1a2" runat="server" OnClick="btn1a2_Click" />
                 </div>
             </div>
                    
        </asp:View>

         <asp:View ID="vistaHorario" runat="server">
             
              <div class="row justify-content-center" style="margin-bottom:100px; margin-top:100px">
                    <div class="col-md-3" style="margin-right:25px">
                         <asp:Calendar Enabled ="false" runat="server" ID="Calendario" OnDayRender="Calendario_DayRender" AutoPostBack="true"  OnSelectionChanged="Calendario_SelectionChanged"></asp:Calendar>   
                    </div> 
                     <div class="col-md-3">
                         <asp:Label Text="HORARIO" Font-Bold="true" Font-Size="Small" ID="lblHora" CssClass="form-label" runat="server" />
                         <asp:DropDownList ID="ddlistHora" Enabled = false CssClass="form-select rounded-pill" AutoPostBack="true" runat="server" EnableViewState="True"></asp:DropDownList>
                         <br />
                         <asp:Label Text="OBSERVACIONES" ID="lblObservaciones" Font-Bold="true" Font-Size="Small" CssClass="form-label" runat="server" />
                         <asp:TextBox TextMode="MultiLine" Rows="4"  CssClass="form-control" ID="txtObservaciones"  runat="server" />
                    </div>

              </div>

                  <div class="row justify-content-md-between">
                      <div class="col-md-2"  style="margin-left: 80px">
                        <asp:Button Text="< ANTERIOR" CssClass="btn btn-secondary rounded-pill" Font-Bold="true" Font-Size="Small" ID="btn2a1" OnClick="btn2a1_Click" runat="server" />  
                      </div>
                      <div class="col-md-2">
                          <asp:Button ID="btnAceptar" Text="ACEPTAR" CssClass="btn btn-primary rounded-pill" Enabled="false" Font-Bold="true" OnClick="Aceptar_Click" Font-Size="Small" runat="server" />
                      </div>
                  </div>

        </asp:View>
    </asp:MultiView>
</asp:Content>
