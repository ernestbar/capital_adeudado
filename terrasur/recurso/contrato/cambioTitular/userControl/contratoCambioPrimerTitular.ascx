<%@ Control Language="VB" ClassName="contratoCambioPrimerTitular" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoViewTitular.ascx" TagName="contratoViewTitular" TagPrefix="uc1" %>
<%@ Register Src="~/recurso/contrato/contratoLote/userControl/contratoFormTitular.ascx" TagName="contratoFormTitular" TagPrefix="uc2" %>

<script runat="server">
    Public Property id_contrato() As Integer
        Get
            Return Integer.Parse(lbl_id_contrato.Text)
        End Get
        Set(ByVal value As Integer)
            lbl_id_contrato.Text = value
            ContratoViewTitular1.id_cliente = New contrato(value).id_titular
            btn_cambiar.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cambioTitular", "primer_titular")
            MultiView1.ActiveViewIndex = 0
        End Set
    End Property
    
    Protected Sub btn_cambiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar.Click
        ContratoFormTitular1.Reset()
        btn_cambiar_titular.Enabled = True
        MultiView1.ActiveViewIndex = 1
    End Sub

    Protected Sub btn_cambiar_titular_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cambiar_titular.Click
        Dim nuevo_id_titular As Integer = 0
        If ContratoFormTitular1.Verificar Then
            If ContratoFormTitular1.id_cliente > 0 Then
                nuevo_id_titular = ContratoFormTitular1.id_cliente
            Else
                Dim clienteTitularObj As New cliente(ContratoFormTitular1.id_lugarcedula, ContratoFormTitular1.id_lugarcobro, ContratoFormTitular1.ci, ContratoFormTitular1.nit, ContratoFormTitular1.nombres, ContratoFormTitular1.paterno, ContratoFormTitular1.materno, ContratoFormTitular1.fecha_nacimiento, ContratoFormTitular1.celular, ContratoFormTitular1.fax, ContratoFormTitular1.email, ContratoFormTitular1.casilla, ContratoFormTitular1.domicilio_direccion, ContratoFormTitular1.domicilio_fono, ContratoFormTitular1.domicilio_id_zona, ContratoFormTitular1.oficina_direccion, ContratoFormTitular1.oficina_fono, ContratoFormTitular1.oficina_id_zona, False)
                If clienteTitularObj.Insertar(Profile.id_usuario) Then
                    nuevo_id_titular = clienteTitularObj.id_cliente
                End If
            End If
        End If
        If nuevo_id_titular > 0 Then
            Dim actual_id_titular As Integer = New contrato(id_contrato).id_titular
            If nuevo_id_titular <> actual_id_titular Then
                If cliente_contrato.Verificar(nuevo_id_titular, id_contrato) = False Then
                    Dim actualTitularObj As New cliente_contrato(actual_id_titular, id_contrato)
                    If actualTitularObj.Eliminar(Profile.id_usuario) Then
                        Dim nuevoTitularObj As New cliente_contrato(nuevo_id_titular, id_contrato, True)
                        If nuevoTitularObj.Insertar(Profile.id_usuario) Then
                            Msg1.Text = "El cambio de titular se realizó correctamente"
                            ContratoViewTitular1.id_cliente = nuevo_id_titular
                            btn_cambiar_titular.Enabled = False
                        Else
                            Dim anteriorTitularObj As New cliente_contrato(actual_id_titular, id_contrato, True)
                            anteriorTitularObj.Insertar(Profile.id_usuario)
                            Msg1.Text = "El cambio de titular NO se realizó correctamente"
                        End If
                    Else
                        Msg1.Text = "El cambio de titular NO se realizó correctamente"
                    End If
                Else
                    Msg1.Text = "El cliente ya esta registrado como titular del contrato"
                End If
            Else
                Msg1.Text = "El nuevo titular debe ser diferente al titular actual"
            End If
        End If
    End Sub

    Protected Sub btn_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_cancelar.Click
        MultiView1.ActiveViewIndex = 0
    End Sub
</script>
<asp:Label ID="lbl_id_contrato" runat="server" Text="0" Visible="false"></asp:Label>
<table align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_primer" runat="server" GroupingText="Primer titular del contrato" DefaultButton="btn_cambiar_titular">
                <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
                    <asp:View ID="View1" runat="server">
                        <table>
                            <tr><td><uc1:contratoViewTitular ID="ContratoViewTitular1" runat="server" /></td></tr>
                            <tr>
                                <td class="tdButtonRealizarAccion1">
                                    <asp:Button ID="btn_cambiar" runat="server" Text="Cambiar titular" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                    <asp:View ID="View2" runat="server">
                        <table>
                            <tr>
                                <td class="tdMsg">
                                    <asp:ValidationSummary ID="vs_contrato" runat="server" DisplayMode="List" ValidationGroup="contrato" />
                                    <asp:Msg ID="Msg1" runat="server"></asp:Msg>
                                </td>
                            </tr>
                            <tr><td><uc2:contratoFormTitular ID="ContratoFormTitular1" runat="server" /></td></tr>
                            <tr>
                                <td class="tdButtonRealizarAccion1">
                                    <asp:Button ID="btn_cambiar_titular" runat="server" Text="Realizar cambio" CausesValidation="true" ValidationGroup="contrato" />
                                    <asp:Button ID="btn_cancelar" runat="server" Text="Cancelar / Volver" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </asp:Panel>
        </td>
    </tr>
</table>