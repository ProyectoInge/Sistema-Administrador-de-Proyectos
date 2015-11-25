<%@ Page Title="Requerimientos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRequerimientos.aspx.cs" Inherits="SAPS.Fronteras.InterfazRequerimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Requerimientos</small></h1>
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
            <div class="col-md-6 col-md-offset-3">
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
    <section id="form">
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información de los requerimientos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:Label runat="server" CssClass="control-label" ID="label_id" AssociatedControlID="input_id_requerimiento">ID del requerimiento <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" CssClass="form-control" placeholder="Formato: RH_I" ID="input_id_requerimiento"></asp:TextBox>
                                    <asp:Label runat="server" ID="label_id_vacio" CssClass="text-danger"><small>Tiene que ingresar un identificador para el requerimiento.</small></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:Label runat="server" CssClass="control-label" ID="label_nombre" AssociatedControlID="input_nombre_requerimiento">Nombre del requerimiento <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="input_nombre_requerimiento"></asp:TextBox>
                                    <asp:Label runat="server" ID="label_nombre_vacio" CssClass="text-danger"><small>Tiene que ingresar un nombre de requerimiento.</small></asp:Label>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-4 col-md-offset-1">
                                    <asp:Label runat="server" CssClass="control-label" ID="label_criterio_aceptacion" AssociatedControlID="input_criterio_aceptacion">Criterios de aceptación <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="input_criterio_aceptacion" Rows="3" Style="resize: none" TextMode="multiline"></asp:TextBox>
                                    <asp:Label runat="server" ID="label_criterio_vacio" CssClass="text-danger"><small>Tiene que ingresar los criterios de aceptación.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="row">
        <div class="col-md-3 col-md-offset-9">
            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
        </div>
    </div>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-3 col-md-offset-1">
                <asp:Button runat="server" CssClass="btn btn-link" ID="btn_Regresar" Text="Ir a diseños" OnClick="btn_Regresar_Click" />
            </div>
            <div class="col-md-3 col-md-offset-5">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_Aceptar_Click" />
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
                <h4>Requerimientos disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-6 col-md-offset-3" style="height: 250px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_requerimientos" CssClass="table table-hover">
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
                                <h4 class="modal-title">
                                    <asp:Label ID="titulo_modal" runat="server" Text="¡Atención!"></asp:Label>
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
                                            <asp:Label runat="server" ID="cuerpo_mensaje_exito" Text="Se eliminó correctamente el requerimiento."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="Label3" Text="Se presentó un error, intente eliminar nuevamente el requerimiento."></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_cancelar_Click" CssClass="btn btn-link" Style="color: darkgray" ID="btn_modal_cancelar" Text="Volver" runat="server" />
                                <asp:Button OnClick="btn_modal_aceptar_Click" CssClass="btn btn-danger" ID="btn_modal_aceptar" Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <script type="text/javascript">
        $(document).ready(function () {

            $("#<%= label_criterio_vacio.ClientID%>").hide();
            $("#<%= label_nombre_vacio.ClientID%>").hide();
            $("#<%= label_id_vacio.ClientID%>").hide();

            // Validacion del identificador
            $("#<%= input_id_requerimiento.ClientID%>").blur(function () {
                var id_ingresado = $("#<%= input_id_requerimiento.ClientID%>").val();
                if (id_ingresado == "") {
                    $("#<%= label_id_vacio.ClientID%>").fadeIn();
                } else {
                    $("#<%= label_id_vacio.ClientID%>").fadeOut();
                }
            });

            // Validacion del nombre
            $("#<%= input_nombre_requerimiento.ClientID %>").blur(function valida_nombre() {
                var nombre_ingresado = $("#<%= input_nombre_requerimiento.ClientID %>").val();
                if (nombre_ingresado == "") {
                    $("#<%= label_nombre_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_nombre_vacio.ClientID %>").fadeOut();
                }
            });

            // Validacion del criterio
            $("#<%= input_criterio_aceptacion.ClientID %>").blur(function valida_requerimiento() {
                var criterio_ingresado = $("#<%= input_criterio_aceptacion.ClientID %>").val();
                if (criterio_ingresado == "") {
                    $("#<%= label_criterio_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_criterio_vacio.ClientID %>").fadeOut();
                }
            });

            // Validacion de todos los campos al hacer click en el boton de "aceptar"
            $("#<%= btn_Aceptar.ClientID %>").click(function () {
                var criterio_ingresado = $("#<%= input_criterio_aceptacion.ClientID %>").val();
                var nombre_ingresado = $("#<%= input_nombre_requerimiento.ClientID %>").val();
                var id_ingresado = $("#<%= input_id_requerimiento.ClientID%>").val();
                if (id_ingresado != "") {
                    $("#<%= label_id_vacio.ClientID%>").fadeOut();
                    if (nombre_ingresado != "") {
                        $("#<%= label_nombre_vacio.ClientID %>").fadeOut();
                        if (criterio_ingresado != "") {
                            $("#<%= label_criterio_vacio.ClientID %>").fadeOut();
                        } else {
                            $("#<%= label_criterio_vacio.ClientID %>").fadeIn();
                            $("#<%= input_criterio_aceptacion.ClientID %>").focus();
                            return false; // Esto previene que realice el PostBack
                        }
                    } else {
                        $("#<%= label_nombre_vacio.ClientID %>").fadeIn();
                        $("#<%= input_nombre_requerimiento.ClientID %>").focus();
                        return false; // Esto previene que realice el PostBack
                    }
                } else {
                    $("#<%= label_id_vacio.ClientID%>").fadeIn();
                    $("#<%= input_id_requerimiento.ClientID%>").focus();
                    return false;
                }
            });
        });
    </script>
</asp:Content>
