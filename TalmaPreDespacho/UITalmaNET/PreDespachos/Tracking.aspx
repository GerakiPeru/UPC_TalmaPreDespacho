<%@ Page Title="" Language="C#" MasterPageFile="~/Content.Master" AutoEventWireup="true" CodeBehind="Tracking.aspx.cs" Inherits="UITalmaNET.PreDespachos.Tracking" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function openPopup(url, ctrl, reloadclose, sfun, ancho, alto, _x, _y, ismax) {
            if (ctrl != '')
                control = document.getElementById(ctrl);
            breloadclose = reloadclose;
            if (breloadclose)
                sfuncion = sfun;
            var oWindow = window.radopen(url, "rwPopup");
            oWindow.setSize(ancho, alto);
            if (ismax == true) oWindow.maximize();
            else
                oWindow.center();
            //oWindow.moveTo(_x, _y);
        }


        function closePopup() {
            $find('<%= rwPopup.ClientID%>').close();
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
        <div class="panel panel-primary" style="width:99%; text-align:left">
            <div class="panel-heading">Filtros de Busqueda</div>
            <div class="panel-body">
                <table class="tabletitle">
                    <tr>
                        <td class="tdLargo" style="width: 70px;">
                            Id Guía :
                        </td>
                        <td class="tdUDLR" style="width: 200px;">
                            <telerik:RadTextBox runat="server" ID="txtGuia" EmptyMessage="Ingrese el N° de guía" Width="200px"></telerik:RadTextBox>
                        </td>
                        <td class="tdLargo" style="width: 70px;">
                            Estado :
                        </td>
                        <td class="tdUDLR" style="width: 200px;">
                            <telerik:RadComboBox runat="server" ID="cboEstado" EmptyMessage="Seleccione el Estado" Width="200px">
                                <Items>
                                    <telerik:RadComboBoxItem Text="Solicitado" Value="SOL" />
                                    <telerik:RadComboBoxItem Text="Enviado" Value="ENV" />
                                    <telerik:RadComboBoxItem Text="Aprobado" Value="APR" />
                                    <telerik:RadComboBoxItem Text="Rechazado" Value="RCH" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>   
                        <td class="tdUDLR" style="width: 120px;text-align:right">
                            <telerik:RadButton runat="server" ID="btnBuscar" Text="Realizar Busqueda" OnClick="btnBuscar_Click"></telerik:RadButton>
                        </td>
                        <td></td>  
                        <td class="tdLargo" style="width: 70px;">
                            Retiro :
                        </td>
                        <td class="tdUDLR" style="width: 120px;text-align:right">
                            <telerik:RadDatePicker runat="server" ID="dtFechaRetiro"></telerik:RadDatePicker>                      
                        </td>
                        <td class="tdUDLR" style="width: 120px;text-align:right">
                            <telerik:RadButton runat="server" ID="btnGenerar" Text="Nuevo Pre-Despacho" OnClick="btnGenerar_Click"></telerik:RadButton>
                        </td>                                        
                    </tr>
                </table>
            </div>
        </div>
        <telerik:RadGrid ID="grid" runat="server" OnNeedDataSource="grid_NeedDataSource" Width="99%" onitemdatabound="grid_ItemDataBound">
            <MasterTableView AutoGenerateColumns="false" TableLayout="Fixed">
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Id Guia" DataField="ID_GUIA" UniqueName="ID_GUIA">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>            
                    <telerik:GridBoundColumn HeaderText="Bultos" DataField="NU_BULT_RECI" UniqueName="NU_BULT_RECI">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>   
                    <telerik:GridBoundColumn HeaderText="Kilos" DataField="KG_RECI" UniqueName="KG_RECI">
                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                        <ItemStyle HorizontalAlign="Center" Width="100px" />
                    </telerik:GridBoundColumn>     
                    <telerik:GridBoundColumn DataField="NO_ENTI_CONC" HeaderText="Consignatario">
                    </telerik:GridBoundColumn>  

                    <telerik:GridTemplateColumn HeaderText="PreFactura" DataField="ST_PREFACTURA" UniqueName="ST_PREFACTURA">
                        <HeaderStyle HorizontalAlign="Center" Width="180px" />
                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("ST_PREFACTURA") %>'></asp:Label>
                            <asp:ImageButton runat="server" ID="imgVerPreFactura" ImageUrl="../Recursos/images/listview_ajax_46.png" Width="20" Height="20" ToolTip="Ver PreFactura"/>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Levante" DataField="ST_LEVANTE" UniqueName="ST_LEVANTE">
                        <HeaderStyle HorizontalAlign="Center" Width="180px" />
                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# Eval("ST_LEVANTE") %>'></asp:Label>
                            <asp:ImageButton runat="server" ID="imgVerLevante" ImageUrl="../Recursos/images/listview_ajax_46.png" Width="20" Height="20" ToolTip="Ver PreFactura"/>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>

                    <telerik:GridTemplateColumn HeaderText="Documentación<br>Aduana" DataField="ST_DOCU_ADUA" UniqueName="ST_DOCU_ADUA">
                        <HeaderStyle HorizontalAlign="Center" Width="180px" />
                        <ItemStyle HorizontalAlign="Center" Width="180px" />
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ST_DOCU_ADUA") %>'></asp:Label>
                            <asp:ImageButton runat="server" ID="imgVerAduana" ImageUrl="../Recursos/images/listview_ajax_46.png" Width="20" Height="20" ToolTip="Ver Documentación Aduana"/>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                   
                    <telerik:GridBoundColumn HeaderText="PreDespacho" DataField="ST_PRE_DESPACHO" UniqueName="ST_PRE_DESPACHO">
                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                        <ItemStyle HorizontalAlign="Center" Width="120px" />
                    </telerik:GridBoundColumn>                                                                                                       
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>

        <telerik:RadWindowManager ID="rwindowman" runat="server" EnableShadow="true" Style="z-index: 7001">
            <Windows>
                <telerik:RadWindow EnableShadow="true" OnClientClose="OnClientclose" Modal="true"
                    Skin="Default" ShowContentDuringLoad="false" EnableAriaSupport="true" VisibleStatusbar="false"
                    ReloadOnShow="true" Behaviors="Close, Move, Resize, Maximize" ID="rwPopup" runat="server">
                </telerik:RadWindow>
            </Windows>
        </telerik:RadWindowManager>  

    </center>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
