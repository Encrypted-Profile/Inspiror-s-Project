using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class _admin_ManageProject : System.Web.UI.Page
{
    string customer = "";
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
            loadTeachers();
            resetData();
        }
    }

    public void loadTeachers()
    {
        try
        {
            Employee obj = new Employee();
            DataTable dt = obj.getTeachers();
            cboTeachers.DataSource = dt;
            cboTeachers.DataTextField = "FirstName";
            cboTeachers.DataValueField = "EmpId";
            cboTeachers.DataBind();
        }
        catch (Exception ex)
        {

            lblError.Text = ex.ToString();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            BindData();
            string ptr = txtSearch.Text;
            if (ptr.Length < 1)
            {
                string title = "Warning!";
                string body = "Pease provide data to search.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                Schedule obj = new Schedule();
                dt = obj.getClass(ptr);
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

            string title = "Error!";
            string body = "Error connecting to database.";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

    protected void btnAddProject_Click(object sender, EventArgs e)
    {
        try
        {
            string code = (string.IsNullOrWhiteSpace(txtClassCode.Text)) ? "0" : txtClassCode.Text;

            Schedule obj = new Schedule();
            obj.classCode = code;
            bool x = obj.checkClass();
            if (x)
            {
                string title = "Error";
                string body = "Sorry Class Already Exists.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                string className = (string.IsNullOrWhiteSpace(txtClassName.Text)) ? "0" : txtClassName.Text;
                string classTiming = (string.IsNullOrWhiteSpace(txtClassTiming.Text)) ? "0" : txtClassTiming.Text;
                string classSubject = (string.IsNullOrWhiteSpace(txtSubject.Text)) ? "0" : txtSubject.Text;
                string classTeacher = cboTeachers.Text;
                double classTeacherPercentage = double.Parse((string.IsNullOrWhiteSpace(txtTeacherPercentage.Text)) ? "0.0" : txtTeacherPercentage.Text);
                double classFee = double.Parse((string.IsNullOrWhiteSpace(txtFee.Text)) ? "0.0" : txtFee.Text);

                obj.className = className;
                obj.classTimming = classTiming;
                obj.classSubject = classSubject;
                obj.classTeacher = classTeacher;
                obj.classTeacherPercentage = classTeacherPercentage;
                obj.classFee = classFee;
                obj.newTeacher();

                BindData();
                resetData();
                string title = "Teacher Registered!";
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
        try
        {
            txtFee.Text = "";
            txtClassCode.Text = "";
            txtClassName.Text = "";
            txtClassTiming.Text = "";
            txtSearch.Text = "";
            txtSubject.Text = "";
            txtTeacherPercentage.Text = "";
        }
        catch (Exception ex)
        {
            lblError.Text = ex.ToString();
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            string code = (string.IsNullOrWhiteSpace(txtClassCode.Text)) ? "0" : txtClassCode.Text;


            if (code == "0")
            {
                string title = "Error";
                string body = "You have not provided class code.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                Schedule obj = new Schedule();
                obj.classCode = code;
                string className = (string.IsNullOrWhiteSpace(txtClassName.Text)) ? "0" : txtClassName.Text;
                string classTiming = (string.IsNullOrWhiteSpace(txtClassTiming.Text)) ? "0" : txtClassTiming.Text;
                string classSubject = (string.IsNullOrWhiteSpace(txtSubject.Text)) ? "0" : txtSubject.Text;
                string classTeacher = cboTeachers.Text;
                double classTeacherPercentage = double.Parse((string.IsNullOrWhiteSpace(txtTeacherPercentage.Text)) ? "0.0" : txtTeacherPercentage.Text);
                double classFee = double.Parse((string.IsNullOrWhiteSpace(txtFee.Text)) ? "0.0" : txtFee.Text);

                obj.className = className;
                obj.classTimming = classTiming;
                obj.classSubject = classSubject;
                obj.classTeacher = classTeacher;
                obj.classTeacherPercentage = classTeacherPercentage;
                obj.classFee = classFee;
                obj.update();

                BindData();
                resetData();
                string title = "Class Data Updated Successfully!";
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
            lblError.Text = ex.ToString();

        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        resetData();
    }
    protected void searchGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Schedule obj = new Schedule();
            GridViewRow dr = searchGridView.SelectedRow;
            obj.classCode = dr.Cells[1].Text;
            DataTable dt = obj.getByCode();
            txtClassCode.Text = dt.Rows[0]["classCode"].ToString();
            txtClassName.Text = dt.Rows[0]["className"].ToString();
            txtSubject.Text = dt.Rows[0]["classSubject"].ToString();
            txtClassTiming.Text = dt.Rows[0]["classTiming"].ToString();
            txtTeacherPercentage.Text = dt.Rows[0]["Percentage"].ToString();
            txtFee.Text = dt.Rows[0]["classFee"].ToString();
            loadTeachers();
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Unable to show data";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }


    }

    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        try
        {
            Schedule obj = new Schedule();
            dt = obj.getAllClasses();
            BindData();
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Unable to show data";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }

    }
}