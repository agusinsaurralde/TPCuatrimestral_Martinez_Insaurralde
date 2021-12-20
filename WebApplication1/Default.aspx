<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="card border-info mb-3" style="max-width: 1000rem;">
    <header class="backgraund: alert-info" style="max-width: 1000rem;">  
        <asp:Label ID="lblNombreUsuario" Text="" runat="server" />
       <%--<asp:ImageButton ID="btnLogOut" ImageUrl="https://image.flaticon.com/icons/png/512/25/25706.png" Width="18px" Height="19px" Style="margin-left: 1000px; margin-top:0;" OnClick="btnLogOut_Click" runat="server" />--%>
        
    </header>
</div>
    <h1>Clinica Dermar</h1>

        <% Dominio.Usuario ejecuta = new Dominio.Usuario(); Dominio.Usuario usuarioSesion = new Dominio.Usuario(); %>
        <% usuarioSesion = (Dominio.Usuario)Session["Usuario"];%> 
        
<% if (ejecuta.UsuarioAdmin(usuarioSesion))
    { %>

    <div class="align-content-center">   
        <div class ="row">
    
                <div class="col-md-3"> 
                    <div class="card-body" style="width: 13rem";>
                        <div class="text-xl-center">
                            <a href="Turnos.aspx">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-clipboard" viewBox="0 0 16 16">
                                    <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1h1a1 1 0 0 1 1 1V14a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V3.5a1 1 0 0 1 1-1h1v-1z"/>
                                    <path d="M9.5 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5h3zm-3-1A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3z"/>
                                </svg>
                            </a>
                        </div>
                        <div class="text-xl-center">
                            <div class="card-group">
                                <h5 class="card-title">Turnos</h5>
                                <p class="card-text">Asignación de turono.</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3"> 
                    <div class="card-body" style="width: 13rem";>
                        <div class="text-xl-center">
                            <a href="Pacientes.aspx">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-people" viewBox="0 0 16 16">
                                    <path d="M15 14s1 0 1-1-1-4-5-4-5 3-5 4 1 1 1 1h8zm-7.978-1A.261.261 0 0 1 7 12.996c.001-.264.167-1.03.76-1.72C8.312 10.629 9.282 10 11 10c1.717 0 2.687.63 3.24 1.276.593.69.758 1.457.76 1.72l-.008.002a.274.274 0 0 1-.014.002H7.022zM11 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4zm3-2a3 3 0 1 1-6 0 3 3 0 0 1 6 0zM6.936 9.28a5.88 5.88 0 0 0-1.23-.247A7.35 7.35 0 0 0 5 9c-4 0-5 3-5 4 0 .667.333 1 1 1h4.216A2.238 2.238 0 0 1 5 13c0-1.01.377-2.042 1.09-2.904.243-.294.526-.569.846-.816zM4.92 10A5.493 5.493 0 0 0 4 13H1c0-.26.164-1.03.76-1.724.545-.636 1.492-1.256 3.16-1.275zM1.5 5.5a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm3-2a2 2 0 1 0 0 4 2 2 0 0 0 0-4z"/>
                                </svg>
                            </a>
                        </div>
                        <div class="text-xl-center">
                             <div class="card-group">
                                <h5 class="card-title">Pacientes.</h5>  
                                <p class="card-text"> Ver pacientes.</p>
                            </div>
                        </div>
                    </div>
                </div>

    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="HistoriaClinica.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-card-heading" viewBox="0 0 16 16">
                    <path d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z"/>
                    <path d="M3 8.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5zm0-5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5v-1z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Historia clinica.</h5>
            <p class="card-text">Ver historia clinica.</p>  
        </div>
        </div>
    </div>
    </div>

        </div>

        <div class ="row">
            <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="Medico.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-person-workspace" viewBox="0 0 16 16">
                    <path d="M4 16s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H4Zm4-5.95a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z"/>
                    <path d="M2 1a2 2 0 0 0-2 2v9.5A1.5 1.5 0 0 0 1.5 14h.653a5.373 5.373 0 0 1 1.066-2H1V3a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v9h-2.219c.554.654.89 1.373 1.066 2h.653a1.5 1.5 0 0 0 1.5-1.5V3a2 2 0 0 0-2-2H2Z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Medicos.</h5>
            <p class="card-text">Ver Medicos.</p>  
        </div>
        </div>
    </div>
    </div>

    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="SpecialtysViews.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-ui-radios" viewBox="0 0 16 16">
                    <path d="M7 2.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5v-1zM0 12a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm7-1.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5v-1zm0-5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zm0 8a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zM3 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6zm0 4.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Especialidades.</h5>
            <p class="card-text">Ver Especialidades.</p>  
        </div>
        </div>
    </div>
    </div>

    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="Coberturas.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-grid-3x3-gap" viewBox="0 0 16 16">
                <path d="M4 2v2H2V2h2zm1 12v-2a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zm0-5V7a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zm0-5V2a1 1 0 0 0-1-1H2a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zm5 10v-2a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zm0-5V7a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zm0-5V2a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1zM9 2v2H7V2h2zm5 0v2h-2V2h2zM4 7v2H2V7h2zm5 0v2H7V7h2zm5 0h-2v2h2V7zM4 12v2H2v-2h2zm5 0v2H7v-2h2zm5 0v2h-2v-2h2zM12 1a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1h-2zm-1 6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1v2a1 1 0 0 1-1 1h-2a1 1 0 0 1-1-1V7zm1 4a1 1 0 0 0-1 1v2a1 1 0 0 0 1 1h2a1 1 0 0 0 1-1v-2a1 1 0 0 0-1-1h-2z"/>
            </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Coberturas.</h5>
            <p class="card-text">Ver Coberturas.</p>  
        </div>
        </div>
    </div>
    </div>

    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="Empleados.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-briefcase" viewBox="0 0 16 16">
                    <path d="M6.5 1A1.5 1.5 0 0 0 5 2.5V3H1.5A1.5 1.5 0 0 0 0 4.5v8A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-8A1.5 1.5 0 0 0 14.5 3H11v-.5A1.5 1.5 0 0 0 9.5 1h-3zm0 1h3a.5.5 0 0 1 .5.5V3H6v-.5a.5.5 0 0 1 .5-.5zm1.886 6.914L15 7.151V12.5a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5V7.15l6.614 1.764a1.5 1.5 0 0 0 .772 0zM1.5 4h13a.5.5 0 0 1 .5.5v1.616L8.129 7.948a.5.5 0 0 1-.258 0L1 6.116V4.5a.5.5 0 0 1 .5-.5z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Empleados.</h5>
            <p class="card-text">Ver Empleados.</p>  
        </div>
        </div>
    </div>
    </div>

        </div>
    </div>
<% } else if (ejecuta.UsuarioRecepcionista(usuarioSesion)) {%>
    <div class="align-content-center">   
        <div class ="row">
    
                <div class="col-md-3"> 
                    <div class="card-body" style="width: 13rem";>
                        <div class="text-xl-center">
                            <a href="Turnos.aspx">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-clipboard" viewBox="0 0 16 16">
                                    <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1h1a1 1 0 0 1 1 1V14a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V3.5a1 1 0 0 1 1-1h1v-1z"/>
                                    <path d="M9.5 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5h3zm-3-1A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3z"/>
                                </svg>
                            </a>
                        </div>
                        <div class="text-xl-center">
                            <div class="card-group">
                                <h5 class="card-title">Turnos</h5>
                                <p class="card-text">Asignación de turno.</p>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-md-3"> 
                    <div class="card-body" style="width: 13rem";>
                        <div class="text-xl-center">
                            <a href="Pacientes.aspx">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-people" viewBox="0 0 16 16">
                                    <path d="M15 14s1 0 1-1-1-4-5-4-5 3-5 4 1 1 1 1h8zm-7.978-1A.261.261 0 0 1 7 12.996c.001-.264.167-1.03.76-1.72C8.312 10.629 9.282 10 11 10c1.717 0 2.687.63 3.24 1.276.593.69.758 1.457.76 1.72l-.008.002a.274.274 0 0 1-.014.002H7.022zM11 7a2 2 0 1 0 0-4 2 2 0 0 0 0 4zm3-2a3 3 0 1 1-6 0 3 3 0 0 1 6 0zM6.936 9.28a5.88 5.88 0 0 0-1.23-.247A7.35 7.35 0 0 0 5 9c-4 0-5 3-5 4 0 .667.333 1 1 1h4.216A2.238 2.238 0 0 1 5 13c0-1.01.377-2.042 1.09-2.904.243-.294.526-.569.846-.816zM4.92 10A5.493 5.493 0 0 0 4 13H1c0-.26.164-1.03.76-1.724.545-.636 1.492-1.256 3.16-1.275zM1.5 5.5a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm3-2a2 2 0 1 0 0 4 2 2 0 0 0 0-4z"/>
                                </svg>
                            </a>
                        </div>
                        <div class="text-xl-center">
                             <div class="card-group">
                                <h5 class="card-title">Pacientes.</h5>  
                                <p class="card-text"> Ver pacientes.</p>
                            </div>
                        </div>
                    </div>
                </div>

                   
                   <div class="col-md-3"> 
           <div class="card-body" style="width: 13rem";>
               <div class="text-xl-center">
                   <a href="MedicoS.aspx">
                       <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-person-workspace" viewBox="0 0 16 16">
                           <path d="M4 16s-1 0-1-1 1-4 5-4 5 3 5 4-1 1-1 1H4Zm4-5.95a2.5 2.5 0 1 0 0-5 2.5 2.5 0 0 0 0 5Z"/>
                           <path d="M2 1a2 2 0 0 0-2 2v9.5A1.5 1.5 0 0 0 1.5 14h.653a5.373 5.373 0 0 1 1.066-2H1V3a1 1 0 0 1 1-1h12a1 1 0 0 1 1 1v9h-2.219c.554.654.89 1.373 1.066 2h.653a1.5 1.5 0 0 0 1.5-1.5V3a2 2 0 0 0-2-2H2Z"/>
                       </svg>
                   </a>
               </div>
               <div class="text-xl-center">
               <div class="card-group">
                   <h5 class="card-title">Medicos.</h5>
                   <p class="card-text">Ver Medicos.</p>  
               </div>
               </div>
           </div>
           </div>

        </div>


        
    </div>   
    <%} else if (ejecuta.UsuarioMedico(usuarioSesion)) {%>
    <div class="align-content-center">   
        <div class ="row">
    
                <div class="col-md-3"> 
                    <div class="card-body" style="width: 13rem";>
                        <div class="text-xl-center">
                            <a href="Turnos.aspx">
                                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-clipboard" viewBox="0 0 16 16">
                                    <path d="M4 1.5H3a2 2 0 0 0-2 2V14a2 2 0 0 0 2 2h10a2 2 0 0 0 2-2V3.5a2 2 0 0 0-2-2h-1v1h1a1 1 0 0 1 1 1V14a1 1 0 0 1-1 1H3a1 1 0 0 1-1-1V3.5a1 1 0 0 1 1-1h1v-1z"/>
                                    <path d="M9.5 1a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-3a.5.5 0 0 1-.5-.5v-1a.5.5 0 0 1 .5-.5h3zm-3-1A1.5 1.5 0 0 0 5 1.5v1A1.5 1.5 0 0 0 6.5 4h3A1.5 1.5 0 0 0 11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3z"/>
                                </svg>
                            </a>
                        </div>
                        <div class="text-xl-center">
                            <div class="card-group">
                                <h5 class="card-title">Turnos</h5>
                                <p class="card-text">Asignación de turono.</p>
                            </div>
                        </div>
                    </div>
                </div>


    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="HistoriaClinica.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-card-heading" viewBox="0 0 16 16">
                    <path d="M14.5 3a.5.5 0 0 1 .5.5v9a.5.5 0 0 1-.5.5h-13a.5.5 0 0 1-.5-.5v-9a.5.5 0 0 1 .5-.5h13zm-13-1A1.5 1.5 0 0 0 0 3.5v9A1.5 1.5 0 0 0 1.5 14h13a1.5 1.5 0 0 0 1.5-1.5v-9A1.5 1.5 0 0 0 14.5 2h-13z"/>
                    <path d="M3 8.5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5zm0 2a.5.5 0 0 1 .5-.5h6a.5.5 0 0 1 0 1h-6a.5.5 0 0 1-.5-.5zm0-5a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5v-1z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Historia clinica.</h5>
            <p class="card-text">Ver historia clinica.</p>  
        </div>
        </div>
    </div>
    </div>

    <div class="col-md-3"> 
    <div class="card-body" style="width: 13rem";>
        <div class="text-xl-center">
            <a href="SpecialtysViews.aspx">
                <svg xmlns="http://www.w3.org/2000/svg" width="50px" height="50px" fill="currentColor" class="bi bi-ui-radios" viewBox="0 0 16 16">
                    <path d="M7 2.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5v-1zM0 12a3 3 0 1 1 6 0 3 3 0 0 1-6 0zm7-1.5a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 .5.5v1a.5.5 0 0 1-.5.5h-7a.5.5 0 0 1-.5-.5v-1zm0-5a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zm0 8a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5zM3 1a3 3 0 1 0 0 6 3 3 0 0 0 0-6zm0 4.5a1.5 1.5 0 1 1 0-3 1.5 1.5 0 0 1 0 3z"/>
                </svg>
            </a>
        </div>
        <div class="text-xl-center">
        <div class="card-group">
            <h5 class="card-title">Especialidades.</h5>
            <p class="card-text">Ver Especialidades.</p>  
        </div>
        </div>
    </div>
    </div>
        </div>




    </div>


    <% } %>
    <%else {
            Response.Redirect("ErrorIngreso.aspx", false);

        } %>
</asp:Content>
