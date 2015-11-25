<%@ Page Title="Proyectos de Pruebas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="SAPS.Fronteras.InterfazProyectosDePruebas" CodeBehind="InterfazProyectosDePruebas.aspx.cs" %>

<asp:Content ID="content_pdp" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_pdp").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <div class="page-header">
                    <h1>SAPS <small>Proyectos De Pruebas</small></h1>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default active" ID="btn_crear" Enabled="true" Text="Ingresar" OnClick="btn_crear_click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Enabled="false" Text="Modificar" OnClick="btn_modificar_click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Enabled="false" Text="Eliminar" OnClick="btn_eliminar_click" />
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
    <section id="form">
        <div class="row">
            <div id="panel_izquierda" class="col-md-5 col-md-offset-1">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Datos del proyecto</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" AssociatedControlID="input_process" CssClass="control-label">Nombre del Proyecto <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="input_process" CssClass="form-control" />
                                </div>
                            </div>
                            <div id="row2_izq" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" AssociatedControlID="input_system" CssClass="control-label">Nombre del Sistema  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="input_system" CssClass="form-control" />
                                </div>
                            </div>
                            <div id="row3_izq" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" AssociatedControlID="input_asignment_date" CssClass="control-label">Fecha de asignación  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="input_asignment_date" CssClass="form-control" TextMode="Date" />
                                    <asp:Label runat="server" ID="label_fecha_asigna_ingresar" CssClass="text-danger"><small>Debe ingresar una fecha de asignación.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row4_izq" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" AssociatedControlID="input_start_date" CssClass="control-label">Fecha de inicio  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="input_start_date" CssClass="form-control" TextMode="Date" />
                                    <asp:Label runat="server" ID="label_fecha_asigna_vacia" CssClass="text-danger"><small>Debe ingresar una fecha de asignación.</small></asp:Label>
                                    <asp:Label runat="server" ID="label_fecha_inicio_pronta" CssClass="text-danger"><small>Esta fecha debe ser posterior a la fecha de asignación.</small></asp:Label>
                                </div>
                            </div>
                            <div id="row5_izq" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" AssociatedControlID="input_finish_date" CssClass="control-label">Fecha de finalización</asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox runat="server" ID="input_finish_date" CssClass="form-control" TextMode="Date" />

                                    <asp:Label runat="server" ID="label_fecha_inicio_vacia" CssClass="text-danger"><small>Debe ingresar una fecha de inicio.</small></asp:Label>
                                    <asp:Label runat="server" ID="label_fecha_final_pronta" CssClass="text-danger"><small>Esta fecha debe ser posterior a la fecha de inicio.</small></asp:Label>
                                </div>
                            </div>
                            <div id="ro6_izq" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" AssociatedControlID="input_objective" CssClass="control-label">Objetivo  <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="input_objective" CssClass="form-control" Rows="3" Style="resize: none" TextMode="multiline" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecho" class="col-md-5">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Otra información</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_der" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_estado_proyecto">Estado del proyecto  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="drop_estado_proyecto" runat="server" CssClass="form-control">
                                         <asp:ListItem Text="-Seleccione un estado-" Value="-Elija un estado"></asp:ListItem> 
                                        <asp:ListItem Text="Pendiente de asignación" Value="Pendiente de asignación"></asp:ListItem>
                                        <asp:ListItem Text="Asignado" Value="Asignado"></asp:ListItem>
                                        <asp:ListItem Text="En ejecución" Value="En ejecución"></asp:ListItem>
                                        <asp:ListItem Text="Finalizado" Value="Finalizado"></asp:ListItem>
                                        <asp:ListItem Text="Cerrado" Value="Cerrado"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <hr />
                            <div id="row2_der" class="form-group">
                                <div class="col-md-5">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Oficina usuaria  <span class="text-danger">*</span></asp:Label>
                                </div>
                                <div class="col-md-7">
                                    <asp:DropDownList ID="drop_oficina_asociada" runat="server" CssClass="form-control" OnSelectedIndexChanged="drop_oficina_asociada_SelectedIndexChanged" AutoPostBack="true">
                                        <%-- <asp:ListItem Text="-Elija una oficina-" Value="-Elija una oficina-"></asp:ListItem> --%>
                                    </asp:DropDownList>
                                    <asp:Button runat="server" CssClass="btn btn-link btn-sm" ID="btn_agregar_oficina" Text="¿Desea agregar una nueva oficina?" OnClick="btn_agregar_oficina_Click" />
                                </div>
                            </div>
                            <div id="row3_der" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Representante de la oficina  <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="input_manager_office" CssClass="form-control" />
                                </div>
                            </div>
                            <div id="row4_der" class="form-group">
                                <div class="col-md-12">
                                    <asp:Label runat="server" AssociatedControlID="input_phone1" CssClass="control-label">Teléfonos de la oficina  <span class="text-danger">*</span></asp:Label>
                                    <asp:TextBox runat="server" ID="input_phone1" CssClass="form-control" />
                                    <br />
                                    <asp:TextBox runat="server" ID="input_phone2" CssClass="form-control" />
                                </div>
                            </div>
                        </div>
                        <!-- Form horizontal -->
                    </div>
                    <!-- Panel body -->
                </div>
                <!-- Panel -->
            </div>
            <!-- Panel derecho -->
        </div>
        <!-- Row -->
    </section>
    <!-- ESTA TABLA ES PARA EL SEGUNDO SPRINT
    <section id="label_lista_ddp" class="row">
        <div class="col-md-11 col-md-offset-1">
            <h4>Diseños de Pruebas</h4>
        </div>
        <br />
        <section id="area_consultas_disenos"">
            <div class="row">
                <div class="col-md-8 col-md-offset-2" style="height: 200px; overflow-y: scroll">
                    <asp:Table runat="server" ID="tabla_disenos_de_prueba" CssClass="table table-hover form-group">
                    </asp:Table>
                </div>
            </div>
        </section>
        <br />
        -->
    <div class="row">
        <div class="col-md-2 col-md-offset-9">
            <asp:Label runat="server" CssClass="text-danger"><small>* Campos obligatorios</small></asp:Label>
        </div>
    </div>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="col-md-3 col-md-offset-9">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_aceptar_click" />
            <asp:Button runat="server" CssClass="btn btn-danger" ID="Button2" Text="Cancelar" OnClick="btn_cancelar_click" />
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
            <div class="col-md-10 col-md-offset-1">
                <h4>Proyectos de Pruebas</h4>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10 col-md-offset-1" style="height: 300px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_proyectos_de_pruebas" CssClass="table table-hover form-group">
                    <asp:TableHeaderRow runat="server" ID="tabla_proyectos_de_pruebas_header">
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </section>
    <!-- Area consultas -->
    <section id="modal_agrega_oficina">
        <div class="modal fade bs-example-sm" id="modal_agregar_oficina" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <asp:UpdatePanel ID="upModalOficina" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-body">
                                <div class="form-horizontal">
                                    <div id="row1_modal" class="form-group">
                                        <div class="col-md-12">
                                            <h2>SAPS<small> Agregar oficina</small></h2>
                                        </div>
                                    </div>
                                    <hr />
                                    <div class="form-group">
                                        <div class="col-md-12">
                                            <div class="alert alert-success" id="alerta_exito_oficina" role="alert" aria-hidden="true" runat="server">
                                                <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="cuerpo_mensaje_exito" Text="No hubo problema al ingresar la oficina."></asp:Label>
                                            </div>
                                            <div class="alert alert-danger" id="alerta_error_oficina_cuerpo" role="alert" aria-hidden="true" runat="server">
                                                <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                                <asp:Label runat="server" ID="alerta_error_oficina" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-6">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="modal_input_nombre_oficina">Nombre de la oficina <span class="text-danger">*</span></asp:Label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="modal_input_nombre_oficina"></asp:TextBox>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="modal_input_representante_oficina">Representante <span class="text-danger">*</span></asp:Label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="modal_input_representante_oficina"></asp:TextBox>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="modal_input_telefono1">Teléfono principal <span class="text-danger">*</span></asp:Label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="modal_input_telefono1"></asp:TextBox>
                                            <asp:Label runat="server" CssClass="control-label" AssociatedControlID="modal_input_telefono2">Teléfono secundario</asp:Label>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="modal_input_telefono2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-4 col-md-offset-8">
                                            <asp:Label runat="server" CssClass="text-danger">* Campos obligatorios</asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_cancelar_oficina_Click" CssClass="btn btn-link" ID="btn_modal_cancelar_oficina" Text="Volver" runat="server" Style="color: darkgray" />
                                <asp:Button OnClick="btn_modal_agregar_oficina_Click" CssClass="btn btn-success" ID="btn_modal_agregar_oficina" Text="Agregar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <!-- Modal agregar oficina -->
    <section id="modal_confirmacion">
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
                                            <asp:Label runat="server" ID="Label2" Text="Se eliminó correctamente el proyecto."></asp:Label>
                                        </div>
                                        <div class="alert alert-danger alert-dismissible" id="mensaje_error_modal" role="alert" aria-hidden="true" runat="server">
                                            <span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span>
                                            <asp:Label runat="server" ID="Label3" Text="Se presentó un error, intente eliminar el proyecto nuevamente."></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_confirmar_cancelar_Click" CssClass="btn btn-link" ID="btn_modal_cancelar" Text="Volver" runat="server" />
                                <asp:Button OnClick="btn_modal_confirmar_aceptar_Click" CssClass="btn btn-danger" ID="btn_modal_aceptar" Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
    <!-- Modal confirmacion -->

    <!-- Script para validacion de fechas ingresadas por el usuario -->

    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn_pdp").addClass("active");// Para activar el elemento en el navbar

            /* Los metodos de aca son para realizar las validacion de datos de lado del cliente. */

            //Se esconden los labels de errores
            // TO DO --> hay que poner esto en el header para que cargue bien.
            $("#<%= label_fecha_inicio_pronta.ClientID%>").hide();
            $("#<%= label_fecha_final_pronta.ClientID%>").hide();
            $("#<%= label_fecha_asigna_vacia.ClientID%>").hide();
            $("#<%= label_fecha_asigna_ingresar.ClientID%>").hide();
            $("#<%= label_fecha_inicio_vacia.ClientID%>").hide();


            // Validacion de la fecha de asignacion:

            $("#<%= input_asignment_date.ClientID %>").blur(function () {

                $("#<%= label_fecha_inicio_pronta.ClientID%>").fadeOut();

                var fecha_asignacion_ingresada = new Date($("#<%= input_asignment_date.ClientID %>").val());

                if (isNaN(fecha_asignacion_ingresada.getTime())) {
                    $("#<%= label_fecha_asigna_ingresar.ClientID%>").fadeIn();
                    $("#<%= label_fecha_asigna_vacia.ClientID%>").fadeOut();
                    $("#<%= input_asignment_date.ClientID %>").focus();
                } else {
                    $("#<%= label_fecha_asigna_ingresar.ClientID%>").fadeOut();
                    $("#<%= label_fecha_asigna_vacia.ClientID%>").fadeOut();
                    $("#<%= input_start_date.ClientID %>").focus();
                }

            });

            // Validacion de la fecha de inicio:

            $("#<%= input_start_date.ClientID %>").blur(function () {

                $("#<%= label_fecha_inicio_vacia.ClientID%>").fadeOut();

                // Asignacion de las fechas a un objeto en Javascript tipo Date
                var fecha_inicio_ingresada = new Date($("#<%= input_start_date.ClientID%>").val());
                var fecha_asignacion_ingresada = new Date($("#<%= input_asignment_date.ClientID %>").val());

                if (isNaN(fecha_asignacion_ingresada.getTime())) {                    // No puede ingresar una fecha de inicio sin ingresar una fecha de asignacion.
                    $("#<%= label_fecha_asigna_vacia.ClientID%>").fadeIn();
                    $("#<%= input_asignment_date.ClientID %>").focus();
                } else {
                    $("#<%= label_fecha_asigna_vacia.ClientID%>").fadeOut();

                    if (isNaN(fecha_inicio_ingresada.getTime())) {

                        $("#<%= input_start_date.ClientID %>").fadeIn();

                    } else {

                        if (fecha_inicio_ingresada < fecha_asignacion_ingresada) {        // La fecha de inicio no puede ser menor a la fecha de asignacion                        
                            $("#<%= label_fecha_inicio_pronta.ClientID%>").show();
                            $("#<%= input_start_date.ClientID %>").fadeIn();
                        } else {
                            $("#<%= label_fecha_inicio_pronta.ClientID%>").fadeOut();
                            $("#<%= label_fecha_asigna_vacia.ClientID%>").fadeOut();
                            $("#<%= label_fecha_inicio_vacia.ClientID%>").fadeOut();
                            $("#<%= label_fecha_final_pronta.ClientID%>").fadeOut();
                            $("#<%= input_finish_date.ClientID %>").focus();
                        }
                    }
                }
            });

            // Validacion de la fecha de finalizacion

            $("#<%= input_finish_date.ClientID %>").blur(function () {

                var fecha_inicio = new Date($("#<%= input_start_date.ClientID%>").val());
                var fecha_final = new Date($("#<%= input_finish_date.ClientID%>").val());

                if (isNaN(fecha_inicio.getTime())) {
                    $("#<%= label_fecha_inicio_vacia.ClientID%>").fadeIn();
                    $("#<%= input_start_date.ClientID %>").focus();
                } else {

                    if (isNaN(fecha_final.getTime())) {
                        $("#<%= input_finish_date.ClientID %>").focus();
                    } else {

                        if (fecha_inicio > fecha_final) {
                            $("#<%= label_fecha_final_pronta.ClientID%>").fadeIn();
                            $("#<%= input_finish_date.ClientID %>").focus();
                        } else {
                            $("#<%= label_fecha_final_pronta.ClientID%>").fadeOut();
                        }
                    }
                }

            });
        });
    </script>
</asp:Content>


