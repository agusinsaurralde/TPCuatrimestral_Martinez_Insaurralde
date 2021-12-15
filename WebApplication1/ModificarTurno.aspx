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
            <h3>Modificar turno</h3>
        <hr />
        <br/>

        <div> 
             <asp:Label ID="lblNumeroTurno" Text="" class="form-control" runat="server" />   
        </div>
        <br/>
        <div>
            <asp:Label ID="lblPaciente" Text="" class="form-label" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblEspecialidad" Text="" class="from-label" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label Text="" ID="lblMedico"  CssClass="form-label" runat="server" />
        </div>
        <br/>
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div>
             <asp:Calendar  runat="server" ID="Calendario" OnDayRender="Calendario_DayRender" OnSelectionChanged="Calendario_SelectionChanged"></asp:Calendar>          
        </div>
        <div>
            <asp:Label Text="Horario" ID="lblHora" CssClass="form-label" runat="server" />
            <asp:DropDownList ID="ddlistHora"  class="form-select" CssClass="form-select" Enabled ="false"  SelectedIndexChanged="ddlistaHora_SelectedIndexChanged" AutoPostBack="true" runat="server" EnableViewState="True"></asp:DropDownList>
        </div>
        </ContentTemplate>
    </asp:UpdatePanel>
         
        <br/>
        <div>
            <asp:Label ID="lblObservaciones" Text="" class="from-label" runat="server" />
            <asp:TextBox  class="form-control" ID="txtObservaciones"  runat="server" />
        </div>
        <br/>
        <div class="col-md-3">
            <label for="lblUsuarioLogueado" class="form-label">Recepcionista: </label>
            <asp:Label ID="lblUsuarioLogueado" Text="" class="for-label" runat="server"></asp:Label>
            <%--<asp:DropDownList ID="ddlistRecepcionista" class="form-select" runat="server"></asp:DropDownList>--%>
    </div>
     <div>
            <label for="ddlistEstado" class="form-label">Estado</label>
            <asp:DropDownList ID="ddlistEstado" class="form-select" runat="server"></asp:DropDownList>
    </div>
        <br/>
            <div>
                <asp:Button ID="btnAceptar" Text="Aceptar" OnClientClick="return checkOk()" Onclick="btnAceptar_Click" runat ="server" />
                <asp:Button ID="btnCancelar" Text="Cancelar" Onclick="btnCancelar_Click" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
        
        

</asp:Content>
