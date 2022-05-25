<%@ Control Language="C#" ClassName="bnbArchivoAbm" %>

<script runat="server">
    public int id_archivo { get { return int.Parse(lbl_id_archivo.Text); } set { lbl_id_archivo.Text = value.ToString(); } }
    public int id_institucion { get { return int.Parse(lbl_id_institucion.Text); } set { lbl_id_institucion.Text = value.ToString(); } }
    public string codigo_tipo_archivo
    {
        get { return lbl_codigo_tipo_archivo.Text; }
        set
        {
            bnb_tipo_archivo taObj = new bnb_tipo_archivo(value);
            lbl_codigo_tipo_archivo.Text = value;
            panel_archivo.GroupingText = "BNB Archivo " + taObj.codigo + " - " + taObj.nombre_corto;
            panel_generar.GroupingText = "Generación del archivo de " + taObj.nombre_corto;
            panel_confirmar.GroupingText = "Confirmación del archivo de " + taObj.nombre_corto;
        }
    }

    public void Reset()
    {
        gv_archivo.DataBind();
        btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "generar");
        btn_archivos.Visible = false;
        //btn_archivos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "ver_archivos_todos");
        panel_generar.Visible = false;
        panel_confirmar.Visible = false;
    }


    protected void gv_archivo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int procesado = int.Parse(DataBinder.Eval(e.Row.DataItem, "procesado").ToString());
            ((LinkButton)e.Row.FindControl("lb_confirmacion")).Visible = procesado.Equals(0).Equals(false);
            if (permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "confirmar") == true)
            {
                ((LinkButton)e.Row.FindControl("lb_confirmar")).Visible =  procesado.Equals(0);
                //((ImageButton)e.Row.FindControl("btn_archivo_confirmacion")).Visible = procesado.Equals(0).Equals(false);
            }
            else { ((LinkButton)e.Row.FindControl("lb_confirmar")).Visible = false; }

            DateTime enviado_fecha = DateTime.Parse(DataBinder.Eval(e.Row.DataItem, "enviado_fecha").ToString());
            if (enviado_fecha >= DateTime.Now.Date) e.Row.CssClass = "gvRowSelected";
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        PrepararParaGenerar();
    }

    protected void gv_archivo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "descargar":
                int _id_archivo = int.Parse(e.CommandArgument.ToString());
                
                bnb_archivo aObj = new bnb_archivo(_id_archivo);
                StringBuilder srt = bnb_archivo.ContenidoParaTxt_StringBuilder(aObj.id_archivo);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "text/plain";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + aObj.nombre);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(srt.ToString());
                Response.End();
                break;
            case "confirmar":
                PrepararParaConfirmar(int.Parse(e.CommandArgument.ToString()));
                break;
            case "ver_archivo":
                //int _id_archivo1 = int.Parse(gv_archivo.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString());
                int _id_archivo1 = int.Parse(e.CommandArgument.ToString());
                Session["id_archivo"] = _id_archivo1;
                WinPopUp1.Show();
                break;
        }
    }

    protected void PrepararParaGenerar()
    {
        lbl_contratos.Visible = codigo_tipo_archivo.Equals("B").Equals(false);
        txt_contratos.Visible = codigo_tipo_archivo.Equals("B").Equals(false);
        btn_generar.Enabled = true;
        panel_generar.Visible = true;
        panel_confirmar.Visible = false;
    }

    protected void PrepararParaConfirmar(int _Id_archivo)
    {
        bnb_archivo aObj = new bnb_archivo(_Id_archivo);
        id_archivo = aObj.id_archivo;
        lbl_tipo_archivo.Text = new bnb_tipo_archivo(aObj.id_tipoarchivo).nombre_corto;
        lbl_fecha_envio.Text = aObj.enviado_fecha.ToString("d");
        lbl_num_envio.Text = aObj.enviado_num.ToString();
        btn_confirmar.Enabled = true;
        panel_generar.Visible = false;
        panel_confirmar.Visible = true;
    }

    protected void btn_generar_Click(object sender, EventArgs e)
    {
        if (cp_fecha.SelectedDate >= DateTime.Now.Date)
        {
            if (cp_fecha.SelectedDate <= DateTime.Now.Date.AddDays(2))
            {
                switch (codigo_tipo_archivo)
                {
                    case "A":
                        if (bnb_contrato.Generar(id_institucion, txt_contratos.Text.Trim(), cp_fecha.SelectedDate, Profile.id_usuario) == true)
                        {
                            Msg1.Text = "Los datos se generaron correctamente";
                            gv_archivo.DataBind();
                            btn_generar.Enabled = false;
                        }
                        else { Msg1.Text = "Los datos NO se generaron correctamente"; }
                        break;
                    case "B":
                        if (bnb_concepto.Generar(id_institucion, cp_fecha.SelectedDate, 1) == true)
                        {
                            Msg1.Text = "Los datos se generaron correctamente";
                            gv_archivo.DataBind();
                            btn_generar.Enabled = false;
                        }
                        else { Msg1.Text = "Los datos NO se generaron correctamente"; }
                        break;
                    case "C":
                        if (bnb_pago_pendiente.GenerarPagosPendientes(id_institucion, cp_fecha.SelectedDate, txt_contratos.Text.Trim(), Profile.id_usuario) == true)
                        {
                            Msg1.Text = "Los datos se generaron correctamente";
                            gv_archivo.DataBind();
                            btn_generar.Enabled = false;
                        }
                        else { Msg1.Text = "Los datos NO se generaron correctamente"; }
                        break;
                }

            }
            else { Msg1.Text = "No se pueden generar datos de fechas posteriores a 2 días la fecha actual"; }
        }
        else { Msg1.Text = "No se pueden generar datos de fechas anteriores a la actual"; }
    }
    protected void btn_generar_volver_Click(object sender, EventArgs e)
    {
        panel_generar.Visible = false;
    }

    protected void btn_confirmar_Click(object sender, EventArgs e)
    {
        if (fu_confirmacion.HasFile == true)
        {
            bnb_archivo aObj = new bnb_archivo(id_archivo);
            try
            {
                string ruta_archivo = Server.MapPath(ConfigurationManager.AppSettings["bnb_files"] + aObj.enviado_fecha.Year.ToString() + "/" + fu_confirmacion.FileName);
                fu_confirmacion.SaveAs(ruta_archivo);
                Msg1.Text = "El archivo de confirmación se cargó correctamente";
                if (bnb_archivo.CargarConfirmacion(aObj, ruta_archivo, fu_confirmacion.FileName, Profile.id_usuario) == true)
                    Msg1.Text = "Los datos del archivo de confirmación se guardaron correctamente";
                else Msg1.Text = "Los datos del archivo de confirmación NO se guardaron correctamente";

                gv_archivo.DataBind();
                btn_confirmar.Enabled = false;
            }
            catch { Msg1.Text = "El archivo de confirmación NO se cargó correctamente"; }
        }
        else { Msg1.Text = "Debe seleccionar el archivo de confirmación"; }

    }
    protected void btn_confirmar_volver_Click(object sender, EventArgs e)
    {
        panel_confirmar.Visible = false;
    }
