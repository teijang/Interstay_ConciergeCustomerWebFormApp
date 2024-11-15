using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Threading.Tasks;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class FCMTest : RootPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.AsyncMode = true;
        }

        protected async void btnToken_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();

            openWith.Add(txtDataKey.Text, txtDataValue.Text);

            Task<string> longRunningTask = SendPushNotificationByToken(txtTitle.Text, txtBody.Text, txtTopic.Text, openWith);
            string rst = await longRunningTask;

            Response.Write(rst);
        }

        protected async void btnTopic_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> openWith = new Dictionary<string, string>();

            openWith.Add(txtDataKey.Text, txtDataValue.Text);

            Task<string> longRunningTask = SendPushNotificationByTopic(txtTitle.Text, txtBody.Text, txtTopic.Text, openWith);
            string rst = await longRunningTask;

            Response.Write(rst);
        }
    }
}