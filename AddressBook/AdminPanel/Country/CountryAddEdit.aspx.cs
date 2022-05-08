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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                lblMessage.Text = "Edit Mode | CountryID = " + Request.QueryString["CountryID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));

            }
            else
            {
                lblMessage.Text = "Add Mode";
            }
        }
    }

    #endregion Load Event 

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Local Variables
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());
        SqlString StrCountryName = SqlString.Null;
        SqlString StrCountryCode = SqlString.Null;

        #endregion Local Variables

        try
        {
            #region Server Side Validation
            //Server Side Validation
           String StrErrorMessage = "";

            if (txtCountryName.Text.Trim() == "")
                StrErrorMessage += "Select CountryName First <br />";

            if (txtCountryCode.Text.Trim() == "")
                StrErrorMessage += "Select CountryCode First <br />";


            if (StrErrorMessage.Trim() != "")
            {
                lblMessage.Text = StrErrorMessage;
                return;
            }
            #endregion Server Side Validation

            #region Set Connection and Command Object

            if (objConn.State != ConnectionState.Open)
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            StrCountryName = txtCountryName.Text.Trim();
            StrCountryCode = txtCountryCode.Text.Trim();

            objCmd.Parameters.AddWithValue("@CountryName", StrCountryName);
            objCmd.Parameters.AddWithValue("@CountryCode", StrCountryCode);

            #endregion Set Connection and Command Object


            if (Request.QueryString["CountryID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.CommandText = "[dbo].[PR_Country_UpdateByPK]";
                objCmd.Parameters.AddWithValue("@CountryID", Request.QueryString["CountryID"].ToString().Trim());
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.CommandText = "[dbo].[PR_Country_Insert]";
                objCmd.ExecuteNonQuery();
                txtCountryName.Text = " ";
                txtCountryCode.Text = " ";

                txtCountryName.Focus();

                lblMessage.Text = "Data Inserted Succsessfully";
                #endregion Insert Record
            }
          

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

    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");

    }

    #endregion Button: Cancel

    #region Fill Controls
    private void FillControls(SqlInt32 CountryID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_Country_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CountryID", CountryID.ToString().Trim());
            #endregion Set Connection and Command object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region read the value and set the controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {
                  
                    if (!objSDR["CountryName"].Equals(DBNull.Value))
                    {
                        txtCountryName.Text = objSDR["CountryName"].ToString().Trim();
                    }
                    if (!objSDR["CountryCode"].Equals(DBNull.Value))
                    {
                        txtCountryCode.Text = objSDR["CountryCode"].ToString().Trim();
                    }
                   
                    break;
                }

            }
            else
            {
                lblMessage.Text = "No Data available for the CountryID = " + CountryID.ToString();
            }
            #endregion read the value and set the controls

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

    #endregion Fill Controls
}