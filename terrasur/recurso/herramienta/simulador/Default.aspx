<%@ Page Language="VB" MasterPageFile="~/modulo/normal.master" Title="Simulador del Plan de Pagos" %>
<%@ Register Src="~/recurso/userControl/recursoMaster.ascx" TagName="recursoMaster" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/userControl/reporte.ascx" TagName="reporte" TagPrefix="uc2" %>

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        If Not Page.IsPostBack Then
            If Not permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "simulador", "simular") Then
                Response.Redirect("~/modulo/" & Profile.entorno.codigo_modulo & "/Default.aspx")
            End If
        End If
    End Sub
    
    Protected Sub btn_simular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_simular.Click
        Dim Codigo_moneda As String = New moneda(Integer.Parse(rbl_moneda.SelectedValue)).codigo

        Dim rep As New simulacion
        
        rep.DataSource = simular.tabla_plan_simulado(simular.lista_plan_simulado(Decimal.Parse(txt_capital.Text.Trim), _
            Decimal.Parse(txt_inicial.Text.Trim), Integer.Parse(txt_num_cuota.Text.Trim), Integer.Parse(txt_num_gracia.Text.Trim), _
            Decimal.Parse(txt_interes.Text.Trim), Decimal.Parse(txt_desgravamen.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim), _
            c_inicio.SelectedDate))
        
        rep.CargarDatos(txt_cliente.Text.Trim, txt_ci.Text.Trim, Decimal.Parse(txt_capital.Text.Trim), Decimal.Parse(txt_inicial.Text.Trim), Integer.Parse(txt_num_cuota.Text.Trim), Integer.Parse(txt_num_gracia.Text.Trim), _
            Decimal.Parse(txt_interes.Text.Trim), Decimal.Parse(txt_desgravamen.Text.Trim), Decimal.Parse(txt_mantenimiento.Text.Trim), _
            c_inicio.SelectedDate, rbl_moneda.SelectedItem.Text.ToUpper(), Codigo_moneda)

        'rep.CalculatedFields("par_cliente").Value = txt_cliente.Text.Trim
        'rep.CalculatedFields("par_ci").Value = txt_ci.Text.Trim
        'rep.CalculatedFields("par_capital").Value = txt_capital.Text.Trim
        'rep.CalculatedFields("par_inicial").Value = txt_inicial.Text.Trim
        'rep.CalculatedFields("par_num_cuota").Value = txt_num_cuota.Text.Trim
        'rep.CalculatedFields("par_num_gracia").Value = txt_num_gracia.Text.Trim
        'rep.CalculatedFields("par_interes").Value = txt_interes.Text.Trim
        'rep.CalculatedFields("par_seguro").Value = txt_desgravamen.Text.Trim
        'rep.CalculatedFields("par_mantenimiento").Value = txt_mantenimiento.Text.Trim
        'rep.CalculatedFields("par_fecha_inicio").Value = c_inicio.SelectedDate.ToString
        'rep.Run()
        Reporte1.WebView.Report = rep

        'gv1.DataSource = simular.tabla_plan_simulado(simular.lista_plan_simulado(Decimal.Parse(txt_capital.Text), Decimal.Parse(txt_inicial.Text), Integer.Parse(txt_num_cuota.Text), Integer.Parse(txt_num_gracia.Text), Decimal.Parse(txt_interes.Text), Decimal.Parse(txt_desgravamen.Text), Decimal.Parse(txt_mantenimiento.Text), c_inicio.SelectedDate))
        'gv1.DataBind()
    End Sub

    Protected Sub rbl_moneda_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_moneda.DataBound
        If rbl_moneda.Items.Count > 0 Then
            rbl_moneda.SelectedIndex = 0
        End If
    End Sub
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
    <uc1:recursoMaster ID="RecursoMaster1" runat="server" recurso="simulador" MostrarLink="true" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">

    <table class="priTable">
        <tr><td class="priTdTitle">Simulación de plan de pagos</td></tr>
        <tr>
            <td class="priTdContenido">
                <asp:Panel ID="panel_contrato" runat="server" DefaultButton="btn_simular">
                    <table class="formEntTable">
                        <tr>
                            <td class="formTdMsg">
                                <asp:ValidationSummary ID="vs_plan" runat="server" DisplayMode="List" ShowMessageBox="false" ValidationGroup="plan" />
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdForm">
                                <table align="center">
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_cliente" runat="server" Width="100%" GroupingText="Datos del cliente">
                                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="formTdEnun">Nombre completo:</td>
                                                        <td class="formTdDato">
                                                            <asp:TextBox ID="txt_cliente" runat="server" SkinID="txtSingleLine400" MaxLength="100"></asp:TextBox>
                                                        </td>
                                                        <td class="formTdEnun">CI:</td>
                                                        <td class="formTdDato">
                                                            <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="plan" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                                                            <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine100" MaxLength="100"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="panel_plan" runat="server" Width="100%" GroupingText="Datos del plan de pagos">
                                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="formTdEnun">Moneda:</td>
                                                        <td class="formTdDato" colspan="3">
                                                            <asp:RadioButtonList ID="rbl_moneda" runat="server" DataSourceID="ods_lista_moneda" DataValueField="id_moneda" DataTextField="nombre_completo" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                                                            </asp:RadioButtonList>
                                                            <%--[id_moneda],[codigo],[nombre],[nombre_completo]--%>
                                                            <asp:ObjectDataSource ID="ods_lista_moneda" runat="server" TypeName="terrasur.moneda" SelectMethod="Lista">
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formTdEnun">Capital total:</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_capital" runat="server" ControlToValidate="txt_capital" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir el capital total"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="rv_capital" runat="server" ControlToValidate="txt_capital" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="0" MaximumValue="999999999" Type="Double" Text="*" ErrorMessage="El Capital total no puede ser menor a 0 ni mayor a 999999999"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_capital" runat="server" ControlToValidate="txt_capital" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_capital" runat="server" SkinID="txtSingleLine100" MaxLength="9" Text="10000" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                        </td>
                                                        <td class="formTdEnun">Fecha de inicio del plan:</td>
                                                        <td class="formTdDato"><ew:CalendarPopup ID="c_inicio" runat="server" Width="100px"></ew:CalendarPopup></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formTdEnun">Cuota inicial:</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_inicial" runat="server" ControlToValidate="txt_inicial" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir la cuota inicial"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="rv_inicial" runat="server" ControlToValidate="txt_inicial" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="0" MaximumValue="999999999" Type="Double" Text="*" ErrorMessage="La cuota inicial no puede ser menor a 0 ni mayor a 999999999"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_inicial" runat="server" ControlToValidate="txt_inicial" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cv_capital_inicial" runat="server" ControlToValidate="txt_inicial" ControlToCompare="txt_capital" Display="Dynamic" SetFocusOnError="true" ValidationGroup="cuota_base" Operator="LessThanEqual" Type="Double" Text="*" ErrorMessage="La cuota inicial no puede ser mayor que el capital total"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_inicial" runat="server" SkinID="txtSingleLine100" MaxLength="9" Text="100" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                        </td>
                                                        <td class="formTdEnun">Interés corriente (% anual):</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir el interés corriente anual"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="rv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="0" MaximumValue="100" Type="Double" Text="*" ErrorMessage="El interés corriente debe estar entre 0 y 100"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_interes" runat="server" ControlToValidate="txt_interes" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_interes" runat="server" SkinID="txtSingleLine100" MaxLength="6" Text="8" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>%
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formTdEnun">Nº de cuotas:</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir el número de cuotas"></asp:RequiredFieldValidator>
                                                            <%--<asp:RangeValidator ID="rv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="1" MaximumValue="<%$ AppSettings: contrato_max_num_cuotas %>" Type="Integer" Text="*" ErrorMessage="El número de cuotas debe estar entre 1 y 480"></asp:RangeValidator> --%>
                                                            <asp:RangeValidator ID="rv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="1" MaximumValue="480" Type="Integer" Text="*" ErrorMessage="El número de cuotas debe estar entre 1 y 480"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_num_cuota" runat="server" ControlToValidate="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Integer" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_num_cuota" runat="server" SkinID="txtSingleLine100" MaxLength="3" Text="120"></asp:TextBox>
                                                        </td>
                                                        <td class="formTdEnun">Seguro de desgravamen (% mensual):</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_desgravamen" runat="server" ControlToValidate="txt_desgravamen" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir el seguro de desgravamen"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="rv_desgravamen" runat="server" ControlToValidate="txt_desgravamen" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="0" MaximumValue="100" Type="Double" Text="*" ErrorMessage="El seguro de desgravamen debe estar entre 0 y 100"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_desgravamen" runat="server" ControlToValidate="txt_desgravamen" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número válido (usar , para decimales)"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_desgravamen" runat="server" SkinID="txtSingleLine100" MaxLength="6" Text="0,07" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>%
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="formTdEnun">Periodo de gracia (meses):</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_num_gracia" runat="server" ControlToValidate="txt_num_gracia" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir el número de meses de gracia"></asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="cv_num_gracia" runat="server" ControlToValidate="txt_num_gracia" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Integer" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cv_num_gracia_cuotas" runat="server" ControlToValidate="txt_num_gracia" ControlToCompare="txt_num_cuota" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="LessThan" Type="Integer" Text="*" ErrorMessage="El número de meses de gracia debe ser menor al número de cuotas"></asp:CompareValidator>
                                                            <asp:CompareValidator ID="cv_num_gracia_positivo" runat="server" ControlToValidate="txt_num_gracia" ValueToCompare="0" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="GreaterThanEqual" Type="Integer" Text="*" ErrorMessage="El número de meses de gracia debe ser 0 o superior 0"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_num_gracia" runat="server" Enabled="false" SkinID="txtSingleLine100" MaxLength="3" Text="0"></asp:TextBox>
                                                        </td>
                                                        <td class="formTdEnun">Cuota de mantenimiento (mensual):</td>
                                                        <td class="formTdDato">
                                                            <asp:RequiredFieldValidator ID="rfv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Text="*" ErrorMessage="Debe introducir la cuota de mantenimiento mensual"></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="rv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" MinimumValue="0" MaximumValue="99999" Type="Double" Text="*" ErrorMessage="La cuota de mantenimiento debe estar entre 0 y 99999"></asp:RangeValidator> 
                                                            <asp:CompareValidator ID="cv_mantenimiento" runat="server" ControlToValidate="txt_mantenimiento" Display="Dynamic" SetFocusOnError="true" ValidationGroup="plan" Operator="DataTypeCheck" Type="Double" Text="*" ErrorMessage="Debe introducir un número entero"></asp:CompareValidator>
                                                            <asp:TextBox ID="txt_mantenimiento" runat="server" Enabled="false" SkinID="txtSingleLine100" MaxLength="5" Text="0" onkeyup="e=event || window.event;el=e.srcElement || e.target;if(el.value.indexOf('.')>-1){el.value=el.value.split('.').join(',');}"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="formEntTdButton">
                                <asp:Button ID="btn_simular" runat="server" SkinID="btnAccion" Text="Simular" CausesValidation="true" ValidationGroup="plan" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>            
            </td>
        </tr>
        <tr>
            <td>
                <uc2:reporte ID="Reporte1" runat="server" />
                <%--<asp:GridView ID="gv1" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField HeaderText="Nº" DataField="num_pago" />
                        <asp:BoundField HeaderText="F.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="F.Proximo" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Nºcuotas" DataField="num_cuotas" />
                        <asp:BoundField HeaderText="Cuotas" DataField="string_cuotas" />
                        <asp:BoundField HeaderText="Pago" DataField="monto_pago" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="Seguro" DataField="seguro" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="F.Seguro" DataField="seguro_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="NºSegMeses" DataField="seguro_meses"/>
                        <asp:BoundField HeaderText="Manten." DataField="mantenimiento_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="F.Manten." DataField="mantenimiento_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="NºMantenMeses" DataField="mantenimiento_meses" />
                        <asp:BoundField HeaderText="Interes" DataField="interes" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="F.Interes" DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="NºdiasInt" DataField="interes_dias" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="NºdiasIntTot" DataField="interes_dias_total" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Amortiza" DataField="amortizacion" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                    </Columns>
                </asp:GridView>--%>
            </td>
        </tr>
    </table>
</asp:Content>

