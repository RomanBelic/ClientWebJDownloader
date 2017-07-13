<%@ Page Language="C#" Title="Gestion des Liens" AutoEventWireup="true" CodeBehind="Page_Link.aspx.cs" Inherits="ClientWebJDownloader.Content.Page_Link"
    MasterPageFile="~/Content/HeaderMaster.Master" %>

<%@ Register TagPrefix="uc" Src="~/Content/UC_AddLink.ascx" TagName="addLink" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="updPanel" runat="server" ChildrenAsTriggers="true">
        <ContentTemplate>
            <div>
                <br />
                <table>
                    <tr>
                        <td style="padding-bottom: 25px">
                            <asp:Button ID="btnAddLink" runat="server" OnClick="btnAddLink_Click" Text="Ajouter un lien" ValidationGroup="grpAdd" CausesValidation="true" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                           <uc:addLink runat="server" id="ucAddLink"></uc:addLink> 
                           <br />
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
                                    <asp:BoundField DataField="Name" HeaderText="Nom" SortExpression="DateCreated" ReadOnly="True" />
                                    <asp:TemplateField HeaderText="Url">
                                        <ItemTemplate>
                                            <div style="text-align:center">
                                                <asp:LinkButton id="urlLink" runat="server" Text='<% #Eval("Url") %>' PostBackUrl='<%# Eval("Url") %>'></asp:LinkButton>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="DateCreatedStr" HeaderText="Date d'Ajout" ReadOnly="True" SortExpression="DateCreatedStr" />
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
