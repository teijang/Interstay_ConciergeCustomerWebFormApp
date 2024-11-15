using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class SiteMaster_Daiso : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void lstLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Cookies["Language"].Value = lstLanguage.SelectedValue;
            Response.Redirect(Request.RawUrl);
        }
    }
}