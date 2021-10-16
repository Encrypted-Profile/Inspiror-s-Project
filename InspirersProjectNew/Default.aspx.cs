using System;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginNow(object sender, EventArgs e)
    {
        try
        {
            if (IsPostBack)
            {
                Employee obj = new Employee();
                if (txtUserLogin.Text.Length < 1)
                {
                    string title = "Error";
                    string body = "Please Insert Correct Login Id Password.";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
                }
                else
                {
                    obj.LoginId = txtUserLogin.Text.Trim();
                    string userPass = txtUserLoginPassword.Text.Trim();
                    obj.LoginPwd = StringCipher.Encrypt("FinalProject", userPass);
                    bool x_secure = obj.checkUser();
                    if (x_secure)
                    {
                        //lblError.Visible = true;
                        obj.empCode = obj.getEmployeeId();
                        Common.adminName = obj.getEmployeeName();
                        if (obj.getEmployeeType().Equals("Admin"))
                        {
                            Session["x_secure_id"] = obj.getEmployeeId();
                            Response.Redirect("~/_admin/dashboard.aspx");
                        }
                        else if (obj.getEmployeeType().Equals("Teacher"))
                        {
                            Session["x_secure_id"] = obj.getEmployeeId();
                            Response.Redirect("~/_employee/dashboard.aspx");
                        }
                    }
                    else
                    {
                        string title = "Sorry";
                        string body = "Invalid ID and Password";
                        ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            //lblError.Text = ex.ToString();
            string title = "Sorry";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}