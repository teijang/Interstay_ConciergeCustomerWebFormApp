using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Telerik.Web.UI;
using System.Data;
using System.Threading.Tasks;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class ServiceRequest : RootPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //다른 메뉴들은 hotel_id가 없어도 동작이 가능하나 Service Request 는 valid한 hotel_id_number가 있는 경우에만 이용 가능
                if (Request.Cookies["hotel_id_number"] is null)
                {
                    Response.Redirect("Contact");
                }
                else
                {
                    //작성 시간이 길어져서 session이 만료가 되어도 동작하도록
                    hdnHotel_Id.Value = Request.Cookies["hotel_id_number"].Value;
                    hdnRoom_Number.Value = Request.Cookies["room_number"].Value;
                    hdnLanguage.Value = Request.Cookies["Language"].Value;

                    DropDownList lstLanguage = (DropDownList)Page.Master.FindControl("lstLanguage");
                    lstLanguage.SelectedValue = Request.Cookies["Language"].Value;

                    //체크인,아웃의 경우에는 요청 서비스 종류를 고를 필요가 없음
                    if (Request["SpecialFeature"] is null) //일반
                        setMessageTypeList(0, lstMessageType);
                    else                                            //check-in, chck-out, etc
                        setMessageTypeList(int.Parse(Request["MessageType_Id"].ToString()), lstMessageType);

                    //Message Template
                    displayTemplate();

                    //자동으로 변환하는 필터를 제거해 준다
                    txtBody.DisableFilter(EditorFilters.ConvertFontToSpan);
                }
            }
        }

        protected void setMessageTypeList(int messageType_Id, RadDropDownList _lstMessageType)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "usp_Concierge_ServiceRequest_MessageType_GetList";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hotel_id", SqlDbType.Int).Value = hdnHotel_Id.Value;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar, 5).Value = hdnLanguage.Value;
                    cmd.Parameters.Add("@messageType_Id", SqlDbType.Int).Value = messageType_Id; //5: Check-in, 6:Check-out, 0 : 모두

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);
                        _lstMessageType.DataTextField = "messageType_Name_selected";
                        _lstMessageType.DataValueField = "MessageType_Id";
                        _lstMessageType.DataSource = dt;
                        _lstMessageType.DataBind();
                    }
                }
                con.Close();
            }


        }

        //메세지 템플릿 읽어오기
        private void displayTemplate()
        {
            string str = "usp_Concierge_ServiceRequest_GetTemplate";

            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = str;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@hotel_id", SqlDbType.Int).Value = int.Parse(hdnHotel_Id.Value);
                    cmd.Parameters.Add("@MessageType_Id", SqlDbType.Int).Value = int.Parse(lstMessageType.SelectedValue);
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar, 5).Value = hdnLanguage.Value;

                    SqlDataReader dr = cmd.ExecuteReader();


                    if (dr.Read())
                    {   
                        txtBody.Content = dr["MessageTemplate_Body"].ToString();
                        txtBody.EditModes = EditModes.Preview;
                    }
                    else
                    {
                        txtBody.Content = "";
                        txtBody.EditModes = EditModes.Design;
                    }

                    dr.Close();

                }
                con.Close();

            }
        }

        protected async void txtSubmit_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "usp_Message_New";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Hotel_Id", SqlDbType.Int).Value = int.Parse(hdnHotel_Id.Value);                    
                    cmd.Parameters.Add("@messageType_Id", SqlDbType.Int).Value = int.Parse(lstMessageType.SelectedValue);
                    cmd.Parameters.Add("@Message_From", SqlDbType.NVarChar, 50).Value = hdnRoom_Number.Value;
                    cmd.Parameters.Add("@Message_Title", SqlDbType.NVarChar, 256).Value = lstMessageType.SelectedText;
                    cmd.Parameters.Add("@Message_Body", SqlDbType.NVarChar).Value = txtBody.Content;
                    cmd.Parameters.Add("@new_id", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();

                    //FCM Notification
                    try
                    {
                        Dictionary<string, string> openWith = new Dictionary<string, string>();

                        openWith.Add("MessageType_Id", lstMessageType.SelectedValue);
                        openWith.Add("Message_Id", cmd.Parameters["@new_id"].Value.ToString());

                        string topic_text = hdnHotel_Id.Value + "_" + lstMessageType.SelectedValue;

                        Task<string> longRunningTask = SendPushNotificationByTopic(lstMessageType.SelectedText, "Room Number: " + hdnRoom_Number.Value, topic_text, openWith);
                        string rst = await longRunningTask;
                    }
                    catch(Exception err)
                    {

                    }
                    //txtBody.Content = string.Empty;
                    //notificationSuccess.Show();                    
                }
                con.Close();
            }

            Response.Redirect("/?SuccessRequestType=" + lstMessageType.SelectedValue);
        }

        protected void lstMessageType_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            displayTemplate();
        }
    }
}