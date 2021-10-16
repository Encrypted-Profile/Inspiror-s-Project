using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _employee_employeeMasterPage : System.Web.UI.MasterPage
{
    string emp;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["x_secure_id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            this.emp = Session["x_secure_id"].ToString();
        }
        if (!IsPostBack)
        {

        }
        adminName.Text = Common.adminName;
        type.Text = "Employee";
        empImage.ImageUrl = (@"~/images/employee/" + this.emp + ".jpg");
    }

    protected void logout(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("~/Default.aspx");
        Session["x_secure_id"] = null;
    }
}
