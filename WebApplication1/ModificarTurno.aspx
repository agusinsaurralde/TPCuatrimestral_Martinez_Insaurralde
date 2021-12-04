<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarTurno.aspx.cs" Inherits="WebApplication1.Formulario_web13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <h3>Modificar turno</h3>
        <hr />
        <br/>
        <div>
            <asp:Label Text="Ingerse el N° Turno" runat="server" />
            <asp:TextBox ID="txtBuscar" runat="server" />
            <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />
            <asp:Label Text="*Opcional*" runat="server" />
        </div>
        <br/>
        <div> 
             <asp:Label ID="lblNumeroTurno" Text="" class="form-control" runat="server" />   
        </div>
        <br/>
        <div>
            <asp:Label ID="lblPacienteNombre" Text="" class="form-label" runat="server" />
            <asp:TextBox ID="txtPacienteNombre" class="form-control"  runat="server"/>
        </div>
        <br/>
        <div>
            <asp:Label ID="lblPacienteApellido" Text="" class="from-label" runat="server" />
            <asp:TextBox ID="txtPacienteApellido" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblEspecialidad" Text="" class="from-label" runat="server" />
            <asp:DropDownList ID="ddlistEspecialidad" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlistEspecialidad_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <br/>
        <div>
            <asp:Label ID="lblMedicoNombre" Text="" class="from-label" runat="server" />
            <%--<asp:TextBox ID="txtMedicoNombre" class="form-control" runat="server" />--%>
            <asp:DropDownList ID="ddlistMedicoNombre" class="form-control" runat="server">
            </asp:DropDownList>

        </div>
        <br/>
        <div>
            <asp:Label ID="lblMedicoApellido" Text="" class="from-label" runat="server" />
            <%--<asp:TextBox ID="txtMedicoApellido" class="form-control" runat="server" />--%>
            <asp:DropDownList ID="ddlistMedicoApellido" class="form-control" runat="server">
            </asp:DropDownList>
        </div>
        <br/>
        <div>
            <asp:Label ID="lblHoraInicio" Text="" class="from-label" runat="server" />
            <asp:TextBox ID="txtHoraInicio" type="time" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblHoraFin" Text="" class="from-label" runat="server" /> 
            <asp:TextBox ID="txtHoraFin" type="time" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblFecha" Text="" class="from-label" runat="server" />
            <asp:TextBox ID="txtFecha" type="date" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblObservaciones" Text="" class="from-label" runat="server" />
            <asp:TextBox  class="form-control" ID="txtObservaciones"  runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblEmpleadoNombre" Text="" class="from-label" runat="server" />
            <asp:TextBox ID="txtEmpleadoNombre" class="form-control" runat="server" />
        </div>
        <br/>
        <div>
            <asp:Label ID="lblEmpleadoApellido" Text="" class="from-label" runat="server" />
            <asp:TextBox ID="txtEmpleadoApellido" class="form-control" runat="server" />
        </div>
        <br/>
        <div>   
            <asp:Label ID="lblEstado" Text="" class="from-label" runat="server" />
            <asp:DropDownList ID="ddlistEstado" class="form-control" runat="server"></asp:DropDownList>
        </div>
        <br/>
            <div>
                <asp:Button ID="btnAceptar" Text="Aceptar" Onclick="btnAceptar_Click" runat ="server" />
                <asp:Button ID="btnCancelar" Text="Cancelar" Onclick="btnCancelar_Click" runat="server" />
            </div>
        
    </body>
</asp:Content>
