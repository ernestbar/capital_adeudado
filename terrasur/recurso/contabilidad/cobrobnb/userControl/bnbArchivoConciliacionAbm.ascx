<%@ Control Language="C#" ClassName="bnbArchivoConciliacionAbm" %>

<script runat="server">
    public int id_institucion { get { return int.Parse(lbl_id_institucion.Text); } set { lbl_id_institucion.Text = value.ToString(); } }
    public string codigo_tipo_archivo { get { return lbl_codigo_tipo_archivo.Text; } set { lbl_codigo_tipo_archivo.Text = value; } }

    public void Reset()
    {
        gv_archivo.DataBind();
        btn_nuevo.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "conciliar");
        btn_archivos.Visible = false;
        //btn_archivos.Visible = permiso.Verificar(Profile.id_usuario, Profile.entorno.id_rol, "cobrobnb", "ver_archivos_todos");
        panel_conciliar.Visible = false;
    }


    protected void gv_archivo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //((LinkButton)e.Row.FindControl("lb_conciliar")).Visible = false;
            DateTime fecha_fin = DateTime.Parse(DataBinder.Eval(e.Row.DataItem, "fecha_fin").ToString());
            if (fecha_fin >= DateTime.Now.Date) e.Row.CssClass = "gvRowSelected";
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        PrepararParaConciliar();
    }

    protected void gv_archivo_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "descargar":
                int _Id_archivoconciliacion = int.Parse(e.CommandArgument.ToString());
                bnb_archivo_conciliacion aObj = new bnb_archivo_conciliacion(_Id_archivoconciliacion);
                StringBuilder srt = bnb_archivo_conciliacion.ConciliacionParaTxt_StringBuilder(_Id_archivoconciliacion);
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "text/plain";
                Response.AddHeader("Content-Disposition", "attachment;filename=" + aObj.nombre);
                Response.Charset = "UTF-8";
                Response.ContentEncoding = Encoding.Default;
                Response.Write(srt.ToString());
                Response.End();
                break;
        }
    }

    protected void PrepararParaConciliar()
    {
        btn_conciliar.Enabled = true;
        panel_conciliar.Visible = true;
    }

    protected void btn_conciliar_Click(object sender, EventArgs e)
    {
        try
        {
            try
            {
                string ruta_archivo = Server.MapPath(ConfigurationManager.AppSettings["bnb_files"] + DateTime.Now.Year.ToString() + "/" + fu_conciliacion.FileName);
                fu_conciliacion.SaveAs(ruta_archivo);
                Msg1.Text = "El archivo de conciliación se cargó correctamente";
                int Id_archivoconciliacion = 0;
                if (bnb_archivo_conciliacion.CargarConciliacion(id_institucion, ruta_archivo, fu_conciliacion.FileName, Profile.id_usuario, ref Id_archivoconciliacion) == true)
                {
                    Msg1.Text = "Los datos del archivo de conciliación se guardaron correctamente";
                    if (Id_archivoconciliacion > 0)
                    {
                        if (bnb_conciliacion.Conciliar(Id_archivoconciliacion) == true)
                        {
                            Msg1.Text = "Los datos de la conciliación se aplicaron correctamente";
                        }
                        else { Msg1.Text = "Los datos de la conciliación NO se aplicaron correctamente"; }
                    }
                }
                else
                {
                    Msg1.Text = "Los datos del archivo de conciliación NO se guardaron correctamente";
                }
            }
            catch { Msg1.Text = "El archivo de conciliación NO se cargó correctamente"; }

            gv_archivo.DataBind();
            btn_conciliar.Enabled = false;
        }
        catch { Msg1.Text = "El archivo de conciliación NO se cargó correctamente"; }
    }
    protected void btn_conciliar_volver_Click(object sender, EventArgs e)
    {
        panel_conciliar.Visible = false;
    }
</script>
<asp:Label ID="lbl_id_institucion" runat="server" Text="0" Visible="false"></asp:Label>
<asp:Label ID="lbl_codigo_tipo_archivo" runat="server" Text="" Visible="false"></asp:Label>

<asp:Panel ID="panel_archivo" runat="server" Width="100%" GroupingText="BNB Archivo D - Conciliación de cobros">
    <table width="100%">
        <tr>
            <td colspan="2">
                <asp:GridView ID="gv_archivo" runat="server" AutoGenerateColumns="false" DataSourceID="ods_lista_archivo_conciliacion" DataKeyNames="id_archivoconciliacion" OnRowDataBound="gv_archivo_RowDataBound" OnRowCommand="gv_archivo_RowCommand">
                    <Columns>
                        <asp:BoundField HeaderText="Desde" DataField="fecha_inicio" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="hasta" DataField="fecha_fin" HtmlEncode="false" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Nro. reg." DataField="num_registros" ItemStyle-CssClass="gvCell1" />
                        <asp:BoundField HeaderText="Monto $us" DataField="total_sus" HtmlEncode="false" DataFormatString="{0:F2}" />
                        <asp:BoundField HeaderText="Monto Bs" DataField="total_bs" HtmlEncode="false" DataFormatString="{0:F2}" />
                        <asp:TemplateField HeaderText="Archivo"><ItemTemplate><asp:LinkButton ID="lb_conciliacion" runat="server" Text='<%# Eval("nombre") %>' CommandName="descargar" CommandArgument='<%# Eval("id_archivoconciliacion") %>'></asp:LinkButton></ItemTemplate></asp:TemplateField>
                        <asp:BoundField HeaderText="Nro.pagos" DataField="num_pagos" ItemStyle-CssClass="gvCell1" />
                        <asp:BoundField HeaderText="Monto pagos $us" DataField="monto_pagos_sus" ItemStyle-CssClass="gvCell1" />
                        <asp:BoundField HeaderText="Monto pagos Bs" DataField="monto_pagos_bs" ItemStyle-CssClass="gvCell1" />
                    </Columns>
                    <EmptyDataTemplate><asp:Label ID="lbl_sin_registros" runat="server" Text="No exixten archivos registrados"></asp:Label></EmptyDataTemplate>
                </asp:GridView>
                <%--[id_archivoconciliacion],[fecha_inicio],[fecha_fin],[num_registros],[total_bs],[total_sus],[num_pagos],[monto_pagos],[nombre],[anio]--%>
                <asp:ObjectDataSource ID="ods_lista_archivo_conciliacion" runat="server" TypeName="terrasur.bnb_archivo_conciliacion" SelectMethod="ListaSimple">
                    <SelectParameters>
                        <asp:ControlParameter Name="Id_institucion" Type="Int32" ControlID="lbl_id_institucion" PropertyName="Text" />
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
                    <tr><td><asp:Button ID="btn_nuevo" runat="server" Text="Cargar archivo" OnClick="btn_nuevo_Click" /></td></tr>
                    <tr><td><asp:Button ID="btn_archivos" runat="server" Text="Archivos anteriores" /></td></tr>
                </table>
            </td>
            <td valign="top" align="center" width="100%">
                <asp:Panel ID="panel_conciliar" runat="server" GroupingText="Confirmación del archvio de " Width="100%" Visible="false">
                    <table class="formTable" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="formTdEnun">Archivo de confirmación:</td>
                            <td class="formTdDato"><asp:FileUpload ID="fu_conciliacion" runat="server" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btn_conciliar" runat="server" Text="Cargar archivo de conciliación" OnClick="btn_conciliar_Click" />
                                <asp:Button ID="btn_conciliar_volver" runat="server" Text="Volver" OnClick="btn_conciliar_volver_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>
