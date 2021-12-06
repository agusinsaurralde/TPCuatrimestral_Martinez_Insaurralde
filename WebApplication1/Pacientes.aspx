﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pacientes.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Pacientes</h1>
    <hr />
    <div class="input-group mb-3">
        <asp:TextBox class="form-control" ID="txtBusqueda" aria-describedby="button-addon2" runat="server" />
        <asp:Button Text="Buscar" OnClick ="Click_Buscar" class="btn btn-outline-secondary" runat="server" />
    </div>
   <div>       
        <asp:Button Text="Agregar" class="btn btn-primary" OnClick="Click_Agregar" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" runat="server" />
   </div> 
   <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False" SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_eliminar" OnRowEditing="Grilla_editar" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "ID" HeaderText ="ID" />
                <asp:BoundField datafield = "DNI" HeaderText ="DNI" />
                <asp:BoundField datafield = "Apellido" HeaderText ="Apellido" />
                <asp:BoundField datafield = "Nombre" HeaderText ="Nombre" />
                <asp:BoundField datafield = "FechaNacimiento" DataFormatString="{0:d}" HeaderText ="Fecha de Nacimiento" />    
                <asp:BoundField datafield = "Cobertura.Nombre" HeaderText ="Cobertura" />
                <asp:BoundField datafield = "Telefono" HeaderText ="Teléfono" />
                <asp:BoundField datafield = "Email" HeaderText ="Email" />
                <asp:BoundField datafield = "Dirección" HeaderText ="Dirección" />
                <asp:BoundField datafield = "Estado" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />   
                <asp:CommandField ButtonType="Button"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC"/>  
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
