<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBookmaster.master" AutoEventWireup="true" CodeFile="CityAddEdit.aspx.cs" Inherits="AdminPanel_City_CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

     <div class="row text-center">
        <div class="col-md-12">
            <h2 style="color:#0094ff"">City Add Edit Page</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="false" />
        </div>
    </div>
    <br />
    <div class="row">
         <div class="col-md-4">
                <h3> State ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
      <div class="row">
          <div class="col-md-4">
                <h3> City Name :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtCityName" CssClass="form-control" />
           </div>
      </div>
    <br />
      <div class="row">
          <div class="col-md-4">
                <h3> STD Code :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtSTDCode" CssClass="form-control" />
           </div>
      </div>
    <br />
      <div class="row">
          <div class="col-md-4">
                <h3> Pin Code :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtPinCode" CssClass="form-control" />
           </div>
      </div>
    <br />
     <div class="row">
          <div class="col-md-4">
            </div>
           <div class="col-md-8">
                <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click"/>
                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click"/>
           </div>
      </div>
</asp:Content>

