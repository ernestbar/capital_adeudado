<%@ Control Language="VB" ClassName="grupoTransaccionAbm" %>

<script runat="server">
    Protected Property id_grupotransaccion() As Integer
        Get
            Return Integer.Parse(lbl_id_grupotransaccion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_grupotransaccion.Text = value
        End Set
    End Property

    Protected Sub gv_transaccion_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gv_transaccion.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim cb_elegir As CheckBox = CType(e.Row.Cells(0).FindControl("cb_elegir"), CheckBox)
            If id_grupotransaccion = 0 Then
                Dim permitir_debito As Boolean = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_debito").ToString)
                cb_elegir.Enabled = permitir_debito
            Else
                'Dim id_tarjetacreditocontrato As Integer = Integer.Parse(DataBinder.Eval(e.Row.DataItem, "id_tarjetacreditocontrato").ToString)
                Dim elegido As Boolean = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "elegido").ToString)
                Dim permitir_debito As Boolean = Boolean.Parse(DataBinder.Eval(e.Row.DataItem, "permitir_debito").ToString)
                cb_elegir.Enabled = permitir_debito
                cb_elegir.Checked = elegido
                If cb_elegir.Enabled = False And cb_elegir.Checked = True Then
                    cb_elegir.Enabled = True
                    e.Row.CssClass = "cajaGvRowUltimo" '"gvRowSelected"
                End If
            End If
        End If
    End Sub
    
    Public Sub CargarInsertar()
        lbl_fecha_referencia.Text = DateTime.Now.ToString("d")
        id_grupotransaccion = 0
        lbl_numero.Text = grupo_transaccion.SiguienteNumero
        ddl_mes.DataBind()
        Dim mes_actual As String
        If DateTime.Now.Month < 10 Then
            mes_actual = "0" & DateTime.Now.Month.ToString
        Else
            mes_actual = DateTime.Now.Month.ToString
        End If
        If ddl_mes.Items.FindByValue(mes_actual) IsNot Nothing Then
            ddl_mes.SelectedValue = mes_actual
        End If
        
        ddl_anio.DataBind()
        cp_fecha_debito.SelectedDate = DateTime.Now
        gv_transaccion.DataBind()
        'btn_guardar.Enabled = True
    End Sub
    Protected Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True

        'Se verifica que la fecha de debito esta en el periodo
        Dim periodo_inicio As DateTime = DateTime.Parse("01/" & ddl_mes.SelectedValue & "/20" & ddl_anio.SelectedValue)
        Dim periodo_fin As DateTime = periodo_inicio.AddMonths(1)
        If cp_fecha_debito.SelectedDate < periodo_inicio Or cp_fecha_debito.SelectedDate >= periodo_fin Then
            correcto = False
            Msg1.Text = "La fecha de debito (" & cp_fecha_debito.SelectedDate.ToString("d") & ") esta fuera del periodo (" & periodo_inicio.ToString("d") & " de " & periodo_fin.AddDays(-1).ToString("d") & ")"
        End If
        
        'Se verifica que la fecha de debito sea igual o posterior a la fecha actual
        If cp_fecha_debito.SelectedDate < DateTime.Now.Date Then
            correcto = False
            Msg1.Text = "La fecha de debito (" & cp_fecha_debito.SelectedDate.ToString("d") & ") no puede ser anterio a la fecha actual (" & DateTime.Now.ToString("d") & ")"
        End If
        
        'Se verifica que se haya seleccionado algún contrato
        Dim seleccionado As Boolean = False
        For Each fila_gv As GridViewRow In gv_transaccion.Rows
            If CType(fila_gv.Cells(0).FindControl("cb_elegir"), CheckBox).Checked = True Then
                seleccionado = True
                Exit For
            End If
        Next
        If seleccionado = False Then
            correcto = False
            Msg1.Text = "Debe seleccinar algún debito a realizar"
        End If

        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() = True Then
            Dim gObj As New grupo_transaccion(grupo_transaccion.SiguienteNumero, ddl_mes.SelectedValue, ddl_anio.SelectedValue, cp_fecha_debito.SelectedDate)
            If gObj.Insertar(Profile.id_usuario) = True Then
                Dim num_items As Integer = 0, num_items_registrados As Integer = 0
                
                For Each fila_gv As GridViewRow In gv_transaccion.Rows
                    If CType(fila_gv.Cells(0).FindControl("cb_elegir"), CheckBox).Checked = True Then
                        Dim id_tarjetacreditocontrato As Integer = Integer.Parse(CType(fila_gv.Cells(0).FindControl("lbl_id_tarjetacreditocontrato"), Label).Text)
                        Dim tct As New tarjeta_credito_transaccion(gObj.id_grupotransaccion, id_tarjetacreditocontrato)
                        If tct.Insertar(Profile.id_usuario) = True Then
                            num_items_registrados += 1
                        End If
                        num_items += 1
                    End If
                Next
                'btn_guardar.Enabled = False
                Msg1.Text = "Las transacciones para el debito automático se guardaron correctamente (" & num_items_registrados & " de " & num_items & ")"
                Return True
            Else
                Msg1.Text = "Las transacciones para el debito automático NO se guardaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function
    
    
    
    Public Sub CargarActualizar(ByVal _Id_grupotransaccion As Integer)
        Dim gtObj As New grupo_transaccion(_Id_grupotransaccion)
        id_grupotransaccion = gtObj.id_grupotransaccion
        lbl_fecha_referencia.Text = gtObj.fecha_debito.ToString("d")
        lbl_numero.Text = gtObj.numero
        ddl_mes.DataBind()
        ddl_mes.SelectedValue = gtObj.periodo_deuda_mes
        ddl_anio.DataBind()
        ddl_anio.SelectedValue = gtObj.periodo_deuda_anio
        cp_fecha_debito.SelectedDate = gtObj.fecha_debito
        gv_transaccion.DataBind()
        'btn_guardar.Enabled = True
    End Sub
    Protected Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True

        'Se verifica que la fecha de debito esta en el periodo
        Dim periodo_inicio As DateTime = DateTime.Parse("01/" & ddl_mes.SelectedValue & "/20" & ddl_anio.SelectedValue)
        Dim periodo_fin As DateTime = periodo_inicio.AddMonths(1)
        If cp_fecha_debito.SelectedDate < periodo_inicio Or cp_fecha_debito.SelectedDate >= periodo_fin Then
            correcto = False
            Msg1.Text = "La fecha de debito (" & cp_fecha_debito.SelectedDate.ToString("d") & ") esta fuera del periodo (" & periodo_inicio.ToString("d") & " - " & periodo_fin.AddDays(-1).ToString("d") & ")"
        End If
        
        'Se verifica que la fecha de debito sea igual o posterior a la fecha actual
        If cp_fecha_debito.SelectedDate < DateTime.Now.Date Then
            correcto = False
            Msg1.Text = "La fecha de debito (" & cp_fecha_debito.SelectedDate.ToString("d") & ") no puede ser anterior a la fecha actual (" & DateTime.Now.ToString("d") & ")"
        End If
        
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() = True Then
            Dim gObj As New grupo_transaccion(id_grupotransaccion, Integer.Parse(lbl_numero.Text), ddl_mes.SelectedValue, ddl_anio.SelectedValue, cp_fecha_debito.SelectedDate)
            If gObj.Actualizar(Profile.id_usuario) = True Then
                Dim num_items As Integer = 0, num_item_modificados As Integer = 0
                For Each fila_gv As GridViewRow In gv_transaccion.Rows
                    Dim cb_elegir As CheckBox = CType(fila_gv.Cells(0).FindControl("cb_elegir"), CheckBox)
                    Dim id_tarjetacreditocontrato As Integer = Integer.Parse(CType(fila_gv.Cells(0).FindControl("lbl_id_tarjetacreditocontrato"), Label).Text)
                    
                    If cb_elegir.Checked = True AndAlso tarjeta_credito_transaccion.Verificar(id_grupotransaccion, id_tarjetacreditocontrato) = False Then
                        num_items += 1
                        Dim tct As New tarjeta_credito_transaccion(gObj.id_grupotransaccion, id_tarjetacreditocontrato)
                        If tct.Insertar(Profile.id_usuario) Then
                            num_item_modificados += 1
                        End If
                    ElseIf cb_elegir.Checked = False AndAlso tarjeta_credito_transaccion.Verificar(id_grupotransaccion, id_tarjetacreditocontrato) = True Then
                        num_items += 1
                        Dim tct As New tarjeta_credito_transaccion(gObj.id_grupotransaccion, id_tarjetacreditocontrato)
                        If tct.Eliminar(Profile.id_usuario) Then
                            num_item_modificados += 1
                        End If
                    End If
                Next
                'btn_guardar.Enabled = False
                Msg1.Text = "Las transacciones para el debito automático se actualizaron correctamente (" & num_item_modificados & " de " & num_items & ")"
                Return True
            Else
                Msg1.Text = "Las transacciones para el debito automático NO se guardaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

