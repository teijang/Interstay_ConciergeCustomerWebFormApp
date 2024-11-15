using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using System.Configuration;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;

namespace Interstay_ConciergeCustomerWebFormApp
{
    
    public class RootPage : Page
    {
        public string ConnString = ConfigurationManager.ConnectionStrings["concierge"].ConnectionString;

        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {   

                /*잘못된 경로로 접근했을 때
                if ((Request["hotel_id"] is null || Request["room_number"] is null) && (Session["hotel_id"] is null || Session["room_number"] is null))
                {
                    Response.Redirect("Contact.aspx");
                }
                */
                if(Request["hotel_id"] != null)
                {
                    Response.Cookies["hotel_id"].Value = Request["hotel_id"].ToString();                                   
                }
                else
                {
                    Response.Cookies["hotel_id"].Value = "";
                }

                if (Request["room_number"] != null)
                {
                    Response.Cookies["room_number"].Value = Request["room_number"].ToString();
                }
                else
                {
                    Response.Cookies["room_number"].Value = "0";
                }
            }
            base.OnLoad(e);
        }

        protected override void InitializeCulture()
        {
            if (Request.Cookies["Language"] != null)
            {
                SetCulture(Request.Cookies["Language"].Value);

            }
            base.InitializeCulture();

            
        }

        protected string GetLocalIP()
        {
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }

            return localIP;
        }

        protected void SetCulture(string languageCulture)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(languageCulture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(languageCulture);
        }

        protected void displayContentList(int contentType_GroupId, RadPanelBar pnlContent)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "usp_Concierge_Content_GetList";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@concierge_HotelId", SqlDbType.NVarChar, 50).Value = Request.Cookies["hotel_id"].Value;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar, 5).Value = Request.Cookies["Language"].Value;
                    cmd.Parameters.Add("@ContentType_GroupID", SqlDbType.Int).Value = contentType_GroupId; //1: 숙소 매뉴얼, 2:주변 정보

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);

                        List<RadPanelItem> panelItems = new List<RadPanelItem> { };
                        //메세지 타입 제목들 생성
                        int currentContentType_Id = 0;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            //ContentType_Id 가 다르면 항목 생성
                            if (currentContentType_Id != int.Parse(dt.Rows[i]["ContentType_Id"].ToString()))
                            {
                                currentContentType_Id = int.Parse(dt.Rows[i]["ContentType_Id"].ToString());

                                RadPanelItem newContentTypeItem = new RadPanelItem();
                                newContentTypeItem.Text = dt.Rows[i]["ContentType_Name_Selected"].ToString();
                                newContentTypeItem.Value = dt.Rows[i]["ContentType_Id"].ToString();
                                newContentTypeItem.ImageUrl = dt.Rows[i]["ContentType_ImageURL"].ToString();
                                newContentTypeItem.ImagePosition = RadPanelItemImagePosition.Left;
                                newContentTypeItem.Expanded = false;

                                panelItems.Add(newContentTypeItem);
                            }
                        }

                        //메세지 타입별로 콘텐츠 세부 항목 등록
                        foreach (RadPanelItem contentType_Item in panelItems)
                        {
                            DataRow[] foundRows;

                            //데이터 테이블에서 해당 타입의 내용만 가져온다.
                            foundRows = dt.Select("ContentType_Id=" + contentType_Item.Value, "Content_Id");

                            for (int i = 0; i < foundRows.Length; i++)
                            {
                                RadPanelItem newContentTypeItem = new RadPanelItem();
                                newContentTypeItem.Text = foundRows[i]["Content_Title"].ToString();
                                newContentTypeItem.Value = foundRows[i]["Content_Id"].ToString();
                                newContentTypeItem.NavigateUrl = "ContentView/?Content_Id=" + foundRows[i]["Content_Id"].ToString();
                                newContentTypeItem.Expanded = false;

                                contentType_Item.Items.Add(newContentTypeItem);
                            }

                            pnlContent.Items.Add(contentType_Item);
                        }


                    }


                }
                con.Close();
            }


        }

        protected void displayContentList_New(int contentType_GroupId, Label lblBody)
        {
            using (SqlConnection con = new SqlConnection(ConnString))
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = "usp_Concierge_Content_GetList";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@concierge_HotelId", SqlDbType.NVarChar, 50).Value = Request.Cookies["hotel_id"].Value;
                    cmd.Parameters.Add("@languageCode", SqlDbType.NVarChar, 5).Value = Request.Cookies["Language"].Value;
                    cmd.Parameters.Add("@ContentType_GroupID", SqlDbType.Int).Value = contentType_GroupId; //1: 숙소 매뉴얼, 2:주변 정보

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                    {
                        adp.Fill(dt);

                        StringBuilder sb = new StringBuilder();

                        //메세지 타입 제목들 생성
                        int currentContentType_Id = 0;
                        int i = 0;
                        while (i < dt.Rows.Count)
                        {
                            currentContentType_Id = int.Parse(dt.Rows[i]["ContentType_Id"].ToString());

                            sb.Append("<div class=\"row\">");
                            sb.Append("<div class=\"col-xs-4 left\">");
                            sb.Append("<img src=\"" + dt.Rows[i]["ContentType_ImageURL"].ToString() + "\">");
                            sb.Append("</div>");
                            sb.Append("<div class=\"col-xs-8 right\">");
                            sb.Append("<h5 class=\"tit\">" + dt.Rows[i]["ContentType_Name_Selected"].ToString() + "</h5>");
                            //sb.Append("<p class=\"txt\">&nbsp;</p>");

                            //하위 항목들 링크 생성
                            while (i < dt.Rows.Count && currentContentType_Id == int.Parse(dt.Rows[i]["ContentType_Id"].ToString()))
                            {
                                sb.Append("<a href=\"" + "ContentView/?Content_Id=" + dt.Rows[i]["Content_Id"].ToString() + "\">");
                                sb.Append(dt.Rows[i]["Content_Title"].ToString() + "&nbsp;&nbsp;&#10095;&#10095;</a>");
                                i++;
                            }

                            sb.Append("</div>");
                            sb.Append("</div>");
                        }

                        lblBody.Text = sb.ToString();
                    }


                }
                con.Close();
            }


        }

        protected async Task<string> SendPushNotificationByTopic(string title, string body, string topic, Dictionary<string,string> data)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("C:\\google\\daring-anagram-294708-f2af1581bd7a_firebase.json"),
                });
            }

            var message = new FirebaseAdmin.Messaging.Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body,
                },
                Data = data,
                Topic = topic,
            };

            string response;

            try
            {
                response = await FirebaseMessaging.DefaultInstance.SendAsync(message).ConfigureAwait(false);
            }
            catch(Exception err)
            {
                response = err.Message;
            }

            return response;
        }

        protected async Task<string> SendPushNotificationByToken(string title, string body, string token, Dictionary<string, string> data)
        {
            if (FirebaseApp.DefaultInstance == null)
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("C:\\google\\daring-anagram-294708-f2af1581bd7a_firebase.json"),
                });
            }

            var message = new FirebaseAdmin.Messaging.Message()
            {
                Notification = new Notification()
                {
                    Title = title,
                    Body = body,
                },
                Data = data,
                Token = token,
            };

            string response;

            try
            {
                response = await FirebaseMessaging.DefaultInstance.SendAsync(message).ConfigureAwait(false);
            }
            catch (Exception err)
            {
                response = err.Message;
            }

            return response;
        }

    }

}