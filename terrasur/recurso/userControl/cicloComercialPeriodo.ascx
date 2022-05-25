<%@ Control Language="VB" ClassName="cicloComercialPeriodo" %>

<script runat="server">
    Public ReadOnly Property inicio() As Date
        Get
            Return cp_inicio.SelectedDate
        End Get
    End Property
    Public ReadOnly Property fin() As Date
        Get
            Return cp_fin.SelectedDate
        End Get
    End Property

    Protected Sub rbl_ciclocomercial_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbl_ciclocomercial.SelectedIndexChanged
        If Integer.Parse(rbl_ciclocomercial.SelectedValue) > 0 Then
            Dim ciclo As New ciclo_comercial(Integer.Parse(rbl_ciclocomercial.SelectedValue))
            cp_inicio.SelectedDate = ciclo.inicio
            cp_fin.SelectedDate = ciclo.fin
        End If
    End Sub
</script>
<table cellpadding="0" cellspacing="0">
    <tr>
        <td><ew:CalendarPopup ID="cp_inicio" runat="server" Width="100px"></ew:CalendarPopup></td>
        <td>&nbsp;-&nbsp;</td>
        <td>
            <ew:CalendarPopup ID="cp_fin" runat="server" Width="100px"></ew:CalendarPopup>
            <asp:CompareValidator ID="cv_fin" runat="server" ControlToValidate="cp_fin" ControlToCompare="cp_inicio" Type="Date" Operator="GreaterThanEqual" Display="Dynamic" Text="*" ErrorMessage="Rango de fechas Incorrecto"></asp:CompareValidator>
        </td>
        <td>&nbsp;&nbsp;<asp:HyperLink ID="lb_ciclo_comercial" runat="server" Text="Elegir ciclo comercial"></asp:HyperLink></td>
    </tr>
</table>

<ajaxToolkit:PopupControlExtender ID="PopupControlExtender1" runat="server" TargetControlID="lb_ciclo_comercial" PopupControlID="panel_ciclocomercial" Position="Top">
</ajaxToolkit:PopupControlExtender>
<asp:Panel ID="panel_ciclocomercial" runat="server" SkinID="panelCicloComercial" GroupingText="Ciclos comerciales" Height="100px" ScrollBars="Vertical">
    <asp:RadioButtonList ID="rbl_ciclocomercial" runat="server" SkinID="rblCicloComercial" AutoPostBack="true" DataSourceID="ods_lista_ciclocomercial" DataTextField="nombre" DataValueField="id_ciclocomercial"></asp:RadioButtonList> 
</asp:Panel>
<asp:ObjectDataSource ID="ods_lista_ciclocomercial" runat="server" TypeName="terrasur.ciclo_comercial" SelectMethod="ListaReportes">
    <SelectParameters><asp:Parameter Name="Recientes_10" Type="Boolean" DefaultValue="True" /></SelectParameters>
</asp:ObjectDataSource>

