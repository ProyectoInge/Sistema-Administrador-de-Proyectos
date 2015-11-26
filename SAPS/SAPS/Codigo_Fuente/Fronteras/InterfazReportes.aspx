<%@ Page Title="Generación de reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InterfazReportes.aspx.cs" Inherits="SAPS.Fronteras.InterfazReportes" %>
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
            <div class="col-md-5 col-md-offset-1">                
                <div class="panel panel-default">
                    <div class="panel-heading">Proyecto
                        <label class="checkbox-inline col-md-offset-9">
                            <input type="checkbox" name ="check_proyecto" class="bootstrap-toggle"/>
                        </label>
                    </div>
                    <div class="panel-body">
                            <div class="form-horizontal">
                                <br/>
                                <div class ="form-group">
                                    <div class ="col-md-10">
                                        <div style="height: 100px;overflow-y:scroll">
                                        <asp:Table runat="server" ID="tabla_proyectos" CssClass="table table-bordered">
                                            <asp:TableHeaderRow runat="server" ID="header_tabla_proyectos">
                                                <asp:TableHeaderCell runat="server" CssClass="col-md-2 text-center" ID="celda_check_proyectos">                                                    
                                                    <asp:CheckBox runat="server" ID="check_header_proyecto"/>
                                                </asp:TableHeaderCell>
                                                <asp:TableHeaderCell runat="server" ID="celda_nombre_proyecto" cssclass="text-center" Text="Nombre"></asp:TableHeaderCell>
                                            </asp:TableHeaderRow>
                                        </asp:Table>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class ="col-md-5">
                                        <asp:Label runat="server"  ID="label_info_proyectos" AssociatedControlID="check_miembros" CssClass="control-label" text="Información a incluir:"/>
                                    </div>
                                </div>
                                <div class ="form-group">
                                    <div class ="col-md-5">
                                        <asp:CheckBox runat="server" ID="check_miembros"/> Miembros asociados
                                    </div>
                                    <div class ="col-md-5">
                                        <asp:CheckBox runat="server" ID="check_fechas"/> Fechas
                                    </div>
                                </div>
                                <div class ="form-group">
                                    <div class ="col-md-5">
                                        <asp:CheckBox runat="server" ID="check_disenos"/> Diseños asociados
                                    </div>
                                    <div class ="col-md-5">
                                        <asp:CheckBox runat="server" ID="check_oficina"/> Oficina asociada
                                    </div>
                                </div>
                                <div class="form-group">                                    
                                    <div class ="col-md-4">
                                        <asp:CheckBox runat="server" ID="check_objetivos"/> Objetivos
                                    </div>
                                </div>
                                <br/>
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Label runat="server" CssClass="control-label" ID="label_filtros_proyecto" AssociatedControlID="drop_encargado" text="Filtros:"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_encargado"/>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_fecha_ini"/>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_fecha_fin"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_oficina"/>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_estado"/>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:dropDownList runat="server" CssClass="form-control" ID="drop_miembro"/>
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
            
            
            <!--Segunda caja-->
            <div class="col-md-5">
                 <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">Diseño</div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      </div>
    </section>
    
</asp:Content>
