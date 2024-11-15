using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Resources;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class _Default_old : RootPage
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            DropDownList lstLanguage = (DropDownList)Page.Master.FindControl("lstLanguage");
            
            if (!IsPostBack)
            {
                validateAccess();

                if (Request.Cookies["Language"] is null)
                {
                    bool hasSupportedLanguage = false;

                    foreach(ListItem item in lstLanguage.Items)
                    {
                        //현재 브라우저의 언어 중에 지원되는 언어가 있다면
                        if (Thread.CurrentThread.CurrentCulture.Equals(CultureInfo.CreateSpecificCulture(item.Value)))
                        {
                            Response.Cookies["Language"].Value = item.Value;
                            item.Selected = true;
                            hasSupportedLanguage = true;
                            Thread.CurrentThread.CurrentUICulture = new CultureInfo(item.Value);

                        }
                    }

                    //영어가 아닌 언어를 사용한다면 페이지를 새로고침
                    if(hasSupportedLanguage) {
                        Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        Response.Cookies["Language"].Value = "en-US";
                        lstLanguage.SelectedValue = "en-US";
                    }
                    
                }
                else
                {
                    lstLanguage.SelectedValue = Request.Cookies["Language"].Value;
                }

                hdnHotel_Id.Value = Request.Cookies["hotel_id_number"].Value;
                hdnRoom_Number.Value = Request.Cookies["room_number"].Value;
                hdnLanguage.Value = Request.Cookies["Language"].Value; 

                //pending request 가 있으면 표시
                displayPendingRequests();

                //요청에서 돌아오면 팝업 메세지 표시
                if(Request["SuccessRequestType"] != null)
                {
                    if(Request["SuccessRequestType"].ToString() == "6") //Check Out
                    {
                        notificationSuccessCheckOut.Show();
                    }
                    else
                    {
                        notificationSuccess.Show();
                    }
                }

            }
        }

        protected void displayPendingRequests()
        {

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "usp_Concierge_ServiceRequest_PendingRequests_GetList";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hotel_id", SqlDbType.Int).Value = hdnHotel_Id.Value;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar, 5).Value = hdnLanguage.Value;
                    cmd.Parameters.Add("@room_number", SqlDbType.VarChar, 50).Value = hdnRoom_Number.Value;

                    SqlDataReader dr = cmd.ExecuteReader();
                    pnlPendingRequests.Items.Clear();

                    if (dr.Read())
                    {
                        RadPanelItem newPendingRequestMenuItem = new RadPanelItem();                        
                        //newPendingRequestMenuItem.ImageUrl = "images/notes.gif";
                        newPendingRequestMenuItem.Expanded = true;                                           
                        newPendingRequestMenuItem.Text = (string)this.GetLocalResourceObject("pnlPendingRequests1.Text");
                        
                        do
                        {
                            RadPanelItem newPendingRequestChildItem = new RadPanelItem();
                            newPendingRequestChildItem.Text = dr["Message_Title"].ToString();
                            string localizedString = (string)this.GetLocalResourceObject("textPendingRequestDetail");
                            newPendingRequestChildItem.Text = localizedString.Replace("{0}", dr["MessageType_Name"].ToString()).Replace("{1}", dr["Status_Name"].ToString()).Replace("{2}", dr["Message_LastModified_Time"].ToString());
                            newPendingRequestChildItem.Value = dr["Message_Id"].ToString();
                            newPendingRequestChildItem.Expanded = false;
                            newPendingRequestMenuItem.Items.Add(newPendingRequestChildItem);

                        } while (dr.Read());

                        pnlPendingRequests.Items.Add(newPendingRequestMenuItem);
                        pnlPendingRequests.Visible = true;
                    }
                    dr.Close();
                }
                con.Close();
            }


        }

        //정상적인 접속인지 판단하고 호텔 관련 변수 세팅
        private void validateAccess()
        {
            //방에 국한되지 않는 시설 정보 등의 콘텐츠는 방 번호 없이도 접속 가능하다.
            string room_number = (Request.Cookies["room_number"] != null) ? Request.Cookies["room_number"].Value : "";

            string str = "usp_Concierge_ValidateAccess";

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = str;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hotel_id", SqlDbType.NVarChar, 50).Value = Request.Cookies["hotel_id"].Value;
                    cmd.Parameters.Add("@room_number", SqlDbType.NVarChar, 50).Value = room_number;

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        Response.Cookies["hotel_id_number"].Value = dr["Hotel_Id"].ToString(); //일련번호 형태, 텍스트 아님
                        Response.Cookies["bnbmall_URL"].Value = dr["Hotel_BnBMall_URL"].ToString().Replace("@room_number", room_number); //쇼핑몰 진입 URL
                    }
                    else
                    {
                        dr.Close();
                        Response.Redirect("Contact");
                    }

                    dr.Close();

                }
                con.Close();

            }

        }
    }
}