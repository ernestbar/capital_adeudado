<%@ Control Language="VB" ClassName="impresoraAbm" %>

<script runat="server">
    Private Property id_impresora() As Integer
        Get
            Return Integer.Parse(lbl_id_impresora.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_impresora.Text = value
        End Set
    End Property
        
    Public Sub CargarInsertar()
        txt_nombre.Text = ""
        txt_direccion.Text = ""
        ddl_bandeja.SelectedIndex = 0
        cbl_documento.Items.FindByValue("factura").Selected = False
        cbl_documento.Items.FindByValue("recibo").Selected = False
        cbl_documento.Items.FindByValue("comprobante").Selected = False
        cbx_activo.Checked = True
        txt_nombre.Focus()
        
        panel_bandejas.Visible = False
        btn_bandeja_imprimir.Visible = False
    End Sub
    
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        'If impresora.Verificar(True, 0, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
        '    Msg1.Text = "El Código o nombre del impresora pertenece a otro impresora registrado"
        '    correcto = False
        'End If
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim direccion_red As String = txt_direccion.Text.Trim
            If Integer.Parse(ddl_bandeja.SelectedValue) >= 0 Then
                direccion_red = direccion_red & "|" & ddl_bandeja.SelectedValue
            End If
            
            Dim impresoraObj As New impresora(txt_nombre.Text.Trim, direccion_red, cbl_documento.Items.FindByValue("factura").Selected, cbl_documento.Items.FindByValue("recibo").Selected, cbl_documento.Items.FindByValue("comprobante").Selected, cbx_activo.Checked)
            If impresoraObj.Insertar() Then
                Msg1.Text = "La impresora se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "La impresora NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_impresora As Integer)
        id_impresora = _Id_impresora
        Dim i As New impresora(id_impresora)
        
        txt_nombre.Text = i.nombre
        If i.direccion_red.Contains("|") Then
            txt_direccion.Text = (i.direccion_red.Split("|"))(0)
            ddl_bandeja.SelectedValue = (i.direccion_red.Split("|"))(1)
        Else
            txt_direccion.Text = i.direccion_red
            ddl_bandeja.SelectedIndex = 0
        End If

        cbl_documento.Items.FindByValue("factura").Selected = i.factura
        cbl_documento.Items.FindByValue("recibo").Selected = i.recibo
        cbl_documento.Items.FindByValue("comprobante").Selected = i.comprobante
        
        cbx_activo.Checked = i.activo
        txt_nombre.Focus()

        panel_bandejas.Visible = False
        btn_bandeja_imprimir.Visible = False
    End Sub
    
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        'If impresora.VerificarCodigoNombre(False, id_impresora, txt_codigo.Text.Trim, txt_nombre.Text.Trim) = True Then
        '    Msg1.Text = "El Código o nombre del impresora pertenece a otro impresora registrado"
        '    correcto = False
        'End If
        Return correcto
    End Function
    
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim direccion_red As String = txt_direccion.Text.Trim
            
            If Integer.Parse(ddl_bandeja.SelectedValue) >= 0 Then
                direccion_red = direccion_red & "|" & ddl_bandeja.SelectedValue
            End If

            Dim impresoraObj As New impresora(id_impresora, txt_nombre.Text, direccion_red, cbl_documento.Items.FindByValue("factura").Selected, cbl_documento.Items.FindByValue("recibo").Selected, cbl_documento.Items.FindByValue("comprobante").Selected, cbx_activo.Checked)
            If impresoraObj.Actualizar() Then
                Msg1.Text = "Los datos de la impresora se actualizaron correctamente"
                Return True
            Else
                Msg1.Text = "Los datos de la impresora NO se actualizaron correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Sub btn_verificar_bandeja_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        
        If txt_direccion.Text.Trim <> "" Then
            Dim rep As New cajaTransaccionPruebaImpresion2
            rep.Run()
            Try
                rep.Document.Printer.PrinterName = txt_direccion.Text.Trim
                'rep.Document.Printer.PrinterSettings.Copies = 1
                rep.Document.Printer.DefaultPageSettings.PaperSource = rep.Document.Printer.PrinterSettings.PaperSources(1)
                'Dim PaperSizeRenacer As New System.Drawing.Printing.PaperSize("tamanioCarta", 850, 1100)
                'rep.Document.Printer.DefaultPageSettings.PaperSize = PaperSizeRenacer

                'Se despliegan las bandejas
                Dim tabla_bandejas As New Data.DataTable
                tabla_bandejas.Columns.Add("id_bandeja")
                tabla_bandejas.Columns.Add("nombre")
                For j As Integer = 0 To rep.Document.Printer.PrinterSettings.PaperSources.Count - 1
                    Dim fila_bandeja As Data.DataRow = tabla_bandejas.NewRow
                    fila_bandeja("id_bandeja") = j.ToString
                    fila_bandeja("nombre") = j.ToString & ": " & rep.Document.Printer.PrinterSettings.PaperSources(j).SourceName
                    tabla_bandejas.Rows.Add(fila_bandeja)
                Next
                
                rbl_bandeja.DataSource = tabla_bandejas
                rbl_bandeja.DataBind()
                panel_bandejas.Visible = True
            Catch ex As Exception
                panel_bandejas.Visible = False
                btn_bandeja_imprimir.Visible = False
            End Try
        Else
            panel_bandejas.Visible = False
            btn_bandeja_imprimir.Visible = False
        End If
    End Sub
    
    Protected Sub rbl_bandeja_DataBound(ByVal sender As Object, ByVal e As System.EventArgs)
        btn_bandeja_imprimir.Visible = rbl_bandeja.Items.Count.Equals(0).Equals(False)
    End Sub
    
    Protected Sub btn_bandeja_imprimir_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If txt_direccion.Text <> "" Then
            If rbl_bandeja.Items.Count > 0 And rbl_bandeja.SelectedIndex >= 0 Then
                Try
                    Dim rep As New cajaTransaccionPruebaImpresion2
                    rep.CargarDatos(txt_direccion.Text.Trim, Integer.Parse(rbl_bandeja.SelectedValue), (rbl_bandeja.SelectedItem.Text.Split(":"))(1).Trim)
                    rep.Run()

                    rep.Document.Printer.PrinterName = txt_direccion.Text.Trim
                    rep.Document.Printer.PrinterSettings.Copies = 1
                    rep.Document.Printer.DefaultPageSettings.PaperSource = rep.Document.Printer.PrinterSettings.PaperSources(Integer.Parse(rbl_bandeja.SelectedValue))
                    Dim PaperSizeLetter As New System.Drawing.Printing.PaperSize("tamanioCartaPrueba", 850, 1100)
                    'Dim PaperSizeLetter As New System.Drawing.Printing.PaperSize("tamanioCartaPrueba", 850, 1300)
                    rep.Document.Printer.DefaultPageSettings.PaperSize = PaperSizeLetter
                    rep.Document.Print(False, False, False)
                    
                    Msg1.Text = "Se envió una prueba de impresión"
                Catch ex As Exception
                    Msg1.Text = ex.Message
                End Try
            Else
                Msg1.Text = "Debe serccionar una bandeja"
            End If
        Else
            Msg1.Text = "Debe introducir la dirección de la impresora"
        End If
    End Sub
 
    


