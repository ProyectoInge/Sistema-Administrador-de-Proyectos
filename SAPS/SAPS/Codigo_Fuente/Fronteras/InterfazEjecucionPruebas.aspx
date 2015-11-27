<%@ Page Title="Ejecución de Pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazEjecucionPruebas.aspx.cs" Inherits="SAPS.Fronteras.InterfazEjecucionPruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_ep").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h1>SAPS <small>Ejecución de Pruebas</small></h1>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-3 col-md-offset-9">
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
            <div id="panel_1" class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información del diseño</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel1" class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_disenos_disponibles"> Diseño <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-3 col-xs-3">
                                    <asp:DropDownList ID="drop_disenos_disponibles" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_disenos_disponibles_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_diseno"><small>Debe seleccionar un diseño de prueba.</small></asp:Label>
                                </div>
                                <div class="col-md-1 col-md-offset-1 col-xs-2">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="input_ambiente_diseno">Ambiente</asp:Label>
                                </div>
                                <div class="col-md-5 col-xs-3">
                                    <asp:TextBox runat="server" CssClass="form-control" ID="input_ambiente_diseno" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row2_panel1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_procedimiento_diseno" CssClass="control-label" AssociatedControlID="input_procedimiento_diseno">Procedimiento</asp:Label>
                                    <asp:TextBox ID="input_procedimiento_diseno" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                            <div id="row3_panel1" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_criterios_aceptacion_diseno" CssClass="control-label" AssociatedControlID="input_criterios_aceptacion_diseno">Criterios de aceptación</asp:Label>
                                    <asp:TextBox ID="input_criterios_aceptacion_diseno" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine" Style="resize: none" Enabled="false"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_2" class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Lista de resultados</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel2" class="form-group">
                                <div class="col-md-12">
                                    <asp:Table runat="server" ID="tabla_resultados" CssClass="table table-bordered">
                                        <asp:TableHeaderRow runat="server" ID="header_tabla_resultados">
                                            <asp:TableHeaderCell runat="server" ID="celda_check_holder_h" Text="  "></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_id_caso_resultado" Text="ID caso de prueba"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_num_resultado" Text="#"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_estado_resultado" Text="Estado"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_no_conformidad_resultado" Text="Tipo de no conformidad"></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_descripcion_resultado">Descripción <span class="text-danger">*</span></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_justificacion_resultado">Justificación <span class="text-danger">*</span></asp:TableHeaderCell>
                                            <asp:TableHeaderCell runat="server" ID="celda_resultados_resultado" Text="Resultados"></asp:TableHeaderCell>
                                        </asp:TableHeaderRow>
                                        <asp:TableRow runat="server" ID="fila_inputs">
                                            <asp:TableCell runat="server" ID="celda_check_holder"/>
                                            <asp:TableCell runat="server" ID="celda_drop_casos">
                                                <asp:DropDownList runat="server" ID="drop_casos" CssClass="form-control">
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_drop_num_resultado"></asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_drop_estado">
                                                <asp:DropDownList runat="server" ID="drop_estado" CssClass="form-control">
                                                    <asp:ListItem runat="server" Text="Satisfactoria" Value="Satisfactoria"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Fallida" Value="Fallida"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Pendiente" Value="Pendiente"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Cancelada" Value="Cancelada"></asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_drop_tipo_no_conformidad">
                                                <asp:DropDownList runat="server" ID="drop_tipo_no_conformidad" CssClass="form-control">
                                                    <asp:ListItem runat="server" Text="No aplica" Value="No aplica"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Funcionalidad" Value="Funcionalidad"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Validación" Value="Validación"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Opciones que no funcionan" Value="Opciones que no funcionan"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Errores de usabilidad" Value="Errores de usabilidad"></asp:ListItem>
                                                    <asp:ListItem runat="server" Text="Excepciones" Value="Excepciones"></asp:ListItem>
                                                </asp:DropDownList>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_descripcion">
                                                <asp:TextBox runat="server" ID="input_descripcion" CssClass="form-control" TextMode="MultiLine" Rows="2" Style="resize: none"
                                                    placeholder="Describa la no conformidad"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_justificacion">
                                                <asp:TextBox runat="server" ID="input_justificacion" CssClass="form-control" TextMode="MultiLine" Rows="2" Style="resize: none"
                                                    placeholder="Escriba la justificación de lo ocurrido"></asp:TextBox>
                                            </asp:TableCell>
                                            <asp:TableCell runat="server" ID="celda_btn_agregar_imagen">
                                                <asp:Button runat="server" ID="btn_agregar_img" CssClass="btn btn-link btn-block" data-target="#modal_imagen" data-toggle="modal" Text="Subir una imagen" />
                                                <asp:Label runat="server" ID="label_img_agregada" CssClass="text-success"><small> &nbsp;&nbsp;&nbsp;Imagen cargada</small></asp:Label>
                                            </asp:TableCell>
                                        </asp:TableRow>
                                    </asp:Table>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_input_resultado"><small>Faltan campos por llenar</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_panel2" class="form-group">
                                <div class="col-md-2 col-md-offset-10">
                                    <asp:Label runat="server" CssClass="text-danger"><small>* Campos obligatorios</small></asp:Label>
                                    <asp:Button runat="server" CssClass="btn btn-link" ID="btn_agregar_resultado" Text="Agregar" OnClick="btn_agregar_resultado_Click" />
                                    <asp:Button runat="server" CssClass="btn btn-link" ID="btn_eliminar_resultado" Text="Eliminar" OnClick="btn_eliminar_resultado_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div id="panel_3" class="col-md-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Información de la ejecución</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_panel3" class="form-group">
                                <div class="col-md-2">
                                    <asp:Label runat="server" ID="label_responsable" AssociatedControlID="drop_rh_disponibles" CssClass="control-label">Responsable <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="drop_rh_disponibles" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_rh"><small>Debe seleccionar un responsable para la ejecución.</small></asp:Label>
                                </div>
                                <div class="col-md-3 col-md-offset-1">
                                    <asp:Label runat="server" ID="label_fecha" AssociatedControlID="input_fecha" CssClass="control-label">Fecha de la última ejecución <span class="text-danger"">*</span></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox runat="server" ID="input_fecha" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_fecha"><small>Debe seleccionar una fecha.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row2_panel3" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" ID="label_incidentes" CssClass="control-label" AssociatedControlID="input_incidentes">Incidentes durante la ejecución <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox ID="input_incidentes" runat="server" CssClass="form-control" Rows="5" TextMode="MultiLine" Style="resize: none" placeholder="Ingrese N/A si no se presentó ningún incidente"></asp:TextBox>
                                    <asp:Label runat="server" CssClass="text-danger" ID="label_error_incidentes"><small>Este campo no puede quedar vacío.</small></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <div class="row">
        <div class="col-md-2 col-md-offset-10">
            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
        </div>
    </div>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-2 col-md-offset-10">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_Aceptar_Click" />
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_Cancelar_Click" />
            </div>
        </div>
    </section>
    <section id="linea_separadora">
        <div class="row">
            <div class="col-md-12">
                <hr />
            </div>
        </div>
    </section>
    <section id="area_consultas">
        <div class="row">
            <div class="col-md-12">
                <h4>Ejecuciones disponibles</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-12" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_ejecuciones" CssClass="table table-hover form-group">
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
                                            <asp:Label runat="server" ID="cuerpo_mensaje_exito_modal" Text="Se eliminó correctamente la ejecución."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="cuerpo_alerta_error_modal" Text="Se presentó un error, intente eliminar nuevamente la ejecución."></asp:Label>
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
    <!-- Modal agregar imagen -->
    <section id="modal_agregar_imagen">
        <div class="modal fade bs-example-sm" id="modal_imagen" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModalImagen" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btn_agregar_imagen" />
                    </Triggers>
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <asp:Label ID="titulo_modal_archivo" runat="server" Text="Agregue una imagen con los resultados obtenidos"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-1">
                                            <div class="alert alert-danger alert-dismissible" id="alerta_error_archivo" role="alert" aria-hidden="true" runat="server">
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="label_mensaje_error_archivo" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-1">
                                            <p>
                                                Seleccione el archivo que desea adjuntar donde se ven los resultados de la prueba realizada. El archivo tiene que estar en formato .jpg, .jpeg o .png solamente 
                                            y no puede pesar más de 1,5 MB.
                                            </p>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-1">
                                            <hr />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-4 col-md-offset-1">
                                            <asp:FileUpload ID="subidor_archivo" runat="server" />
                                        </div>
                                        <div class="col-md-5 col-md-offset-1">
                                            <asp:Button runat="server" CssClass="btn btn-primary btn-block" Text="Guardar imagen" ID="btn_agregar_imagen" OnClick="btn_agregar_imagen_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-link" style="color: darkgray" data-dismiss="modal" aria-label="Close">Volver</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <!--Mostrar imgen -->
    <section id="modal_imagen_mostrar">
        <div class="modal fade bs-example-sm" id="modal_mostrar_imagen" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="update_mostrar_imagen" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                    <asp:Label ID="Label1" runat="server" Text="Imagen"></asp:Label>
                                </h4>
                            </div>
                            <div class="modal-body">
                                <div class="row">
                                    <div class="col-md-6 col-md-offset-3">
                                        <asp:Image ID="visor_imagen" runat="server" CssClass="img-thumbnail" />
                                    </div>
                                </div>
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_ep").addClass("active");// Para activar el elemento en el navbar

            /* Los metodos de aca son para realizar las validacion de datos de lado del cliente. */

            //Escondo los labels de errores
            $("#<%= label_error_diseno.ClientID%>").hide();
            $("#<%= label_error_rh.ClientID%>").hide();
            $("#<%= label_error_fecha.ClientID%>").hide();
            $("#<%= label_error_incidentes.ClientID%>").hide();
            $("#<%= label_error_input_resultado.ClientID%>").hide();

            //Validacion del diseño seleccionado
            $("#<%= drop_disenos_disponibles.ClientID%>").blur(function () {
                var diseno_seleccionado = $(this).val();
                if (diseno_seleccionado == "") {
                    $("#<%= label_error_diseno.ClientID%>").fadeIn();
                } else {
                    $("#<%= label_error_diseno.ClientID%>").fadeOut();
                }
            });

            //Validacion del responsable seleccionado
            $("#<%= drop_rh_disponibles.ClientID%>").blur(function () {
                var rh_seleccionado = $(this).val();
                if (rh_seleccionado == "") {
                    $("#<%= label_error_rh.ClientID%>").fadeIn();
                } else {
                    $("#<%= label_error_rh.ClientID%>").fadeOut();
                }
            });

            //Validacion de la fecha ingresada
            $("#<%= input_fecha.ClientID%>").blur(function () {
                var fecha_seleccionada = $(this).val();
                if (fecha_seleccionada == "") {
                    $("#<%= label_error_fecha.ClientID%>").fadeIn();
                } else {
                    $("#<%= label_error_fecha.ClientID%>").fadeOut();
                }
            });

            //Validacion de los incidentes
            $("#<%= input_incidentes.ClientID%>").blur(function () {
                var incidentes_ingresados = $("#<%= input_incidentes.ClientID%>").val();
                if (incidentes_ingresados == "") {
                    $("#<%= label_error_incidentes.ClientID%>").fadeIn();
                } else {
                    $("#<%= label_error_incidentes.ClientID%>").fadeOut();
                }
            });

            //Valida la entrada de datos en la tabla de los resultados
            $("#<%= btn_agregar_resultado.ClientID %>").click(function () {
                var caso_seleccionado = $("#<%= drop_casos.ClientID %>").val();
                //alert(caso_seleccionado);
                if (caso_seleccionado == null) {
                    $("#<%= celda_drop_casos.ClientID%>").addClass("has-error");
                    $("#<%= drop_casos.ClientID%>").focus();
                    $("#<%= label_error_input_resultado.ClientID%>").fadeIn();
                    return false;
                } else {
                    $("#<%= celda_drop_casos.ClientID%>").removeClass("has-error");
                    $("#<%= label_error_input_resultado.ClientID%>").fadeOut();
                }

                var descripcion_ingresada = $("#<%= input_descripcion.ClientID%>").val();
                var justificacion_ingresada = $("#<%= input_justificacion.ClientID%>").val();
                if (descripcion_ingresada == "") {
                    $("#<%= celda_descripcion.ClientID%>").addClass("has-error");
                    $("#<%= input_descripcion.ClientID%>").focus();
                    $("#<%= label_error_input_resultado.ClientID%>").fadeIn();
                    return false;
                } else {
                    $("#<%= celda_descripcion.ClientID%>").removeClass("has-error");
                    $("#<%= label_error_input_resultado.ClientID%>").fadeOut();
                }
                if (justificacion_ingresada == "") {
                    $("#<%= celda_justificacion.ClientID%>").addClass("has-error");
                    $("#<%= input_justificacion.ClientID%>").focus();
                    $("#<%= label_error_input_resultado.ClientID%>").fadeIn();
                    return false;
                } else {
                    $("#<%= celda_justificacion.ClientID%>").removeClass("has-error");
                    $("#<%= label_error_input_resultado.ClientID%>").fadeOut();
                }
            });

            $("#<%=btn_Aceptar.ClientID%>").click(function () {
                ///@todo
            });
        });
    </script>
</asp:Content>
