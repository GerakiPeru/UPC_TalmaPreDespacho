<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="Tracking_Levante.aspx.cs" Inherits="UITalmaNET.PreDespachos.Tracking_Levante" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function OnShowMessage(mensaje) {
            alert(mensaje);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="holder" runat="server">
    <asp:UpdatePanel ID="udpatepanel" runat="server">
    <ContentTemplate> 
        <center>
            <div class="panel panel-primary" style="width:100%; text-align:left">
                <div class="panel-heading">Datos de la Guía</div>
                <div class="panel-body">
                    <table class="tabletitle">
                        <tr>
                            <td class="tdLargo" style="width: 120px;">
                                Id Guía
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtIdGuia"></telerik:RadTextBox>
                            </td>    
                            <td class="tdLargo" style="width: 120px;">
                                Bultos
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtBultos"></telerik:RadTextBox>
                            </td>
                            <td class="tdLargo" style="width: 120px;">
                                Kilos
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtKilos"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Origen
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtOrigen"></telerik:RadTextBox>
                            </td>
                            <td class="tdLargo" style="width: 120px;">
                                Destino
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtDestino"></telerik:RadTextBox>
                            </td>    
                            <td></td>
                        </tr>   

                        <tr>
                            <td class="tdLargo" style="width: 80px;">
                                Linea Aerea
                            </td>         
                            <td class="tdUDLR" colspan="3">
                                <telerik:RadTextBox Width="388px" ReadOnly="true" runat="server" ID="txtLineaAerea"></telerik:RadTextBox>
                            </td>    
                            <td class="tdLargo" style="width: 120px;">
                                Vuelo
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtVuelo"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Arribó
                            </td>   
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtFechaVuelo"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Ingreso
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtFechaIngreso"></telerik:RadTextBox>
                            </td> 
                            <td></td>
                        </tr>                                                                                            
                        <tr>
                            <td class="tdLargo" style="width: 120px;">
                                Consignatario
                            </td>         
                            <td class="tdUDLR" colspan="3">
                                <telerik:RadTextBox Width="388px" ReadOnly="true" runat="server" ID="txtConsignatario"></telerik:RadTextBox>
                            </td>  
                            <td class="tdLargo" style="width: 120px;">
                                Agente
                            </td>         
                            <td class="tdUDLR" colspan="3">
                                <telerik:RadTextBox Width="388px" ReadOnly="true" runat="server" ID="txtAgenteCarga"></telerik:RadTextBox>
                            </td> 
                                                     
                            <td class="tdLargo" style="width: 120px;">
                                Retiro
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadDatePicker Width="120px" runat="server" ID="dtFechaRetiro" Enabled="false"></telerik:RadDatePicker>
                            </td>
                            <td></td>    
                        </tr> 
                    </table>
                </div>
            </div>
            <div class="panel panel-primary" style="width:100%; text-align:left;">
                <div class="panel-heading">Datos del Levante Autorizado</div>
                <div class="panel-body">
                    <table class="tabletitle">
                        <tr>
                            <td class="tdLargo" style="width: 120px;">
                                DUA
                            </td>         
                            <td class="tdUDLR" colspan="3">
                                <telerik:RadTextBox Width="388px" ReadOnly="true" runat="server" ID="txtDua" Text="2015-10-1-000345-00-1-01"></telerik:RadTextBox>
                            </td>    
                            <td class="tdUDLR" style="width: 120px;">                                
                            </td>         
                            <td class="tdUDLR">
                            </td>
                            <td class="tdUDLR" style="width: 120px;">                                
                            </td>         
                            <td class="tdUDLR">                                
                            </td> 
                            <td class="tdUDLR" style="width: 120px;">                                
                            </td>         
                            <td class="tdUDLR" colspan="3">             
                            </td>  
                            <td></td>
                        </tr> 
                        <tr>
                            <td class="tdLargo" style="width: 120px;">
                                Tipo
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtTipoAduana" Text="Agente Aduana"></telerik:RadTextBox>
                            </td>    
                            <td class="tdLargo" style="width: 120px;">
                                Agente
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtCodigoAduana" Text="0645"></telerik:RadTextBox>
                            </td>
                            <td class="tdLargo" style="width: 120px;">
                                Semaforo
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtSemaforoAduana" Text="VERDE"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Estado Sunat
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtEstadoAduana" Text="Levante Autorizado"></telerik:RadTextBox>
                            </td>  
                            <td class="tdLargo" style="width: 120px;">
                                CIF
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtCIF" Text="2,100.00"></telerik:RadTextBox>
                            </td>  
                            <td></td>
                        </tr> 
                    </table>                                    
                </div>
            </div>
        </center>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
