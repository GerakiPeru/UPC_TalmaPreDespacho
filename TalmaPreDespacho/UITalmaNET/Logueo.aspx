<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="UITalmaNET.Logueo" %>
<!DOCTYPE html>

<html xml:lang="es-PE" xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Acceso al Sistema</title>
    <link href="/sites/talma/Recursos/css/bootstrap.min.css" rel="stylesheet">
    <link href="/sites/talma/Recursos/css/styles.css" rel="stylesheet">
    <link rel="stylesheet" href="/sites/talma/Recursos/css/toastr.min.css" />

    <script language="javascript" src="/sites/talma/Recursos/Scripts/init.js" type="text/javascript"></script> 
    <script language="javascript" src="/sites/talma/Recursos/Scripts/jquery.js" type="text/javascript"></script> 
    <script language="javascript" src="/sites/talma/Recursos/Scripts/toastr.min.js" type="text/javascript"></script>
	<script language="javascript" src="/sites/talma/Recursos/Scripts/bootstrap.min.js" type="text/javascript"></script>      
        
    
</head>
<body>
<div id="loginModal" class="modal show" tabindex="-1" role="dialog" aria-hidden="true">
  <div class="modal-dialog">
  <div class="modal-content">
      <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
          <h1 class="text-center">Acceso al Sistema</h1>
      </div>
      <div class="modal-body">
          <form class="form col-md-12 center-block">
            <div class="form-group">
              <input type="text" class="form-control input-lg" placeholder="Usuario" id="txtUsuario">
            </div>
            <div class="form-group">
              <input type="password" class="form-control input-lg" placeholder="Contraseña" id="txtPassword">
            </div>
            <div class="form-group">                         
              <div class="btn btn-primary btn-lg btn-block" onclick="Entry();return false;"><i class="fa fa-fw fa-key"></i>Iniciar Sesión</div>
              <span class="pull-right" id="resultado"></span>
            </div>
          </form>
      </div>
      <div class="modal-footer">
          <div class="col-md-12">
          <%--<button class="btn" data-dismiss="modal" aria-hidden="true">Cancel</button>--%>
		  </div>	
          <label id="msg"></label>
      </div>
  </div>
  </div>
</div>
	<!-- script references -->

        <script language="javascript" type="text/javascript">
            function Entry() {
                var Usuario = $("#txtUsuario").val();
                var Contrasenna = $("#txtPassword").val();
                //$(location).attr('href', 'Pagebase.aspx');
                var isValid = true;                
                if (isValid) {
                    $.ajax({
                        type: "POST",
                        contentType: 'application/json; charset=utf-8',
                        url: "Logueo.aspx/Valida_Usuario",
                        //url: "http://localhost:55902/PreDespacho/Contratos/srvSeguridad.svc/Session",
                        dataType: "json",
                        data: "{AL_USUA: '" + $('#txtUsuario').val() + "', PW_USUA: '" + $('#txtPassword').val() + "'}",
                        //data: JSON.stringify({ "Usuario": Usuario, "Clave": Contrasenna }),
                        async: false,
                        processData: false,
                        cache: false,
                        success: function (response) {
                            
                            //if (response == "ok") {
                            $(location).attr('href', 'Pagebase.aspx');
                            //}
                            //else {
                            //    showErrorMessage(response);
                            //}
                        },
                        error: function (response) {
                            showErrorMessage(response);
                            //showErrorMessage(response);
                        }
                    })
                }
            }

            $("#btnAcceder").click(function () {
                showErrorMessage("Ud. debe ingresar un usuario");
                if ($('#txtUsuario').val() == '') {
                    alert("Ud. debe ingresar un usuario");
                    return false;
                }
                if ($('#txtPassword').val() == '') {
                    alert("Ud. debe ingresar la contraseña");
                    return false;
                }
                //var $btn = $(this).button('loading')
                IntoSystem();
                event.preventDefault();
                event.stopPropagation();
                
                //$btn.button('reset')
            });
            //url: "Logueo.aspx/Valida_Usuario",                    
            function IntoSystem() {
                $.ajax({
                    type: "POST",
                    url: "http://www.talmanet.com.pe/services/srvPRETalma/PreDespacho/Contratos/srvSeguridad.svc/Session",
                    data: "{Usuario: '" + $('#txtUsuario').val() + "', Clave: '" + $('#txtPassword').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    beforeSend: function () {
                        $("#resultado").html("Procesando, espere por favor...");
                    },
                    dataType: "json",
                    success: access,
                    error: failed
                });
            }

            function access(msg) {
                $(location).attr('href', 'Pagebase.aspx');
                //$("#msg").val(msg.d);
                /*
                $("#resultado").html(msg.d);
                if (msg.d) {
                    $(location).attr('href', 'Pagebase.aspx');
                }*/
            }

            function failed(msg) {
                //$("#msg").val(msg.d);
                $("#resultado").html(msg);
                //alert('Error: ' + msg.responseText);
            }
        </script>
	</body>
</html>