using System;
using System.Data;

public partial class _admin_ManageClient : System.Web.UI.Page
{
    string emp;
    int serial;
    string stdCode;

    double totalAmount = 0;
    DataTable dtx = new DataTable();
    string[] a = new string[5];

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["x_secure_id"] == null)
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {
            dtx.Columns.AddRange(new DataColumn[4] { new DataColumn("Course Name"), new DataColumn("Timing"), new DataColumn("Fee"), new DataColumn("Teacher") });
            this.emp = Session["x_secure_id"].ToString();
        }
        if (!IsPostBack)
        {
            this.serial = Int32.Parse(Request.QueryString["serial"].ToString());
            this.stdCode = Request.QueryString["student"].ToString();
            loadData();
        }
    }
    DataTable installments;
    DataTable registrationData;
    public void loadData()
    {

        //-- Get Personal Information
        Students std = new Students();
        std.code = this.stdCode;
        DataTable dx = std.getSpecificStudent();
        lblName.Text = dx.Rows[0]["studentName"].ToString();
        lblFatherName.Text = dx.Rows[0]["studentFather"].ToString();
        //-- Get Installment Information
        Installment ins = new Installment();
        ins.serial = this.serial;
        DataTable ds = ins.getInstallmentBySerial();
        lblPaymentDate.Text = DateTime.Parse(ds.Rows[0][2].ToString()).ToString("MMMM dd, yyyy");
        bindGrid();
    }

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
                        dtx.Rows.Add(a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString());
                    }
                }
                for (int i = 0; i < dtx.Rows.Count; i++)
                {
                    totalAmount += double.Parse(dtx.Rows[i][2].ToString());
                }
                lblTotalAmount.Text = "Total Amount : Rs. " + totalAmount.ToString();
                GridView1.DataSource = dtx;
                GridView1.DataBind();
            }
        }
        catch (Exception ex)
        {
            string title = "Error";
            string body = "Error Display Class Data. Check for incomplete data." + ex;
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}