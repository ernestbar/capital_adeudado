<%@ Control Language="VB" ClassName="reemAbm" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/reembolsoAbm.ascx" tagname="reembolsoAbm" tagprefix="uc1" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/contratoReembolsoAbm.ascx" tagname="contratoReembolsoAbm" tagprefix="uc2" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/itemReembolsoInsert.ascx" tagname="itemReembolsoInsert" tagprefix="uc3" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/itemReembolsoUpdate.ascx" tagname="itemReembolsoUpdate" tagprefix="uc4" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/contratoDestinoInsert.ascx" tagname="contratoDestinoInsert" tagprefix="uc5" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/contratoDestinoUpdate.ascx" tagname="contratoDestinoUpdate" tagprefix="uc6" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/pagoDevolucionInsert.ascx" tagname="pagoDevolucionInsert" tagprefix="uc7" %>
<%@ Register src="~/recurso/reembolso/traspaso/userControl/pagoDevolucionUpdate.ascx" tagname="pagoDevolucionUpdate" tagprefix="uc8" %>

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

    Public Property traspaso() As Boolean
        Get
            Return Boolean.Parse(lbl_traspaso.Text)
        End Get
        Set(ByVal value As Boolean)
            lbl_traspaso.Text = value.ToString
            If value = True Then
                panel_reembolso.GroupingText = "Datos del traspaso"
                panel_item.GroupingText = "Elementos del traspaso"
            Else
                panel_reembolso.GroupingText = "Datos de la devolución"
                panel_item.GroupingText = "Elementos de la devolución"
            End If
        End Set
    End Property
    

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        AddHandler reembolsoAbm1.Eleccion, AddressOf eleccion_contrato_origen_realizada
        AddHandler itemReembolsoInsert1.Eleccion, AddressOf eleccion_items_insert_realizada
        AddHandler itemReembolsoUpdate1.Eleccion, AddressOf eleccion_items_update_realizada
    End Sub

    Public Sub CargarInsertar(ByVal _Traspaso As Boolean)
        id_reembolso = 0
        insert = True
        traspaso = _Traspaso
        
        reembolsoAbm1.CargarInsertar(_Traspaso)
        panel_contrato.Visible = False
        panel_item.Visible = False
        panel_traspaso.Visible = False
        panel_devolucion.Visible = False
        panel_observacion.Visible = False
        txt_observacion.Text = ""
    End Sub

    Private Function VerificarInsertar() As Boolean
        Dim correcto As Boolean = True
        
        If reembolsoAbm1.VerificarInsertar = False Then
            correcto = False
        End If
        
        If itemReembolsoInsert1.VerificarInsertar = False Then
            correcto = False
        End If
        
        If traspaso Then
            If contratoDestinoInsert1.VerificarInsertar = False Then
                correcto = False
            End If
        Else
            If pagoDevolucionInsert1.VerificarInsertar = False Then
                correcto = False
            End If
        End If
        
        If correcto Then
            If reembolsoAbm1.id_contrato_elegido <> id_contrato Or reembolsoAbm1.fecha <> fecha Then
                Msg1.Text = "Debe presionar el botón Obtener datos"
                
                panel_contrato.Visible = False
                panel_item.Visible = False
                panel_traspaso.Visible = False
                panel_devolucion.Visible = False
                panel_observacion.Visible = False
                
                correcto = False
            End If
        End If
        
        If correcto Then
            If panel_contrato.Visible = False Or panel_item.Visible = False Then
                Msg1.Text = "Debe elegir un contrato válido"
                correcto = False
            End If
        End If
        
        Return correcto
    End Function
    
    Public Function Insertar() As Boolean
        If VerificarInsertar() Then
            Dim correcto As Boolean = True
            
            If reembolsoAbm1.Insertar(itemReembolsoInsert1.monto_total, txt_observacion.Text.Trim) = False Then
                correcto = False
            End If
            
            If correcto Then
                If itemReembolsoInsert1.Insertar(reembolsoAbm1.id_reembolso_registrado) = False Then
                    correcto = False
                End If
                
                If correcto = False Then
                    Dim rObj As New terrasur.traspaso.reembolso(reembolsoAbm1.id_reembolso_registrado)
                    rObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host)
                End If
            End If
            
            If correcto = True And traspaso = True Then
                If contratoDestinoInsert1.Insertar(reembolsoAbm1.id_reembolso_registrado) = False Then
                    correcto = False
                End If
                
                If correcto = False Then
                    Dim rObj As New terrasur.traspaso.reembolso(reembolsoAbm1.id_reembolso_registrado)
                    rObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host)
                End If
            End If
            
            If correcto = True And traspaso = False Then
                If pagoDevolucionInsert1.Insertar(reembolsoAbm1.id_reembolso_registrado) = False Then
                    correcto = False
                End If
                
                If correcto = False Then
                    Dim rObj As New terrasur.traspaso.reembolso(reembolsoAbm1.id_reembolso_registrado)
                    rObj.Eliminar(Profile.id_usuario, Profile.entorno.context_ip, Profile.entorno.context_host)
                End If
            End If
            
            Return correcto
        Else
            Return False
        End If
    End Function
    
    Public Sub CargarActualizar(ByVal reObj As terrasur.traspaso.reembolso)
        id_reembolso = reObj.id_reembolso
        insert = False
        traspaso = reObj.traspaso
        
        reembolsoAbm1.CargarActualizar(reObj)
        
        panel_contrato.Visible = True
        contratoReembolsoAbm1.CargarActualizar(reObj.id_reembolso)
        
        panel_item.Visible = True
        panel_item_insert.Visible = False
        panel_item_update.Visible = True
        itemReembolsoUpdate1.CargarActualizar(reObj.id_reembolso, reObj.traspaso, reObj.codigo_moneda)
        
        If traspaso Then
            panel_traspaso.Visible = True
            panel_traspaso_insert.Visible = False
            panel_traspaso_update.Visible = True
            contratoDestinoUpdate1.CargarActualizar(reObj.id_reembolso, reObj.fecha, reObj.codigo_moneda, reObj.monto, reObj.pagado)
            
            panel_devolucion.Visible = False
        Else
            panel_traspaso.Visible = False

            panel_devolucion.Visible = True
            panel_devolucion_insert.Visible = False
            panel_devolucion_update.Visible = True
            pagoDevolucionUpdate1.CargarActualizar(reObj.id_reembolso, reObj.fecha, reObj.codigo_moneda, reObj.monto)
        End If
        
        panel_observacion.Visible = True
        txt_observacion.Text = reObj.observacion
        
    End Sub
    Private Function VerificarActualizar() As Boolean
        Dim correcto As Boolean = True

        If reembolsoAbm1.VerificarActualizar = False Then
            correcto = False
        End If

        If terrasur.traspaso.reembolso.MontoTotal(id_reembolso) <= 0 Then
            correcto = False
            If traspaso Then
                Msg1.Text = "El monto del traspaso debe ser mayor a 0"
            Else
                Msg1.Text = "El monto de la devolución debe ser mayor a 0"
            End If
        End If
        
        If pagoDevolucionUpdate1.VerificarActualizar = False Then
            correcto = False
        End If
        
        Return correcto
    End Function
    Public Function Actualizar() As Boolean
        If VerificarActualizar() Then
            Dim correcto As Boolean = True
            
            If reembolsoAbm1.Actualizar(txt_observacion.Text.Trim) = False Then
                correcto = False
            End If
            
            Return correcto
        Else
            Return False
        End If
    End Function
    
    
    
    Protected Sub eleccion_contrato_origen_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        If reembolsoAbm1.VerificarInsertar Then
            id_contrato = reembolsoAbm1.id_contrato_elegido
            fecha = reembolsoAbm1.fecha
            
            panel_contrato.Visible = True
            contratoReembolsoAbm1.CargarInsertar(id_contrato, fecha)
            
            panel_item.Visible = True
            panel_item_insert.Visible = True
            panel_item_update.Visible = False
            itemReembolsoInsert1.CargarInsertar(traspaso, id_contrato, fecha)
            
            If traspaso Then
                panel_traspaso.Visible = True
                panel_traspaso_insert.Visible = True
                panel_traspaso_update.Visible = False
                contratoDestinoInsert1.CargarInsertar(id_contrato, fecha, itemReembolsoInsert1.monto_total)
                
                panel_devolucion.Visible = False
            Else
                panel_traspaso.Visible = False
                
                panel_devolucion.Visible = True
                panel_devolucion_insert.Visible = True
                panel_devolucion_update.Visible = False
                pagoDevolucionInsert1.CargarInsertar(id_contrato, fecha, itemReembolsoInsert1.monto_total)
            End If
            
            panel_observacion.Visible = True
        Else
            panel_contrato.Visible = False
            panel_item.Visible = False
            panel_traspaso.Visible = False
            panel_devolucion.Visible = False
            panel_observacion.Visible = False
        End If
    End Sub
    
    Protected Sub eleccion_items_insert_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        If traspaso Then
            contratoDestinoInsert1.m_trastasar = itemReembolsoInsert1.monto_total
        Else
            pagoDevolucionInsert1.m_devolver = itemReembolsoInsert1.monto_total
        End If
    End Sub

    Protected Sub eleccion_items_update_realizada(ByVal sender As Object, ByVal e As System.EventArgs)
        If traspaso Then
            contratoDestinoUpdate1.m_trastasar = terrasur.traspaso.reembolso.MontoTotal(id_reembolso)
        Else
            pagoDevolucionUpdate1.m_devolver = terrasur.traspaso.reembolso.MontoTotal(id_reembolso)
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
            <%--<asp:ValidationSummary ID="vs_reembolso" runat="server" DisplayMode="List" ValidationGroup="reembolso" />--%>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_reembolso" runat="server" GroupingText="Datos del traspaso">
                <uc1:reembolsoAbm ID="reembolsoAbm1" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_contrato" runat="server" GroupingText="Datos del contrato">
                <uc2:contratoReembolsoAbm ID="contratoReembolsoAbm1" runat="server" />
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_item" runat="server" GroupingText="Elementos del traspaso">
                <asp:Panel ID="panel_item_insert" runat="server"><uc3:itemReembolsoInsert ID="itemReembolsoInsert1" runat="server" /></asp:Panel>
                <asp:Panel ID="panel_item_update" runat="server"><uc4:itemReembolsoUpdate ID="itemReembolsoUpdate1" runat="server" /></asp:Panel>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_traspaso" runat="server" GroupingText="Contrato(s) que recibirán el traspaso">
                <asp:Panel ID="panel_traspaso_insert" runat="server"><uc5:contratoDestinoInsert ID="contratoDestinoInsert1" runat="server" /></asp:Panel>
                <asp:Panel ID="panel_traspaso_update" runat="server"><uc6:contratoDestinoUpdate ID="contratoDestinoUpdate1" runat="server" /></asp:Panel>
            </asp:Panel>
            <asp:Panel ID="panel_devolucion" runat="server" GroupingText="Pagos previstos para la devolución">
                <asp:Panel ID="panel_devolucion_insert" runat="server"><uc7:pagoDevolucionInsert ID="pagoDevolucionInsert1" runat="server" /></asp:Panel>
                <asp:Panel ID="panel_devolucion_update" runat="server"><uc8:pagoDevolucionUpdate ID="pagoDevolucionUpdate1" runat="server" /></asp:Panel>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="panel_observacion" runat="server" GroupingText="Observación">
                <asp:TextBox ID="txt_observacion" runat="server" TextMode="MultiLine" MaxLength="400" Width="600" Height="50">
                </asp:TextBox>
            </asp:Panel>
        </td>
    </tr>
</table>

