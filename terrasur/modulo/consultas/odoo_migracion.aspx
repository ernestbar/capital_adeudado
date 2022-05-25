<%@ Page Language="C#" AutoEventWireup="true" CodeFile="odoo_migracion.aspx.cs" Inherits="modulo_consultas_odoo_migracion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h3>TRANSACCIONES, REVERSIONES EN EFECTIVO Y DPRS ERRONEAS O NO PRECESADAS ODOO<br /></h3>
    Tiempo inicio migracion:<asp:Label ID="lblInicio" runat="server" Text=""></asp:Label><br />
    Tiempo final migracion:<asp:Label ID="lblFin" runat="server" Text=""></asp:Label><br />
    Nro. de registros de la tabla:<asp:Label ID="lblTotal" runat="server" Text="0"></asp:Label><br />
    Nro. inserciones validas: <asp:Label ID="lblValidos" runat="server" Text="0"></asp:Label><br />
    Nro. inserciones erroneas: <asp:Label ID="lblError" runat="server" Text="0"></asp:Label><br />
    Transacciones no migradas o con error: <asp:Label ID="lblTransInvalid" runat="server" Text="0"></asp:Label><br />
    <table>
        <tr>
            <td>
                <asp:Button ID="btnTrans" runat="server" Text="Pagos" 
                    onclick="btnTrans_Click" />
            </td>
            <td>
                 <asp:Button ID="btnRev" runat="server" Text="Reversiones" 
                     onclick="btnRev_Click" />
            </td>
             <td>
                 <asp:Button ID="btnLotes" runat="server" Text="Lotes" 
                     onclick="btnLotes_Click" />
            </td>
        </tr>
    </table>
       
       
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
            <h3>PROCESAR TRANSACCIONES ERRONEAS O NO PRECESADAS ODOO<br /></h3>
                    Migrar todo el dia seleccionado?: <asp:CheckBox ID="cbDia" 
                            runat="server" Text="SI/NO" AutoPostBack="true" 
                            oncheckedchanged="cbDia_CheckedChanged" /><br />
                    <br />
                    Fecha transaccion:<br />
                     <ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup>
                        <asp:Button ID="btnVerTrans" runat="server" onclick="btnVerTrans_Click" 
                            Text="Ver transacciones segun la fecha" /><br />
                        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                        <hr />
                        OPCIONES DE MIGRACION<br />
                        <asp:CheckBox ID="cbEfectivo" Checked="true" Text="Pago efectivo (normal,adelantado,inicial)" runat="server" /><br />
                        <asp:CheckBox ID="cbCosto" Checked="true" Text="Porcentaje al costo (inventarios)" runat="server" /><br />
                        <asp:CheckBox ID="cbVentaLotesEfectivo" Checked="true" Text="Venta lote efectivo" runat="server" /><br />
                        <asp:CheckBox ID="cbVentaLotesCosto" Checked="true" Text="Venta lote costo (inventarios)" runat="server" /><br /><br />
                        Transacciones a migrar:<br />
                        <asp:TextBox ID="txtTrans" runat="server" TextMode="MultiLine" Width="70%" Height="200"></asp:TextBox><br /><br />
                        <asp:Button ID="btnVer" runat="server" Text="Ver transacciones del textbox" 
                            onclick="btnVer_Click" /> <asp:Button ID="btnMigrar" runat="server" Text="Migrar transacciones" 
                            onclick="btnMigrar_Click" /><br /><br />
                             <asp:GridView ID="gvData" runat="server">
                        </asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                  <h3>PROCESAR REVERSIONES ERRONEAS O NO PRECESADAS ODOO<br /></h3>
                     Desde:  <ew:CalendarPopup ID="cp_fecha_rev1" runat="server"></ew:CalendarPopup> Hasta: <ew:CalendarPopup ID="cp_fecha_rev2" runat="server"></ew:CalendarPopup><br />
                             <asp:CheckBox ID="cbRevTxt" Text="Si selecciona este check, debera introducir el ID_REVERSION en el cuadro de texto y la fecha." runat="server" /><br />
                    <asp:TextBox ID="txtRev" runat="server"></asp:TextBox><br />
                    <asp:Button ID="btnVerRev" runat="server" Text="Ver reversiones" 
                        onclick="btnVerRev_Click" /><br />
                        <asp:Label ID="lblMsjRev" runat="server"></asp:Label><br />
                     <asp:CheckBox ID="cb_rev_efectivo" Checked="true" Text="Reversion al efectivo" runat="server" /><br />
                    <asp:CheckBox ID="cb_rev_costo" Checked="true" Text="Reversion al costo (inventarios)" runat="server" /><br />
                    Reversiones a migrar:<asp:Button ID="btnMigrarRev" runat="server" 
                        Text="Migrar" onclick="btnMigrarRev_Click" />
                    <br />

                    <asp:GridView ID="gvData2" runat="server"> </asp:GridView>  

            </asp:View>
            <asp:View ID="View3" runat="server">
                <h3>LOTES CREADOS EN CARTERA PERO NO EN ODOO<br /></h3>
                <table>
                    <tr>
                        <td>Urbanizacion:</td>
                        <td>
                        <asp:DropDownList ID="ddlUrbanizacion" runat="server" DataSourceID="odsUrbanizacion" DataTextField="nombre" DataValueField="id_urbanizacion" AutoPostBack="True" OnSelectedIndexChanged="ddlUrbanizacion_SelectedIndexChanged"></asp:DropDownList>
                            <asp:ObjectDataSource ID="odsUrbanizacion" runat="server" SelectMethod="Lista" TypeName="terrasur.urbanizacion">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="0" Name="Id_localizacion" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>Manzano:</td>
                        <td><asp:DropDownList ID="ddlManzano" runat="server" DataSourceID="odsManzano" DataTextField="codigo" DataValueField="id_manzano" AutoPostBack="True" OnSelectedIndexChanged="ddlManzano_SelectedIndexChanged"></asp:DropDownList>
                            <asp:ObjectDataSource ID="odsManzano" runat="server" SelectMethod="Lista" TypeName="terrasur.manzano">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlUrbanizacion" DefaultValue="999999" Name="Id_urbanizacion" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td>Lotes:</td>
                        <td>
                            <asp:CheckBoxList ID="cblLote" runat="server" DataSourceID="odsLote" DataTextField="codigo" DataValueField="id_lote">
                            </asp:CheckBoxList>
                            <asp:ObjectDataSource ID="odsLote" runat="server" SelectMethod="Lista" TypeName="terrasur.lote">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="ddlManzano" DefaultValue="99999" Name="Id_manzano" PropertyName="SelectedValue" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnMigrarLotes" runat="server" Text="Migrar Lotes" 
                     onclick="btnMigrarLotes_Click" /></td>
                        <td></td>
                    </tr>
                </table>
            </asp:View>
        </asp:MultiView>
    </div>
    </form>
    
</body>
</html>
