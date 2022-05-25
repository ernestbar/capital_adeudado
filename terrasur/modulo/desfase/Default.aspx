<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="modulo_desfase_Default" %>

<%@ Register Src="~/recurso/userControl/contratoBusqueda.ascx" TagPrefix="uc1" TagName="contratoBusqueda" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 style="text-align:center">ESTADO CONTRATO EN EL TIEMPO</h2><br />
         <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="formTdEnun">BUSCAR CONTRATO<br />
                                <uc1:contratoBusqueda runat="server" ID="ContratoBusqueda1" />
                                <asp:Button ID="btnVolver" runat="server" Text="Volver"  OnClick="btnVolver_Click"/>
                            </td>
                        </tr>
             <tr>
                  <td class="tdGrid"><br />
                      <asp:Panel ID="PanelEstao" runat="server" Visible="false">
                          <asp:Button ID="btnExportar" CssClass="tdButtonVolver" runat="server" Text="Exportar a excel" OnClick="btnExportar_Click" />
                            <asp:GridView ID="gv_estado" runat="server" AutoGenerateColumns="false" DataSourceID="ods_estado_contrato" DataKeyNames="id_contrato" OnRowDataBound="gv_estado_RowDataBound">
                                <Columns>
                                   <%-- <asp:ButtonField CommandName="ver" Text="Detalles" ButtonType="Image" ImageUrl="~/images/gv/view.gif" />--%>
                                    <asp:BoundField HeaderText="Mes" DataField="mes" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="Año" DataField="año" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Monto Pagado" DataField="monto_pag" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Interes" DataField="interes" ItemStyle-CssClass="gvCell1"/>
                                    <asp:BoundField HeaderText="Capital" DataField="capital" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="Cuota Base" DataField="cuota_base" ItemStyle-CssClass="gvCell1" />
                                     <asp:BoundField HeaderText="Interes Ideal" DataField="interesIdeal" ItemStyle-CssClass="gvCell1" />
                                    <asp:BoundField HeaderText="Capital Ideal" DataField="capitalIdeal" ItemStyle-CssClass="gvCell1" />
                                   <%--<asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Repeater ID="r_contrato" runat="server">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="hl_EstadoCuenta" runat="server" Text="Estado cuenta"  Target="_blank" NavigateUrl='<%# String.Format("~/recurso/inventario/lote/loteDetalleReporte.aspx?reporte={0}&contrato={1}", "EstadoCuenta", Eval("id_contrato")) %>'></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ItemTemplate>
                                   </asp:TemplateField>--%>
                                </Columns>
                            </asp:GridView>
                            <%-- [id_lote],[codigo],[superficie_m2],[costo_m2_sus],[precio_m2_sus],[nombre_estado],[nombre_lote]--%>
                            <asp:ObjectDataSource ID="ods_estado_contrato" runat="server" TypeName="terrasur.contratoReporte" SelectMethod="ReporteEstadoCuentaDesfase">
                                <SelectParameters>
                                   <asp:ControlParameter Name="Id_contrato" Type="Int32" ControlID="lblIdContrato" PropertyName="Text" />
                               </SelectParameters>
                            </asp:ObjectDataSource>
                          </asp:Panel>
                        </td>
                 
             </tr>
          </table>
        <asp:Label ID="lblIdContrato" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
