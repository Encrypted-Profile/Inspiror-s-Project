using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Expenditure
/// </summary>
public class Expenditure
{
    public int expId { get; set; }
    public int ledgerId { get; set; }
    public double amount { get; set; }
    public DateTime date { get; set; }
    public string month { get; set; }
    public int year { get; set; }
    public string reason { get; set; }
    public string note { get; set; }
    public string attachment { get; set; }
    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;
    //=========================================================
    public bool check()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT count(*) from Expenditure where Id='" + this.expId + "'";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            int value = Int32.Parse(cmd.ExecuteScalar().ToString());
            connection.Close();
            if (value > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public int getExpId()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT max(Id) from Expenditure";
            cmd.Connection = connection;
            int value = Int32.Parse(string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "0" : cmd.ExecuteScalar().ToString());
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {
            
            throw new Exception(ex.ToString());
        }

    }
    public void newExpenditure()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Expenditure(Id,LedgerId,Reason,Date,Amount,Note)"
            + "VALUES(@id,@ledgerId,@reason,@date,@amount,@note)";
            cmd.Parameters.AddWithValue("@id", this.expId);
            cmd.Parameters.AddWithValue("@ledgerId", this.ledgerId);
            cmd.Parameters.AddWithValue("@reason", this.reason);
            cmd.Parameters.AddWithValue("@date", this.date);
            cmd.Parameters.AddWithValue("@amount", this.amount);
            cmd.Parameters.AddWithValue("@note", this.note);

            // cmd.Parameters.AddWithValue("@amount", this.Amount);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //===================
    public DataTable getData()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  Id,Amount,Reason,convert(varchar, Date, 6) as Date from Expenditure  where Id='" + this.expId + "'", connection))
            {
                DataSet ds = new DataSet();
                ds1.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    //===========================================================================
    public void updateExpenditure()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Expenditure set Reason=@reason, Amount=@amount ,Note=@note where Id='" + this.expId + "'";
            cmd.Parameters.AddWithValue("@reason", this.reason);
            cmd.Parameters.AddWithValue("@amount", this.amount);
            cmd.Parameters.AddWithValue("@note", this.note);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception)
        {
            throw new Exception(expId.ToString());
        }
    }
    //=========================================================================================
    public DataTable byDate()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
           SqlCommand cmd = connection.CreateCommand();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT Id,Amount,Reason,Note from  Expenditure  where  Date='" + this.date + "'", connection))
            {
                DataSet ds = new DataSet();
                ds1.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public DataTable getExpById()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
           SqlCommand cmd = connection.CreateCommand();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT * from  Expenditure  where  Id='" + this.expId + "'", connection))

            {
                DataSet ds = new DataSet();
                ds1.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //==============================================================================
  

    public int getLedgerId()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT LedgerId from Expenditure Where Id='" + this.expId+ "'";
            cmd.Connection = connection;
            int value = Int32.Parse(string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "0" : cmd.ExecuteScalar().ToString());
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }

    }
    //=====================================================================
    public DataTable byMonth()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT COALESCE(sum(Amount),0) as Amount,convert(varchar, Date, 6) as Date  from  Expenditure where DATENAME(Month,Date)='" + this.month + "' And Year(Date)='" + this.year + "' GROUP BY Date order by Date", connection))
            {
                DataSet ds = new DataSet();
                ds1.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public DataTable byReason()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
           SqlCommand cmd = connection.CreateCommand();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  Id,Amount,Reason,convert(varchar,Date,6) as Date from Expenditure  where Reason= '" + this.reason + "'", connection))
            {
                DataSet ds = new DataSet();
                ds1.Fill(ds);
                DataTable dt = new DataTable();
                dt = ds.Tables[0];
                connection.Close();
                return dt;
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
   
}