using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _admin_ManageExpenditure : System.Web.UI.Page
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
    public void resetData()
    {
        txtId.Text = "";
        txtReason.Text = "";
        txtAmount.Text = "";
        txtNote.Text = "";
        txtSearch.Text = "";
        txtDate.Text = "";
        image.ImageUrl = "";

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Int32.Parse((string.IsNullOrWhiteSpace(txtId.Text)) ? "0" : txtId.Text);
            double expAmount = double.Parse((string.IsNullOrWhiteSpace(txtAmount.Text)) ? "0" : txtAmount.Text);
            Expenditure obj = new Expenditure();
            Ledger led = new Ledger();
            obj.expId = id;
            bool x = obj.check();
            if (x)
            {
                string title = "Error";
                string body = "Sorry Data Already Exists.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                led.Id = led.getId() + 1;
                led.empId = this.emp;
                led.credit = 0;
                led.debit = expAmount;
                led.reason = "Expenditure";
                led.date = DateTime.Parse(DateTime.Parse((string.IsNullOrWhiteSpace(txtDate.Text)) ? DateTime.Now.ToShortDateString() : txtDate.Text).ToShortDateString());
                led.note = "Data Entered By "+Common.adminName;
                led.insertDebit();
                obj.expId = obj.getExpId() + 1;
                obj.ledgerId = led.Id;
                obj.amount = expAmount;
                obj.reason = (string.IsNullOrWhiteSpace(txtReason.Text)) ? "-" : txtReason.Text;
                obj.note = (string.IsNullOrWhiteSpace(txtNote.Text)) ? "Not Provided" : txtNote.Text;
                obj.date = DateTime.Parse(DateTime.Parse((string.IsNullOrWhiteSpace(txtDate.Text)) ? DateTime.Now.ToShortDateString() : txtDate.Text).ToShortDateString());
                //---------leadger
                obj.newExpenditure();
                dt = obj.getData();
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
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            int id = Int32.Parse((string.IsNullOrWhiteSpace(txtId.Text)) ? "0" : txtId.Text);
            double expAmount = double.Parse((string.IsNullOrWhiteSpace(txtAmount.Text)) ? "0" : txtAmount.Text);
            Expenditure obj = new Expenditure();
            Ledger led = new Ledger();
            obj.expId = id;

            if (id == 0)
            {
                string title = "Error";
                string body = "Please make correct selection.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                obj.ledgerId = led.Id;
                obj.amount = expAmount;
                obj.reason = (string.IsNullOrWhiteSpace(txtReason.Text)) ? "-" : txtReason.Text;
                obj.note = (string.IsNullOrWhiteSpace(txtNote.Text)) ? "Not Provided" : txtNote.Text;
                obj.date = DateTime.Parse(DateTime.Parse((string.IsNullOrWhiteSpace(txtDate.Text)) ? DateTime.Now.ToShortDateString() : txtDate.Text).ToShortDateString());
                //---------leadger
                obj.updateExpenditure();
                led.Id = obj.getLedgerId();
                led.debit = expAmount;
                led.reason = "Expenditure";

                led.updateDebit();
                dt = obj.getData();
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        
        resetData();
    }
    protected void searchGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            Expenditure obj = new Expenditure();
            GridViewRow dr = searchGridView.SelectedRow;
            obj.expId = Int32.Parse(dr.Cells[1].Text);
            DataTable dt = obj.getExpById();
            txtId.Text = dt.Rows[0]["Id"].ToString();
            txtAmount.Text = dt.Rows[0]["Amount"].ToString();
            txtNote.Text = dt.Rows[0]["Note"].ToString();
            txtReason.Text = dt.Rows[0]["Reason"].ToString();
            txtDate.Text =DateTime.Parse( dt.Rows[0]["Date"].ToString()).ToShortDateString();
            image.ImageUrl = (@"~/images/ExpenditureAttachment/" + dr.Cells[1].Text + ".jpg");

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
            Expenditure obj = new Expenditure();
            obj.reason = txtSearch.Text;
            if (txtSearch.Text.Length < 1)
            {
                string title = "Warning!";
                string body = "Pease provide data to search.";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {
                dt = obj.byReason();
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
    protected void btnUploadPicture_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow dr = searchGridView.SelectedRow;
            string Id = (string.IsNullOrWhiteSpace(dr.Cells[1].Text)) ? "0" : dr.Cells[1].Text;
            if (Id == "0")
            {
                string title = "Error";
                string body = "Please make correct selection";
                ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
            }
            else
            {

                Response.Redirect("UploadExpenditureFile.aspx?id=" + Id);
            }
        }
        catch (Exception ex)
        {

            string title = "Error";
            string body = "Please make correct selection";
            ClientScript.RegisterStartupScript(this.GetType(), "MyPopup", "ShowPopup('" + title + "', '" + body + "');", true);
        }
    }
}