<%@ Control Language="C#" ClassName="localizacionViewDato" %>

<script runat="server">
    public int id_localizacion
    {
        get { return int.Parse(lbl_id_localizacion.Text); }
        
        set
        {
            localizacion localizacionObj = new localizacion(value);
            lbl_codigo.Text = localizacionObj.codigo;
            lbl_nombre.Text = localizacionObj.nombre;
            img_imagen.ImageUrl = localizacion.ImagenDireccion(localizacionObj.imagen);
            lbl_id_localizacion.Text = value.ToString();
            lbl_num_urb.Text = localizacionObj.num_urbanizacion_activa.ToString();
            lbl_num_lotes.Text = localizacionObj.num_lote.ToString();
        }
    }
    protected void lb_img_imagen_Click(object sender, EventArgs e)
    {
        localizacion l = new localizacion(id_localizacion);
        if (l.imagen.Equals("").Equals(false) == true)
        {
            Session["id_localizacion"] = id_localizacion;
            WinPopUp1.NavigateUrl = localizacion.ImagenDireccion(l.imagen);
            WinPopUp1.Show();
        }
    }
</script>
<asp:Label ID="lbl_id_localizacion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl=""
        Visible="False" Win_Directories="False" Win_Fullscreen="False" Win_Height="400"
        Win_Left="100" Win_Location="False" Win_Menubar="False" Win_Resizable="True" Win_Scrollbars="True"
        Win_Status="True" Win_Titlebar="True" Win_Toolbar="False" Win_Top="100" Win_Width="800">[WinPopUp1]</asp:WinPopUp>
<table class="viewTable" align="center" cellpadding="0" cellspacing="0">
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_codigo_enun" runat="server" Text="Código:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_codigo" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_nombre_enum" runat="server" Text="Nombre de la localización:"></asp:Label></td>
        <td class="formTdDato">
            <asp:Label ID="lbl_nombre" runat="server"></asp:Label></td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_imagen" runat="server" Text="Imagen:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table>
               <tr>
                    <td><asp:ImageButton ID="img_imagen"  OnClick="lb_img_imagen_Click" runat="server" Height="<%$ AppSettings:localizacion_tam_img %>" /></td>
               </tr>
            </table>
         </td>
    </tr>
    <tr>
        <td class="formTdEnun">
            <asp:Label ID="lbl_num_urb_enun" runat="server" Text="No. de sectores:"></asp:Label>
        </td>
        <td class="formTdDato">
           <asp:Label ID="lbl_num_urb" runat="server"></asp:Label>
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
            <asp:Label ID="lbl_det_urb_enun" runat="server" Text="Sectores:"></asp:Label>
        </td>
        <td class="formTdDato">
            <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="tdGrid">
                        <asp:GridView ID="gv_urbaniz" runat="server" AutoGenerateColumns="False" DataSourceID="ods_urb_lista"
                            DataKeyNames="id_urbanizacion">
                            <Columns>
                                <asp:BoundField HeaderText="Sector" DataField="nombre" />
                                <asp:BoundField HeaderText="No. de lotes" DataField="num_lote" />
                            </Columns>
                        </asp:GridView>
                        <%--[id_paquete4n],[nombre],[activo]--%>
                        <asp:ObjectDataSource ID="ods_urb_lista" runat="server" TypeName="terrasur.urbanizacion"
                            SelectMethod="ListaPorActivo">
                            <SelectParameters>
                                <asp:ControlParameter Name="Id_localizacion" Type="Int32" ControlID="lbl_id_localizacion" PropertyName="Text" />
                                <asp:Parameter DefaultValue="True" Name="Activo" Type="Boolean"  />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
