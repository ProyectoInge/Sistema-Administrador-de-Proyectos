<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SAPS.ErrorPage.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-celeste"></div>
    <div style="margin-top: -100px">
        <section id="mensaje_error">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-3">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-md-12 col-sm-12">
                                        <h2>Error :( <small>sentimos el inconveniente</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1">
                                            <p>Lamentablemente el sistema se detuvo, estamos trabajando para solucionar el problema y que esto no vuelva a ocurrir.
                                                Mientras tanto, lo invitamos a que vuelva a la pantalla de inicio :).
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <asp:Button runat="server" ID="btn_home" CssClass="btn btn-warning btn-block" Text="Volver a home" OnClick="btn_home_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>
