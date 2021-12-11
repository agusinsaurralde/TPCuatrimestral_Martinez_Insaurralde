<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarMedico.aspx.cs" Inherits="WebApplication1.Formulario_web21" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <h1>Modificar Médico</h1>
    <hr />
    <br />
      <!-- tabs -->
  <ul class="nav nav-tabs" role="tablist">
    <li class="nav-item">
      <a class="nav-link active" data-bs-toggle="tab" href="#datos">Datos Personales</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" href="#especialidades">Especialidades</a>
    </li>
    <li class="nav-item">
      <a class="nav-link" data-bs-toggle="tab" href="#usuario">Usuario</a>
    </li>
  </ul>

      <!-- contenido -->
  <div class="tab-content">
       <!-- datos personales -->

      <div id="datos" class="container tab-pane active"><br>
      <h4>Datos Personales</h4>
        <hr />
      <br />
         <div class="row g-3">
           <div class="col-md-4">
               <label for="txtDNI" class="form-label">DNI</label>
               <asp:TextBox class="form-control" ID="txtDNI" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtMatricula" class="form-label">Matrícula</label>
               <asp:TextBox class="form-control" ID="txtMatricula" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtApellido" class="form-label">Apellido</label>
               <asp:TextBox class="form-control" ID="txtApellido" runat="server" />
           </div>

           <div class="col-md-4">
               <label for="txtNombre" class="form-label">Nombre</label>
               <asp:TextBox class="form-control" ID="txtNombre" runat="server" />
           </div>


           <div class="col-md-3">
               <label for="txtFechaNac" class="form-label">Fecha de Nacimiento</label>
               <asp:TextBox type="date" class="form-control" ID="txtFechaNac" runat="server" />
           </div>


           <div class="col-md-3">
               <label for="txtTelefono" class="form-label">Teléfono</label>
               <asp:TextBox type="tel" class="form-control" ID="txtTelefono" runat="server" />
           </div>

           <div class="col-12">
               <label for="txtEmail" class="form-label">Email</label>
               <asp:TextBox type="email" class="form-control" ID="txtEmail" runat="server" />
           </div>

           <div class="col-12">
               <label for="txtDireccion" class="form-label">Dirección</label>
               <asp:TextBox class="form-control" ID="txtDireccion" runat="server" />
           </div>
        </div>
    </div>


      <!-- especialidades -->
      
    <div id="especialidades" class="container tab-pane fade"><br>
      <h3>Especialidades</h3>
        <asp:Button class="btn btn-primary" id="btnAgregar" OnClick="btnAgregar_Click" Text="Agregar" runat="server" />
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <%foreach (var item in listaEsp) 
                 { 
                      int idEspecialidad = item.especialidad.Id;
                  %>

                       <div class="card border-primary mb-3" style="max-width: 18rem;">
                          <div class="card-body text-primary">
                                <h5 class="card-text"><%: item.especialidad.Nombre%></h5>
                              <a href="ModificarMedico.aspx?id=<%:idEspecialidad%>" class="btn btn-primary">Eliminar</a>
                           </div>
                       </div>
                 <% } %>
            </ContentTemplate>
        </asp:UpdatePanel>
       

    <h5>Horarios</h5>
        
                <asp:GridView CssClass="table table-hover" BorderStyle="None" ID="Grilla"  runat="server" AutoGenerateColumns="False" OnRowDeleting="Grilla_RowDeleting" OnSelectedIndexChanged="Grilla_SelectedIndexChanged" DataKeyNames="ID" EmptyDataRowStyle-BorderStyle="None" HeaderStyle-BorderColor="#333333" HeaderStyle-CssClass="table-dark" SortedDescendingCellStyle-HorizontalAlign="Left" SortedDescendingCellStyle-VerticalAlign="Middle">
            <Columns>
                <asp:BoundField datafield = "ID" HeaderText ="#" />
                <asp:BoundField datafield = "especialidad.Nombre" HeaderText ="Especialidad" />
                <asp:BoundField datafield = "NombreDia" HeaderText ="Día" />
                <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}"  HeaderText ="Entrada" />
                <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}"  HeaderText ="Salida" />
                 <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Editar"  ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />
                <asp:CommandField ButtonType="Button"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC"/>  

            </Columns>
        </asp:gridview>
      </div>


      <!-- usuario -->
       <div id="usuario" class="container tab-pane fade">
     
        <h4>Usuario</h4>
         <hr />
           <div class="col-12">
            <label for="txtNombreUsuario" class="form-label">Usuario</label>
            <asp:TextBox class="form-control" ID="txtNombreUsuario" runat="server" />
          </div>
          <div class="col-12">
            <label for="txtContraseña" class="form-label">Contraseña</label>
            <asp:TextBox class="form-control" type="Password" ID="txtContraseña" runat="server" />
          </div>
         <br />
         <div class="col-12">
         <asp:Button class="btn btn-primary" Text="Aceptar" OnClick="Click_Aceptar" runat="server" />
        </div>
    </div>

  </div>

<!-- modal eliminar especialidad -->
   <asp:Button  style="display:none" runat="server" ID="btnEliminarEspecialidadModal" />
   <ajaxToolkit:ModalPopupExtender ID="btnEliminarEspecialidad_Modal" CancelControlID="exitEliminarEspecialidad" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminarEspecialidad_Modal" TargetControlID="btnEliminarEspecialidadModal" PopupControlID="PanelEliminarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelEliminarEspecialidad" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exitEliminarEspecialidad" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar la especialidad?</label>
          
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <asp:Button class="btn btn-primary" ID="btnAceptarEliminarEspecialidad" Text="Aceptar" OnClick="btnAceptarEliminarEspecialidad_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>


