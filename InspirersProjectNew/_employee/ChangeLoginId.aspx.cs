using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _employee_ChangeLoginId : System.Web.UI.Page
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
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Employee obj = new Employee();
        obj.LoginId = loginId.Text;
        obj.empCode = this.emp;
        try
        {
            obj.changeLoginId();
            //Response.Redirect(Request.RawUrl);
            string title = "Thank You!";
            string body = "Done";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            loginId.Text = "";
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

    }
}