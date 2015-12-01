<%@ Page Title="Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="SAPS.ErrorPage.ErrorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="barra-celeste"></div>
    <div style="margin-top: -100px">
        <section id="mensaje_error">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 col-sm-6 col-sm-offset-3 col-lg-4 col-lg-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <div class="col-md-12 col-sm-12 col-lg-12">
                                        <h2>Error <small>sentimos el inconveniente</small></h2>
                                    </div>
                                </div>
                                <hr />
                                <div class="form-group">
                                    <div class="col-md-4 col-md-offset-3">
                                        <img src="http://telegram-stickers.github.io/public/stickers/animals/15.png" class="img-rounded" alt="imagen error" width="170" height="200">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-10 col-md-offset-1 col-sm-10 col-sm-offset-1">
                                        <p>
                                            Lamentablemente el sistema se detuvo, estamos trabajando para solucionar el problema y que esto no vuelva a ocurrir.
                                                Mientras tanto, lo invitamos a que vuelva a la pantalla de inicio.
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            <button class="btn btn-warning btn-block" id="btn_volver">Volver al inicio</button>
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                $("#btn_volver").click(function () {
                    window.location = "../Default.aspx";
                });
            </script>
        </section>
    </div>
</asp:Content>