<!-- modal agregar especialidad -->
   <asp:Button  style="display:none" runat="server" ID="btnEspecialidadModal" />
   <ajaxToolkit:ModalPopupExtender ID="btnAgregarEspecialidad_Modal"  CancelControlID="exitAgregar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnAgregarEspecialidad_Modal" TargetControlID="btnEspecialidadModal" PopupControlID="PanelAgregarEspecialidad">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarEspecialidad" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Agregar Especialidad</h5>
            <asp:Button id="exitAgregar"  class="btn-close" data-bs-dismiss="modal" aria-label="Cancelar" OnClick="exitAgregar_Click" runat="server" />
        </div>
        <div class="modal-body"> 
           
            <asp:UpdatePanel runat="server">
            <ContentTemplate>
               <div>
                 <asp:Label Text="Especialidad" ID="lblEspecialidad" CssClass="form-label" runat="server" />
                 <asp:DropDownList ID="ddlistEspecialidad" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
               </div>

               <div>
                   <div>
                     <asp:Label Text="Días" ID="lblDias" Visible="false" CssClass="form-label" runat="server" />
                     <asp:DropDownList ID="ddlistDiaAgregar" Visible="false" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistDiaAgregar_SelectedIndexChanged">
                         <asp:ListItem Text="Seleccionar" />
                         <asp:ListItem Text="Lunes" />
                         <asp:ListItem Text="Martes" />
                         <asp:ListItem Text="Miércoles" />
                         <asp:ListItem Text="Jueves" />
                         <asp:ListItem Text="Viernes" />
                         <asp:ListItem Text="Sábado" />
                     </asp:DropDownList>              
                   </div>

                   <div>
                      <asp:DropDownList ID="ddlistEntradaAgregar" Visible="false" class="form-select" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntradaAgregar_SelectedIndexChanged"/>
                   </div>
                   <div>
                       <asp:TextBox ID="txtSalidaAgregar" Visible ="false" Enabled="false" DataFormatString="HH:mm" AutoPostBack="true"  class="form-control" runat="server" />
                   </div>
                   <div>
                      <asp:Button  ID="btnAgregarDia" Text="+ Día" Visible="false" OnClick="btnAgregarDia_Click" AutoPostBack="true" runat="server" />
                   </div>
                   <div>
                      <asp:Button  ID="btnAgregaEspecialidadModal" Text="Agregar Especialidad" Visible="false" OnClick="btnAgregarEspecialidadModal_Click" AutoPostBack="true" runat="server" />
                   </div>
                 </div>

            </ContentTemplate>
          </asp:UpdatePanel>

        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <asp:Button class="btn btn-primary" ID="btnAceptarEspecialidad" Text="Aceptar" OnClick="btnAceptarEspecialidad_Click" runat="server" />
        </div>
    </asp:Panel>



<!-- modal eliminar dia -->
   <asp:Button  style="display:none" runat="server" ID="btnModalEliminar" />
   <ajaxToolkit:ModalPopupExtender ID="btnEliminar_ModalPopupExtender" CancelControlID="exitEliminar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEliminar_ModalPopupExtender" TargetControlID="btnModalEliminar" PopupControlID="Panel">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="Panel" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Eliminar</h5>
          <button id="exitEliminar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">
            <label>¿Está seguro que desea eliminar el día?</label>
          
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <asp:Button class="btn btn-primary" ID="btnAceptarEliminar" Text="Aceptar" OnClick="btnAceptarEliminar_Click" AutoPostback="true" runat="server" />
        </div>
    </asp:Panel>

<!-- modal editar dia-->
   <asp:Button  style="display:none" runat="server" ID="btnModalEditar" />
   <ajaxToolkit:ModalPopupExtender ID="btnEditar_ModalPopupExtender" CancelControlID="exitEditar" Enabled="true" runat="server" BackgroundCssClass="fondo" BehaviorID="btnEditar_ModalPopupExtender" TargetControlID="btnModalEditar" PopupControlID="PanelEditar">
    </ajaxToolkit:ModalPopupExtender>

    <asp:Panel ID="PanelEditar" BackColor="White" runat="server">
        <div class="modal-header">
          <h5 class="modal-title" >Editar</h5>
          <button id="exitEditar" type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
        </div>
        <div class="modal-body">

            <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div>
                <asp:Label Text="Día" runat="server" />
                <asp:DropDownList ID="ddlistDia" class="form-select" AutoPostBack="true" runat="server">
                <asp:ListItem Text="Lunes" />
                <asp:ListItem Text="Martes" />
                <asp:ListItem Text="Miércoles" />
                <asp:ListItem Text="Jueves" />
                <asp:ListItem Text="Viernes" />
                <asp:ListItem Text="Sábado" />
            </asp:DropDownList>
            </div>

            <div>
                 <asp:Label Text="Horario" runat="server" />
                 <asp:DropDownList ID="ddlistEntrada" class="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlistEntrada_SelectedIndexChanged" runat="server"> </asp:DropDownList>
                <asp:TextBox id="txtHoraSalida" Enabled="false" runat="server" />
            </div>
            </ContentTemplate>
        </asp:UpdatePanel>
            
          
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <asp:Button class="btn btn-primary" ID="btnAceptarEditar" Text="Aceptar" OnClick="btnAceptarEditar_Click" runat="server" />
        </div>
    </asp:Panel>



</asp:Content>
       
              
              
  
