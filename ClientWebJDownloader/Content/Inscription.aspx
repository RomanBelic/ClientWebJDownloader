<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inscription.aspx.cs" Inherits="ClientWebJDownloader.Content.Inscription" %>

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
                    <td>Nom : 
                    </td>
                    <td>
                        <asp:TextBox ID="tbNom" runat="server" ValidationGroup="inscUser"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator2" ControlToValidate="tbNom" ErrorMessage="*Champs Requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="inscUser" />
                    </td>
                </tr>
                <tr>
                    <td>Prenom : 
                    </td>
                    <td>
                        <asp:TextBox ID="tbPrenom" runat="server" ValidationGroup="inscUser"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="tbPrenom" ErrorMessage="*Champs Requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="inscUser" />
                    </td>
                </tr>
                <tr>
                    <td>Login : 
                    </td>
                    <td>
                        <asp:TextBox ID="tbLogin" runat="server" ValidationGroup="inscUser" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator3" ControlToValidate="tbLogin" ErrorMessage="*Champs Requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="inscUser" />
                        <asp:Label ID="lblLoginError" Text="Login dèja existant" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>Password : 
                    </td>
                    <td>
                        <asp:TextBox ID="tbPassword" runat="server" ValidationGroup="inscUser" TextMode="Password" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator4" ControlToValidate="tbPassword" ErrorMessage="*Champs Requis" Display="Dynamic"
                            ForeColor="Red" ValidationGroup="inscUser" />
                    </td>
                </tr>
                <tr>
                    <td>Type du Compte : </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeUser" runat="server" DataSourceID="odsddlTypeUser" EnableViewState="true" DataTextField="NameStr" DataValueField="Id">
                        </asp:DropDownList>
                        <asp:ObjectDataSource ID="odsddlTypeUser" runat="server" TypeName="Common.Metier.UserTypeMetier"
                            OldValuesParameterFormatString="original_{0}" SelectMethod="GetUserTypes"></asp:ObjectDataSource>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnInscrire" runat="server" OnClick="btnInscrire_Click" Text="S'Inscrire" CausesValidation="true" ValidationGroup="inscUser" />
                    </td>
                    <td>
                        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Retour" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
