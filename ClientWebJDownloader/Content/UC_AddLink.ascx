<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AddLink.ascx.cs" Inherits="ClientWebJDownloader.Content.UC_AddLink" %>

<asp:Panel ID="pnlNewLink" runat="server" Visible="false">
    <table>
        <tr>
            <td>URL : 
            </td>
            <td>
                <asp:TextBox ID="tbURL" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="tbURL" ErrorMessage="Entrez l'URL du lien" Display="Dynamic"
                    ForeColor="Red" ValidationGroup="grpAdd" />
            </td>
        </tr>
        <tr>
            <td>Nom de l'URL : 
            </td>
            <td>
                <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnValider" runat="server" Text="Valider" OnClick="btnValider_Click" CausesValidation="true" ValidationGroup="grpAdd" />
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="Annuler" OnClick="btnClose_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
