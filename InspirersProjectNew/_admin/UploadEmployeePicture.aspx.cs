using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _admin_UploadEmployeePicture : System.Web.UI.Page
{
    private string emp;
    string emp2;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["x_secure_id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            this.emp2 = Session["x_secure_id"].ToString();
            this.emp = Request.QueryString["emp"].ToString();
        }
      
    }

    protected void FileUpload1_DataBinding(object sender, EventArgs e)
    {

        try
        {

            FileUpload1.PostedFile.SaveAs(Server.MapPath(@"~/images/employee/") + this.emp + ".jpg");
            //Response.Redirect(Request.RawUrl);
            string title = "Thank You!";
            string body = "Done";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
        catch (Exception ex)
        {
            string title = "Error!";
            string body = "Incorrect File Format.";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

}