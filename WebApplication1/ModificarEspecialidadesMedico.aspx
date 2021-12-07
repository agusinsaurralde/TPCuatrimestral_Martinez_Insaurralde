<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarEspecialidadesMedico.aspx.cs" Inherits="WebApplication1.ModificarEspecialidadesMedico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView CssClass="table table-hover" ID="Grilla"  runat="server" AutoGenerateColumns="False"  SelectedRowStyle-BackColor="#999999" OnRowDeleting="Grilla_RowDeleting" OnRowEditing="Grilla_RowEditing" DataKeyNames="ID" >
            <Columns>
                <asp:BoundField datafield = "Especialidad.Nombre" HeaderText ="Especialidad" />
                <asp:BoundField datafield = "NombreDia" HeaderText ="Dia" />
                <asp:BoundField datafield = "HorarioEntrada" DataFormatString="{0:HH:mm}" HeaderText ="Hora de Entrada" />
                <asp:BoundField datafield = "HorarioSalida" DataFormatString="{0:HH:mm}" HeaderText ="Hora de Salida" />
                <asp:BoundField datafield = "Estado" DataFormatString="{0:HH:mm}" HeaderText ="Estado" />
                <asp:CommandField ButtonType="Button"  ShowEditButton="true" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC" />   
                <asp:CommandField ButtonType="Button"  ShowDeleteButton="True" ControlStyle-CssClass="btn btn-primary" ControlStyle-BackColor="#0099CC" ControlStyle-BorderColor="#0099CC"/>  
            </Columns>
        </asp:gridview>
    </div>

</asp:Content>