</script>

<asp:Label ID="lbl_id_impresora" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="3">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td valign="top">
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <%--<asp:Msg ID="Msg1" runat="server"></asp:Msg>--%>
            <asp:ValidationSummary ID="vs_impresora" runat="server" DisplayMode="List" ValidationGroup="impresora" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la impresora"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_nombre" runat="server" SkinID="txtSingleLine100" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="impresora" Text="*" ErrorMessage="Debe introducir el nombre de la impresora"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ControlToValidate="txt_nombre" Display="Dynamic" SetFocusOnError="true" ValidationGroup="impresora" Text="*" ErrorMessage="El nombre de la impresora contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:impresora_ExpReg_nombre %>"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_direccion_enun" runat="server" Text="Dirección de red:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0" align="left">
                <tr>
                    <td>
                        <asp:TextBox ID="txt_direccion" runat="server" SkinID="txtSingleLine200" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_direccion" runat="server" ControlToValidate="txt_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="impresora" Text="*" ErrorMessage="Debe introducir la dirección de la impresora"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_direccion" runat="server" ControlToValidate="txt_direccion" Display="Dynamic" SetFocusOnError="true" ValidationGroup="impresora" Text="*" ErrorMessage="La dirección de la impresora contiene caracteres inválidos" ValidationExpression="<%$ AppSettings:impresora_ExpReg_direccion %>"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_bandeja" runat="server">
                            <asp:ListItem Text="" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                            <asp:ListItem Text="6" Value="6"></asp:ListItem>
                            <asp:ListItem Text="7" Value="7"></asp:ListItem>
                            <asp:ListItem Text="8" Value="8"></asp:ListItem>
                            <asp:ListItem Text="9" Value="9"></asp:ListItem>
                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                            <asp:ListItem Text="13" Value="13"></asp:ListItem>
                            <asp:ListItem Text="14" Value="14"></asp:ListItem>
                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                            <asp:ListItem Text="16" Value="16"></asp:ListItem>
                            <asp:ListItem Text="17" Value="17"></asp:ListItem>
                            <asp:ListItem Text="18" Value="18"></asp:ListItem>
                            <asp:ListItem Text="19" Value="19"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:LinkButton ID="btn_verificar_bandeja" runat="server" Text="Verificar" OnClick="btn_verificar_bandeja_Click"></asp:LinkButton>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_documento_enum" runat="server" Text="Documento:"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBoxList ID="cbl_documento" runat="server" RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0">
                <asp:ListItem Text="Factura" Value="factura"></asp:ListItem>
                <asp:ListItem Text="Recibo" Value="recibo"></asp:ListItem>
                <asp:ListItem Text="Comprobante" Value="comprobante"></asp:ListItem>
            </asp:CheckBoxList>
        </td> 
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enum" runat="server" Text="Activo"></asp:Label>
        </td>
        <td class="formTdDato">
            <asp:CheckBox ID="cbx_activo" runat="server" Text="Impresora activa"/>
        </td>
    </tr>
</table>
        </td>
        <td valign="top">
            <asp:Panel ID="panel_bandejas" runat="server" GroupingText="Bandejas" Visible="false" Height="160" ScrollBars="Vertical" HorizontalAlign="Left">
                <asp:RadioButtonList ID="rbl_bandeja" runat="server" DataTextField="nombre" DataValueField="id_bandeja" OnDataBound="rbl_bandeja_DataBound"></asp:RadioButtonList>
            </asp:Panel>
        </td>
        <td valign="bottom">
            <asp:LinkButton ID="btn_bandeja_imprimir" runat="server" Text="Imprimir" Visible="false" OnClick="btn_bandeja_imprimir_Click"></asp:LinkButton>
        </td>
    </tr>
</table>
