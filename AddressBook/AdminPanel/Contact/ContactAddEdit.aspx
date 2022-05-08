<%@ Page Title="" Language="C#" MasterPageFile="~/Content/AddressBookmaster.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" Runat="Server">

     <div class="row text-center">
        <div class="col-md-12">
            <h2 style="color: #0094ff">Contact Add Edit Page</h2>
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
                <h3> Country ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
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
                <h3> City ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlCityID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
     <div class="row">
         <div class="col-md-4">
                <h3> ContactCategory ID : </h3>
          </div>
          <div class="col-md-8">
              <br />
               <asp:DropDownList runat="server" ID="ddlContactCategoryID" CssClass="form-control"></asp:DropDownList>
          </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> ContactName :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtContactName" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> ContactNo :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtContactNo" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> WhatsApp No :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtWhatsAppNo" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Birthdate :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtBirthdate" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Email :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Age :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtAge" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Address :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> BloodGroup :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtBloodGroup" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Facebook ID :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtFacebookID" CssClass="form-control" />
           </div>
      </div>
    <div class="row">
          <div class="col-md-4">
                <h3> Linkedin ID :</h3>
            </div>
           <div class="col-md-8">
               <br />
                <asp:TextBox runat="server" ID="txtLinkedinID" CssClass="form-control" />
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

