using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Installment
/// </summary>
public class Installment
{
    public int serial { get; set; }
    public int registrationCode { get; set; }
    public DateTime installmentDate { get; set; }
    public string month { get; set; }
    public int year { get; set; }
    public double fee { get; set; }
    public bool paid { get; set; }
    public DateTime nextInstallment { get; set; }

    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;
    public bool checkInstallment()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) from Installments where serial='" + this.serial + "'", connection);
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
    //---------------
    public int insert()
    {
        //insert
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO Installments(registrationCode,installmentDate,installmentMonth,installmentYear,Fee,paid,nextInstallmentDate)"
            + "VALUES(@registrationCode,@installmentDate,@installmentMonth,@installmentYear,@Fee,@paid,@nextInstallmentDate)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@registrationCode", this.registrationCode);
            cmd.Parameters.AddWithValue("@installmentDate", this.installmentDate);
            cmd.Parameters.AddWithValue("@installmentMonth", this.month);
            cmd.Parameters.AddWithValue("@installmentYear", this.year);
            cmd.Parameters.AddWithValue("@Fee", this.fee);
            cmd.Parameters.AddWithValue("@paid", this.paid);
            cmd.Parameters.AddWithValue("@nextInstallmentDate", this.nextInstallment);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT @@IDENTITY";
            int value = Convert.ToInt32(cmd.ExecuteScalar());
            connection.Close();
            return value;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    //public void update()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = "update Installment set Installment=@installment,Amount=@amount,Date=@date,Note=@note where Id='" + this.Id + "'";
    //        cmd.Parameters.AddWithValue("@installment", this.ins);
    //        cmd.Parameters.AddWithValue("@amount", this.Amount);
    //        cmd.Parameters.AddWithValue("@date", this.Date);
    //        cmd.Parameters.AddWithValue("@note", this.Note);
    //        cmd.CommandType = CommandType.Text;
    //        cmd.ExecuteNonQuery();
    //        connection.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //}
    public DataTable getInstallmentBySerial()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  * from Installments where serial='" + this.serial + "'", connection))
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

    //public double getAllClientInstallment()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();

    //        SqlCommand cmd = new SqlCommand("SELECT COALESCE(sum(Amount),0) from Installment where ProjectId='" + this.ProjectId + "'", connection);
    //        double value = double.Parse(cmd.ExecuteScalar().ToString());
    //        connection.Close();
    //        return value;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //}
    //public DataTable getData()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();

    //        using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  I.Id,P.ProjectName,c.FirstName as [Client],I.Installment, I.Amount from Project P,Client c,Installment I Where p.ClientId=c.ClientId And p.ProjectId=I.ProjectId And I.Id='" + this.Id + "'", connection))
    //        {
    //            DataSet ds = new DataSet();
    //            ds1.Fill(ds);
    //            DataTable dt = new DataTable();
    //            dt = ds.Tables[0];
    //            connection.Close();
    //            return dt;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());

    //    }
    //}
    //public DataTable getById()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  * from Installment Where Id='" + this.Id + "'", connection))
    //        {
    //            DataSet ds = new DataSet();
    //            ds1.Fill(ds);
    //            DataTable dt = new DataTable();
    //            dt = ds.Tables[0];
    //            connection.Close();
    //            return dt;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());

    //    }
    //}
    //public DataTable getByProjectId()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  I.Id,p.ProjectName,I.Installment,I.Amount,convert(varchar,I.Date,6) as Date from Project p,Installment I where I.ProjectId=p.ProjectId And I.ProjectId='" + this.ProjectId + "'", connection))
    //        {
    //            DataSet ds = new DataSet();
    //            ds1.Fill(ds);
    //            DataTable dt = new DataTable();
    //            dt = ds.Tables[0];
    //            connection.Close();
    //            return dt;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());

    //    }
    //}
    //public int getId()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = "SELECT max(Id) from Installment";
    //        cmd.Connection = connection;
    //        int value = Int32.Parse(string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "0" : cmd.ExecuteScalar().ToString());
    //        connection.Close();

    //        return value;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw new Exception(ex.ToString());
    //    }

    //}
    //public int getInstallmentNo()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = "SELECT max(Installment) from Installment where ProjectId='" + this.ProjectId + "'";
    //        cmd.Connection = connection;
    //        int value = Int32.Parse(string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "0" : cmd.ExecuteScalar().ToString());
    //        connection.Close();

    //        return value;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw new Exception(ex.ToString());
    //    }

    //}
    //public int getLedgerId()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();

    //        SqlCommand cmd = connection.CreateCommand();
    //        cmd.CommandText = "SELECT LedgerId from Installment Where Id='" + this.Id + "'";
    //        cmd.Connection = connection;
    //        int value = Int32.Parse(string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "0" : cmd.ExecuteScalar().ToString());
    //        connection.Close();

    //        return value;
    //    }
    //    catch (Exception ex)
    //    {

    //        throw new Exception(ex.ToString());
    //    }

    //}
    //public void delete()
    //{
    //    try
    //    {
    //        SqlConnection connection = new SqlConnection(strcon);
    //        connection.Open();
    //        string sql = "Delete from Installment Where Id='" + this.Id + "'";
    //        SqlCommand cmd = new SqlCommand(sql, connection);
    //        cmd.ExecuteNonQuery();
    //        connection.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.ToString());
    //    }
    //}
}