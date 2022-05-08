<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBookmaster.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

    <div class="row text-center">
        <div class="col-md-12">
            <h2 style="color: #0094ff">Country Add Edit Page</h2>
        </div>
    </div>
     <br />
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <h3>Country Name : </h3>
        </div>
        <div class="col-md-8">
            <br />
            <asp:TextBox runat="server" ID="txtCountryName" CssClass="form-control" />
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-4">
           <h3> Country Code :</h3>
        </div>
        <div class="col-md-8">
            <br />
            <asp:TextBox runat="server" ID="txtCountryCode" CssClass="form-control" />
        </div>
    </div>
   
    <br />
    <div class="row">
        <div class="col-md-4">
        </div>
        <div class="col-md-8">
            <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary btn-sm" OnClick="btnSave_Click"/>
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger btn-sm" OnClick="btnCancel_Click"/>
        </div>
    </div>

</asp:Content>

