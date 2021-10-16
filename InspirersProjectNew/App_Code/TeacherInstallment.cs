using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for TeacherInstallmnet
/// </summary>
public class TeacherInstallment
{
    public int serial { get; set; }
    public string teacherCode { get; set; }
    public DateTime installmentDate { get; set; }
    public string installmentTime { get; set; }
    public double cashIn { get; set; }
    public double cashOut { get; set; }
    public string reason { get; set; }
    public bool confirmed { get; set; }

    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public TeacherInstallment()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void insert()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO TeacherInstallment(TeacherCode,InstallmentDate,InstallmentTime,CashIn,CashOut,Reason,Confirmed)"
            + "VALUES(@TeacherCode,@InstallmentDate,@InstallmentTime,@CashIn,@CashOut,@Reason,@Confirmed)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@TeacherCode", this.teacherCode);
            cmd.Parameters.AddWithValue("@InstallmentDate", this.installmentDate);
            cmd.Parameters.AddWithValue("@InstallmentTime", this.installmentTime);
            cmd.Parameters.AddWithValue("@CashIn", this.cashIn);
            cmd.Parameters.AddWithValue("@CashOut", this.cashOut);
            cmd.Parameters.AddWithValue("@Reason", this.reason);
            cmd.Parameters.AddWithValue("@Confirmed", this.confirmed);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public DataTable getSpecificInstallment(string month, int year)
    {

        SqlConnection connection = new SqlConnection(strcon);
        connection.Open();
        using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  * from TeacherInstallment where TeacherCode='" + this.teacherCode + "' and datename(month,InstallmentDate)='" + month + "' and Year(InstallmentDate)='" + year + "'", connection))
        {
            DataSet ds = new DataSet();
            ds1.Fill(ds);
            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            connection.Close();
            return dt;
        }

    }
}