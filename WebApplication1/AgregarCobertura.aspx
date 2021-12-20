<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCobertura.aspx.cs" Inherits="WebApplication1.Formulario_web116" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 
    <h1>Agregar Cobertura</h1>
    <hr />
    <div class="row g-3">
    <div class="col-md-4">
        <label for="txtCobertura" class="form-label">Cobertura</label>
        <asp:TextBox class="form-control" ID="txtCobertura"  runat="server" />
        <div style="font-size:13px">
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Debe llenar el campo" ControlToValidate="txtCobertura" ForeColor="#CC0000" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" OnServerValidate="CustomValidator1_ServerValidate" runat="server" ForeColor="Red" ErrorMessage="*error" ControlToValidate="txtCobertura" Display="Dynamic"></asp:CustomValidator>

            </div>


      
        </div>

    <div>
        <asp:Button class="btn btn-primary" Text="Aceptar" OnClientClick="return checkOK()" OnClick="Click_Aceptar" runat="server" />
    </div>
    </div>
</asp:Content>
