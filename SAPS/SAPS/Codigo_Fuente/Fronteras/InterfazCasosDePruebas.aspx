<%@ Page Title="Casos de pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazCasosDePruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazCasosDePruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_cdp").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Caso de Pruebas</small></h1>
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
    <div id="form">
        <div class="row">
            <div id="panel_izquierda" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Resumen</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row0_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_proyecto" CssClass="control-label" AssociatedControlID="drop_proyecto_asociado">Proyecto<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_proyecto_asociado" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_proyecto_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="label_proyecto_asociado_vacio" CssClass="text-danger"><small>Debe seleccionar un proyecto.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_diseno" CssClass="control-label" AssociatedControlID="drop_diseno_asociado">Diseño<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:DropDownList ID="drop_diseno_asociado" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_diseno_asociado_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="label_diseno_asociado_vacio" CssClass="text-danger"><small>Debe seleccionar un diseno.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="label_id_diseno">ID de Caso<span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label runat="server" CssClass="form-control" ID="label_id_diseno"><span><i>ID diseño</i></span></asp:Label>
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="drop_id_requerimientos" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" ID="label_id_requerimiento_asociado_vacio" CssClass="text-danger"><small>Debe seleccionar un requerimiento.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Requerimientos disponibles</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-6 col-lg-6" style="height: 130px; overflow-y: scroll">
                                    <asp:Table runat="server" ID="tabla_requerimientos_asociados" CssClass="table table-hover">
                                    </asp:Table>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6 col-lg-5">
                                        <asp:TextBox ID="output_procedimiento_requerimiento" runat="server" CssClass="form-control" Rows="6" TextMode="MultiLine" Style="resize: none" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_izquierda2" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Datos del caso de prueba</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq_2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lebel_text_proposito" CssClass="control-label" AssociatedControlID="text_proposito">Propósito<span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="text_proposito" CssClass="form-control" Rows="3" Style="resize: none" TextMode="multiline" />
                                    <asp:Label runat="server" ID="label_proposito_vacio" CssClass="text-danger"><small>Debe ingresar un propósito.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_izq_2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="lebel_text_flujo_central" CssClass="control-label" AssociatedControlID="text_flujo_central">Flujo Central<span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="text_flujo_central" CssClass="form-control" Rows="8" Style="resize: none" TextMode="multiline" />
                                    <asp:Label runat="server" ID="label_flujo_central_vacio" CssClass="text-danger"><small>Debe ingresar un flujo central.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha_2" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Entrada de datos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="label_valor_entradas" AssociatedControlID="input_entradas_valor" CssClass="control-label">Valor</asp:Label>
                                    <asp:TextBox runat="server" ID="input_entradas_valor" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label runat="server" ID="label_entradas_estado" AssociatedControlID="drop_entradas_estado" CssClass="control-label">Tipo</asp:Label>
                                    <asp:DropDownList runat="server" ID="drop_entradas_estado" CssClass="form-control">
                                        <asp:ListItem Text="" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Válido" Value="v"></asp:ListItem>
                                        <asp:ListItem Text="Inválido" Value="i"></asp:ListItem>
                                        <asp:ListItem Text="No aplica" Value="na"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-5 col-md-offset-7">
                                    <div class="btn-group" role="group">
                                        <asp:Button runat="server" ID="btn_agregar_entrada" CssClass="btn btn-link" Text="Agregar" OnClick="btn_agregar_entrada_Click" />
                                        <asp:Button runat="server" CssClass="btn btn-link" ID="btn_entradas_eliminar" Text="Eliminar" OnClick="btn_entradas_eliminar_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_entradas_disponibles" CssClass="control-label" AssociatedControlID="drop_entradas_disponibles">Entradas disponibles</asp:Label>
                                    <asp:DropDownList runat="server" ID="drop_entradas_disponibles" CssClass="form-control" OnSelectedIndexChanged="drop_entradas_disponibles_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr />
                            <div class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_entradas_resultado" AssociatedControlID="input_entradas_resultado" CssClass="control-label">Resultado esperado</asp:Label>
                                    <asp:TextBox runat="server" ID="input_entradas_resultado" CssClass="form-control" Rows="2" Style="resize: none" TextMode="multiline"></asp:TextBox>
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
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_aceptar_Click" />
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_cancelar_Click" />
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
                <h4>Casos de pruebas disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_casos_pruebas" CssClass="table table-hover form-group">
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
                                            <asp:Label runat="server" ID="cuerpo_mensaje_exito" Text="Se eliminó correctamente el diseño de preuba."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="label3" Text="Se presentó un error, intente eliminar nuevamente el diseño de prueba."></asp:Label>
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
            $("#btn_cdp").addClass("active");// Para activar el elemento en el navbar
            /* Los metodos de aca son para realizar las validacion de datos de lado del cliente. */

            //Escondo los labels de errores
            // TO DO --> hay que poner esto en el header para que cargue bien.
            $("#<%= label_proposito_vacio.ClientID%>").hide();
            $("#<%= label_flujo_central_vacio.ClientID%>").hide();
            $("#<%= label_flujo_central_vacio.ClientID%>").hide();
            $("#<%= label_proyecto_asociado_vacio.ClientID%>").hide();
            $("#<%= label_diseno_asociado_vacio.ClientID%>").hide();
            $("#<%= label_id_requerimiento_asociado_vacio.ClientID%>").hide();

            // Validacion del proyecto seleccionado":
            $("#<%= drop_proyecto_asociado.ClientID%>").blur(function () {
                var texto_ingresado = new String();
                texto_ingresado = $("#<%= drop_proyecto_asociado.ClientID %>").val();
                if (texto_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_proyecto_asociado_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_proyecto_asociado_vacio.ClientID %>").fadeOut();
                }
            });

            // Validacion del diseno seleccionado":
            $("#<%= drop_diseno_asociado.ClientID%>").blur(function () {
                var texto_ingresado = new String();
                texto_ingresado = $("#<%= drop_diseno_asociado.ClientID %>").val();
                if (texto_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_diseno_asociado_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_diseno_asociado_vacio.ClientID %>").fadeOut();
                }
            });


            // Validacion del requerimiento seleccionado":
            $("#<%= drop_id_requerimientos.ClientID%>").blur(function () {
                var texto_ingresado = new String();
                texto_ingresado = $("#<%= drop_id_requerimientos.ClientID %>").val();
                if (texto_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_id_requerimiento_asociado_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_id_requerimiento_asociado_vacio.ClientID %>").fadeOut();
                }
            });


            // Validacion del proposito:
            $("#<%= text_proposito.ClientID%>").blur(function () {
                var texto_ingresado = $("#<%= text_proposito.ClientID %>").val();
                if (texto_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_proposito_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_proposito_vacio.ClientID %>").fadeOut();
                }
            });

            // Validacion del flujo central:
            $("#<%= text_flujo_central.ClientID%>").blur(function () {
                var texto_ingresado = $("#<%= text_flujo_central.ClientID %>").val();
                if (texto_ingresado == "") { //Verifica que no este vacia
                    $("#<%= label_flujo_central_vacio.ClientID %>").fadeIn();
                } else {
                    $("#<%= label_flujo_central_vacio.ClientID %>").fadeOut();
                }
            });

            //TO DO Mostrar procedimiento cuando se acerca el mouse
            $("#<%= tabla_requerimientos_asociados. ClientID%>").hover(function () {
                $("#<%= output_procedimiento_requerimiento.ClientID %>").text("La idea esq se muestre el procedimiento cuando se pasa sobre un requerimiento");
            });


        });
    </script>
</asp:Content>
