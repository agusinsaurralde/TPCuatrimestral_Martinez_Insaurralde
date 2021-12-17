<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Turnos.aspx.cs" Inherits="WebApplication1.Formulario_web12" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Turnos</h1>
    <hr />

     <div class="container" style="margin:20px 0px 20px 0px">
        <div class="d-flex flex-row-reverse">
         <div class="col-md-4">
            <div class="input-group mb-3">
               <asp:TextBox class="form-control" ID="txtBusqueda" OnTextChanged="txtBusqueda_TextChanged" AutoPostBack="true" runat="server" />  
               <asp:DropDownList ID="ddlistCriterio" class="btn btn-outline-primary dropdown-toggle" runat="server">
                   <asp:ListItem Text="Paciente" />
                   <asp:ListItem Text="Médico" />
                   </asp:DropDownList>
               <asp:Button Text="BUSCAR" OnClick ="Click_Buscar" class="btn btn-primary" Font-Bold="true" Font-Size="Small" runat="server" />
             </div>
          </div>
            <div class="col ">
                  <asp:Button Text="Agregar +" CssClass="btn btn-primary rounded-pill" ID="btnAsignarTurno" OnClick="Click_Agregar" Font-Bold="true" runat="server" />
            </div>
         </div>
    </div>

    <asp:Label id="resultados" Text="No se encontraron resultados." Visible="false" runat="server" />
   
     <div class="container">
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" OnRowDeleting="Grilla_RowDeleting" OnRowEditing="Grilla_editar" DataKeyNames="Numero" HeaderStyle-CssClass="table-primary" BorderStyle="None" HeaderStyle-Font-Size="Small" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>   
                <asp:BoundField datafield = "Paciente.NombreCompleto" HeaderText ="PACIENTE" />
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="ESPECIALIDAD" />
                <asp:BoundField datafield = "Medico.NombreCompleto"  HeaderText ="MÉDICO" />
                <asp:BoundField datafield = "Dia" DataFormatString="{0:d}"  HeaderText ="DÍA" />
                <asp:BoundField datafield = "HorarioInicio" DataFormatString="{0:HH:mm}"  HeaderText ="HORA" />
                <asp:BoundField datafield = "Observaciones" ItemStyle-Width="20%" HeaderText ="MOTIVO DE CONSULTA" />
                <asp:BoundField datafield = "AdministrativoResponsable.NombreCompleto" HeaderText ="RECEPCIONISTA" />
                <asp:BoundField datafield = "Estado.Estado" HeaderText ="ESTADO" />
                <asp:CommandField  ButtonType="Button" ShowEditButton="true" EditText="OBSERVACIÓN +"  ControlStyle-Font-Bold="true" ControlStyle-Font-Size="Small" ControlStyle-CssClass="btn btn-primary rounded-pill"/>
                <asp:CommandField  ButtonType="Image" ShowSelectButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" SelectImageUrl="Iconos/pencil-square.svg"/>
                <asp:CommandField ButtonType="Image"  ShowDeleteButton="true" ControlStyle-CssClass="btn btn-primary rounded-pill"  ControlStyle-BackColor="White" ControlStyle-BorderColor="White" DeleteImageUrl="Iconos/x-circle.svg" />                   
            </Columns>
        </asp:gridview>
    </div>
 
       <!-- modal eliminar cobertura-->
    <asp:Button  style="display:none" runat="server" ID="btnCancelarTurno" />
    
   <ajaxToolkit:ModalPopupExtender ID="cancelarTurno_Modal" CancelControlID="exit" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="cancelarTurno_Modal" TargetControlID="btnCancelarTurno" PopupControlID="Panel">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="Panel" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Cancelar Turno</h5>
          <button id="exit" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="¿Está seguro que desea cancelar el turno?" runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="Cancelar" class="btn btn-secondary rounded-pill" data-bs-dismiss="modal" runat="server" />
            <asp:Button class="btn btn-primary rounded-pill" ID="btnAceptarCancelar" Text="Aceptar" OnClick="btnAceptarCancelar_Click" runat="server" />
        </div>
    </asp:Panel>



        <!-- modal editar restringido-->
    <asp:Button  style="display:none" runat="server" ID="btnEditarRestringido" />
    
   <ajaxToolkit:ModalPopupExtender ID="btnEditarRestringido_Modal" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEditarRestringido_Modal" TargetControlID="btnEditarRestringido" PopupControlID="PanelEditar">
    </ajaxToolkit:ModalPopupExtender>
    
    <asp:Panel ID="PanelEditar" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Editar Turnos</h5>
          <button id="exitEditar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <asp:Label Text="No se puede editar un turno cerrado." runat="server" />
          
        </div>
        <div class="modal-footer">
            <asp:Button Text="CERRAR" class="btn btn-outline-secondary rounded-pill" BorderStyle="None" Font-Bold="true" Font-Size="Small" data-bs-dismiss="modal" runat="server" />
        </div>
    </asp:Panel>


</asp:Content>
