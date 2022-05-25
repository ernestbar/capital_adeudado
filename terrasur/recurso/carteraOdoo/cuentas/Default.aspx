<%@ Page Title="" Language="C#" MasterPageFile="~/modulo/normal.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="recurso_carteraOdoo_cuentas_Default" %>

<%@ Register Src="~/recurso/carteraOdoo/cuentas/userControl/ABMcuentasodoo.ascx" TagPrefix="uc1" TagName="ABMcuentasodoo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cph_r" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_c" Runat="Server">
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
             <table  class="priTable">
                <tr>
                  <td class="priTdTitle" style="height: 23px">
                      OPERACIONES Y CUENTAS
                  </td>
                </tr>
                 <tr>
                  <td class="priTdContenido">
                      <asp:DropDownList ID="ddlOperacion" runat="server" AutoPostBack="True" DataSourceID="odsOperacion" DataTextField="nombre" DataValueField="id_operacioncartera"></asp:DropDownList><asp:ObjectDataSource ID="odsOperacion" runat="server" SelectMethod="Lista" TypeName="terrasur.operacionCartera"></asp:ObjectDataSource>
                  </td>
                </tr>
                 <tr>
                     <td class="priTdContenido">
                         <asp:Button ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" Text="Nuevo" />
                     </td>
                 </tr>
                 <tr>
                  <td class="priTdContenido">
                      <asp:GridView ID="gvCuentas" runat="server" DataSourceID="odsCuentas" EnableModelValidation="True"></asp:GridView>
                      <asp:ObjectDataSource ID="odsCuentas" runat="server" SelectMethod="Lista" TypeName="terrasur.cuentaContable">
                          <SelectParameters>
                              <asp:ControlParameter ControlID="ddlOperacion" Name="Id_operacioncartera" PropertyName="SelectedValue" Type="Int32" />
                          </SelectParameters>
                      </asp:ObjectDataSource>
                  </td>
                </tr>
            </table>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            <uc1:ABMcuentasodoo runat="server" ID="ABMcuentasodoo" />
        </asp:View>

    </asp:MultiView>
   
</asp:Content>

