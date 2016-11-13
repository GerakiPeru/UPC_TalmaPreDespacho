<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="Tracking_Aduana.aspx.cs" Inherits="UITalmaNET.PreDespachos.Tracking_Aduana" %>
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
            <table class="tabletitle">
                <tr>
                    <td style="width:35%; text-align:center;vertical-align:top">
                        <div class="panel panel-primary" style="width:100%; text-align:left;">
                            <div class="panel-heading">Adjuntar Documento</div>
                            <div class="panel-body">
                                <table class="tabletitle" width="250px">
                                    <tr>
                                        <td class="tdLargo" style="width: 120px;">
                                            Ingrese Voucher
                                        </td>         
                                        <td class="tdUDLR">
                                            <asp:FileUpload runat="server" Height="30px" Width="250px" ID="uplvoucher" />
                                        </td>    
                                    </tr>
                                    <tr>
                                        <td class="tdLargo" style="width: 120px;">
                                            Observación
                                        </td>   
                                        <td class="tdUDLR">
                                            <telerik:RadTextBox Width="250px" Height="50px" runat="server" ID="txtObservacion" TextMode="MultiLine">
                                            </telerik:RadTextBox>
                                        </td> 
                                    </tr>
                                    <tr>
                                        <td class="tdUDLR">
                                        </td>
                                        <td class="tdUDLR">
                                            <telerik:RadButton runat="server" ID="btnAdjuntar" Text="Adjuntar Voucher" OnClick="btnAdjuntar_Click"></telerik:RadButton>
                                        </td>
                                    </tr>
                                </table>                                    
                            </div>
                        </div>
                    </td>
                    <td style="width:65%; text-align:center;vertical-align:top">
                        <telerik:RadGrid ID="documento" runat="server" OnNeedDataSource="documento_NeedDataSource" Width="100%" onitemdatabound="documento_ItemDataBound">
                            <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed" ShowFooter="true">
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Id" DataField="ID_ARCH" UniqueName="ID_ARCH">
                                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                    </telerik:GridBoundColumn>                                                                 
                                    <telerik:GridDateTimeColumn HeaderText="Fecha Carga" DataField="FE_ARCH_UPLOAD" DataType="System.DateTime" 
                                        DataFormatString="{0:dd MMMM yyyy hh:mm}"
                                        UniqueName="FE_ARCH_UPLOAD">
                                        <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                        <ItemStyle HorizontalAlign="Center" Width="90px" />
                                    </telerik:GridDateTimeColumn>   
                                    <telerik:GridBoundColumn DataField="RT_ARCH_WEB" UniqueName="RT_ARCH_WEB" Display="false" /> 
                                    <telerik:GridTemplateColumn HeaderText="Ver Documento" DataField="RT_ARCH_WEB" UniqueName="RT_ARCH_WEB">
                                        <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                        <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        <ItemTemplate>
                                            <asp:ImageButton runat="server" ID="imgVerDocumento" ImageUrl="../Recursos/images/listview_ajax_46.png" Width="20" Height="20" ToolTip="Ver Documento"/>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>    
                                    <telerik:GridBoundColumn HeaderText="Estado" DataField="ST_ARCH" UniqueName="ST_ARCH">
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                                    </telerik:GridBoundColumn>                                                                                                                                          
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>

                    </td>
                </tr>
            </table>

        </center>
    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnAdjuntar" />
    </Triggers>
</asp:UpdatePanel>
</asp:Content>
