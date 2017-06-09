<%@ Page Language="C#" Title="Gestion des Liens" AutoEventWireup="true" CodeBehind="Page_Link.aspx.cs" Inherits="ClientWebJDownloader.Content.Page_Link"
    MasterPageFile="~/Content/HeaderMaster.Master" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPanel" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div>
                <br />
                <table>
                    <tr>
                           <td style="padding-bottom:25px">Url de téléchargement : 
                             <asp:TextBox ID="tbUrl" runat="server" ValidationGroup="grpAdd"></asp:TextBox>
                        </td>
                        <td style="padding-bottom:25px">
                            <asp:Button ID="btnAddLink" runat="server" OnClick="btnAddLink_Click" Text="Ajouter" ValidationGroup="grpAdd" CausesValidation="true" />
                            <asp:RequiredFieldValidator runat="server" ID="reqName" ControlToValidate="tbUrl" ErrorMessage="Entrez l'URL du lien" Display="Dynamic"
                                ForeColor="Red" ValidationGroup="grpAdd" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gvLinks" runat="server" DataSourceID="odsGvLinks" AutoGenerateColumns="False" AllowPaging="true"
                                OnPageIndexChanging="gvLinks_PageIndexChanging" DataKeyNames="Id" PageSize="20">
                                <Columns>
                                    <asp:TemplateField ItemStyle-Width="25px">
                                        <ItemTemplate>
                                            <div style="text-align: center">
                                                <%# (Container.DataItemIndex + 1) %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Url" HeaderText="Url" SortExpression="DateCreated" ReadOnly="True" ItemStyle-Width="200px" />
                                    <asp:BoundField DataField="DateCreatedStr" HeaderText="Date" ReadOnly="True" SortExpression="DateCreatedStr" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button ID="btnDelete" OnClick="btnDelete_Click" Text="Supprimer" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource runat="server" ID="odsGvLinks" TypeName="Common.Metier.LinkMetier"
                                OnSelecting="odsGvLinks_Selecting"
                                SelectMethod="GetLinks" OldValuesParameterFormatString="original_{0}">
                                <SelectParameters>
                                    <asp:Parameter Name="IdUser" DefaultValue="0" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnAddLink" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
