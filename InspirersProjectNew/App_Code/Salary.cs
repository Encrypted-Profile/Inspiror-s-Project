using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Salary
/// </summary>
public class Salary
{
   
    public int SalaryId { get; set; }
    public string EmpId { get; set; }
    public string SalaryType { get; set; }
    public double SalaryAmount { get; set; }
    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;
    public bool check()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) from Salary where EmpId='" + this.EmpId + "'", connection);
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
    public void insert()
    {
        //insert
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            string sql = "INSERT INTO Salary(SalaryId,EmpId,SalaryType,SalaryAmount)"
            + "VALUES(@salaryId,@empId,@salaryType,@salaryAmount)";
            SqlCommand cmd = new SqlCommand (sql, connection);
            cmd.Parameters.AddWithValue("@salaryId", this.SalaryId);
            cmd.Parameters.AddWithValue("@empId", this.EmpId);
            cmd.Parameters.AddWithValue("@salaryType", this.SalaryType);
            cmd.Parameters.AddWithValue("@salaryAmount", this.SalaryAmount);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
 public void update()
    {
        try
        {
           SqlConnection connection = new SqlConnection(strcon);
           connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Salary set SalaryType=@salaryType,SalaryAmount=@salaryAmount where EmpId='" + this.EmpId + "'";
            cmd.Parameters.AddWithValue("@salaryType", this.SalaryType);
            cmd.Parameters.AddWithValue("@salaryAmount", this.SalaryAmount);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
 
    public int getId()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
           connection.Open();
            
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT max(SalaryId) from Salary";
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
    public DataTable getSalary()
    {
       
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT SalaryAmount from Salary where EmpId='"+this.EmpId+"'", connection))
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
