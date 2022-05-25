<%@ Control Language="VB" ClassName="tarjetaCreditoAbm" %>

<script runat="server">
    Protected Property id_tarjetacredito() As Integer
        Get
            Return Integer.Parse(lbl_id_tarjetacredito.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_tarjetacredito.Text = value
        End Set
    End Property
    
    Public Sub CargarInsertar()
        id_tarjetacredito = 0
        
        txt_num_tarjeta.Text = ""
        ddl_mes.SelectedIndex = 0
        ddl_anio.SelectedIndex = 0
        rbl_tipo_tarjeta.DataBind()
        If rbl_tipo_tarjeta.Items.Count > 0 Then
            rbl_tipo_tarjeta.SelectedIndex = 0
        End If
        ddl_banco.DataBind()
        txt_titular.Text = ""
        txt_ci.Text = ""
        ddl_lugar_cedula.DataBind()
        rbl_activo.SelectedValue = "true"
        
        txt_num_tarjeta.Focus()
    End Sub
    Public Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        If tarjeta_credito.VerificarNumero(True, 0, txt_num_tarjeta.Text.Trim) = True Then
            Msg1.Text = "El número de tarjeta (" & txt_num_tarjeta.Text.Trim & ") ya esta registrada o pertenece a otro cliente"
            correcto = False
        End If
        If rbl_tipo_tarjeta.Items.Count = 0 Then
            Msg1.Text = "No exixten tipos de tarjeta registrados"
            correcto = False
        End If
        If ddl_banco.Items.Count = 0 Then
            Msg1.Text = "No exixten bancos registrados"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim tcObj As New tarjeta_credito(Integer.Parse(rbl_tipo_tarjeta.SelectedValue), Integer.Parse(ddl_banco.SelectedValue), Integer.Parse(ddl_lugar_cedula.SelectedValue), txt_titular.Text.Trim, txt_ci.Text.Trim, txt_num_tarjeta.Text.Trim, ddl_mes.SelectedValue, ddl_anio.SelectedValue, Boolean.Parse(rbl_activo.SelectedValue))
            If tcObj.Insertar(Profile.id_usuario) Then
                Msg1.Text = "La tarjeta de credito se guardó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "La tarjeta de credito NO se guardó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Sub CargarActualizar(ByVal _Id_tarjetacredito As Integer)
        id_tarjetacredito = _Id_tarjetacredito
        Dim tcObj As New tarjeta_credito(id_tarjetacredito)
        
        txt_num_tarjeta.Text = tcObj.numero
        ddl_mes.SelectedValue = tcObj.vencimiento_mes
        ddl_anio.SelectedValue = tcObj.vencimiento_anio
        rbl_tipo_tarjeta.DataBind()
        rbl_tipo_tarjeta.SelectedValue = tcObj.id_tipotarjetacredito
        ddl_banco.DataBind()
        ddl_banco.SelectedValue = tcObj.id_banco
        txt_titular.Text = tcObj.titular
        txt_ci.Text = tcObj.ci
        ddl_lugar_cedula.SelectedValue = tcObj.id_lugarcedula
        If tcObj.activo = True Then
            rbl_activo.SelectedValue = "true"
        Else
            rbl_activo.SelectedValue = "false"
        End If
        txt_num_tarjeta.Focus()
    End Sub
    Public Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True
        If tarjeta_credito.VerificarNumero(False, id_tarjetacredito, txt_num_tarjeta.Text.Trim) = True Then
            Msg1.Text = "El número de tarjeta (" & txt_num_tarjeta.Text.Trim & ") ya esta registrada o pertenece a otro cliente"
            correcto = False
        End If
        If rbl_tipo_tarjeta.Items.Count = 0 Then
            Msg1.Text = "No exixten tipos de tarjeta registrados"
            correcto = False
        End If
        If ddl_banco.Items.Count = 0 Then
            Msg1.Text = "No exixten bancos registrados"
            correcto = False
        End If
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim tcObj As New tarjeta_credito(id_tarjetacredito, Integer.Parse(rbl_tipo_tarjeta.SelectedValue), Integer.Parse(ddl_banco.SelectedValue), Integer.Parse(ddl_lugar_cedula.SelectedValue), txt_titular.Text.Trim, txt_ci.Text.Trim, txt_num_tarjeta.Text.Trim, ddl_mes.SelectedValue, ddl_anio.SelectedValue, Boolean.Parse(rbl_activo.SelectedValue))
            If tcObj.Actualizar(Profile.id_usuario) Then
                Msg1.Text = "La tarjeta de credito se actualizó correctamente"
                CargarInsertar()
                Return True
            Else
                Msg1.Text = "La tarjeta de credito NO se actualizó correctamente"
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Sub lb_verificar_tarjeta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lb_verificar_tarjeta.Click
        If tarjeta_credito.VerificarNumero(id_tarjetacredito.Equals(0), id_tarjetacredito, txt_num_tarjeta.Text.Trim) = True Then
            Msg1.Text = "El número de tarjeta (" & txt_num_tarjeta.Text.Trim & ") pertenece a otra tarjeta registrada"
        Else
            Msg1.Text = "Número de tarjeta disponible"
        End If
    End Sub
</script>
<asp:Label ID="lbl_id_tarjetacredito" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_tarjeta" runat="server" DisplayMode="List" ValidationGroup="tarjeta" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos de la tarjeta de credito"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Nº tarjeta:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_num_tarjeta" runat="server" SkinID="txtSingleLine200" MaxLength="30"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_num_tarjeta" runat="server" ControlToValidate="txt_num_tarjeta" Display="Dynamic" ValidationGroup="tarjeta" Text="*" ErrorMessage="Debe introducir el número de tarjeta"></asp:RequiredFieldValidator>
            <asp:LinkButton ID="lb_verificar_tarjeta" runat="server" Text="Verificar"></asp:LinkButton>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Fecha de vencicmiento:</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>Mes:</td>
                    <td>
                        <asp:DropDownList ID="ddl_mes" runat="server">
                            <asp:ListItem Text="Enero" Value="01" />
                            <asp:ListItem Text="Febrero" Value="02" />
                            <asp:ListItem Text="Marzo" Value="03" />
                            <asp:ListItem Text="Abril" Value="04" />
                            <asp:ListItem Text="Mayo" Value="05" />
                            <asp:ListItem Text="Junio" Value="06" />
                            <asp:ListItem Text="Julio" Value="07" />
                            <asp:ListItem Text="Agosto" Value="08" />
                            <asp:ListItem Text="Septiembre" Value="09" />
                            <asp:ListItem Text="Octubre" Value="10" />
                            <asp:ListItem Text="Noviembre" Value="11" />
                            <asp:ListItem Text="Diciembre" Value="12" />
                        </asp:DropDownList>
                    </td>
                    <td>Año:</td>
                    <td>
                        <asp:DropDownList ID="ddl_anio" runat="server">
                            <asp:ListItem Text="2010" Value="10" />
                            <asp:ListItem Text="2011" Value="11" />
                            <asp:ListItem Text="2012" Value="12" />
                            <asp:ListItem Text="2013" Value="13" />
                            <asp:ListItem Text="2014" Value="14" />
                            <asp:ListItem Text="2015" Value="15" />
                            <asp:ListItem Text="2016" Value="16" />
                            <asp:ListItem Text="2017" Value="17" />
                            <asp:ListItem Text="2018" Value="18" />
                            <asp:ListItem Text="2019" Value="19" />
			    <asp:ListItem Text="2020" Value="20" />
                            <asp:ListItem Text="2021" Value="21" />
                            <asp:ListItem Text="2022" Value="22" />
                            <asp:ListItem Text="2023" Value="23" />
                            <asp:ListItem Text="2024" Value="24" />
                            <asp:ListItem Text="2025" Value="25" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Tipo de tarjeta:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_tipo_tarjeta" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal" 
            DataSourceID="ods_lista_tipo_tarjeta" DataTextField="nombre" DataValueField="id_tipotarjetacredito">
            </asp:RadioButtonList>
            <%--[id_tipotarjetacredito],[codigo],[nombre],[num_tarjetas]--%>
            <asp:ObjectDataSource ID="ods_lista_tipo_tarjeta" runat="server" TypeName="terrasur.tipo_tarjeta_credito" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Banco:</td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_banco" runat="server" DataSourceID="ods_lista_banco" DataTextField="nombre" DataValueField="id_banco">
            </asp:DropDownList>
            <%--[id_banco],[id_usuario],[codigo],[nombre],[activo],[num_cheques]--%>
            <asp:ObjectDataSource ID="ods_lista_banco" runat="server" TypeName="terrasur.banco" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Titular:</td>
        <td class="formTdDato">
            <asp:TextBox ID="txt_titular" runat="server" SkinID="txtSingleLine200" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_titular" runat="server" ControlToValidate="txt_titular" Display="Dynamic" ValidationGroup="tarjeta" Text="*" ErrorMessage="Debe introducir el nombre del titular"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Titular (CI):</td>
        <td class="formTdDato">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:TextBox ID="txt_ci" runat="server" SkinID="txtSingleLine50" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="true" ValidationGroup="tarjeta" Text="*" ErrorMessage="Debe introducir el C.I. del titular"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_ci" runat="server" ControlToValidate="txt_ci" Display="Dynamic" SetFocusOnError="True" ValidationGroup="tarjeta" ValidationExpression="<%$ AppSettings:cliente_ExpReg_ci %>" Text="*" ErrorMessage="El C.I. contiene caracteres inválidos"></asp:RegularExpressionValidator> 
                    </td>
                    <td><asp:DropDownList ID="ddl_lugar_cedula" runat="server" DataSourceID="ods_lista_lugar_cedula" DataTextField="codigo" DataValueField="id_lugarcedula"></asp:DropDownList></td>

                </tr>
            </table>
            <%--[id_lugarcedula],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_lista_lugar_cedula" runat="server" TypeName="terrasur.lugar_cedula" SelectMethod="Lista"></asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun">Tarjeta activa:</td>
        <td class="formTdDato">
            <asp:RadioButtonList ID="rbl_activo" runat="server" CellPadding="0" CellSpacing="0" RepeatDirection="Horizontal">
                <asp:ListItem Text="Activa" Value="true" Selected="true" />
                <asp:ListItem Text="Inactiva" Value="false" />
            </asp:RadioButtonList>
        </td>
    </tr>

</table>