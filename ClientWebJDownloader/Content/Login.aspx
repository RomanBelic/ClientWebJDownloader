<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ClientWebJDownloader.Content.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Login : </td>
                    <td>
                        <asp:TextBox ID="tbLogin" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="tbLogin" ErrorMessage="Login requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="grpLog" />
                    </td>
                </tr>
                <tr>
                    <td>Mot de passe : </td>
                    <td>
                        <asp:TextBox ID="tbPass" runat="server" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="tbPass" ErrorMessage="Mot de passe requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="grpLog" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" ValidationGroup="grpLog" CausesValidation="true" />
                    </td>
                    <td>
                        <asp:Label ID="lblError" Visible="false" ForeColor="Red" runat="server" Text="Utilisateur non trouvé"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSubscribe" runat="server" OnClick="btnSubscribe_Click" Text="S'inscrire" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
