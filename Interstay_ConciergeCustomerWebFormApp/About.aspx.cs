using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div id='ctl00_MainContent_pnlContentType' class='RadPanelBar RadPanelBar_MetroTouch' style='width: 100 %; '>");
            sb.Append("<ul class='rpRootGroup'>");
            sb.Append("<li class='rpItem rpFirst'><a href='#' class='rpLink rpRootLink rpExpandable '><span class='rpOut'><img alt='' src='images/in_out.png' class='rpImage'><span class='rpExpandHandle'></span><span class='rpText'>체크인/체크아웃</span></span></a><div class='rpSlide'>");
            sb.Append("<ul class='rpGroup rpLevel1 '>");
            sb.Append("    <li class='rpItem rpFirst'><a href='ContentView/?Content_Id=16' class='rpLink'><span class='rpOut rpNavigation'><span class='rpExpandHandle'></span><span class='rpText'>자녀 동반 숙박 무료 서비스</span></span></a></li><li class='rpItem rpLast'><a href='ContentView/?Content_Id=35' class='rpLink'><span class='rpOut rpNavigation'><span class='rpExpandHandle'></span><span class='rpText'>무료 조식 서비스 안내</span></span></a></li>");
            sb.Append("</ul>");
            sb.Append("</div></li>");
            sb.Append("</ul>");
            sb.Append("</div>");
            Label1.Text = sb.ToString();
        }
    }
}