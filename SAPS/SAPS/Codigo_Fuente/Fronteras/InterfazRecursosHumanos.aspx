<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRecursosHumanos.aspx.cs" Inherits="SAPS.Fronteras.Recursos_Humanos" EnableEventValidation="false" %>

<asp:Content ID="content_hr" ContentPlaceHolderID="MainContent" runat="server">
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Recursos humanos</small></h1>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default active" ID="btn_crear" Enabled="true" Text="Ingresar" OnClick="btn_crear_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Text="Modificar" OnClick="btn_modificar_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Text="Eliminar" OnClick="btn_eliminar_Click" />
                </div>
            </div>
        </div>
    </section>
    <br />
    <section id="alertas">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
                </div>
                <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_exito"></asp:Label>
                </div>
                <div class="alert alert-warning alert-dismissible" id="alerta_advertencia" role="alert" aria-hidden="true" runat="server">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                    <asp:Label runat="server" ID="cuerpo_alerta_advertencia"></asp:Label>
                </div>
            </div>
        </div>
    </section>
    <br />
    <div id="form">
        <div class="row">
            <div id="panel_izquierda" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Datos personales</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_cedula" CssClass="control-label" AssociatedControlID="input_cedula">Cédula <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_cedula" CssClass="form-control" placeholder="1-1111-1111" />
                                    <asp:Label runat="server" ID="label_cedula_vacia" CssClass="text-danger"><small>Tiene que ingresar una cédula.</small></asp:Label>
                                    <asp:Label runat="server" ID="label_error_input_cedula" CssClass="text-danger"><small>La cédula ingresada no es válida.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Nombre <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_name" CssClass="form-control" />
                                    <asp:Label runat="server" ID="label_nombre_vacio" CssClass="text-danger"><small>Tiene que ingresar un nombre.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row3_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_correo" CssClass="control-label">Correo <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_correo" CssClass="form-control" TextMode="Email" placeholder="ejemplo@ejemplo.com" />
                                    <asp:Label runat="server" ID="label_correo_vacio" CssClass="text-danger"><small>Tiene que ingresar un correo.</small></asp:Label>
                                    <asp:Label runat="server" ID="label_error_correo" CssClass="text-danger"><small>El correo ingresado no es válido.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row4_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_telefono" CssClass="control-label">Telefono <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_telefono" CssClass="form-control" TextMode="Phone" />
                                    <asp:Label runat="server" ID="label_telefono_vacio" CssClass="text-danger"><small>Tiene que ingresar un teléfono.</small></asp:Label>
                                    <asp:Label runat="server" ID="label_error_telefono" CssClass="text-danger"><small>El teléfono ingresado no es válido.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Otros datos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_der" class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="radio_buttons">Perfil <span class="text-danger">*</span></asp:Label>
                                </div>
                                <section id="radio_buttons" runat="server">
                                    <div class="col-md-3 col-md-offset-1">
                                        <!-- El atributo "GroupName" es para que los radio buttons sepan que pertenecen a un grupo y que solo puede haber
                                                uno de ellos seleccionado.-->
                                        <asp:RadioButton runat="server" CssClass="form-group radio-inline" ID="radio_btn_miembro" GroupName="lista_radio_buttons" OnCheckedChanged="radio_btn_miembro_CheckedChanged" AutoPostBack="true" Text="Miembro" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:RadioButton runat="server" ID="radio_btn_administrador" CssClass="form-group radio-inline" GroupName="lista_radio_buttons" OnCheckedChanged="radio_btn_administrador_CheckedChanged" AutoPostBack="true" Text="Administrador" />
                                    </div>
                                </section>
                            </div>
                            <div id="row2_der" class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_proyecto_asociado">Proyecto</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="drop_proyecto_asociado" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="row3_der" class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_rol">Rol</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="drop_rol" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Lider" Value="Lider"></asp:ListItem>
                                        <asp:ListItem Text="Usuario" Value="Usuario"></asp:ListItem>
                                        <asp:ListItem Text="Tester" Value="Tester"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr />
                            <div id="row4_der" class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" AssociatedControlID="input_usuario" CssClass="control-label">Usuario  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" />
                                    <asp:Label runat="server" ID="label_usuario_vacio" CssClass="text-danger"><small>Tiene que ingresar un nombre de usuario.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row5_der" class="form-group">
                                <div class="col-md-4">
                                    <asp:Label runat="server" ID="label_contrasena" CssClass="control-label" AssociatedControlID="input_contrasena">Contraseña  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" />
                                    <asp:Button runat="server" ID="btn_reestablece_contrasena" CssClass="btn btn-link btn-xs" Text="¿Desea reestablecer la contraseña?" OnClick="btn_reestablece_contrasena_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3 col-md-offset-9">
            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
        </div>
    </div>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-3 col-md-offset-9">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_Aceptar_Click"/>
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_Cancelar_Click" />
            </div>
        </div>
    </section>
    <section id="linea_separadora">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <hr />
            </div>
        </div>
    </section>
    <section id="area_consultas">
        <div class="row">
            <div class="col-md-11 col-md-offset-1">
                <h4>Recursos humanos disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_recursos_humanos" CssClass="table table-hover form-group">
                    <asp:TableHeaderRow runat="server" ID="tabla_recursos_humanos_header">
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </section>
    <!-- Modals eliminar -->
    <section id="modal_eliminar">
        <div class="modal fade bs-example-sm" id="modal_alerta" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">
                                    <asp:Label ID="titulo_modal" runat="server" Text=""></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="cuerpo_modal" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-10 col-md-offset-1">
                                        <div class="alert alert-success" id="mensaje_exito_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="cuerpo_mensaje_exito" Text="Se eliminó correctamente el recurso humano."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="Label3" Text="Se presentó un error, intente eliminar nuevamente el recurso humano."></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_cancelar_Click" CssClass="btn btn-defalt" ID="btn_modal_cancelar" Text="Volver" runat="server" />
                                <asp:Button OnClick="btn_modal_aceptar_Click" CssClass="btn btn-danger" ID="btn_modal_aceptar" Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <!-- Modal reestablecer contraseña -->
    <section id="modal_cambio_contrasena">
        <div class="modal fade bs-example-sm" id="modal_reestablece_contrasena" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="update_modal_contrasena" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="form-horizontal">
                                                    <div id="row1_modal" class="form-group">
                                                        <div class="col-md-12">
                                                            <h2>SAPS<small> Reestablecer contraseña</small></h2>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <section id="alertas_modal_reestablecer">
                                                        <div class="form-group">
                                                            <div class="col-md-12">
                                                                <div class="alert alert-danger alert-dismissible" id="alerta_error_reestablecer" role="alert" aria-hidden="true" runat="server">
                                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                                    <asp:Label runat="server" ID="label_modal_error_reestablecer"></asp:Label>
                                                                </div>
                                                                <div class="alert alert-success alert-dismissible" id="alerta_exito_reestablecer" role="alert" aria-hidden="true" runat="server">
                                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                                                    <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                                                    <asp:Label runat="server" ID="label_modal_exito">Se reestableció correctamente la contraseña.</asp:Label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </section>
                                                    <div id="row2_modal" class="form-group">
                                                        <div class="col-md-4">
                                                            <asp:Label runat="server" ID="label_modal_reestablecer_usuario" AssociatedControlID="modal_reestablecer_input_usuario">Nombre de usuario</asp:Label>
                                                        </div>
                                                        <div class="col-md-8">
                                                            <asp:TextBox runat="server" ID="modal_reestablecer_input_usuario" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div id="row3_modal" class="form-group">
                                                        <div class="col-md-8 col-md-offset-4">
                                                            <asp:TextBox runat="server" ID="modal_reestablecer_input_contrasena_1" CssClass="form-control" TextMode="Password" placeholder="Ingrese la nueva contraseña"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div id="row4_modal" class="form-group">
                                                        <div class="col-md-8 col-md-offset-4">
                                                            <asp:TextBox runat="server" ID="modal_reestablecer_input_contrasena_2" CssClass="form-control" TextMode="Password" placeholder="Digite nuevamente la contraseña"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_reestablecer_cancelar_Click" CssClass="btn btn-defalt" ID="btn_modal_reestablecer_cancelar" Text="Volver" runat="server" />
                                <asp:Button OnClick="btn_modal_reestablecer_aceptar_Click" CssClass="btn btn-warning" ID="btn_modal_reestablecer_aceptar" Text="Confirmar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_rh").addClass("active");// Para activar el elemento en el navbar

            /* Los metodos de aca son para realizar las validacion de datos de lado del cliente. */

            //Escondo los labels de errores
            // TO DO --> hay que poner esto en el header para que cargue bien.
            $("#<%= label_cedula_vacia.ClientID%>").hide();
            $("#<%= label_error_input_cedula.ClientID%>").hide();
            $("#<%= label_nombre_vacio.ClientID%>").hide();
            $("#<%= label_correo_vacio.ClientID %>").hide();
            $("#<%= label_error_correo.ClientID %>").hide();
            $("#<%= label_error_telefono.ClientID%>").hide();
            $("#<%= label_telefono_vacio.ClientID%>").hide();
            $("#<%= label_usuario_vacio.ClientID%>").hide();

            // Validacion de la cedula:
            $("#<%= input_cedula.ClientID %>").blur(function () {
                var cedula_ingresada = $("#<%= input_cedula.ClientID %>").val();
                if (cedula_ingresada == "") {   //Verifica que no este vacía
                    $("#<%= label_error_input_cedula.ClientID%>").hide();
                    $("#<%= label_cedula_vacia.ClientID %>").show();
                } else {
                    $("#<%= label_cedula_vacia.ClientID%>").hide();
                    var regex = /([1-7]|9)-\d{4}-\d{4}/;
                    if (regex.test(cedula_ingresada) == false) {    //Verifica que coincida con la REGEX
                        $("#<%= label_error_input_cedula.ClientID%>").show();
                    } else {
                        $("#<%= label_error_input_cedula.ClientID%>").hide();
                    }
                }
            });

            //Validacion del nombre
            $("#<%= input_name.ClientID%>").blur(function () {
                var nombre_ingresado = $("#<%= input_name.ClientID %>").val();
                if (nombre_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_nombre_vacio.ClientID %>").show();
                } else {
                    $("#<%= label_nombre_vacio.ClientID %>").hide();
                }
            });

            //Validacion del correo
            $("#<%= input_correo.ClientID %>").blur(function () {
                var correo_ingresado = $("#<%= input_correo.ClientID %>").val();
                if (correo_ingresado == "") { //Verifica que no este vacio
                    $("#<%= label_error_correo.ClientID %>").hide();
                    $("#<%= label_correo_vacio.ClientID %>").show();
                } else {
                    $("#<%= label_correo_vacio.ClientID %>").hide();
                    // TO DO --> validar el correo con una regex
                }
            });

            //Validacion del telefono
            $("#<%= input_telefono.ClientID %>").blur(function () {
                var telefono_ingresado = $("#<%= input_telefono.ClientID %>").val();
                if (telefono_ingresado == "") { //Verifica que no este vacio
                    $("#<%= label_error_telefono.ClientID%>").hide();
                    $("#<%= label_telefono_vacio.ClientID%>").show();
                } else {
                    $("#<%= label_telefono_vacio.ClientID%>").hide();
                    var regex_telefono = /(\(?\+?\d{3}\))?(2|4|5|6|7|8)\d{3}-?\d{4}/;
                    if (regex_telefono.test(telefono_ingresado) == false) { //Revisa si coincide el numero ingresado con la regex
                        $("#<%= label_error_telefono.ClientID%>").show();
                    } else {
                        $("#<%= label_error_telefono.ClientID%>").hide();
                    }
                }
            });

            //Validacion del username
            $("#<%= input_usuario.ClientID %>").blur(function () {
                var usuario_ingresado = $("#<%= input_usuario%>").val();
                if (usuario_ingresado == "") {
                    $("#<%= label_usuario_vacio.ClientID%>").show();
                } else {
                    $("#<%= label_usuario_vacio.ClientID%>").hide();
                }
            });
        });
    </script>
</asp:Content>
