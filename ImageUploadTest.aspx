<%@ Page Title="" Language="C#" MasterPageFile="~/MegnaSolar.Master" AutoEventWireup="true"
    EnableEventValidation="false" CodeBehind="ImageUploadTest.aspx.cs" Inherits="EATL.WebClient.CommonUI.ImageUploadTest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxConTK" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <fieldset>
            <legend>Customer Info</legend>
            <table width="100%">
                <colgroup>
                    <col width="15%" />
                    <col width="32%" />
                    <col width="6%" />
                    <col width="15%" />
                    <col width="32%" />
                </colgroup>
                <tr>
                    <td class="LabelTD_D">
                        Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerName" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        Father Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerFatherName" runat="server" CssClass="STextBox" Text=""
                            Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D">
                        Spouse Name :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerSpouseName" runat="server" CssClass="STextBox" Text=""
                            Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        District :
                    </td>
                    <td>
                        <asp:DropDownList ID="dropDLDistrict" runat="server" CssClass="STextBox" Width="95%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D" style="display: none;">
                        Sub District :
                    </td>
                    <td style="display: none;">
                        <asp:DropDownList ID="dropDLSubDistrict" runat="server" CssClass="STextBox" AutoPostBack="true"
                            Width="95%">
                        </asp:DropDownList>
                    </td>
                    <td style="display: none;">
                    </td>
                    <td class="LabelTD_D">
                        Post Office :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPostOffice" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        Union :
                    </td>
                    <td>
                        <asp:DropDownList ID="dropDLUnion" runat="server" CssClass="STextBox" Width="95%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D">
                        Mobile Phone :
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobilePhone" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        Village :
                    </td>
                    <td>
                        <asp:TextBox ID="txtVillage" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D">
                        National ID :
                    </td>
                    <td>
                        <asp:TextBox ID="txtNationalID" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        Home Phone :
                    </td>
                    <td>
                        <asp:TextBox ID="txtHomePhone" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D">
                        Pass Book No :
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassBookNo" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                        Customer No :
                    </td>
                    <td>
                        <asp:TextBox ID="txtCustomerNo" runat="server" CssClass="STextBox" Text="" Width="95%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="LabelTD_D">
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                    <td class="LabelTD_D">
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
    <div id="CustomerImage">
        <fieldset>
            <legend>Customer Picture</legend>
            <table width="100%">
                <colgroup>
                    <col width="15%" />
                    <col width="33%" />
                    <col width="4%" />
                    <col width="20%" />
                    <col width="28%" />
                </colgroup>
                <tr>
                    <td colspan="5">
                        <asp:CheckBox ID="CheckBox" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:Image ID="ImgCustomerPicture" runat="server" Width="220px" Height="200px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:FileUpload ID="file" runat="server" Width="80px" />
                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" /><br />
                        <asp:Label ID="lblImagePath" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="True"
                OnRowCancelingEdit="GridView1_RowCancelingEdit" DataKeyNames="IID" CellPadding="4"
                OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" ForeColor="#333333">
                <Columns>
                    <asp:TemplateField HeaderText="Sl." HeaderStyle-Width="30px">
                        <ItemTemplate>
                            <asp:Label ID="lblSRNO" runat="server" Text='<%#Container.DataItemIndex+1 %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="IID" HeaderStyle-Width="200px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblIID" runat="server" Text='<%# Eval("IID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CustomerID" HeaderStyle-Width="200px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblCustomerID" runat="server" Text='<%# Eval("CustomerID") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ImageLocation" HeaderStyle-Width="200px">
                        <ItemTemplate>
                            <asp:Label ID="lblImageLocation" runat="server" Text='<%# Eval("ImageLocation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Image" HeaderStyle-Width="105px">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("ImageLocation") %>' Height="80px"
                                Width="100px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Image ID="img_user" runat="server" ImageUrl='<%# Eval("ImageLocation") %>' Height="80px"
                                Width="100px" /><br />
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-Width="150px">
                        <ItemTemplate>
                            <asp:LinkButton ID="LkB1" runat="server" CommandName="Edit">Edit</asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:LinkButton ID="LkB2" runat="server" CommandName="Update">Update</asp:LinkButton>
                            <asp:LinkButton ID="LkB3" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </fieldset>
    </div>
    <%--<div>
        <fieldset>
            <asp:Button ID="btnSave" runat="server" Text="Save" Width="100px" ForeColor="#05799e"
                Font-Bold="true" OnClick="btnSave_Click" />
            <asp:Label ID="lblWarning" runat="server" Text=""></asp:Label>
        </fieldset>
    </div>--%>
</asp:Content>
