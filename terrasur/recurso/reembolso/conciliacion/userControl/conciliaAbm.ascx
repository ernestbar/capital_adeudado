<%@ Control Language="VB" ClassName="conciliaAbm" %>
<%@ Register Src="~/recurso/reembolso/conciliacion/userControl/conciliacionAbm.ascx" TagPrefix="uc1" TagName="conciliacionAbm" %>
<%@ Register Src="~/recurso/reembolso/conciliacion/userControl/contratoConciliacionAbm.ascx" TagPrefix="uc2" TagName="contratoConciliacionAbm" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormLote.ascx" TagPrefix="uc3" TagName="contratoFormLote" %>


<script runat="server">
    Protected Property id_reembolso As Integer
        Get
            Return Integer.Parse(lbl_id_reembolso.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_reembolso.Text = value.ToString
        End Set
    End Property

    Protected Property id_contrato As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value.ToString
        End Set
    End Property

    Protected Property fecha As DateTime
        Get
            Return DateTime.Parse(lbl_fecha.Text)
        End Get
        Set(ByVal value As DateTime)
            lbl_fecha.Text = value.ToString
        End Set
    End Property

    Public Property insert() As Boolean
        Get
            Return Boolean.Parse(lbl_insertar.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_insertar.Text = value.ToString
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler conciliacionAbm1.Eleccion, AddressOf eleccion_contrato_origen_realizada
    End Sub

    Public Sub CargarInsertar()
        id_reembolso = 0
        insert = True
        conciliacionAbm1.CargarInsertar()
        panel_contrato.Visible = False
        panel_observacion.Visible = False
        panel_lote.Visible = False
        txt_observacion.Text = ""
    End Sub

    Private Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True

        If txt_observacion.Text.Trim = "" Then
            Msg1.Text = "Debe ingresar una observación"
            correcto = False
        End If

        If correcto Then
            If conciliacionAbm1.VerificarInsertar = False Then
                correcto = False
            End If
        End If

        If correcto Then
            If conciliacionAbm1.id_contrato_elegido <> id_contrato Or conciliacionAbm1.fecha <> fecha Then
                Msg1.Text = "Debe presionar el botón Obtener datos"
                panel_contrato.Visible = False
                panel_observacion.Visible = False
                panel_lote.Visible = False
                correcto = False
            End If
        End If

        If correcto Then
            If panel_contrato.Visible = False Then
                Msg1.Text = "Debe elegir un contrato válido"
                correcto = False
            End If
        End If

        Return correcto
    End Function

    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim correcto As Boolean = True

            If conciliacionAbm1.Insertar(txt_observacion.Text.Trim, contratoFormLote1.id_lote) = False Then
                correcto = False
            End If

            Return correcto
        Else
            Return False
        End If
    End Function

    Protected Sub eleccion_contrato_origen_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        If conciliacionAbm1.VerificarInsertar Then
            id_contrato = conciliacionAbm1.id_contrato_elegido
            fecha = conciliacionAbm1.fecha
            panel_contrato.Visible = True
            contratoConciliacionAbm1.CargarInsertar(id_contrato, fecha)
            panel_observacion.Visible = True
            panel_lote.Visible = True
        Else
            panel_contrato.Visible = False
            panel_observacion.Visible = False
            panel_lote.Visible = False
        End If
    End Sub
</script>

<asp:Label ID="lbl_id_reembolso" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_insertar" runat="server" Text="true" Visible="false"></asp:Label>

<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha" runat="server" Text="01/01/1900" Visible="false"></asp:Label>

<asp:Label ID="lbl_traspaso" runat="server" Text="true" Visible="false"></asp:Label>

<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td>
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reembolso" runat="server" GroupingText="Datos de la conciliación">
                <uc1:conciliacionAbm runat="server" ID="conciliacionAbm1" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Datos del contrato">
                <uc2:contratoConciliacionAbm runat="server" ID="contratoConciliacionAbm1" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_lote" runat="server" GroupingText="Datos del lote">
                <uc3:contratoFormLote runat="server" ID="contratoFormLote1" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_observacion" runat="server" GroupingText="Observación">
                <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" MaxLength="400" Width="600" Height="50"></asp:TextBox>
            </asp:Panel>
        </td>
    </tr>
</table>