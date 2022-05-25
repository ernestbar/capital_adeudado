<%@ Control Language="VB" ClassName="cambioEstadoLote" %>

<script runat="server">
    Public Property id_lote() As Integer
        Get
            Return Integer.Parse(lbl_id_lote.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_lote.Text = value
        End Set
    End Property
    Public Property id_manzano() As Integer
        Get
            Return Integer.Parse(lbl_id_manzano.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_manzano.Text = value
        End Set
    End Property
    Public Property id_urbanizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_urbanizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_urbanizacion.Text = value
        End Set
    End Property
    Public Property id_localizacion() As Integer
        Get
            Return Integer.Parse(lbl_id_localizacion.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_localizacion.Text = value
        End Set
    End Property
    Protected Property id_estado_bloqueado() As Integer
        Get
            Return Integer.Parse(lbl_id_estado_bloqueado.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_estado_bloqueado.Text = value
        End Set
    End Property
    Protected Property id_motivobloqueo_intercambio() As Integer
        Get
            Return Integer.Parse(lbl_id_motivobloqueo_intercambio.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_motivobloqueo_intercambio.Text = value
        End Set
    End Property
    
    Public Sub CargarActualizar(ByVal _Id_lote As Integer)
        id_lote = _Id_lote
        Dim loteObj As New lote(id_lote)
        Dim negocio_lote As New negocio_lote(loteObj.id_negociolote)
        id_manzano = loteObj.id_manzano
        lbl_manzano.Text = loteObj.codigo_manzano
        lbl_localizacion.Text = loteObj.nombre_localizacion
        lbl_urbanizacion.Text = loteObj.nombre_urbanizacion
        lbl_lote.Text = loteObj.codigo
        lbl_estado_actual.Text = loteObj.nombre_estado
        txt_observacion.Text = ""
        id_estado_bloqueado = New estado("blo").id_estado
        id_motivobloqueo_intercambio = New motivo_bloqueo("int").id_motivobloqueo
        ddl_estado.DataBind()
    End Sub
    Public Function Actualizar() As Boolean
        Dim est_lote As New estado_lote(ddl_estado.SelectedValue, id_lote, 0, 0, txt_observacion.Text)
        If est_lote.Insertar(Profile.id_usuario) Then

            If Integer.Parse(ddl_estado.SelectedValue) = id_estado_bloqueado Then
                motivo_bloqueo.AsociarMotivoBloqueoConEstadoLote(est_lote.id_estadolote, Integer.Parse(ddl_motivo_bloqueo.SelectedValue))
                If Integer.Parse(ddl_motivo_bloqueo.SelectedValue) = id_motivobloqueo_intercambio Then
                    Dim intObj As New intercambio(0, est_lote.id_estadolote, DateTime.Now.Date, txt_empresa.Text.Trim, txt_descripcion.Text.Trim)
                    intObj.Insertar(Profile.id_usuario)
                End If
            End If
            
            Msg1.Text = "El estado del lote se guardó correctamente"
            Return True
        Else
            Msg1.Text = "El estado del lote NO se guardó correctamente"
            Return False
        End If
    End Function

    Protected Sub ddl_estado_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_estado.SelectedIndexChanged, ddl_estado.DataBound
        If Integer.Parse(ddl_estado.SelectedValue) = id_estado_bloqueado Then
            lbl_motivo_bloqueo.Visible = True
            ddl_motivo_bloqueo.Visible = True
            rfv_motivo_bloqueo.Enabled = True
            ddl_motivo_bloqueo.DataBind()
        Else
            lbl_motivo_bloqueo.Visible = False
            ddl_motivo_bloqueo.Visible = False
            rfv_motivo_bloqueo.Enabled = False
            panel_intercambio.Visible = False
        End If
    End Sub

    Protected Sub ddl_motivo_bloqueo_DataBound_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl_motivo_bloqueo.DataBound, ddl_motivo_bloqueo.SelectedIndexChanged
        If Integer.Parse(ddl_motivo_bloqueo.SelectedValue) = id_motivobloqueo_intercambio Then
            panel_intercambio.Visible = True
            txt_empresa.Text = ""
            txt_descripcion.Text = ""
            txt_empresa.Focus()
        Else
            panel_intercambio.Visible = False
        End If
    End Sub
</script>

<asp:Label ID="lbl_id_lote" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_manzano" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_estado_bloqueado" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_motivobloqueo_intercambio" runat="server" Text="0" Visible="false"></asp:Label>
<table class="formTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
            <asp:ValidationSummary ID="vs_lote" runat="server" DisplayMode="List" ValidationGroup="lote" />
        </td>
    </tr>
    <tr>
        <td class="formTdTitle" colspan="2">
            <asp:Label ID="lbl_title" runat="server" Text="Datos del lote"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_localizacion_enun" runat="server" Text="Localización:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_localizacion" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_urbanizacion_enun" runat="server" Text="Sector:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_urbanizacion" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_manzano_enun" runat="server" Text="Manzano:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_manzano" runat="server" ></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_lote_enun" runat="server" Text="Lote:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_lote" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_estado_actual_enun" runat="server" Text="Estado Actual:"></asp:Label></td>
        <td class="formTdDato"><asp:Label ID="lbl_estado_actual" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_estados_enum" runat="server" Text="Cambiar el estado a:"></asp:Label></td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_estado" runat="server" DataSourceID="ods_estado_lista" DataTextField="nombre" DataValueField="id_estado" AutoPostBack="true" />
            <%--[id_estado],[nombre]--%>
            <asp:ObjectDataSource ID="ods_estado_lista" runat="server" TypeName="terrasur.estado" SelectMethod="Lista_cambiar">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_motivo_bloqueo" runat="server" Text="Motivo de bloqueo:" Visible="false"></asp:Label></td>
        <td class="formTdDato">
            <asp:DropDownList ID="ddl_motivo_bloqueo" runat="server" DataSourceID="ods_motivo_bloqueo_lista" DataTextField="nombre" DataValueField="id_motivobloqueo" AutoPostBack="true" Visible="false"></asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_motivo_bloqueo" runat="server" ControlToValidate="ddl_motivo_bloqueo" ValidationGroup="lote" Text="*" ErrorMessage="Debe elegir el motivo de bloqueo del lote" Enabled="false"></asp:RequiredFieldValidator>
            <%--[id_motivobloqueo],[codigo],[nombre]--%>
            <asp:ObjectDataSource ID="ods_motivo_bloqueo_lista" runat="server" TypeName="terrasur.motivo_bloqueo" SelectMethod="Lista">
            </asp:ObjectDataSource>
        </td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Panel ID="panel_intercambio" runat="server" GroupingText="Intercambio" Visible="false">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="formTdEnun">Empresa/Persona:</td>
                        <td class="formTdDato">
                            <asp:TextBox ID="txt_empresa" runat="server" MaxLength="50">
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv_empresa" runat="server" ControlToValidate="txt_empresa" ValidationGroup="lote" Text="*" ErrorMessage="Sebe introducir el nombre de la Empresa o Persona con quien se está realizando el intercambio"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <td class="formTdEnun">Fecha del intercambio:</td>
                        <td class="formTdDato">
                            <ew:CalendarPopup ID="cp_fecha" runat="server">
                            </ew:CalendarPopup>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="formTdEnun">Descripción:</td>
                        <td class="formTdDato">
                            <asp:TextBox ID="txt_descripcion" runat="server" MaxLength="1000">
                            </asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="formTdEnun"><asp:Label ID="lbl_observacion_enun" runat="server" Text="Observación:"></asp:Label></td>
        <td class="formTdDato"><asp:TextBox TextMode="MultiLine"  ID="txt_observacion" runat="server" SkinID="txtSingleLine200" MaxLength="500"></asp:TextBox></td>
    </tr>
</table>