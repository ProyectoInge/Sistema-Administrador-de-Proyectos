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
                                        <div class="col-md-12 col-sm-12 col-xs-12 col-lg-10 col-lg-offset-1">
                                            <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                                                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label><a href="~/Codigo_Fuente/Fronteras/InterfazCerrarSesionRemota.aspx" runat="server" id="link_cerrar_sesion" class="alert-link"> ¿Desea cerrar la sesión remota?</a>
                                            </div>
                                        </div>
                                    </div>
                                </section>
                                <div id="row2" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12 col-lg-8 col-lg-offset-2">
                                        <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                                        <asp:Label runat="server" ID="label_usuario_vacio" CssClass="text-danger"><small>Tiene que ingresar un usuario.</small></asp:Label>
                                    </div>
                                </div>
                                <div id="row3" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12  col-lg-8 col-lg-offset-2">
                                        <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                                        <asp:Label runat="server" ID="label_contrasena_vacia" CssClass="text-danger"><small>Tiene que ingresar una contraseña.</small></asp:Label>
                                    </div>
                                </div>
                                <div id="row4" class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-8 col-sm-offset-2 col-xs-12  col-lg-8 col-lg-offset-2">
                                        <div class="checkbox">
                                            <asp:CheckBox runat="server" ID="checkbox_recordarme" Text="Recordar mis datos" Checked="true" />
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
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%= label_usuario_vacio.ClientID%>").hide();
            $("#<%= label_contrasena_vacia.ClientID%>").hide();

            //Validacion del usuario
            $("#<%= input_usuario.ClientID%>").blur(function () {
                var nombre_ingresado = $("#<%= input_usuario.ClientID %>").val();
                if (nombre_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_usuario_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_usuario_vacio.ClientID %>").fadeOut();
                }
            });

            //Validacion del nombre
            $("#<%= input_contrasena.ClientID%>").blur(function () {
                var nombre_ingresado = $("#<%= input_contrasena.ClientID %>").val();
                if (nombre_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_contrasena_vacia.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_contrasena_vacia.ClientID %>").fadeOut();
                }
            });

            $("#<%= btn_login.ClientID %>").click(function () {
                var usuario_ingresado = $("#<%= input_usuario.ClientID %>").val();
                var contrasena_ingresada = $("#<%= input_contrasena.ClientID %>").val();
                if (usuario_ingresado != "") {
                    $("#<%= label_usuario_vacio.ClientID %>").fadeOut();
                    if (contrasena_ingresada != "") {
                        $("#<%= label_contrasena_vacia.ClientID %>").fadeOut();
                    } else {
                        $("#<%= label_contrasena_vacia.ClientID %>").fadeIn();
                        $("#<%= input_contrasena.ClientID %>").focus();
                        return false; // Esto previene que realice el PostBack
                    }
                } else {
                    $("#<%= label_usuario_vacio.ClientID %>").fadeIn();
                    $("#<%= input_usuario.ClientID %>").focus();
                    return false; // Esto previene que realice el PostBack
                }
            });


        });
    </script>
</asp:Content>
