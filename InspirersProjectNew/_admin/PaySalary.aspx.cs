using System;
using System.Data;

public partial class _admin_PaySalary : System.Web.UI.Page
{
    string emp;
    string empCode;
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
        this.empCode = Request.QueryString["empCode"].ToString();
        if (!IsPostBack)
        {
            txtCode.Text = this.empCode;
            Employee emp = new Employee();
            emp.empCode = this.empCode;
            txtName.Text = emp.getEmployeeNameByCode();
            loadData();
        }
    }
    public void loadData()
    {
        try
        {

        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

    protected void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {

            string month = cboMonth.SelectedItem.Text;
            int year = Int32.Parse(string.IsNullOrWhiteSpace(txtYear.Text) ? "0" : txtYear.Text);
            TeacherInstallment obj = new TeacherInstallment();
            obj.teacherCode = this.empCode;
            DataTable dt = obj.getSpecificInstallment(month, year);
            salaryGrid.DataSource = dt;
            salaryGrid.DataBind();

        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}