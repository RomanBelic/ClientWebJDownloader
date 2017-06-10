<%@ Page Language="C#" Title="Profil" AutoEventWireup="true" CodeBehind="Page_Profil.aspx.cs" Inherits="ClientWebJDownloader.Content.Page_Profil" MasterPageFile="~/Content/HeaderMaster.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPanel" runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <br />
                <table>
                    <tr>
                        <td>Nom : 
                        </td>
                        <td>
                            <asp:Label ID="lblNom" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Prénom : 
                        </td>
                        <td>
                            <asp:Label ID="lblPrenom" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Login :
                        </td>
                        <td>
                            <asp:TextBox ID="tbLogin" runat="server" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="tbLogin" ErrorMessage="*Ne doît pas être vide" Display="Dynamic"
                                ForeColor="Red" ValidationGroup="grpProfile" />
                            <asp:Label ID="lblErrorLogin" ForeColor="Red" Text="Login dèja existant" Visible="false" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>Mot de passe :
                        </td>
                        <td>
                            <asp:TextBox ID="tbPass" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" ControlToValidate="tbPass" ErrorMessage="*Ne doît pas être vide" Display="Dynamic"
                                ForeColor="Red" ValidationGroup="grpProfile" />
                        </td>
                    </tr>
                    <tr>
                        <td>Compte : 
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeCompte" runat="server" DataTextField="NameStr" DataValueField="Id" OnPreRender="ddlTypeCompte_PreRender"
                                EnableViewState="false" DataSourceID="odsddlTypeCompte">
                            </asp:DropDownList>
                            <asp:ObjectDataSource ID="odsddlTypeCompte" runat="server" TypeName="Common.Metier.UserTypeMetier"
                                OldValuesParameterFormatString="original_{0}" SelectMethod="GetUserTypes"></asp:ObjectDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            <asp:Label ID="lblSuccessUpdate" runat="server" ForeColor="Green" Text="Compte a été mise à jour" Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnValidate" runat="server" Text="Valider" OnClick="btnValidate_Click" ValidationGroup="grpProfile" CausesValidation="true" />
                        </td>
                        <td>
                            <asp:Button ID="btnAnnuler" runat="server" Text="Retour" OnClick="btnAnnuler_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAnnuler" />
            <asp:AsyncPostBackTrigger ControlID="btnValidate" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
