<%@ Control Language="C#" ClassName="urbDatosView" %>

<script runat="server">
    public bool VerObservacion
    {
        set { lbl_observacion_enun.Visible = value; lbl_observacion.Visible = value; }
        get { return lbl_observacion_enun.Visible; }
    }
    
    public int id_urbanizacion
    {
        set
        {
            lbl_id_urbanizacion.Text = value.ToString();

            terrasur.so.so_obraMaestro omObj = new terrasur.so.so_obraMaestro(value);
            lbl_urbanizacion.Text = omObj.urbanizacion_nombre;
            if (omObj.estado_nombre != "") { lbl_estado.Text = omObj.estado_nombre; } else { lbl_estado.Text = "---"; }
            lbl_avance.Text = omObj.avance.ToString("N2") + @" %";
            
            lbl_localizacion.Text = omObj.localizacion_nombre;

            terrasur.so.so_urbanizacion_prioridad up = new terrasur.so.so_urbanizacion_prioridad(0, omObj.id_urbanizacion);
            if (up.prioridad_nombre != "") { lbl_prioridad.Text = up.prioridad_nombre; } else { lbl_prioridad.Text = "---"; }
            if (up.fecha_planificada.Date != DateTime.Parse("01/01/1900")) { lbl_fecha_planificada.Text = up.fecha_planificada.ToString("d"); } else { lbl_fecha_planificada.Text = "---"; }

            if (lbl_observacion_enun.Visible == true)
            {
                if (up.observacion != "")
                {
                    lbl_observacion_enun.Visible = true;
                    lbl_observacion.Visible = true;
                    lbl_observacion.Text = up.observacion;
                }
                else
                {
                    lbl_observacion_enun.Visible = false;
                    lbl_observacion.Visible = false;
                }
            }
        }
        get { return int.Parse(lbl_id_urbanizacion.Text); }
    }
</script>

<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<table cellpadding="0" cellspacing="0" align="center">
    <tr>
        <td>
            <asp:Panel ID="panel_urbanizacion" runat="server" GroupingText="Urbanización y seguimiento de obras">
                <table class="contratoDatosTable">
                    <tr>
                        <td class="contratoDatosTdGrupo" colspan="3">
                            <table align="left">
                                <tr>
                                    <td class="contratoDatosTdNumEnun">Urbanizacion:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_urbanizacion" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdEstadoEnun">Estado:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_estado" runat="server"></asp:Label></td>
                                    <td class="contratoDatosTdNumEspacio"></td>
                                    <td class="contratoDatosTdNumEnun">Avance:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_avance" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoDatosTdGrupo">
                            <table align="left">
                                <tr>
                                    <td class="contratoDatosTdEnun">Localización:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
                                    <td style="width:20px";></td>
                                    <td class="contratoDatosTdEnun">Prioridad:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_prioridad" runat="server"></asp:Label></td>
                                    <td style="width:20px";></td>
                                    <td class="contratoDatosTdEnun">Entrega planificada:</td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_fecha_planificada" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="contratoDatosTdGrupo">
                            <table align="left">
                                <tr>
                                    <td class="contratoDatosTdEnun"><asp:Label ID="lbl_observacion_enun" runat="server" Text="Observación:"></asp:Label></td>
                                    <td class="contratoDatosTdDato"><asp:Label ID="lbl_observacion" runat="server"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>