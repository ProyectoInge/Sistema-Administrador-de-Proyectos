<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazLogin.aspx.cs" Inherits="SAPS.Fronteras.InterfazLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-celeste"></div>
    <div style="margin-top: -100px">
        <section id="login">
            <div class="row">
                <div id="panel_login" class="col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4 col-xs-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div id="row1" class="form-group">
                                    <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                        <h2>SAPS<small> Ingreso al sistema</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <section id="alertas">
                                    <div class="row">
                                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-12">
                                            <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label><a href="~/Codigo_Fuente/Fronteras/InterfazCerrarSesionRemota.aspx" runat="server" id="link_cerrar_sesion" class="alert-link"> ¿Desea cerrar la sesión remota?</a>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                                <div id="row2" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12">
                                        <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="row3" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12">
                                        <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                    </div>
                                </div>
                                <div id="row4" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12">
                                        <div class="checkbox">
                                            <asp:CheckBox runat="server" ID="checkbox_recordarme" Text="Recordar mis datos" Checked="true"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <asp:Button runat="server" ID="btn_login" CssClass="btn btn-primary btn-block" Text="Iniciar sesión" OnClick="btn_login_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
