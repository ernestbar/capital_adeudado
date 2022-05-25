<%@ Control Language="VB" ClassName="reprogramacionFormFechaInteres" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.Common" %>
<%@ Import Namespace="Microsoft.Practices.EnterpriseLibrary.Data" %>

<script runat="server">
    
    Public Property id_ultimo_pago() As Integer
        Get
            Return Integer.Parse(lbl_id_ultimo_pago.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_ultimo_pago.Text = value
        End Set
    End Property
    
    Public Property Fecha_inicio_plan() As DateTime
        Get
            Return DateTime.Parse(lbl_fecha_inicio_plan.Text)
        End Get
        Set(ByVal value As DateTime)
            lbl_fecha_inicio_plan.Text = value
        End Set
    End Property
    
    Public Sub Reset()
        If id_ultimo_pago > 0 Then
            cp_fecha_interes.SelectedDate = New pago(id_ultimo_pago).interes_fecha
            btn_cambiar.Visible = True
        Else
            cp_fecha_interes.SelectedDate = DateTime.Now()
            btn_cambiar.Visible = False
        End If
        
    End Sub
    
    Protected Sub btn_cambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        If id_ultimo_pago > 0 Then
            If FechaInteres_Actualizar2(id_ultimo_pago, cp_fecha_interes.SelectedDate, logica.FechaProximoPago(cp_fecha_interes.SelectedDate, Fecha_inicio_plan), Profile.id_usuario) Then
                Msg1.Text = "La fecha de interés se actualizó correctamente"
            Else
                Msg1.Text = "La fecha de interés no se actualizó correctamente"
            End If
        End If
    End Sub
    
    Public Function FechaInteres_Actualizar2(ByVal id_ultimo_pago As Integer, _
                                             ByVal interes_fecha As DateTime, _
                                             ByVal fecha_proximo As DateTime, _
                                             ByVal audit_id_usuario As Integer) As Boolean
        Try
            Dim db1 As Database = DatabaseFactory.CreateDatabase(ConfigurationManager.AppSettings("conn"))
            Dim cmd As DbCommand = db1.GetStoredProcCommand("pago_FechaInteres_Actualizar2")
            cmd.CommandTimeout = Integer.Parse(ConfigurationManager.AppSettings("CommandTimeout"))
            db1.AddInParameter(cmd, "id_ultimo_pago", DbType.Int32, id_ultimo_pago)
            db1.AddInParameter(cmd, "interes_fecha", DbType.DateTime, interes_fecha)
            db1.AddInParameter(cmd, "fecha_proximo", DbType.DateTime, fecha_proximo)
            db1.AddInParameter(cmd, "audit_id_usuario", DbType.Int32, audit_id_usuario)
            db1.ExecuteNonQuery(cmd)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
</script>

<asp:Label ID="lbl_id_ultimo_pago" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_fecha_inicio_plan" runat="server" Text="" Visible="false"></asp:Label>
<table class="contratoFormTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="contratoFormTdMsg" colspan="2">
            <asp:Msg ID="Msg1" runat="server"></asp:Msg>
        </td>
    </tr>
    <tr>
        <td>
            <table align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="contratoFormTdEnun">Nueva Fecha de Interés:</td>
                    <td class="contratoFormTdDato"><ew:CalendarPopup ID="cp_fecha_interes" runat="server"></ew:CalendarPopup></td>
                    <td > <asp:Button ID="btn_cambiar" runat="server" SkinID="btnAccion" Text="Cambiar Fecha de Interés" CausesValidation="true" ValidationGroup="fechainteres" /></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td class="contratoFormTdDato">
            <asp:Label ID="lbl_mensaje" runat="server" Text="Este cambio también provocará que se actualice la fecha de vencimiento del último pago." Visible="True"></asp:Label>
        </td>
    </tr>
</table>