using System;
using System.Data;


public partial class _admin_deleteItem : System.Web.UI.Page
{
    int seriel;
    string[] a = new string[5];
    string classCode, className, timing, teacher;
    double fee;
    string student;
    protected void Page_Load(object sender, EventArgs e)
    {
        student = Request.QueryString["student"].ToString();
        if (!IsPostBack)
            removeData();
    }
    public void removeData()
    {
        string result = "";
        int count = 0;
        string s, t;
        seriel = Convert.ToInt32(Request.QueryString["serial"].ToString());
        DataTable dt = new DataTable();
        dt.Rows.Clear();
        dt.Columns.AddRange(new DataColumn[6] { new DataColumn("Seriel"), new DataColumn("Course Code"), new DataColumn("Course Name"), new DataColumn("Timing"), new DataColumn("Fee"), new DataColumn("Teacher") });
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
                dt.Rows.Add(i + "", a[0].ToString(), a[1].ToString(), a[2].ToString(), a[3].ToString(), a[4].ToString());
            }

        }
        dt.Rows.RemoveAt(seriel);
        dt.AcceptChanges();
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(-10);
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(-10);

        foreach (DataRow dr in dt.Rows)
        {
            classCode = dr["Course Code"].ToString();
            className = dr["Course Name"].ToString();
            timing = dr["Timing"].ToString();
            fee = double.Parse(dr["Fee"].ToString());
            timing = dr["Teacher"].ToString();
            count = count + 1;
            if (count == 1)
            {
                //Response.Cookies["items"].Value = item + "," + quantity.ToString() + "," + amount.ToString() + "," + urduname;
                //Response.Cookies["items"].Expires = DateTime.Now.AddDays(1);
                result = classCode + "," + className + "," + timing + "," + fee + "," + teacher;
            }
            else
            {
                //Response.Cookies["items"].Value = Request.Cookies["items"].Value + "|" + item + "," + quantity.ToString() + "," + amount.ToString() + "," + urduname;
                result = result + "|" + classCode + "," + className + "," + timing + "," + fee + "," + teacher;
            }
        }
        Response.Cookies["items"].Value = result;
        Response.Cookies["items"].Expires = DateTime.Now.AddDays(1);

        Response.Redirect("RegisterStudent.aspx?code=" + this.student);
    }
}