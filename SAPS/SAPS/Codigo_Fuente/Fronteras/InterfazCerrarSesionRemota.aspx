<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCerrarSesionRemota.aspx.cs" Inherits="SAPS.Fronteras.InterfazCerrarSesionRemota" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="background: #5682a3; height: 220px; margin-top: -50px; margin-left: -15px; margin-right: -15px"></div>
    <div style="margin-top: -100px">
        <section id="login">
            <div class="row">
                <div id="panel_login" class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div id="row1" class="form-group">
                                    <div class="col-md-12">
                                        <h2>SAPS<small> Cerrar sesión remota</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <section id="alertas">
                                    <div class="form-group">
                                        <div class="col-md-12">
                                            <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                                            </div>
                                            <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                                <p>Se cerró correctamente su sesión, </p><a href="~/Codigo_Fuente/Fronteras/InterfazLogin.aspx" runat="server" class="alert-link">inicie sesión nuevamente.</a>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                                <div id="row2" class="form-group">
                                    <div class="col-md-10 col-md-offset-1">
                                        <p>Para poder cerrar su sesión activa, es necesario que se valide como usuario del sistema. Por favor ingrese sus datos de autenticación.</p>
                                    </div>
                                </div>
                                <div id="row3" class="form-group">
                                    <div class="col-md-10 col-md-offset-1">
                                        <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="row4" class="form-group">
                                    <div class="col-md-10 col-md-offset-1">
                                        <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="row5" class="form-group">
                                    <div class="col-md-2 col-md-offset-8">
                                        <asp:Button runat="server" ID="btn_regresar" CssClass="btn btn-link" Style="color:darkgray" Text="Regresar" OnClick="btn_regresar_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <asp:Button runat="server" ID="btn_login" CssClass="btn btn-warning btn-block" Text="Cerrar sesión remota e ingresar" OnClick="btn_cerrar_sesion_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