</script>
<asp:Label ID="lbl_id_grupotransaccion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha_referencia" runat="server" Text="01/01/2010" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_grupo" runat="server" DisplayMode="List" ValidationGroup="grupo" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle">Generación de transacciones</td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" align="left">
                <tr>
                    <td class="formTdEnun">Grupo de transacciones:</td>
                    <td class="formTdDato">
                        <asp:Label ID="lbl_numero" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Periodo del debito:</td>
                    <td class="formTdDato">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:DropDownList ID="ddl_mes" runat="server" DataSourceID="ods_lista_mes" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                                    <%--[codigo],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_mes" runat="server" TypeName="terrasur.grupo_transaccion" SelectMethod="ListaMesParaDebito">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Fecha_referencia" Type="String" ControlID="lbl_fecha_referencia" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddl_anio" runat="server" DataSourceID="ods_lista_anio" DataValueField="codigo" DataTextField="nombre"></asp:DropDownList>
                                    <%--[codigo],[nombre]--%>
                                    <asp:ObjectDataSource ID="ods_lista_anio" runat="server" TypeName="terrasur.grupo_transaccion" SelectMethod="ListaAnioParaDebito">
                                        <SelectParameters>
                                            <asp:ControlParameter Name="Fecha_referencia" Type="String" ControlID="lbl_fecha_referencia" PropertyName="Text" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </td>
                                <td>
                                    <asp:Button ID="btn_mostrar" runat="server" Text="Generar" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="formTdEnun">Fecha de debito:</td>
                    <td class="formTdDato">
                        <ew:CalendarPopup ID="cp_fecha_debito" runat="server"></ew:CalendarPopup>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="gv_transaccion" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_transaccion" DataKeyNames="id_tarjetacreditocontrato">
                <Columns>
                    <asp:TemplateField HeaderText="Contrato" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:CheckBox ID="cb_elegir" runat="server" Text='<%# Eval("num_contrato") %>' />
                            <asp:Label ID="lbl_id_tarjetacreditocontrato" runat="server" Visible="false" Text='<%# Eval("id_tarjetacreditocontrato") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:BoundField HeaderText="Nº contrato" DataField="num_contrato" />--%>
                    <asp:BoundField HeaderText="Estado" DataField="estado" />

                    <asp:BoundField HeaderText="C.Mensual" DataField="cuota_base" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="F.Ult.Pago" DataField="fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                    <asp:BoundField HeaderText="F.Interes" DataField="interes_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                    <asp:BoundField HeaderText="F.Prox.Pago" DataField="fecha_proximo" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-CssClass="cajaGvCellDate" />
                    <asp:BoundField HeaderText="Saldo" DataField="saldo" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    
                    <asp:BoundField HeaderText="Importe ($us)" DataField="monto_sus" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Importe (Bs)" DataField="monto_bs" HtmlEncode="false" DataFormatString="{0:F2}" ItemStyle-CssClass="gvCell1" />
                    <asp:BoundField HeaderText="Nº tarjeta" DataField="num_tarjeta" />
                    <asp:BoundField HeaderText="F.Vencim." DataField="vencimiento" />
                    <asp:BoundField HeaderText="Periodicidad" DataField="periodicidad"/>
                    <asp:BoundField HeaderText="F.Debito" DataField="fecha_debito" HtmlEncode="false" DataFormatString="{0:dd}" ItemStyle-CssClass="cajaGvCellDate" />

                    <asp:BoundField HeaderText="Último debito" DataField="ultimo_debito" />
                </Columns>
            </asp:GridView>
            <%--[id_tarjetacreditocontrato],[num_contrato],[estado],[permitir_debito]
            [cuota_base],[fecha],[interes_fecha],[fecha_proximo],[saldo]
            [monto_sus],[monto_bs],[fecha_debito],[num_tarjeta],[titular],[ultimo_debito]--%>
            <asp:ObjectDataSource ID="ods_lista_transaccion" runat="server" TypeName="terrasur.tarjeta_credito_transaccion" SelectMethod="ListaPorPeriodo">
                <SelectParameters>
                    <asp:ControlParameter Name="Id_grupotransaccion" Type="Int32" ControlID="lbl_id_grupotransaccion" PropertyName="Text" />
                    <asp:ControlParameter Name="Periodo_deuda_mes" Type="String" ControlID="ddl_mes" PropertyName="SelectedValue" />
                    <asp:ControlParameter Name="Periodo_deuda_anio" Type="String" ControlID="ddl_anio" PropertyName="SelectedValue" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
    </tr>
    <%--<tr>
        <td align="center">
            <asp:Button ID="btn_guardar" runat="server" Text="Guardar grupo de transacciones" />
        </td>
    </tr>--%>
</table>