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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            FillDropDownList();

            if (Request.QueryString["CityID"] != null)
            {
                lblMessage.Text = "Edit Mode | CityID = " + Request.QueryString["CityID"].ToString();
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
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
        SqlInt32 StrStateID = SqlInt32.Null;
        SqlString StrCityName = SqlString.Null;
        SqlString StrSTDCode = SqlString.Null;
        SqlString StrPinCode = SqlString.Null;
      
        #endregion Local Variables

        try
        {
            #region  Server Side Validation
            //Server side Validation
            String StrErrorMessage = "";

            if (ddlStateID.SelectedIndex == 0)
                StrErrorMessage += "- Select State <br />";

            if (txtCityName.Text.Trim() == "")
                StrErrorMessage += "- Enter City Name <br/>";

            if (txtSTDCode.Text.Trim() == "")
                StrErrorMessage += "- Enter STD Code <br/>";

            if (txtPinCode.Text.Trim() == "")
                StrErrorMessage += "- Enter Pin Code <br/>";


            if (StrErrorMessage.Trim() != "")
            {
                lblMessage.Text = StrErrorMessage;
                return;
            }
            #endregion  Server Side Validation

            #region Gather Information
            //Gather the Information
            if (ddlStateID.SelectedIndex > 0)
            {
                StrStateID = Convert.ToInt32(ddlStateID.SelectedValue);
            }
            if (txtCityName.Text.Trim() != "")
            {
                StrCityName = txtCityName.Text.Trim();
            }

            if (txtSTDCode.Text.Trim() != "")
            {
                StrSTDCode = txtSTDCode.Text.Trim();
            }
            if (txtPinCode.Text.Trim() != "")
            {
                StrPinCode = txtPinCode.Text.Trim();
            }

            #endregion Gather Information

            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
            objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;

            objCmd.Parameters.AddWithValue("@StateID", StrStateID);
            objCmd.Parameters.AddWithValue("@CityName", StrCityName);
            objCmd.Parameters.AddWithValue("@STDCode", StrSTDCode);
            objCmd.Parameters.AddWithValue("@PinCode", StrPinCode);
          
            #endregion Set Connection and Command Object


            if (Request.QueryString["CityID"] != null)
            {
                #region Update Record
                //edit mode
                objCmd.Parameters.AddWithValue("@CityID", Request.QueryString["CityID"].ToString().Trim());
                objCmd.CommandText = "[dbo].[PR_City_UpdateByPK]";
                objCmd.ExecuteNonQuery();
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
                #endregion Update Record

            }
            else
            {
                #region Insert Record
                //Add mode
                objCmd.CommandText = "[dbo].[PR_City_Insert]";
                objCmd.ExecuteNonQuery();

                txtCityName.Text = "";
                ddlStateID.SelectedIndex = 0;
                txtSTDCode.Text = "";
                txtPinCode.Text = "";
               
                txtCityName.Focus();

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

    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");

    }

    #endregion Button : Cancel

    #region  Fill DropDownList
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
            objCmd.CommandText = "PR_State_SelectForDropDownList";
            SqlDataReader objSDR = objCmd.ExecuteReader();
            #endregion Set Connection and Command Object

            if (objSDR.HasRows == true)
            {
                ddlStateID.DataSource = objSDR;
                ddlStateID.DataValueField = "StateID";
                ddlStateID.DataTextField = "StateName";
                ddlStateID.DataBind();

            }

            ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

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
    
    #endregion  Fill DropDownList

    #region Fill Controls
    private void FillControls(SqlInt32 CityID)
    {
        SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["AddressBookConnectionString"].ConnectionString.Trim());

        try
        {
            #region Set Connection and Command Object
            if (objConn.State != ConnectionState.Open)
                objConn.Open();

            SqlCommand objCmd = objConn.CreateCommand();
            objCmd.CommandType = CommandType.StoredProcedure;
            objCmd.CommandText = "[dbo].[PR_City_SelectByPK]";
            objCmd.Parameters.AddWithValue("@CityID", CityID.ToString().Trim());
            #endregion Set Connection and Command Object

            SqlDataReader objSDR = objCmd.ExecuteReader();

            #region read the value and set the controls
            if (objSDR.HasRows)
            {
                while (objSDR.Read())
                {

                    if (!objSDR["CityName"].Equals(DBNull.Value))
                    {
                        txtCityName.Text = objSDR["CityName"].ToString().Trim();
                    }
                    if (!objSDR["StateID"].Equals(DBNull.Value))
                    {
                        ddlStateID.SelectedValue = objSDR["StateID"].ToString().Trim();
                    }
                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                    {
                        txtSTDCode.Text = objSDR["STDCode"].ToString().Trim();
                    }
                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                    {
                        txtPinCode.Text = objSDR["PinCode"].ToString().Trim();
                    }
                    break;
                }

            }
            else
            {
                lblMessage.Text = "No Data available for the CityID = " + CityID.ToString();
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