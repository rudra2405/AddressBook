<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBookmaster.master" AutoEventWireup="true" CodeFile="CityList.aspx.cs" Inherits="AdminPanel_City_CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

     <div class="row">
        <div class="col-md-12 text-center">
            <h2 style="color: #0094ff"><u>City List</u></h2>
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
                 <asp:HyperLink runat="server" ID="h1AddCity" Text="Add new City" NavigateUrl="~/AdminPanel/City/CityAddEdit.aspx" CssClass="btn btn-primary"></asp:HyperLink>
            </div>
            <div>
             <asp:GridView ID="gvCity" runat="server" OnRowCommand="gvCity_RowCommand" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
                  <AlternatingRowStyle BackColor="PaleGoldenrod" />
                  <Columns>
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnDelete" Text="Delete" CssClass="btn btn-danger" 
                                commandName="DeleteRecord" CommandArgument='<%# Eval("CityID").ToString() %>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Edit">
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="h1Edit" Text="Edit" CssClass="btn btn-warning" NavigateUrl='<%# "~/AdminPanel/City/CityAddEdit.aspx?CityID=" + Eval("CityID").ToString().Trim() %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="CityID" HeaderText="ID" />
                    <asp:BoundField DataField="StateName" HeaderText="State" />
                    <asp:BoundField DataField="CityName" HeaderText="City" />
                    <asp:BoundField DataField="STDCode" HeaderText="STDCode" />
                    <asp:BoundField DataField="PinCode" HeaderText="PinCode" />

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

