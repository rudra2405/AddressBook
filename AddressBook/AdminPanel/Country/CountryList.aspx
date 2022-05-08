<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBookmaster.master" AutoEventWireup="true" CodeFile="CountryList.aspx.cs" Inherits="AdminPanel_Country_CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <div class="row">
        <div class="col-md-12 text-center">
            <h2 style="color:#0094ff"><u>Country List</u></h2>
        </div>
    </div>
     <div class="row">
        <div class="col-md-12">
            <asp:Label ID="lblMessage" runat="server" EnableViewState="false"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
             <div>
                 <asp:HyperLink runat="server" ID="h1AddCountry" Text="Add new Country" NavigateUrl="~/AdminPanel/Country/CountryAddEdit.aspx" CssClass="btn btn-primary"></asp:HyperLink>
            </div>
            <div>
            <asp:GridView ID="gvCountry" runat="server" OnRowCommand="gvCountry_RowCommand"  AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                 <AlternatingRowStyle BackColor="PaleGoldenrod" />
                 <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" 
                                 CommandName="DeleteRecord" CommandArgument='<%# Eval("CountryID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="h1Edit" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/Country/CountryAddEdit.aspx?CountryID=" + Eval("CountryID").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                     
                    <asp:BoundField DataField="CountryID" HeaderText="ID" />
                    <asp:BoundField DataField="CountryName" HeaderText="Country" />
                    <asp:BoundField DataField="CountryCode" HeaderText="CountryCode" />
                </Columns>
                 <FooterStyle BackColor="Tan" />
                 <HeaderStyle BackColor="Tan" Font-Bold="True" />
                 <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                 <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                 <SortedAscendingCellStyle BackColor="#FAFAE7" />
                 <SortedAscendingHeaderStyle BackColor="#DAC09E" />
                 <SortedDescendingCellStyle BackColor="#E1DB9C" />
                 <SortedDescendingHeaderStyle BackColor="#C2A47B" />
            </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

