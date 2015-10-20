using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SAPS
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl nav_bar = (HtmlGenericControl)Page.Master.FindControl("navigation_bar"); //para ocultar el navbar
            HtmlGenericControl cuerpo = (HtmlGenericControl)Page.Master.FindControl("cuerpo");
            cuerpo.Attributes.Add("class", "container-fluid body-content");
            nav_bar.Style.Add("display", "none");
        }
    }
}