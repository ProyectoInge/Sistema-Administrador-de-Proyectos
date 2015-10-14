<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="SAPS.Codigo_Fuente.Fronteras.InterfazProyectosDePruebas" CodeBehind="InterfazProyectosDePruebas.aspx.cs" %>

<asp:Content ID="content_pdp" ContentPlaceHolderID="MainContent" runat="server">

    <section id="page_header">
        <div class="page-header">
            <h1>SAPS <small>Proyectos De Pruebas</small></h1>
        </div>
    </section>

    <section id="botones_IME">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <div class="btn-group" role="group">
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_crear" Enabled="true" Text="Crear" Onclick="btn_crear_click"/>
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Enabled="false" Text="Modificar" Onclick="btn_modificar_click"/>
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Enabled="false" Text="Eliminar" Onclick="btn_eliminar_click"/>
                </div>
            </div>
        </div>
    </section>
    <br/>
    
    <section id="alertas">
        <div class="col-md-10 col-md-offset-1">
            <div class="alert alert-danger alert-dismissible" id="alerta_error" role="alert" aria-hidden="true" runat="server">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <b><asp:Label runat="server" ID="titulo_alerta" Text="¡Error! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_error"></asp:Label>
            </div>
            <div class="alert alert-success alert-dismissible" id="alerta_exito" role="alert" aria-hidden="true" runat="server">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <b><asp:Label runat="server" ID="Label1" Text="¡Éxito! "></asp:Label></b><asp:Label runat="server" ID="cuerpo_alerta_exito"></asp:Label>
            </div>
        </div>
    </section>
    <br/>

    <section id="form" class="col-md-offset-1">        

        <div id="row1" class="row">
            <div class="form-group">
                <div class="col-md-2">
                        <asp:Label runat="server" AssociatedControlID="input_system" CssClass="control-label">Nombre del sistema:</asp:Label>
                </div>
                <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_system" CssClass="form-control" />
                </div>
                <div class="col-md-1"><!-- Espacio al propio--></div>
                <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Oficina usuaria:</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drop_oficina_asociada" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Oficina 1" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Oficina 2" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Oficina 3" Value="2"></asp:ListItem>
                    </asp:DropDownList>    
                </div>
            </div>
        </div>

        <br/>

        <div id="row2" class="row">
            <div class="col-md-2">
                        <asp:Label runat="server" AssociatedControlID="input_process" CssClass="control-label">Nombre del proceso:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_process" CssClass="form-control" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Estado del proyecto:</asp:Label>
            </div>
            <div class="col-md-3">
                    <asp:DropDownList ID="drop_estado_proyecto" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Pendiente de asignación" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Asignado" Value="1"></asp:ListItem>
                        <asp:ListItem Text="En ejecución" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Finalizado" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Cerrado" Value="4"></asp:ListItem>
                    </asp:DropDownList>    
            </div>
        </div>

        <br/>

        <div id="row3" class="row">
            <div class="col-md-2">
                        <asp:Label runat="server" AssociatedControlID="input_leader" CssClass="control-label">Líder del proyecto:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_leader" CssClass="form-control" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Representante de oficina:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_manager_office" CssClass="form-control" />
            </div>
        </div>

        </br>

        <div id="row4" class="row">            
            <div class="col-md-2">
                        <asp:Label runat="server" AssociatedControlID="input_phone1" CssClass="control-label">Teléfono:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_phone1" CssClass="form-control" />
                        </br>
                        <asp:TextBox runat="server" ID="input_phone2" CssClass="form-control" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-2">
                        <asp:Label runat="server" AssociatedControlID="input_objective" CssClass="control-label">Objetivo:</asp:Label>
            </div>                        
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_objective" CssClass="form-control" rows="5" TextMode="multiline"  />
            </div>
        </div>

        </br>

        <section id="label_lista_ddp" class="row">
        <div class="col-md-11 col-md-offset-1">
            <h4>Diseños de Pruebas</h4>
        </div>
    </section>

        </br>

        <section id="area_consultas_disenos" class="col-md-offset-3">
        <div class="row">            
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-7" style="height:150px; overflow-y:scroll">
                <asp:Table runat="server" ID="tabla_disenos_de_prueba" CssClass="table table-hover form-group">

                </asp:Table>                
            </div>
        </div>
    </section>

        </br>
        </br>

        <section id="botones_aceptar_cancelar">
        <div class="col-md-3 col-md-offset-9">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar" OnClick="btn_aceptar_click" />
            <asp:Button runat="server" CssClass="btn btn-danger" ID="Button2" Text="Cancelar" OnClick="btn_cancelar_click"/>
    </section>

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
            <h4>Proyectos de Pruebas</h4>
        </div>
    </section>
    <br />

    <section id="area_consultas" class="col-md-offset-3">
        <div class="row">
            <div class="col-md-1">
                <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_consultar" Enabled="true" Text="Consultar" OnClick="btn_consultar_click" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-7" style="height:200px; overflow-y:scroll">
                <asp:Table runat="server" ID="tabla_proyectos_de_pruebas" CssClass="table table-hover form-group">

                </asp:Table>                
            </div>
        </div>
    </section>

    </asp:Content>


