<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" Inherits="SAPS.Fronteras.InterfazProyectosDePruebas" CodeBehind="InterfazProyectosDePruebas.aspx.cs" %>

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
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_crear" Enabled="true" Text="Crear" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_modificar" Enabled="false" Text="Modificar" />
                    <asp:Button runat="server" CssClass="btn btn-default" ID="btn_eliminar" Enabled="false" Text="Eliminar" />
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
                        <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Nombre del sistema:</asp:Label>
                </div>
                <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_name" CssClass="form-control" />
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
                        <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Nombre del proceso:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_process" CssClass="form-control" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Estado del proyecto:</asp:Label>
            </div>
            <div class="col-md-3">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
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
                        <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Líder del proyecto:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_leader" CssClass="form-control" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_oficina_asociada">Representante de oficina:</asp:Label>
            </div>
            <div class="col-md-3">
                        <asp:TextBox runat="server" ID="input_office" CssClass="form-control" />
            </div>
        </div>

        </br>

        <div id="row3" class="row">

        </div>


    </section>





    </asp:Content>


