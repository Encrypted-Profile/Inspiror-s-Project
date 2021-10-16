using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class admin_RegisterEmployee : System.Web.UI.Page
{
    string emp;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
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
                resetData();
            }

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnRegisterEmployee_Click(object sender, EventArgs e)
    {
        try
        {
            string code = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "0" : txtCode.Text; ;

            Employee obj = new Employee();
            obj.empCode = code;
            bool x = obj.checkEmployee();
            if (x)
            {
                string title = "Error";
                string body = "Sorry Data Already Exists.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                obj.empCode = code;
                obj.empFirstName = (string.IsNullOrWhiteSpace(empFirstName.Text)) ? "" : empFirstName.Text;
                obj.empLastName = (string.IsNullOrWhiteSpace(empLastName.Text)) ? "" : empLastName.Text;
                obj.gender = (string.IsNullOrWhiteSpace(empGender.Text)) ? "-" : empGender.Text;
                obj.Designation = (string.IsNullOrWhiteSpace(empDesignation.Text)) ? "-" : empDesignation.Text;
                obj.Type = (string.IsNullOrWhiteSpace(empType.Text)) ? "-" : empType.Text;
                obj.mobile = (string.IsNullOrWhiteSpace(empMobile.Text)) ? "Not Provided" : empMobile.Text;
                obj.email = (string.IsNullOrWhiteSpace(empEmail.Text)) ? "Not Provided" : empEmail.Text;
                obj.joiningDate = DateTime.Parse(DateTime.Parse(((string.IsNullOrWhiteSpace(empJoiningDate.Text)) ? "2/2/2018" : empJoiningDate.Text)).ToShortDateString());
                obj.address = (string.IsNullOrWhiteSpace(empAddress.Text)) ? "Not Provided" : empAddress.Text;
                obj.grade = (string.IsNullOrWhiteSpace(empGrade.Text)) ? "A" : empGrade.Text;
                obj.LoginId = code;
                obj.LoginPwd = StringCipher.Encrypt("FinalProject", code);
                obj.qualification = (string.IsNullOrWhiteSpace(empQualification.Text)) ? "Not Provided" : empQualification.Text;
                obj.status = true;

                obj.addEmployee();
                dt = obj.getAllEmployees();
                BindData();
                resetData();
                string title = "Thank You!";
                string body = "Done";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);


            }
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {

            Employee emp = new Employee();
            if (empSearch.Text.Length < 1)
            {
                string title = "Warning!";
                string body = "Pease provide name to search.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                emp.empFirstName = empSearch.Text;
                dt = emp.getEmployee();
                if (dt.Rows.Count > 0)
                {
                    BindData();
                    resetData();
                }
                else
                {
                    dt = null;
                    BindData();
                    resetData();
                    string title = "Warning!";
                    string body = "There is no data.";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
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


    protected void searchGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try

        {
            Employee emp = new Employee();
            GridViewRow dr = searchGridView.SelectedRow;
            Common.empId = dr.Cells[1].Text;
            emp.empCode = dr.Cells[1].Text;
            DataTable dt = emp.getEmployeeById();
            empImage.ImageUrl = (@"~/images/employee/" + emp.empCode + ".jpg");
            txtCode.Text = dt.Rows[0]["EmpId"].ToString();
            empFirstName.Text = dt.Rows[0]["FirstName"].ToString();
            empLastName.Text = dt.Rows[0]["LastName"].ToString();
            empAddress.Text = dt.Rows[0]["Address"].ToString();
            empType.Text = dt.Rows[0]["Type"].ToString();
            empGender.Text = dt.Rows[0]["Gender"].ToString();
            empMobile.Text = dt.Rows[0]["Mobile"].ToString();
            empQualification.Text = dt.Rows[0]["Qualification"].ToString();
            empEmail.Text = dt.Rows[0]["Email"].ToString().Trim();
            empDesignation.Text = dt.Rows[0]["Designation"].ToString();
            empGrade.Text = dt.Rows[0]["Grade"].ToString();
            empJoiningDate.Text = DateTime.Parse(dt.Rows[0]["JoiningDate"].ToString()).ToShortDateString();
            empLeavingDate.Text = DateTime.Parse(dt.Rows[0]["LeavingDate"].ToString()).ToShortDateString();

        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = ex.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

    }


    protected void update()
    {
        try
        {
            Employee emp = new Employee();

            Employee obj = new Employee();
            string code = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            obj.empCode = code;
            obj.empFirstName = (string.IsNullOrWhiteSpace(empFirstName.Text)) ? "" : empFirstName.Text;
            obj.empLastName = (string.IsNullOrWhiteSpace(empLastName.Text)) ? "" : empLastName.Text;
            obj.gender = (string.IsNullOrWhiteSpace(empGender.Text)) ? "-" : empGender.Text;
            obj.Designation = (string.IsNullOrWhiteSpace(empDesignation.Text)) ? "-" : empDesignation.Text;
            obj.Type = (string.IsNullOrWhiteSpace(empType.Text)) ? "-" : empType.Text;
            obj.mobile = (string.IsNullOrWhiteSpace(empMobile.Text)) ? "Not Provided" : empMobile.Text;
            obj.email = (string.IsNullOrWhiteSpace(empEmail.Text)) ? "Not Provided" : empEmail.Text;
            obj.joiningDate = DateTime.Parse(DateTime.Parse(((string.IsNullOrWhiteSpace(empJoiningDate.Text)) ? "2/2/2018" : empJoiningDate.Text)).ToShortDateString());
            obj.address = (string.IsNullOrWhiteSpace(empAddress.Text)) ? "Not Provided" : empAddress.Text;
            obj.grade = (string.IsNullOrWhiteSpace(empGrade.Text)) ? "A" : empGrade.Text;
            obj.LoginId = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "Not Provided" : txtCode.Text;
            obj.LoginPwd = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "Not Provided" : txtCode.Text;
            obj.qualification = (string.IsNullOrWhiteSpace(empQualification.Text)) ? "Not Provided" : empQualification.Text;
            if (obj.checkIfActive())
            {
                obj.updateEmployee();
                dt = obj.getEmployee();
                BindData();
                resetData();
                string title = "Thank You!";
                string body = "Done";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                string title = "Error";
                string body = "Sorry this employee is not active.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }

        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string code = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (code.Length == 0)
            {
                string title = "Error";
                string body = "Please provide employee code to update";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {

                Employee emp = new Employee();

                Employee obj = new Employee();
                obj.empCode = code;
                obj.empFirstName = (string.IsNullOrWhiteSpace(empFirstName.Text)) ? "" : empFirstName.Text;
                obj.empLastName = (string.IsNullOrWhiteSpace(empLastName.Text)) ? "" : empLastName.Text;
                obj.gender = (string.IsNullOrWhiteSpace(empGender.Text)) ? "-" : empGender.Text;
                obj.Designation = (string.IsNullOrWhiteSpace(empDesignation.Text)) ? "-" : empDesignation.Text;
                obj.Type = (string.IsNullOrWhiteSpace(empType.Text)) ? "-" : empType.Text;
                obj.mobile = (string.IsNullOrWhiteSpace(empMobile.Text)) ? "Not Provided" : empMobile.Text;
                obj.email = (string.IsNullOrWhiteSpace(empEmail.Text)) ? "Not Provided" : empEmail.Text;
                obj.joiningDate = DateTime.Parse(DateTime.Parse(((string.IsNullOrWhiteSpace(empJoiningDate.Text)) ? "2/2/2018" : empJoiningDate.Text)).ToShortDateString());
                obj.address = (string.IsNullOrWhiteSpace(empAddress.Text)) ? "Not Provided" : empAddress.Text;
                obj.grade = (string.IsNullOrWhiteSpace(empGrade.Text)) ? "A" : empGrade.Text;
                obj.LoginId = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "Not Provided" : txtCode.Text;
                obj.LoginPwd = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "Not Provided" : txtCode.Text;
                obj.qualification = (string.IsNullOrWhiteSpace(empQualification.Text)) ? "Not Provided" : empQualification.Text;
                if (obj.checkIfActive())
                {
                    obj.updateEmployee();
                    dt = obj.getEmployee();
                    BindData();
                    resetData();
                    string title = "Thank You!";
                    string body = "Done";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
                }
                else
                {
                    string title = "Error";
                    string body = "Sorry this employee is not active.";
                    ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
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
    DataTable dt = null;
    public void BindData()
    {
        try
        {
            searchGridView.DataSource = dt;
            searchGridView.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnActive_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            emp.empCode = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (emp.empCode == "")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                emp.activeEmployee();
                dt = emp.getEmployee();
                BindData();
                resetData();
                string title = "Thank You!";
                string body = "Done";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }


        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);

        }
    }
    protected void btnDeactive_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            emp.empCode = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (emp.empCode == "")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                emp.empCode = Common.empId;
                emp.leavingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                emp.deactiveEmployee();
                dt = emp.getEmployee();
                BindData();
                resetData();
                string title = "Thank You!";
                string body = "Done";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }


        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);

        }

    }
    protected void btnAssignSalary_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            emp.empCode = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (emp.empCode == "")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {

                Response.Redirect("PaySalary.aspx?empCode=" + emp.empCode);
            }
        }
        catch (Exception ex)
        {

            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);

        }
    }
    protected void btnResetCredential_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            emp.empCode = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (emp.empCode == "")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                emp.LoginId = emp.empCode;
                emp.LoginPwd = StringCipher.Encrypt("FinalProject", emp.empCode.Trim());
                emp.resetCredentials();
                dt = null;
                BindData();
                resetData();
                string title = "Thank You!";
                string body = "Done";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);

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
        empDesignation.Text = "";
        empType.SelectedIndex = 0;
        empGender.SelectedIndex = 0;
        txtCode.Text = "";
        empAddress.Text = "";
        empEmail.Text = "";
        empFirstName.Text = "";
        empLastName.Text = "";
        empMobile.Text = "";
        empQualification.Text = "";
        empGrade.Text = "";
        empSearch.Text = "";
        empJoiningDate.Text = "";
        empLeavingDate.Text = "";
        empImage.ImageUrl = "";

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        try
        {
            resetData();

        }
        catch (Exception ex)
        {

        }

    }
    protected void btnUploadPicture_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            emp.empCode = (string.IsNullOrWhiteSpace(txtCode.Text)) ? "" : txtCode.Text;
            if (emp.empCode == "")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {

                Response.Redirect("UploadEmployeePicture.aspx?emp=" + emp.empCode);
            }
        }
        catch (Exception ex)
        {

            string title = "Error";
            string body = "Error Connecting To Server";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            Employee emp = new Employee();
            DataTable dt = emp.getAllActiveEmployee();
            searchGridView.DataSource = dt;
            searchGridView.DataBind();
        }
        catch (Exception ex)
        {

        }
    }
}