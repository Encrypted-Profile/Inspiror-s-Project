using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Payroll
/// </summary>
public class Payroll
{
    public int Serial { get; set; }
    public string teacherCode { get; set; }
    public string month { get; set; }
    public int year { get; set; }
    public double cashIn { get; set; }
    public double cashOut { get; set; }
    public double balance { get; set; }
    public DateTime receivingDate { get; set; }
    public string receivingTime { get; set; }
    public bool received { get; set; }


    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public Payroll()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool checkMonthlyPayroll()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) from Payroll where TeacherCode='" + this.teacherCode + "' and [Month]='" + this.month + "' and [Year]='" + this.year + "'", connection);
            int value = Convert.ToInt32(cmd.ExecuteScalar());

            connection.Close();
            if (value > 0)
                return true;
            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public void updatePayroll()
    {

        try
        {
            bool x = checkMonthlyPayroll();
            if (x)
            {
                //update existing
                SqlConnection connection = new SqlConnection(strcon);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "update Payroll set CashIn=@CashIn+CashIn,CashOut=@CashOut+Cashout  where TeacherCode='" + this.teacherCode + "' and [Month]='" + this.month + "' and [Year]='" + this.year + "'";
                cmd.Parameters.AddWithValue("@CashIn", this.cashIn);
                cmd.Parameters.AddWithValue("@CashOut", this.cashOut);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                //Insert new
                SqlConnection connection = new SqlConnection(strcon);
                connection.Open();
                string sql = "INSERT INTO Payroll(TeacherCode,[Month],[Year],CashIn,CashOut,ReceivingDate,ReceivingTime,Received)"
                + "VALUES(@TeacherCode,@Month,@Year,@CashIn,@CashOut,@ReceivingDate,@receivingTime,@Received)";
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@TeacherCode", this.teacherCode);
                cmd.Parameters.AddWithValue("@Month", this.month);
                cmd.Parameters.AddWithValue("@Year", this.year);
                cmd.Parameters.AddWithValue("@CashIn", this.cashIn);
                cmd.Parameters.AddWithValue("@CashOut", this.cashOut);
                cmd.Parameters.AddWithValue("@receivingDate", this.receivingDate);
                cmd.Parameters.AddWithValue("@receivingTime", this.receivingTime);
                cmd.Parameters.AddWithValue("@Received", this.received);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        catch (Exception ex)
        {

        }
    }
}