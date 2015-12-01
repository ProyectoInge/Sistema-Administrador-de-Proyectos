<%@ Page Title="Generación de reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReportes.aspx.cs" Inherits="SAPS.Fronteras.InterfazReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript"> <!-- Para activar el elemento en el navbar -->
    $(document).ready(function () {
        $("#btn_rp").addClass("active");
    });
    </script>
    <section id="page_header">
        <div class="row">
            <div class="col-md-12">
                <div class="page-header">
                    <h1>SAPS <small>Generación de reportes</small></h1>
                </div>
            </div>
        </div>
    </section>
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
            <!--Primer caja - Proyecto-->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Proyectos
                               
                                <div class="btn-group">
                                    <button type="button" class="btn btn-default btn-sm" id="btn_estado_proyecto">Incluir</button>
                                    <button type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                        <span class="caret"></span>
                                        <span class="sr-only">Toggle Dropdown</span>
                                    </button>
                                    <ul class="dropdown-menu">
                                        <li id="proyecto_habilitado"><a href="#">Incluir</a></li>
                                        <li id="proyecto_inhabilitado"><a href="#">No incluir</a></li>
                                    </ul>
                                </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <section id="seccion_filtros_proyecto">
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <asp:Label runat="server" CssClass="control-label" ID="label_filtros_proyecto" AssociatedControlID="proyecto_drop_oficina" Text="Filtros" />
                                    </div>
                                    <div class="col-md-3 col-md-offset-7">
                                        <small>
                                            <asp:Button runat="server" CssClass="btn btn-link btn-sm" Style="color: darkgray" ID="proyecto_btn_limpiar_filtros" Text="Limpiar filtros" OnClick="proyecto_btn_limpiar_filtros_Click" /></small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Oficinas" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_oficina" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Estado" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_estado" AutoPostBack="true">
                                            <asp:ListItem Text="-Seleccione-" Value=""></asp:ListItem>
                                            <asp:ListItem Text="Asignado" Value="Asignado"></asp:ListItem>
                                            <asp:ListItem Text="Pendiente de asignación" Value="Pendiente de asignación"></asp:ListItem>
                                            <asp:ListItem Text="En ejecución" Value="En ejecución"></asp:ListItem>
                                            <asp:ListItem Text="Finalizado" Value="Finalizado"></asp:ListItem>
                                            <asp:ListItem Text="Cerrado" Value="Cerrado"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Miembros" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="proyecto_drop_miembro" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Después de" />
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="proyecto_input_fecha_inicio" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Antes de" />
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" ID="proyecto_input_fecha_final" AutoPostBack="true" />
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_proyectos_disponibles">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Proyectos disponibles" AssociatedControlID="tabla_proyectos" />
                                    </div>
                                    <div class="col-md-4 col-md-offset-4">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="proyecto_check_todos" OnCheckedChanged="proyecto_check_todos_CheckedChanged" Text="Seleccionar todos" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div style="height: 200px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_proyectos" CssClass="table table-hover">
                                            </asp:Table>
                                        </div>
                                        <label class="text-info"><small>Los proyectos en rojo ya fueron marcados como "eliminados" en el sistema.</small></label>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_info_incluir_proyecto">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" ID="label_info_proyectos" AssociatedControlID="proyecto_check_miembros" CssClass="control-label" Text="Información a incluir" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_miembros" CssClass="checkbox checkbox-inline" Text="Miembros asociados" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_fechas" CssClass="checkbox checkbox-inline" Text="Fechas" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_disenos" CssClass="checkbox checkbox-inline" Text="Diseños asociados" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_oficina" CssClass="checkbox checkbox-inline" Text="Oficina asociada" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="proyecto_check_objetivos" CssClass="checkbox checkbox-inline" Text="Objetivos" />
                                    </div>
                                </div>
                            </section>
                            <section id="proyecto_boton_continuar">
                                <div class="col-md-2 col-md-offset-10">
                                    <button class="btn btn-default btn-sm btn-block" type="button" id="proyecto_btn_continuar" runat="server" onserverclick="proyecto_btn_continuar_ServerClick"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span></button>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <!--Segunda caja - Diseños -->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Diseños
                           
                            <div class="btn-group">
                                <button type="button" class="btn btn-default btn-sm" id="btn_estado_diseno">Incluir</button>
                                <button type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <span class="caret"></span>
                                    <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li id="diseno_habilitado"><a href="#">Incluir</a></li>
                                    <li id="diseno_inhabilitado"><a href="#">No incluir</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <section id="seccion_filtros_diseno">
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <asp:Label runat="server" CssClass="control-label" ID="label1" AssociatedControlID="proyecto_drop_oficina" Text="Filtros" />
                                    </div>
                                    <div class="col-md-3 col-md-offset-7">
                                        <small>
                                            <asp:Button runat="server" CssClass="btn btn-link btn-sm" Style="color: darkgray" ID="diseno_btn_limpiar_filtros" Text="Limpiar filtros" OnClick="diseno_btn_limpiar_filtros_Click" /></small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Técnica de prueba" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="diseno_drop_tecnicas_prueba" AutoPostBack="true">
                                            <asp:ListItem Text="-Seleccione-" Value="" />
                                            <asp:ListItem Text="Caja negra" Value="Caja negra" />
                                            <asp:ListItem Text="Caja blanca" Value="Caja blanca" />
                                            <asp:ListItem Text="Exploratoria" Value="Exploratoria" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Tipo de prueba" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="diseno_drop_tipo_prueba" AutoPostBack="true">
                                            <asp:ListItem Text="-Seleccione-" Value="" />
                                            <asp:ListItem Text="Funcional" Value="Funcional" />
                                            <asp:ListItem Text="Interfaz de usuario" Value="Interfaz de usuario" />
                                            <asp:ListItem Text="Rendimiento" Value="Rendimiento" />
                                            <asp:ListItem Text="Stress" Value="Stress" />
                                            <asp:ListItem Text="Volumen" Value="Volumen" />
                                            <asp:ListItem Text="Configuración" Value="Configuración" />
                                            <asp:ListItem Text="Instalación" Value="Instalación" />
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Nivel de prueba" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="diseno_drop_nivel_prueba" AutoPostBack="true">
                                            <asp:ListItem Text="-Seleccione-" Value="" />
                                            <asp:ListItem Text="Unitaria" Value="Unitaria" />
                                            <asp:ListItem Text="De integración" Value="De integración" />
                                            <asp:ListItem Text="Del sistema" Value="Del sistema" />
                                            <asp:ListItem Text="De aceptación" Value="De aceptación" />
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Después de" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="diseno_fecha_despues" TextMode="Date" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Antes de" />
                                        <asp:TextBox runat="server" CssClass="form-control" ID="diseno_fecha_antes" TextMode="Date" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Responsable" />
                                        <asp:DropDownList runat="server" CssClass="form-control" ID="diseno_drop_responsables" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_disenos_disponibles">
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:Label runat="server" CssClass="control-label" Text="Diseños disponibles" AssociatedControlID="diseno_check_todos" />
                                    </div>
                                    <div class="col-md-4 col-md-offset-4">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="diseno_check_todos" Text="Seleccionar todos" AutoPostBack="true" OnCheckedChanged="diseno_check_todos_CheckedChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div style="height: 195px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_disenos" CssClass="table table-hover">
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <section id="seccion_info_incluir_diseno">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" CssClass="control-label" Text="Información a incluir" AssociatedControlID="diseno_check_flujo_central"></asp:Label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="diseno_check_flujo_central" Text="Flujo central" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="diseno_check_resultado_esperado" Text="Resultado esperado" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="diseno_check_entrada_datos" Text="Entrada de datos" />
                                    </div>
                                </div>
                            </section>
                            <section id="diseno_botones_volver_continuar">
                                <div class="col-md-2">
                                    <button class="btn btn-default btn-sm btn-block" type="button" id="diseno_btn_volver" runat="server" onserverclick="diseno_btn_volver_ServerClick"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span></button>
                                </div>
                                <div class="col-md-2 col-md-offset-8">
                                    <button class="btn btn-default btn-sm btn-block" type="button" id="diseno_btn_continuar" runat="server" onserverclick="diseno_btn_continuar_ServerClick"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span></button>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <!-- Tercera caja - Casos de pruebas -->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Casos de pruebas
                            <div class="btn-group">
                                <button type="button" class="btn btn-default btn-sm" id="btn_estado_casos">Incluir</button>
                                <button type="button" class="btn btn-default dropdown-toggle btn-sm" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <span class="caret"></span>
                                    <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li id="casos_habilitado"><a href="#">Incluir</a></li>
                                    <li id="casos_inhabilitado"><a href="#">No incluir</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <!-- Tabla de casos de prueba disponibles-->
                            <section id="seccion_casos_de_prueba_disponibles">
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Casos de prueba disponibles" AssociatedControlID="tabla_casos_de_prueba_disponibles" />
                                    </div>
                                    <div class="col-md-4 col-md-offset-2">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="Checkbox_casos_de_prueba_todos" OnCheckedChanged="Checkbox_casos_de_prueba_todos_CheckedChanged" Text="Seleccionar todos" AutoPostBack="true" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div style="height: 390px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_casos_de_prueba_disponibles" CssClass="table table-hover">
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <!-- Checkbox de información a incluir -->
                            <section id="seccion_casos_de_prueba_info_incluir">
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Información a incluir" AssociatedControlID="tabla_proyectos" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="casos_check_proposito" CssClass="checkbox checkbox-inline" Text="Propósito" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="casos_check_flujo" CssClass="checkbox checkbox-inline" Text="Flujo central" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="casos_check_entrada_datos" CssClass="checkbox checkbox-inline" Text="Entrada de datos" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="casos_check_resultado" CssClass="checkbox checkbox-inline" Text="Resultado esperado" />
                                    </div>
                                </div>
                            </section>
                            <section id="ejecuciones_botones_volver_continuar">
                                <div class="col-md-2">
                                    <button class="btn btn-default btn-sm btn-block" runat="server" type="button" id="casos_btn_volver" onserverclick="casos_btn_volver_ServerClick"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span></button>
                                </div>
                                <div class="col-md-2 col-md-offset-8">
                                    <button class="btn btn-default btn-sm btn-block" runat="server" type="button" id="casos_btn_continuar" onserverclick="casos_btn_continuar_ServerClick"><span class="glyphicon glyphicon-chevron-right" aria-hidden="true"></span></button>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Cuarta caja - Ejecución -->
            <div class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            Ejecuciones de pruebas
                            <div class="btn-group">
                                <button type="button" class="btn btn-default btn-sm" id="btn_estado_ejecucion">Incluir</button>
                                <button type="button" class="btn btn-default btn-sm dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                    <span class="caret"></span>
                                    <span class="sr-only">Toggle Dropdown</span>
                                </button>
                                <ul class="dropdown-menu">
                                    <li id="ejecucion_habilitado"><a href="#">Incluir</a></li>
                                    <li id="ejecucion_inhabilitado"><a href="#">No incluir</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <!-- Filtros de ejecucion-->
                            <section id="seccion_ejecuciones_filtros">
                                <div class="form-group">
                                    <div class="col-md-2">
                                        <asp:Label runat="server" CssClass="control-label" Text="Filtros" AssociatedControlID="ejecucion_btn_limpiar_filtros" />
                                    </div>
                                    <div class="col-md-3 col-md-offset-7">
                                        <small>
                                            <asp:Button runat="server" CssClass="btn btn-link btn-sm" Style="color: darkgray" ID="ejecucion_btn_limpiar_filtros" Text="Limpiar filtros" OnClick="ejecucion_btn_limpiar_filtros_Click" /></small>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Responsable" />
                                        <asp:DropDownList runat="server" ID="ejecucion_drop_responsables" CssClass="form-control" AutoPostBack="true" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Label runat="server" CssClass="control-label" Text="Después de" />
                                        <asp:TextBox runat="server" CssClass="form-control" TextMode="Date" AutoPostBack="true" ID="ejecucion_input_fecha" />
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <!-- Ejecuciones disponibles -->
                            <section id="seccion_ejecuciones_disponibles">
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:Label runat="server" Text="Ejecuciones diponibles" CssClass="control-label" AssociatedControlID="check_ejecuciones_todos" />
                                    </div>
                                    <div class="col-md-4 col-md-offset-2">
                                        <asp:CheckBox runat="server" CssClass="checkbox checkbox-inline" ID="check_ejecuciones_todos" Text="Seleccionar todos" AutoPostBack="true" OnCheckedChanged="check_ejecuciones_todos_CheckedChanged" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <div style="height: 250px; overflow-y: scroll">
                                            <asp:Table runat="server" ID="tabla_ejecuciones_disponibles" CssClass="table table-hover">
                                            </asp:Table>
                                        </div>
                                    </div>
                                </div>
                            </section>
                            <hr />
                            <!-- Informacion a incluir de las ejecuciones -->
                            <section id="seccion_ejecuciones_info_incluir">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" CssClass="control-label" Text="Información a incluir" AssociatedControlID="ejecucion_check_resultados" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="ejecucion_check_resultados" CssClass="checkbox checkbox-inline" Text="Lista de resultados" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="ejecucion_check_responsable" CssClass="checkbox checkbox-inline" Text="Responsable" />
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="ejecucion_check_fecha" CssClass="checkbox checkbox-inline" Text="Fecha de ejecución" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:CheckBox runat="server" ID="ejecucion_check_incidentes" CssClass="checkbox checkbox-inline" Text="Incidentes durante la ejecución" />
                                    </div>
                                </div>
                            </section>
                            <section id="seccion_ejecuciones_boton_volver_y_listo">
                                <div class="col-md-2">
                                    <button class="btn btn-default btn-block btn-sm" type="button" id="ejecucion_btn_volver" runat="server" onserverclick="ejecucion_btn_volver_ServerClick"><span class="glyphicon glyphicon-chevron-left" aria-hidden="true"></span></button>
                                </div>
                                <div class="col-md-2 col-md-offset-8">
                                    <button class="btn btn-success btn-block btn-sm" type="button" id="btn_listo" runat="server" onserverclick="btn_listo_ServerClick"><span class="glyphicon glyphicon-ok" aria-hidden="true"></span></button>
                                </div>
                            </section>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <section id="botones_generar_reporte">
        <div class="row">
            <div class="form-horizontal">
                <div class="form-group">
                    <div class="col-md-12">
                        <hr />
                    </div>
                </div>
                <div class="form-group">
                    <!-- Aca van los iconos de pdf o excel y los respectivos checkbox-->
                    <div class="col-md-2 col-md-offset-4">
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-2 col-md-offset-4">
                        <asp:Button runat="server" CssClass="btn btn-success btn-block" ID="btn_generar_reporte" OnClick="btn_generar_reporte_Click" Text="Generar reporte" />
                    </div>
                    <div class="col-md-2">
                        <button class="btn btn-danger btn-block" type="button" id="btn_cancelar">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <script type="text/javascript">

        $("#btn_cancelar").click(function () {
            window.location = "InterfazReportes.aspx";
        });

        // ---------------------------------------------------------------------- Panel de proyectos ----------------------------------------------------------------------
        $("#proyecto_habilitado").click(function () {
            $("#btn_estado_proyecto").text("Incluir");

        });

        $("#proyecto_inhabilitado").click(function () {
            $("#btn_estado_proyecto").text("No inlcuir");
        });

        //Desactivo los campos del panel de proyectos y activo el de diseños
        $("#proyecto_btn_continuar").click(function () {
            $("#<%=proyecto_drop_estado.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_input_fecha_final.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_input_fecha_inicio.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_drop_miembro.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_drop_oficina.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_disenos.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_fechas.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_miembros.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_objetivos.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_oficina.ClientID%>").prop("disabled", true);
            $("#<%=proyecto_check_todos.ClientID%>").prop("disabled", true);
            //Deshabilito la tabla de los proyectos
            $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", true);

            /*
            $("#proyecto_btn_continuar").prop("disabled", true);

            //Habilito los botones en el panel de disenos
            $("#diseno_btn_volver").prop("disabled", false);
            $("#diseno_btn_continuar").prop("disabled", false);*/
        });

        $("#diseno_btn_volver").click(function () {
            $("#<%=proyecto_drop_estado.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_input_fecha_final.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_input_fecha_inicio.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_drop_miembro.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_drop_oficina.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_disenos.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_fechas.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_miembros.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_objetivos.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_oficina.ClientID%>").prop("disabled", false);
            $("#<%=proyecto_check_todos.ClientID%>").prop("disabled", false);
            //Habilito la tabla de los proyectos
            $("#<%= tabla_proyectos.ClientID%>").find("*").prop("disabled", false);

            /*
            //Habilito  el boton de continuar en el panel de proyectos
            $("#proyecto_btn_continuar").prop("disabled", false);
            //Deshabilito los botones de volver y continuar en el panel de 
            $("#diseno_btn_volver").prop("disabled", true);
            $("#diseno_btn_continuar").prop("disabled", true);*/
        });
        // ---------------------------------------------------------------------- Fin panel proyectos ---------------------------------------------------------------------

        //---------------------------------------------------------------------- Panel de diseños ----------------------------------------------------------------------

        $("#diseno_habilitado").click(function () {
            $("#btn_estado_diseno").text("Incluir");
        });

        $("#diseno_inhabilitado").click(function () {
            $("#btn_estado_diseno").text("No incluir");
        });
        // ---------------------------------------------------------------------- Fin panel diseños ---------------------------------------------------------------------

        // ---------------------------------------------------------------------- Panel de casos ----------------------------------------------------------------------

        //Revisa si el check de proyectos esta seleccionado para marcar todos
        if ($("#<%=Checkbox_casos_de_prueba_todos.ClientID%>").is(":checked")) {
            $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("checked", true);
            //Deshabilito la tabla de los proyectos
            $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("disabled", true);
        } else {
            $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("checked", false);
            //Habilito la tabla de los proyectos
            $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("disabled", false);
        }

        //Selecciono todos los proyectos
        $("#<%=Checkbox_casos_de_prueba_todos.ClientID%>").click(function () {
            if ($("#<%=Checkbox_casos_de_prueba_todos.ClientID%>").is(":checked")) {
                $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("checked", true);
                //Deshabilito la tabla de los proyectos
                $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("disabled", true);
            } else {
                $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("checked", false);
                //Habilito la tabla de los proyectos
                $("#<%= tabla_casos_de_prueba_disponibles.ClientID%>").find("*").prop("disabled", false);
            }
            return true;
        });
        // ---------------------------------------------------------------------- Fin panel casos ---------------------------------------------------------------------
        // ---------------------------------------------------------------------- Panel de ejecuciones ----------------------------------------------------------------------
        $("#ejecucion_habilitado").click(function () {
            $("#btn_estado_ejecucion").text("Incluir");
        });
        $("#ejecucion_inhabilitado").click(function () {
            $("#btn_estado_ejecucion").text("No inlcuir");
        });
        // ---------------------------------------------------------------------- Fin panel ejecuciones ---------------------------------------------------------------------
    </script>

</asp:Content>
