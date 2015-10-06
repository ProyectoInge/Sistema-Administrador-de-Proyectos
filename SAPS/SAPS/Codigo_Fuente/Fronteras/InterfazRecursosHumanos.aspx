<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazRecursosHumanos.aspx.cs" Inherits="SAPS.Fronteras.Recursos_Humanos" %>
<asp:Content ID="content_hr" ContentPlaceHolderID="MainContent" runat="server">
    <section id="page_header">
        <div class="page-header">
            <h1>SAPS <small>Recursos humanos</small></h1>
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
    <br/>
    <section id="form" class="col-md-offset-1">
        <div id="row1" class="row"">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="input_name" CssClass="control-label">Nombre</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="input_name" CssClass="form-control" />
                </div>
            <div class="col-md-6"><!-- Espacio al propio--></div>
         </div>
        </div>
        <br/>
        <div id="row2" class="row">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="input_usuario" CssClass="control-label">Usuario</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" />
                </div>
                <div class="col-md-1"><!-- Espacio al propio--></div>
                <div class="col-md-1">
                    <asp:Label runat="server" AssociatedControlID="radio_btn_miembro" CssClass="control-label">Miembro</asp:Label>
                </div>
                <div class="col-md-1">
                    <!-- El atributo "GroupName" es para que los radio buttons sepan que pertenecen a un grupo y que solo puede haber
                    uno de ellos seleccionado.-->
                    <asp:RadioButton runat="server" CssClass ="form-group" ID="radio_btn_miembro" GroupName="lista_radio_buttons" />
                </div>
                <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="radio_btn_administrador">Administrador</asp:Label>
                </div>
                <div class="col-md-1">
                    <!-- El atributo "GroupName" es para que los radio buttons sepan que pertenecen a un grupo y que solo puede haber
                        uno de ellos seleccionado.-->
                    <asp:RadioButton runat="server" ID="radio_btn_administrador" CssClass="form-group" GroupName="lista_radio_buttons" />
                </div>
            </div>
        </div>
        <br/>
        <div id="row3" class="row">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="input_correo" CssClass="control-label">Correo</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="input_correo" CssClass="form-control" TextMode="Email" />
                </div>
                <div class="col-md-1"><!-- Espacio al propio--></div>
                <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_proyecto_asociado">Proyecto</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drop_proyecto_asociado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Proyecto 1" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Proyecto 2" Value="1"></asp:ListItem>
                    </asp:DropDownList>    
                </div>
            </div>
        </div>
        <br />
        <div id="row4" class="row">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Label runat="server" AssociatedControlID="input_telefono" CssClass="control-label">Telefono</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="input_telefono" CssClass="form-control" TextMode="Phone"/>
                </div>
                <div class="col-md-1"><!-- Espacio al propio--></div>
                <div class="col-md-2">
                    <asp:Label runat="server" CssClass="control-label" AssociatedControlID="drop_rol">Rol</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:DropDownList ID="drop_rol" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Lider" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Tester" Value="2"></asp:ListItem>
                    </asp:DropDownList> 
                </div>
            </div>
        </div>
        <br />
        <div id="row5" class="row">
            <div class="form-group">
                <div class="col-md-2">
                    <asp:Label runat="server" ID="label_contrasena" CssClass="control-label" AssociatedControlID="input_contrasena">Contraseña</asp:Label>
                </div>
                <div class="col-md-3">
                    <asp:TextBox runat="server" ID="input_contrasena" CssClass="form-control" TextMode="Password" />
                </div>
                <div class="col-md-1"><!-- Espacio al propio--></div>
                <div class="col-md-5"><!-- Espacio al propio--></div>
            </div>
        </div>
        <br />
    </section>
    <section id="botones_aceptar_cancelar">
        <div class="col-md-3 col-md-offset-9">
            <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar"/>
            <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar" OnClick="btn_Cancelar_Click"/>
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
    <section id="area_consultas" class="col-md-offset-3">
        <div class="row">
            <div class="col-md-1">
                <asp:Button runat="server" CssClass="btn btn-primary" ID="btn_consultar" Enabled="true" Text="Consultar" OnClick="btn_consultar_Click" />
            </div>
            <div class="col-md-1"><!-- Espacio al propio--></div>
            <div class="col-md-7">
                <!-- https://msdn.microsoft.com/en-us/library/7bewx260.aspx aqui sale como llenar la tabla dinamicamente o
                    en el archivo Recursos_Humanos.aspx.cs en el constructro hay un ejemplo de como llenarla -->
                <div runat="server" class="list-group" id="lista_rh">
                </div>
            </div>
        </div>
    </section>
</asp:Content>
