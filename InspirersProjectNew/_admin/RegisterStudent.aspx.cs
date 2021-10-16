using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class _admin_ManageClient : System.Web.UI.Page
{
    string emp;
    DataTable dtx = new DataTable();
    string[] a = new string[5];
    string stdcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["x_secure_id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            this.emp = Session["x_secure_id"].ToString();
            stdcode = Request.QueryString["code"].ToString();
            dtx.Columns.AddRange(new DataColumn[6] { new DataColumn("Seriel"), new DataColumn("Course Code"), new DataColumn("Course Name"), new DataColumn("Timing"), new DataColumn("Fee"), new DataColumn("Teacher") });
        }
        if (!IsPostBack)
        {
            bindGrid();
            Students std = new Students();
            std.code = stdcode;
            DataTable dt = std.getSpecificStudent();
            txtCode.Text = dt.Rows[0][0].ToString();
            txtName.Text = dt.Rows[0][1].ToString();
            //--------
            loadClasses();
        }
    }
    public void loadClasses()
    {
        try
        {
            Schedule obj = new Schedule();
            DataTable dt = obj.getAllClasses();

            cboClass.DataSource = dt;
            cboClass.DataTextField = "className";
            cboClass.DataValueField = "classCode";
            cboClass.DataBind();
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Could not load classes try again!";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
    protected void btnRegisterClient_Click(object sender, EventArgs e)
    {
        try
        {
            string code = txtCode.Text;
            // - - - Date
            string time = DateTime.Now.ToShortTimeString();
            Registration reg = new Registration();
            reg.studentCode = code;
            reg.registrationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            reg.registrationTime = time;
            reg.active = true;
            int regId = reg.insert();
            //---------------

            string s, t;
            if (Request.Cookies["items"] != null)
            {
                s = Convert.ToString(Request.Cookies["items"].Value);
                string[] strArr = s.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strBrr = t.Split(',');
                    for (int j = 0; j < strBrr.Length; j++)
                    {
                        a[j] = strBrr[j].ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(a[0]))
                    {
                        CourseRegistration cr = new CourseRegistration();
                        cr.registrationCode = regId;
                        cr.courseCode = a[0].ToString();
                        cr.fee = double.Parse(a[3].ToString());
                        cr.active = true;
                        cr.insertCourseRegistration();
                        totalAmount += double.Parse(a[3].ToString());

                        //get teachers code and percentage amount
                        Schedule sch = new Schedule();
                        sch.classCode = a[0].ToString();
                        DataTable dt = sch.getTeacherPercentage();

                        double cashIn = double.Parse(dt.Rows[0][1].ToString()) / 100 * double.Parse(a[3].ToString());
                        TeacherInstallment obj = new TeacherInstallment();
                        obj.teacherCode = dt.Rows[0][0].ToString();
                        obj.installmentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        obj.installmentTime = DateTime.Now.ToShortTimeString();
                        obj.cashIn = cashIn;
                        obj.cashOut = 0.0;
                        obj.reason = "Course Registered REG [ " + regId + "] Course [" + a[0].ToString() + "] Amount [" + a[3].ToString() + "]";
                        obj.confirmed = false;
                        obj.insert();

                        Payroll p = new Payroll();
                        p.teacherCode = dt.Rows[0][0].ToString();
                        p.month = DateTime.Now.ToString("MMMM");
                        p.year = DateTime.Now.Year;
                        p.cashIn = cashIn;
                        p.cashOut = 0.0;
                        p.receivingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        p.receivingTime = DateTime.Now.ToShortTimeString();
                        p.received = false;
                        p.updatePayroll();
                    }
                }
            }

            //---------------

            Installment ins = new Installment();
            ins.fee = totalAmount;
            ins.registrationCode = regId;
            ins.installmentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            ins.month = DateTime.Now.ToString("MMMM");
            ins.year = Int32.Parse(DateTime.Now.Year.ToString());
            ins.paid = false;
            ins.nextInstallment = DateTime.Now.AddMonths(1);
            int serial = ins.insert();

            Response.Redirect("RegistrationReceipt.aspx?serial=" + serial + "&student=" + stdcode);
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

    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        resetData();
    }


    protected void cboClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string code = cboClass.SelectedItem.Value.ToString();
            Schedule obj = new Schedule();
            obj.classCode = code;
            DataTable dt = obj.getByCode();
            txtTiming.Text = dt.Rows[0]["classTiming"].ToString();
            txtSubject.Text = dt.Rows[0]["classSubject"].ToString();
            txtTeacher.Text = dt.Rows[0]["Teacher"].ToString();
            txtTiming.Text = dt.Rows[0]["classTiming"].ToString();
            txtFee.Text = dt.Rows[0]["classFee"].ToString();
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Display Class Data. Check for incomplete data.";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
    int counter = 1;
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            string code = cboClass.SelectedItem.Value.ToString();
            string className = cboClass.SelectedItem.Text;
            string Timing = txtTiming.Text;
            double Fee = double.Parse(txtFee.Text);
            string Teacher = txtTeacher.Text;

            if (Request.Cookies["items"] == null)
            {
                Response.Cookies["items"].Value = code + "," + className + "," + Timing + "," + Fee + "," + Teacher;
                Response.Cookies["items"].Expires = DateTime.Now.AddDays(1);
            }
            else
            {
                Response.Cookies["items"].Value = Request.Cookies["items"].Value + "|" + code + "," + className + "," + Timing + "," + Fee + "," + Teacher;
            }
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Display Class Data. Check for incomplete data.";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
    double totalAmount = 0;
    public void bindGrid()
    {
        try
        {
            dtx.Rows.Clear();
            string s, t;
            if (Request.Cookies["items"] != null)
            {
                s = Convert.ToString(Request.Cookies["items"].Value);
                string[] strArr = s.Split('|');
                for (int i = 0; i < strArr.Length; i++)
                {
                    t = Convert.ToString(strArr[i].ToString());
                    string[] strBrr = t.Split(',');
                    for (int j = 0; j < strBrr.Length; j++)
                    {
                        a[j] = strBrr[j].ToString();
                    }
                    if (!string.IsNullOrWhiteSpace(a[0]))
                    {
                        dtx.Rows.Add(i + "", a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString());
                    }
                }
                for (int i = 0; i < dtx.Rows.Count; i++)
                {
                    totalAmount += double.Parse(dtx.Rows[i][4].ToString());
                }
                lblTotalAmount.Text = "Total Amount : Rs. " + totalAmount.ToString();
                orderGrid.DataSource = dtx;
                orderGrid.DataBind();
            }
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Display Class Data. Check for incomplete data." + ex;
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
    public void deleteRow(object sender, EventArgs e)
    {
        try
        {
            LinkButton lnk = sender as LinkButton;
            String Value1 = lnk.Attributes["CustomParameter"].ToString();
            Response.Redirect("deleteItem.aspx?serial=" + Value1 + "&student=" + this.stdcode);
        }
        catch (Exception ex)
        {
            string title = "Sorry";
            string body = "Could Not Delete Data";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }

    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(-1);
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(-1);
    }
}