<%@ Control Language="C#" ClassName="urbanizacionViewDato" %>

<script runat="server">
    public int id_urbanizacion
    {
        get { return int.Parse(lbl_id_urbanizacion.Text); }
        
        set
        {
            urbanizacion urbanizacionObj = new urbanizacion(value);
            localizacion locObj = new localizacion(urbanizacionObj.id_localizacion);
            lbl_localizacion.Text = locObj.nombre;
            lbl_codigo.Text = urbanizacionObj.codigo;
            lbl_nombre.Text = urbanizacionObj.nombre + " (" + urbanizacionObj.nombre_corto + ")";
            lbl_manten.Text = urbanizacionObj.mantenimiento_sus.ToString();
            lbl_costo.Text = urbanizacionObj.costo_m2_sus.ToString();
            lbl_precio.Text = urbanizacionObj.precio_m2_sus.ToString();
            if (urbanizacionObj.activo == true) { lbl_activo.Text = "Sector activo"; } else { lbl_activo.Text = "Sector inactivo";  }
            img_imagen.ImageUrl = urbanizacion.ImagenDireccion(urbanizacionObj.imagen);
            lbl_id_urbanizacion.Text = value.ToString();
            lbl_num_manzanos.Text = urbanizacionObj.num_manzano.ToString();
            lbl_num_lotes.Text = urbanizacionObj.num_lote.ToString();
        }
    }
    protected void lb_img_imagen_Click(object sender, EventArgs e)
    {
         urbanizacion u = new urbanizacion(id_urbanizacion);
         if (u.imagen.Equals("").Equals(false) == true)
         {
             Session["id_urbanizacion"] = id_urbanizacion;
             WinPopUp1.NavigateUrl = urbanizacion.ImagenDireccion(u.imagen);
             WinPopUp1.Show();
         }
    }
</script>

<asp:Label ID="lbl_id_urbanizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl=""
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_localizacion_enum" runat="server" Text="Localización:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_localizacion" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_codigo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enun" runat="server" Text="Nombre del sector:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_nombre" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_manten_enun" runat="server" Text="Mantenimiento ($us):"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_manten" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_costo_enun" runat="server" Text="Costo M2 ($us):"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_costo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_precio_enun" runat="server" Text="Precio M2 ($us)"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_precio" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_activo_enun" runat="server" Text="Activo:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_activo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_imagen" runat="server" Text="Imagen:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table>
               <tr>
                    <td><asp:ImageButton ID="img_imagen"  OnClick="lb_img_imagen_Click" runat="server" Height="<%$ AppSettings:urbanizacion_tam_img %>" /></td>
               </tr>
            </table>
         </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_num_man_enun" runat="server" Text="No. de manzanos:"></asp:Label>
        </td>
        <td class="formTdDato">
           <asp:Label ID="lbl_num_manzanos" runat="server"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_num_lotes_enun" runat="server" Text="No. de lotes:"></asp:Label>
        </td>
        <td class="formTdDato">
           <asp:Label ID="lbl_num_lotes" runat="server"></asp:Label>
        </td>
    </tr> 
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_det_man_enun" runat="server" Text="Manzanos:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_manzanos" runat="server" AutoGenerateColumns="False" DataSourceID="ods_manzanos_lista"
                            DataKeyNames="id_manzano">
                            <Columns>
                                <asp:BoundField HeaderText="Manzano" DataField="codigo" />
                                <asp:BoundField HeaderText="No. de lotes" DataField="num_lote" ItemStyle-CssClass="gvCell1"/>
                            </Columns>
                        </asp:GridView>
                        <%--[id_manzano],[codigo],[num_lote]--%>
                        <asp:ObjectDataSource ID="ods_manzanos_lista" runat="server" TypeName="terrasur.manzano"
                            SelectMethod="Lista">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_urbanizacion" Type="Int32" ControlID="lbl_id_urbanizacion" PropertyName="Text" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