</script>
<asp:Label ID="lbl_id_archivo" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_id_institucion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_tipo_archivo" runat="server" Text="" Visible="false"></asp:Label>



<asp:Panel ID="panel_archivo" runat="server" Width="100%">
    <asp:WinPopUp ID="WinPopUp1" runat="server" NavigateUrl="~/recurso/contabilidad/cobrobnb/viewArchivo.aspx"></asp:WinPopUp>
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv_archivo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_archivo" DataKeyNames="id_archivo" OnRowDataBound="gv_archivo_RowDataBound" OnRowCommand="gv_archivo_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha" DataField="enviado_fecha" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Nro. envio" DataField="enviado_num" ItemStyle-CssClass="gvCell1" />
                        <asp:BoundField HeaderText="Nro. reg." DataField="enviado_num_registros" ItemStyle-CssClass="gvCell1" />

                        <asp:TemplateField HeaderText="Archivo"><ItemTemplate><asp:LinkButton ID="lb_envio" runat="server" Text='<%# Eval("nombre") %>' CommandName="descargar" CommandArgument='<%# Eval("id_archivo") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                        <%--<asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_archivo" runat="server" ImageUrl="~/images/gv/view.gif" CommandName="ver_archivo" CommandArgument='<%# Eval("id_archivo") %>' /></ItemTemplate></asp:TemplateField>--%>
                        <asp:BoundField HeaderText="Estado" DataField="estado" />
                        <asp:BoundField HeaderText="Conf.Nro.Reg." DataField="procesado_num_registros" ItemStyle-CssClass="gvCell1" />
                        <asp:TemplateField HeaderText="Conf.Archivo">
                            <ItemTemplate>
                                <asp:LinkButton ID="lb_confirmacion" runat="server" Text='<%# Eval("procesado_nombre") %>' CommandName="descargar" CommandArgument='<%# Eval("procesado_id_archivo") %>'></asp:LinkButton>
                                <asp:LinkButton ID="lb_confirmar" runat="server" Text="Confirmar" CommandName="confirmar" CommandArgument='<%# Eval("id_archivo") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:TemplateField><ItemTemplate><asp:ImageButton ID="btn_archivo_confirmacion" runat="server" ImageUrl="~/images/gv/view.gif" CommandName="ver_archivo" CommandArgument='<%# Eval("procesado_id_archivo") %>' /></ItemTemplate></asp:TemplateField>--%>
                    </Columns>
                    <EmptyDataTemplate><asp:Label ID="lbl_sin_registros" runat="server" Text="No exixten archivos registrados"></asp:Label></EmptyDataTemplate>
                </asp:GridView>
                <%--[id_archivo],[enviado_fecha],[enviado_num],[enviado_num_registros],[nombre],[estado],
                [procesado],[procesado_id_archivo],[procesado_fecha],[procesado_num_registros],[procesado_nombre]--%>
                <asp:ObjectDataSource ID="ods_lista_archivo" runat="server" TypeName="terrasur.bnb_archivo" SelectMethod="ListaSimple">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_institucion" Type="Int32" ControlID="lbl_id_institucion" PropertyName="Text" />
                        <asp:ControlParameter Name="Codigo_tipo_archivo" Type="String" ControlID="lbl_codigo_tipo_archivo" PropertyName="Text" />
                    </SelectParameters>
                </asp:ObjectDataSource> 
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Msg ID="Msg1" runat="server"></asp:Msg> 
            </td>
        </tr>
        <tr>
            <td valign="top" align="left">
                <table cellpadding="0" cellspacing="0">
                    <tr><td><asp:Button ID="btn_nuevo" runat="server" Text="Generar archivo" OnClick="btn_nuevo_Click" /></td></tr>
                    <tr><td><asp:Button ID="btn_archivos" runat="server" Text="Archivos anteriores" /></td></tr>
                </table>
            </td>
            <td valign="top" align="center">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <asp:Panel ID="panel_generar" runat="server" GroupingText="Generación del archivo de " Visible="false">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <%--<tr>
                                        <td class="formTdTitle" colspan="2">
                                            <asp:Label ID="lbl_generacion" runat="server" Text="Datos del lote"></asp:Label>
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_fecha_enun" runat="server" Text="Fecha:"></asp:Label></td>
                                        <td class="formTdDato"><ew:CalendarPopup ID="cp_fecha" runat="server"></ew:CalendarPopup></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun"><asp:Label ID="lbl_contratos" runat="server" Text="Contratos:"></asp:Label></td>
                                        <td class="formTdDato"><asp:TextBox ID="txt_contratos" runat="server" SkinID="txtSingleLine200"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btn_generar" runat="server" Text="Generar" OnClick="btn_generar_Click" />
                                            <asp:Button ID="btn_generar_volver" runat="server" Text="Volver" OnClick="btn_generar_volver_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="panel_confirmar" runat="server" GroupingText="Confirmación del archvio de " Visible="false">
                                <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td class="formTdEnun">Tipo de archivo:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_tipo_archivo" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Fecha de envio:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_fecha_envio" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Nº envio:</td>
                                        <td class="formTdDato"><asp:Label ID="lbl_num_envio" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td class="formTdEnun">Archivo de confirmación:</td>
                                        <td class="formTdDato"><asp:FileUpload ID="fu_confirmacion" runat="server" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btn_confirmar" runat="server" Text="Cargar archivo de confirmación" OnClick="btn_confirmar_Click" />
                                            <asp:Button ID="btn_confirmar_volver" runat="server" Text="Volver" OnClick="btn_confirmar_volver_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
