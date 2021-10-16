using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Leadger
/// </summary>
public class Ledger
{
    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public int Id { get; set; }
    public string empId { get; set; }
    public string reason { get; set; }
    public double debit { get; set; }
    public double credit { get; set; }
    public double totalAmount { get; set; }
    public string note { get; set; }
    public string attachment{ get; set; }
    public DateTime date { get; set; }
    public string month { get; set; }
    public int year { get; set; }
    //---------------------------------------
    //------------------  COUNT ORDERS   -------------------------------------------
    public int getId()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT max(LedgerId) from Ledger";
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
    public double sumDebit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT COALESCE(sum(Debit),0) from Ledger", connection);
            double value = double.Parse(cmd.ExecuteScalar().ToString());
            connection.Close();
            return value;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //------------------  COUNT ORDERS   -------------------------------------------
    public double sumCredit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT COALESCE(sum(Credit),0) from Ledger ", connection);
            double value = double.Parse(cmd.ExecuteScalar().ToString());
            connection.Close();
            return value;
        }
        catch (Exception ex)
        {
            throw new Exception("Could not get Order data" + ex);
        }
    }
    //start of functions
    public void insertCredit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            string sql = "INSERT INTO Ledger(LedgerId,EmpId,Credit,Debit,TotalAmount,Reason,Date,Note)"
            + "VALUES(@id,@empId,@credit,@debit,@totalAmount,@reason,@date,@note)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.Parameters.AddWithValue("@empId", this.empId);
            cmd.Parameters.AddWithValue("@credit", this.credit);
            cmd.Parameters.AddWithValue("@debit", this.debit);
            cmd.Parameters.AddWithValue("@totalAmount", this.totalAmount);
            cmd.Parameters.AddWithValue("@reason", this.reason);
            cmd.Parameters.AddWithValue("@date", this.date);
            cmd.Parameters.AddWithValue("@note", this.note);
            cmd.ExecuteNonQuery();
            connection.Close();
            this.totalAmount = sumCredit() - sumDebit();
            updateBalance();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //start of functions
    public bool check()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT count(*) from Ledger where LedgerId='" + this.Id + "' And Reason='" + this.reason + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connection;
            int value = Int32.Parse(cmd1.ExecuteScalar().ToString());
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
    public void updateBalance()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Ledger set TotalAmount=@totalAmount where LedgerId=(SELECT max(LedgerId) from Ledger)";
            cmd.Parameters.AddWithValue("@totalAmount", this.totalAmount);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }

    public void insertDebit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            string sql = "INSERT INTO Ledger(LedgerId,EmpId,Credit,Debit,TotalAmount,Reason,Date,Note)"
            + "VALUES(@id,@empId,@credit,@debit,@totalAmount,@reason,@date,@note)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@id", this.Id);
            cmd.Parameters.AddWithValue("@empId", this.empId);
            cmd.Parameters.AddWithValue("@credit", this.credit);
            cmd.Parameters.AddWithValue("@debit", this.debit);
            cmd.Parameters.AddWithValue("@totalAmount", this.totalAmount);
            cmd.Parameters.AddWithValue("@reason", this.reason);
            cmd.Parameters.AddWithValue("@date", this.date);
            cmd.Parameters.AddWithValue("@note", this.note);
            cmd.ExecuteNonQuery();
            connection.Close();
            this.totalAmount = sumCredit() - sumDebit();
            updateBalance();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //------------------------ Update Expenditrue
    public void updateDebit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Ledger set Debit=@debit where LedgerId='" + this.Id + "' AND Reason='" + this.reason + "'";
            cmd.Parameters.AddWithValue("@debit", this.debit);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            this.totalAmount = sumCredit() - sumDebit();
            updateBalance();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //------------------------ Update Expenditrue
    public void updateCredit()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Ledger set Credit=@credit where LedgerId='" + this.Id + "' AND Reason='" + this.reason + "'";
            cmd.Parameters.AddWithValue("@credit", this.credit);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
            this.totalAmount = sumCredit() - sumDebit();
            updateBalance();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //------------------- delete extra
    public void deleteExtra()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            string sql = "Delete from Ledger where LedgerId='" + this.Id + "' AND Reason='" + this.reason + "'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            this.totalAmount = sumCredit() - sumDebit();

            updateBalance();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    //------------------- delete extra
    public void deleteEntry()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            string sql = "Delete from Ledger where LedgerId='" + this.Id + "'";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    //------------------------
    public DataTable getLedgerByMonth()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  COALESCE(sum(Credit),0) as Credit,COALESCE(sum(Debit),0) as Debit,COALESCE(sum(Credit),0)-COALESCE(sum(Debit),0) as [TotalAmount],convert(varchar, Date, 6) as Date from Ledger  where DATENAME(Month,Date)='" + this.month + "' And Year(Date)='" + this.year + "' GROUP BY Date order by Date", connection))
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
    public DataTable getDailyLedger()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  l.LedgerId as [ID],e.FirstName as [Employee],l.Credit,l.Debit,l.TotalAmount,l.Reason  from Ledger l,Employee e  where e.EmpId=l.EmpId And l.Date='" + this.date + "'", connection))
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
    public DataTable getLedgerById()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  * from Ledger where LedgerId='" + this.Id+ "'", connection))
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
    //------------------------
   
  
      
}