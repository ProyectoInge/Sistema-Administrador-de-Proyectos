<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRecursosHumanos.aspx.cs" Inherits="SAPS.Fronteras.Recursos_Humanos" %>

<asp:Content ID="content_hr" ContentPlaceHolderID="MainContent" runat="server">
    <section id="page_header">
        <div class="page-header">
            <h1>SAPS <small>Recursos humanos</small></h1>
        </div>
    </section>
    <!-- Esta alerta creo que se puede quitar mas adelante -->
    <section id="alerta_confirmacion">
        <!-- TO DO: revisar que funciona -->
        <script type="text/javascript">
            function Confirm() {
                var confirm_value = document.createElement("INPUT");
                confirm_value.type = "hidden";
                confirm_value.name = "confirm_value";
                if (confirm("¿Esta seguro que desea eliminar el recurso humano?")) {
                    confirm_value.value = "Si";
                } else {
                    confirm_value.value = "No";
                }
                document.forms[0].appendChild(confirm_value);
            }
        </script>
    </section>
    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default active" ID="btn_crear" Enabled="true" Text="Insertar" OnClick="btn_crear_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Text="Modificar" OnClick="btn_modificar_Click" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Text="Eliminar" OnClick="btn_eliminar_Click" />
                </div>
            </div>
        </div>
    </section>
    <br />
    <section id="alertas">
        <div class="col-md-10 col-md-offset-1">
            <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <b>
                    <asp:Label runat="server" ID="label_alerta_error" Text="¡Error! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
            </div>
            <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <b>
                    <asp:Label runat="server" ID="label_alerta_exito" Text="¡Éxito! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_exito"></asp:Label>
            </div>
        </div>
    </section>
    <br />
    <section id="form">
        <div class="row">
            <div id="panel_izquierda" class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Datos personales</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Nombre</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_name" CssClass="form-control" />
                                </div>
                            </div>
                            <div id="row2_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_cedula" CssClass="control-label" AssociatedControlID="input_cedula">Cédula</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_cedula" CssClass="form-control" placeholder="1-1111-1111" />
                                </div>
                            </div>
                            <div id="row3_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_correo" CssClass="control-label">Correo</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_correo" CssClass="form-control" TextMode="Email" placeholder="ejemplo@ejemplo.com" />
                                </div>
                            </div>
                            <div id="row4_izq" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_telefono" CssClass="control-label">Telefono</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_telefono" CssClass="form-control" TextMode="Phone" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="panel_derecha" class="col-md-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Otros datos</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div id="row1_der" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" AssociatedControlID="input_usuario" CssClass="control-label">Usuario</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" />
                                </div>
                            </div>
                            <div id="row2_der" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" ID="label_contrasena" CssClass="control-label" AssociatedControlID="input_contrasena">Contraseña</asp:Label>
                                </div>
                                <div class="col-md-9">
                                    <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" />
                                    <asp:Button runat="server" ID="btn_reestablece_contrasena" CssClass="btn btn-link btn-xs" Text="¿Desea reestablecer la contraseña?" OnClick="btn_reestablece_contrasena_Click" />
                                </div>
                            </div>
                            <hr />
                            <div id="row3_der" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="radio_buttons">Perfil:</asp:Label>
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
                            <div id="row4_der" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_proyecto_asociado">Proyecto</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="drop_proyecto_asociado" runat="server" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div id="row5_der" class="form-group">
                                <div class="col-md-3">
                                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_rol">Rol</asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:DropDownList ID="drop_rol" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="Lider" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Tester" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <br />
    <section id="botones_aceptar_cancelar">
        <div class="col-md-3 col-md-offset-9">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_Aceptar_Click" />
            <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_Cancelar_Click" />
        </div>
    </section>
    <section id="linea_separadora">
        <div class="row">
            <div class="col-md-10 col-md-offset-1">
                <hr />
            </div>
        </div>
    </section>
    <section id="label_lista_rh" class="row">
        <div class="col-md-11 col-md-offset-1">
            <h4>Recursos humanos disponibles</h4>
        </div>
    </section>
    <br />
    <section id="area_consultas" class="col-md-offset-2">
        <div class="row">
            <div class="col-md-10" style="height: 250px; overflow-y: scroll">
                <asp:Table runat="server" ID="tabla_recursos_humanos" CssClass="table table-hover form-group">
                    <asp:TableHeaderRow runat="server" ID="tabla_recursos_humanos_header">
                        <asp:TableHeaderCell runat="server" ID="celda_nombre" Text="Nombre"></asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server" ID="celda_proyecto" Text="Proyecto asociado"></asp:TableHeaderCell>
                        <asp:TableHeaderCell runat="server" ID="celda_rol" Text="Rol"></asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <!-- https://msdn.microsoft.com/en-us/library/7bewx260.aspx aqui sale como llenar la tabla dinamicamente -->
            </div>
        </div>
    </section>
    <section id="modal">
        <!-- Bootstrap Modal Dialog -->
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
                                <asp:Label ID="cuerpo_modal" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">
                                <asp:Button OnClick="btn_modal_cancelar_Click" CssClass="btn btn-defalt" ID="btn_modal_cancelar" Text="Cancelar" runat="server" />
                                <asp:Button OnClick="btn_modal_aceptar_Click" CssClass="btn btn-danger" ID="btn_modal_aceptar" Text="Eliminar" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </section>
</asp:Content>
