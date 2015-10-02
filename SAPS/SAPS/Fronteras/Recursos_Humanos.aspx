<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recursos_Humanos.aspx.cs" Inherits="SAPS.Fronteras.Recursos_Humanos" %>
<asp:Content ID="content_hr" ContentPlaceHolderID="MainContent" runat="server">
    <br/>
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
    <section id="form" class="col-md-offset-2">
        <div id="row1" class="row"">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="input_name" CssClass="col-md-2 control-label">Nombre</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="input_name" CssClass="form-control" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="drop_down_oficinas">Oficinas</asp:Label>
                    <asp:DropDownList ID="drop_down_oficinas" runat="server" CssClass="col-md-4 form-control" Width="200px">
                        <asp:ListItem Text="Oficina 1" Value="0"></asp:ListItem>
                        <asp:ListItem Text="Oficina 2" Value="1"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <br/>
        <div id="row2" class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="input_usuario" CssClass="col-md-2 control-label">Usuario</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="input_usuario" CssClass="form-control" />
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="input_rol" CssClass="col-md-2 control-label">Rol</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="input_rol" CssClass="form-control" />
                    </div>
                </div>
            </div>
        </div>
        <br/>
        <div id="row3" class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="input_correo" CssClass="col-md-2 control-label">Correo</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="input_correo" CssClass="form-control" TextMode="Email"/>
                    </div>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="input_telefono" CssClass="col-md-2 control-label">Telefono</asp:Label>
                    <div class="col-md-4">
                        <asp:TextBox runat="server" ID="input_telefono" CssClass="form-control" TextMode="Phone"/>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <div id="row4" class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label" AssociatedControlID="proyectos_asociados">Proyectos</asp:Label>
                    <div class="aumenta-margin">
                        <asp:ListBox runat="server" CssClass="col-md-4 form-control" ID="proyectos_asociados" Width="200px">
                            <asp:ListItem Text="Proyecto1" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Proyecto2" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Proyecto3" Value="2"></asp:ListItem>
                        </asp:ListBox>
                    </div>    
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <div id="radio_buttons">
                        <asp:RadioButton runat="server" CssClass="col-md-3" Text="Miembro" ID="btn_miembro" />
                        <asp:RadioButton runat="server" CssClass="col-md-3" ID="btn_admi" Text="Admi" />
                    </div>
                </div>
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
    <section id="grid"></section>
    <section id="botones_aceptar_cancelar">
        <div class="row">
            <div class="col-md-4 col-md-offset-8">
                <asp:Button runat="server" CssClass="btn btn-success" ID="btn_Aceptar" Text="Aceptar"/>
                <asp:Button runat="server" CssClass="btn btn-danger" ID="btn_Cancelar" Text="Cancelar"/>
            </div>
        </div>
    </section>
</asp:Content>
