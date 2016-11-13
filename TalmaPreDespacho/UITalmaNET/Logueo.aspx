<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logueo.aspx.cs" Inherits="UITalmaNET.Logueo" %>
<!DOCTYPE html>

<html xml:lang="es-PE" xmlns="http://www.w3.org/1999/xhtml">
<head id="head">
    <meta http-equiv="content-type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta name="generator" content="Bootply" />
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
    <link href="Recursos/css/bootstrap.min.css" rel="stylesheet">
    <link href="Recursos/css/styles.css" rel="stylesheet">
    <title>Acceso al Sistema</title>
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
              <button class="btn btn-primary btn-lg btn-block" id="btnAcceder" data-loading-text="Procesando, espere por favor..." autocomplete="off">Ingresar</button>
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
		<script src="Recursos/Scripts/jquery-2.1.4.min.js"></script>
		<script src="Recursos/Scripts/bootstrap.min.js"></script>
        <script language="javascript" type="text/javascript">
            $("#btnAcceder").click(function () {
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

            function IntoSystem() {
                $.ajax({
                    type: "POST",
                    url: "Logueo.aspx/Valida_Usuario",                    
                    data: "{AL_USUA: '" + $('#txtUsuario').val() + "', PW_USUA: '" + $('#txtPassword').val() + "'}",
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
                
                //$("#msg").val(msg.d);
                $("#resultado").html(msg.d);
                if (msg.d) {
                    $(location).attr('href', 'Pagebase.aspx');
                }
            }

            function failed(msg) {
                //$("#msg").val(msg.d);
                $("#resultado").html(msg);
                //alert('Error: ' + msg.responseText);
            }
        </script>
	</body>
</html>