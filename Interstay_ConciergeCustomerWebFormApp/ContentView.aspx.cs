using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class ContentView : RootPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList lstLanguage = (DropDownList)Page.Master.FindControl("lstLanguage");
                lstLanguage.SelectedValue = (Request.Cookies["Language"] == null) ? "en-US" : Request.Cookies["Language"].Value;

                if (Request["Content_Id"] != null)
                    displayContent(int.Parse(Request["Content_Id"].ToString()));
            }
        }

        private void displayContent(int content_id)
        {
            string str = "usp_Concierge_Content_GetContent";

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = str;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hotel_id_number", SqlDbType.Int).Value = int.Parse(Request.Cookies["hotel_id_number"].Value);
                    cmd.Parameters.Add("@content_id", SqlDbType.Int).Value = content_id;

                    SqlDataReader dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {
                        //lblTitle.Text = dr["Content_Title"].ToString();
                        lblBody.Text = dr["Content_Body"].ToString();

                    }

                    dr.Close();

                }
                con.Close();

            }
        }
    }
}