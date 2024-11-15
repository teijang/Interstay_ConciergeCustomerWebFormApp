﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data;
using System.Data.SqlClient;

namespace Interstay_ConciergeCustomerWebFormApp
{
    public partial class FacilityGuide_old : RootPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DropDownList lstLanguage = (DropDownList)Page.Master.FindControl("lstLanguage");
                lstLanguage.SelectedValue = Request.Cookies["Language"].Value;

                //displayContentList(1, pnlContentType); //1: 숙소 매뉴얼, 2:주변 정보
            }
        }

        
    }
}