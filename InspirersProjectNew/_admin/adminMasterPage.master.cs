using System;

public partial class admin_adminMasterPage : System.Web.UI.MasterPage
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
        empImage.ImageUrl = (@"~/images/employee/" + this.emp + ".jpg");
    }

    protected void logout(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }
        catch (Exception ex)
        {
            ex.ToString();
        }
    }
}
