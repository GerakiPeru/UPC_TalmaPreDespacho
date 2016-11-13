<%@ Page Title="" Language="C#" MasterPageFile="~/Popup.Master" AutoEventWireup="true" CodeBehind="Tracking_PreFactura.aspx.cs" Inherits="UITalmaNET.PreDespachos.Tracking_PreFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">        
    <script type="text/javascript">
        function metTabSelected(sender, args) {
            var control = sender;
            var _selIndex = control._selectedIndex;
            var multipage = $find("<%=mPage.ClientID%>");
            multipage.set_selectedIndex(_selIndex);
        }

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
                                <telerik:RadDatePicker Width="120px" runat="server" ID="dtFechaRetiro" AutoPostBack="true" 
                                    onselecteddatechanged="dtFechaRetiro_SelectedDateChanged"></telerik:RadDatePicker>
                            </td>
                            <td></td>    
                        </tr> 
                        <tr>
                            <td class="tdLargo" style="width: 120px;">
                                Días
                            </td> 
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtDias"></telerik:RadTextBox>
                            </td>  
                                <td class="tdLargo" style="width: 120px;">
                                Total Dolares
                            </td>   
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtTotalDolares"></telerik:RadTextBox>
                            </td>       
                            <td class="tdLargo" style="width: 120px;">
                                Importe Venta
                            </td>         
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtTotalVenta"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Importe IGV
                            </td>   
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtTotalIGV"></telerik:RadTextBox>
                            </td> 
                            <td class="tdLargo" style="width: 120px;">
                                Total Soles
                            </td>   
                            <td class="tdUDLR">
                                <telerik:RadTextBox Width="120px" ReadOnly="true" runat="server" ID="txtTotalSoles"></telerik:RadTextBox>
                            </td> 
                            <td></td>    
                        </tr> 
                    </table>
                </div>
            </div>                                    
            <telerik:RadTabStrip ID="tbPreFacturacion" runat="server" MultiPageID="radPages" OnClientTabSelected="metTabSelected"
                SelectedIndex="0" Width="100%">
                <Tabs>
                    <telerik:RadTab Text="Pre-Factura" Value="tab1" PageViewID="viewPreFactura" Selected="True"></telerik:RadTab>
                    <telerik:RadTab Text="Transferencias" Value="tab2" PageViewID="viewTransferencias"></telerik:RadTab>
                </Tabs>
            </telerik:RadTabStrip>
            <telerik:RadMultiPage ID="mPage" runat="server" SelectedIndex="0" style="border-top: 1px solid #5A7892;">
                <telerik:RadPageView ID="viewPreFactura" runat="server">
                    <telerik:RadGrid ID="grid" runat="server" OnNeedDataSource="grid_NeedDataSource" Width="100%" onitemdatabound="grid_ItemDataBound">
                        <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                            <Columns>
                                <telerik:GridBoundColumn HeaderText="Concepto" DataField="DE_CPTO" UniqueName="DE_CPTO">
                                </telerik:GridBoundColumn>            
                                <telerik:GridBoundColumn HeaderText="Importe<br>Venta" DataField="IM_VENT" UniqueName="IM_VENT">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>   
                                <telerik:GridBoundColumn HeaderText="% Descuento" DataField="PC_DCTO" UniqueName="PC_DCTO">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>     
                                <telerik:GridBoundColumn HeaderText="Importe<br>Descuento" DataField="IM_DCTO" UniqueName="IM_DCTO">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>    
                                <telerik:GridBoundColumn HeaderText="Importe<br>IGV" DataField="IM_IGVS" UniqueName="IM_IGVS">
                                    <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </telerik:GridBoundColumn>                                                                                                                                          
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </telerik:RadPageView>
                <telerik:RadPageView ID="viewTransferencias" runat="server">
                    <table class="tabletitle">
                        <tr>
                            <td style="width:35%; text-align:center;vertical-align:top">
                                <div class="panel panel-primary" style="width:100%; text-align:left;">
                                    <div class="panel-heading">Adjuntar Voucher</div>
                                    <div class="panel-body">
                                        <table class="tabletitle">
                                            <tr>
                                                <td class="tdLargo" style="width: 120px;">
                                                    Ingrese Voucher
                                                </td>         
                                                <td class="tdUDLR">
                                                    <asp:FileUpload runat="server" Height="30px" ID="uplvoucher" />
                                                </td>    
                                            </tr>
                                            <tr>
                                                <td class="tdLargo" style="width: 120px;">
                                                    Monto
                                                </td>   
                                                <td class="tdUDLR">
                                                    <telerik:RadNumericTextBox Width="120px" runat="server" ID="txtImporteVoucher">
                                                        <NumberFormat DecimalDigits="2" />
                                                    </telerik:RadNumericTextBox>
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
                                <telerik:RadGrid ID="voucher" runat="server" OnNeedDataSource="voucher_NeedDataSource" Width="100%" onitemdatabound="voucher_ItemDataBound">
                                    <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed" ShowFooter="true">
                                        <Columns>
                                            <telerik:GridBoundColumn HeaderText="Id" DataField="ID_ARCH" UniqueName="ID_ARCH">
                                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                            </telerik:GridBoundColumn>                                                                 
                                            <telerik:GridDateTimeColumn HeaderText="Fecha<br>Carga" DataField="FE_ARCH_UPLOAD" DataType="System.DateTime" 
                                                DataFormatString="{0:dd MMMM yyyy hh:mm}"
                                                UniqueName="FE_ARCH_UPLOAD">
                                                <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                                <ItemStyle HorizontalAlign="Center" Width="90px" />
                                            </telerik:GridDateTimeColumn>   
                                            <telerik:GridBoundColumn DataField="RT_ARCH_WEB" UniqueName="RT_ARCH_WEB" Display="false" /> 
                                            <telerik:GridTemplateColumn HeaderText="Ver Voucher" DataField="RT_ARCH_WEB" UniqueName="RT_ARCH_WEB">
                                                <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                <ItemStyle HorizontalAlign="Center" Width="70px" />
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="imgVerVoucher" ImageUrl="../Recursos/images/listview_ajax_46.png" Width="20" Height="20" ToolTip="Ver Voucher"/>
                                                </ItemTemplate>
                                            </telerik:GridTemplateColumn>   
                                            <telerik:GridNumericColumn HeaderText="Importe<br>Voucher" 
                                                DataType="System.Double" Aggregate="Sum"
                                                DataField="IM_ARCH" UniqueName="IM_ARCH">
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                                                <FooterStyle HorizontalAlign="Center" Width="100px" />
                                            </telerik:GridNumericColumn>    
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
                    

                </telerik:RadPageView>
            </telerik:RadMultiPage>
        </center> 

    </ContentTemplate>
    <Triggers>
        <asp:PostBackTrigger ControlID="btnAdjuntar" />
    </Triggers>
</asp:UpdatePanel>

</asp:Content>
