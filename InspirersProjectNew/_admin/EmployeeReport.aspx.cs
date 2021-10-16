using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _admin_EmployeeReport : System.Web.UI.Page
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
            loadEmployee();
            searchNow();
        }
    }
    public void loadEmployee()
    {
        try
        {
            Employee obj = new Employee();
            DataTable dt = obj.getAllActiveEmployee();
            cboEmployee.DataSource = dt;
            cboEmployee.DataTextField = "FirstName";
            cboEmployee.DataValueField = "EmpId";
            cboEmployee.DataBind();
        }
        catch (Exception ex)
        {

            lblError.Text = ex.ToString();
        }
    }
    public void searchNow()
    {
        lblError.Visible = false;
        string xemp = cboEmployee.Text;
        Employee obj = new Employee();
        obj.empCode = xemp;
        try
        {
            DataTable dt = obj.getEmployeeById();
            if (dt.Rows.Count > 0)
            {
                lblEmployeeId.Text = dt.Rows[0]["EmpId"].ToString();
                lblFirstName.Text = dt.Rows[0]["FirstName"].ToString();
                lblLastName.Text = dt.Rows[0]["LastName"].ToString();
                lblEmail.Text = dt.Rows[0]["Email"].ToString();
                lblPhone.Text = dt.Rows[0]["Mobile"].ToString();
                lblQualification.Text = dt.Rows[0]["Qualification"].ToString();
                lblDesignation.Text = dt.Rows[0]["Designation"].ToString();
                lblType.Text = dt.Rows[0]["Type"].ToString();
                lblGender.Text = dt.Rows[0]["Gender"].ToString();
                lblAddress.Text = dt.Rows[0]["Address"].ToString();
                lblJoiningDate.Text = dt.Rows[0]["JoiningDate"].ToString();
                lblLeavingDate.Text = dt.Rows[0]["LeavingDate"].ToString();
                lblStatus.Text = dt.Rows[0]["Status"].ToString();
                empImg.ImageUrl = (@"~/images/employee/" + xemp + ".jpg");
                if (dt.Rows[0]["Type"].ToString() == "Employee")
                {
                    lblSalaryType.Text = "Hourly";
                    lblSalaryLabel.Text = "Salary/Hour";
                }
                else if (dt.Rows[0]["Type"].ToString() != "Employee")
                {
                    lblSalaryType.Text = "Monthly";
                    lblSalaryLabel.Text = "Salary/Month";

                }
                Salary sal = new Salary();
                sal.EmpId = xemp;
                DataTable ds = sal.getSalary();
                if (ds.Rows.Count > 0)
                {
                    lblHourSalary.Text = ds.Rows[0]["SalaryAmount"].ToString();
                    lblHourSalary.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    lblHourSalary.Text = "Salary Not Assigned";
                    lblHourSalary.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                string title = "Sorry!";
                string body = "There is no data for this date.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }

        }
        catch (Exception ex)
        {
            string title = "Error!";
            string body = "Error connecting to database.";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
    protected void search(object sender, EventArgs e)
    {
        try
        {
            searchNow();
        }
        catch (Exception ex)
        { 
        
        }
    }
    protected void cboEmployee_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            searchNow();
        }
        catch (Exception ex)
        {

        }
    }
}