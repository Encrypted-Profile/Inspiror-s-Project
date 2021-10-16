using System;

public partial class _admin_ManageClient : System.Web.UI.Page
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
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(-1);

        if (!IsPostBack)
        {
            resetData();
        }
    }

    protected void btnRegisterClient_Click(object sender, EventArgs e)
    {
        try
        {
            string code = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "0" : txtCode.Text;

            Students obj = new Students();
            obj.code = code;
            bool x = obj.checkStudent();
            if (x)
            {
                string title = "Error";
                string body = "Sorry Data Already Exists.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                obj.name = (string.IsNullOrWhiteSpace(txtName.Text)) ? "" : txtName.Text;
                obj.father = (string.IsNullOrWhiteSpace(txtFather.Text)) ? "" : txtFather.Text;
                obj.gender = (string.IsNullOrWhiteSpace(cboGender.Text)) ? "-" : cboGender.Text;
                obj.mobile = (string.IsNullOrWhiteSpace(txtMobile.Text)) ? "-" : txtMobile.Text;
                obj.email = (string.IsNullOrWhiteSpace(txtEmail.Text)) ? "-" : txtEmail.Text;
                obj.address = (string.IsNullOrWhiteSpace(txtAddress.Text)) ? "-" : txtAddress.Text;
                obj.emergency = (string.IsNullOrWhiteSpace(txtEmergency.Text)) ? "-" : txtEmergency.Text;
                obj.active = true;
                obj.registrationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                if (obj.name.Length < 3)
                {
                    string title = "Error!";
                    string body = "Please Fill mandatory fields..";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
                }
                else
                {


                    obj.newStudent();
                    Response.Redirect("RegisterStudent.aspx?code=" + code);
                }
            }
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }


    public void resetData()
    {
        txtAddress.Text = "";
        txtCode.Text = "";
        txtEmail.Text = "";
        txtEmergency.Text = "";
        txtFather.Text = "";
        txtMobile.Text = "";
        txtName.Text = "";
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetData();
        generateCode();
    }
    public void generateCode()
    {
        string code = "";
        DateTime tm = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
        DateTime dtNow = DateTime.Now;
        TimeSpan result = dtNow.Subtract(tm);
        int minutes = Convert.ToInt32(result.TotalSeconds);
        code += minutes.ToString();
        int l = code.Length;
        if (l < 8)
        {
            for (int j = 1; j <= 8 - l; j++)
            {
                code = "0" + code;
            }
        }
        txtCode.Text = DateTime.Now.ToString("yy") + code;
    }
}