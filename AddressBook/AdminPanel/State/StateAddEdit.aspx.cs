using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (Request.QueryString["StateID"] != null)
            {
                lblMessage.Text = "Edit Mode | StateID = " + Request.QueryString["StateID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
            else
            {
                lblMessage.Text = "Add Mode";
            }

        }
     }

    #endregion Load Event

    #region Buttton : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        SqlInt32 StrCountryID = SqlInt32.Null;
        SqlString StrStateName = SqlString.Null;
        SqlString StrStateCode = SqlString.Null;
        #endregion Local Variables

        try
        {
            #region  Server Side Validation
            //Server Side Validation 
            String StrErrorMessage = "";

            if (ddlCountryID.SelectedIndex == 0)
                StrErrorMessage += "- Select Country <br />";

            if (txtStateName.Text.Trim() == "")
                StrErrorMessage += "- Enter State Name <br/>";

            if (txtStateCode.Text.Trim() == "")
                StrErrorMessage += "- Enter State Code <br/>";

        

            if (StrErrorMessage.Trim() != "")
            {
                lblMessage.Text = StrErrorMessage;
                return;
            }
            #endregion  Server Side Validation

            #region Gather Information
            //Gather the Information
            if (ddlCountryID.SelectedIndex > 0)
            {
                StrCountryID = Convert.ToInt32(ddlCountryID.SelectedValue);
            }
            if (txtStateName.Text.Trim() != "")
            {
                StrStateName = txtStateName.Text.Trim();
            }

            if (txtStateCode.Text.Trim() != "")
            {
                StrStateCode = txtStateCode.Text.Trim();
            }

      
            #endregion Gather Information

            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
            objConn.Open();


            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;


            objCmd.Parameters.AddWithValue("@CountryID", StrCountryID);
            objCmd.Parameters.AddWithValue("@StateName", StrStateName);
            objCmd.Parameters.AddWithValue("@StateCode", StrStateCode);
            #endregion Set Connection and Command Object


            if (Request.QueryString["StateID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@StateID", Request.QueryString["StateID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_State_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/State/StateList.aspx");
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.CommandText = "[dbo].[PR_State_Insert]";
                objCmd.ExecuteNonQuery();
                txtStateName.Text = "";
                ddlCountryID.SelectedIndex = 0;
                txtStateCode.Text = "";

                txtStateName.Focus();

                lblMessage.Text = "Data Inserted Succsessfully";
                #endregion Insert Record

            }


            if (objConn.State == ConnectionState.Open)
                objConn.Close();

          
         }
        catch(Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Buttton : Save

    #region Button: Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
        
    }

    #endregion Button: Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "PR_Country_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddlCountryID.DataSource = objSDR;
                ddlCountryID.DataValueField = "CountryID";
                ddlCountryID.DataTextField = "CountryName";
                ddlCountryID.DataBind();

            }

            ddlCountryID.Items.Insert(0, new ListItem("Select Country", "-1"));

            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }
        finally
        {
            if (objConn.State == ConnectionState.Open)
                objConn.Close();
        }
    }

    #endregion Fill DropDownList

    #region Fill Controls
    private void FillControls(SqlInt32 StateID)
    {
       SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

       try
       {
           #region Set Connection and Command Object
           if (objConn.State != ConnectionState.Open)
               objConn.Open();

           SqlCommand objCmd = objConn.CreateCommand();
           objCmd.CommandType = CommandType.StoredProcedure;
           objCmd.CommandText = "[dbo].[PR_State_SelectByPK]";
           objCmd.Parameters.AddWithValue("@StateID", StateID.ToString().Trim());
           #endregion Set Connection and Command Object

           SqlDataReader objSDR = objCmd.ExecuteReader();

           #region read the value and set the controls
           if (objSDR.HasRows)
           {
               while(objSDR.Read())
               {
                  
                   if(!objSDR["StateName"].Equals(DBNull.Value))
                   {
                       txtStateName.Text = objSDR["StateName"].ToString().Trim();
                   }
                   if (!objSDR["CountryID"].Equals(DBNull.Value))
                   {
                       ddlCountryID.SelectedValue = objSDR["CountryID"].ToString().Trim();
                   }
                   if (!objSDR["StateCode"].Equals(DBNull.Value))
                   {
                       txtStateCode.Text = objSDR["StateCode"].ToString().Trim();
                   }
          
                  break;
               }

           }
           else
           {
               lblMessage.Text = "No Data available for the StateID = " + StateID.ToString();
           }
           #endregion read the value and set the controls

       }
       catch(Exception ex)
       {
           lblMessage.Text = ex.Message;
       }
       finally
       {
           if (objConn.State == ConnectionState.Open)
               objConn.Close();
       }
    }

    #endregion Fill Controls
}