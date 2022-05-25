<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ABMcuentasodoo.ascx.cs" Inherits="recurso_carteraOdoo_cuentas_userControl_ABMcuentasodoo" %>
<style type="text/css">
    .auto-style1 {
        height: 30px;
    }
    .auto-style2 {
        height: 23px;
    }
</style>
<table>
    <tr>
        <td>
            OPERACION CARTERA:
        </td>
        <td>
            <asp:DropDownList ID="ddlOperacion" runat="server" AutoPostBack="True" DataSourceID="odsOperacion" DataTextField="nombre" DataValueField="id_operacioncartera" OnSelectedIndexChanged="ddlOperacion_SelectedIndexChanged"></asp:DropDownList>
            <asp:ObjectDataSource ID="odsOperacion" runat="server" SelectMethod="Lista" TypeName="terrasur.operacionCartera"></asp:ObjectDataSource>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            NOMBRE CUENTA:</td>
        <td>
            <asp:TextBox ID="txtNombreCuenta" runat="server" Width="300px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            PORCENTAJE OPERACION:</td>
        <td>
            <asp:TextBox ID="txtPorcentaje" runat="server" OnTextChanged="txtPorcentaje_TextChanged" Width="300px">100</asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            DESCRIPCION CUENTA:</td>
        <td>
            <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            CODIGO
            CUENTA DEBITO
        </td>
        <td class="auto-style2">
            CODIGO
            CUENTA CREDITO
        </td>
        <td class="auto-style2">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
           
            <asp:TextBox ID="txtDebito" runat="server"></asp:TextBox>
        </td>
        <td>
            
            <asp:TextBox ID="txtCredito" runat="server"></asp:TextBox>
        </td>
        <td>
            
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Button ID="btnAddDebito" runat="server" Text="Agregar" OnClick="btnAddDebito_Click" />
        </td>
        
        <td>
           <asp:Button ID="btnAddCredito" runat="server" Text="Agregar" OnClick="btnAddCredito_Click" />
        </td>
        
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:ListBox ID="lbCuentasDebito" runat="server" Height="200px" Width="400px" DataSourceID="odsCuentasDebito" DataTextField="nombre_completo" DataValueField="id_cuentacontable"></asp:ListBox>
        </td>
        <td>
            <asp:ListBox ID="lbCuentasCredito" runat="server" Height="200px" Width="400px" DataSourceID="odsCuentasCredito" DataTextField="nombre_completo" DataValueField="id_cuentacontable"></asp:ListBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:ObjectDataSource ID="odsCuentasDebito" runat="server" FilterExpression="debe=1" SelectMethod="Lista" TypeName="terrasur.cuentaContable">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlOperacion" Name="Id_operacioncartera" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        
        <td class="auto-style1">
            <asp:ObjectDataSource ID="odsCuentasCredito" runat="server" FilterExpression="haber=1" SelectMethod="Lista" TypeName="terrasur.cuentaContable">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddlOperacion" Name="Id_operacioncartera" PropertyName="SelectedValue" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
        </td>
        
        <td class="auto-style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            Monto de comprobacion:<asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
        </td>
        
        <td class="auto-style1">
            <asp:Button ID="btnProbar" runat="server" OnClick="btnProbar_Click" Text="Comprobar" />
            <br />
            <asp:Label ID="lblMsgComprobacion" runat="server"></asp:Label>
        </td>
        
        <td class="auto-style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            Suma debito:<asp:Label ID="lblSumaDebito" runat="server">0</asp:Label>
        </td>
        
        <td class="auto-style1">
            Suma credito:<asp:Label ID="lblSumaCredito" runat="server" Text="0"></asp:Label>
        </td>
        
        <td class="auto-style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style1">
            <asp:Button ID="btnDelDebito" runat="server" Text="Quitar" OnClick="btnDelDebito_Click" />
        </td>
        
        <td class="auto-style1">
           <asp:Button ID="btnDelCredito" runat="server" Text="Quitar" OnClick="btnDelCredito_Click" />
        </td>
        
        <td class="auto-style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        
        <td>
            &nbsp;</td>
        
        <td>
            &nbsp;</td>
    </tr>
</table>