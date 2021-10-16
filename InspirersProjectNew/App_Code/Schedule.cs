using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Schedule
/// </summary>
public class Schedule
{
    public string classCode { get; set; }
    public string className { get; set; }
    public string classTimming { get; set; }
    public string classSubject { get; set; }
    public string classTeacher { get; set; }
    public double classTeacherPercentage { get; set; }
    public double classFee { get; set; }
    public Schedule()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;
    public bool checkClass()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) from Schedule where classCode='" + this.classCode + "'", connection);
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
    public void newTeacher()
    {
        //insert
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO Schedule(classCode,className,classTiming,classSubject,classTeacher,classTeacherPercentage,classFee)"
            + "VALUES(@classCode,@className,@classTiming,@classSubject,@classTeacher,@classTeacherPercentage,@classFee)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@classCode", this.classCode);
            cmd.Parameters.AddWithValue("@className", this.className);
            cmd.Parameters.AddWithValue("@classTiming", this.classTimming);
            cmd.Parameters.AddWithValue("@classSubject", this.classSubject);
            cmd.Parameters.AddWithValue("@classTeacher", this.classTeacher);
            cmd.Parameters.AddWithValue("@classTeacherPercentage", this.classTeacherPercentage);
            cmd.Parameters.AddWithValue("@classFee", this.classFee);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public DataTable getClass(string ptr)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  p.classCode,p.className,p.classTiming,p.classSubject,p.classTeacherPercentage as [Percentage],p.classFee,e.FirstName as [Teacher] from Schedule p,Employee e Where  p.classTeacher=e.EmpId And (p.classCode='" + ptr + "' OR p.className='" + ptr + "')", connection))
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
    public DataTable getByCode()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  p.classCode,p.className,p.classTiming,p.classSubject,p.classTeacherPercentage as [Percentage],p.classFee,e.FirstName as [Teacher] from Schedule p,Employee e Where  p.classTeacher=e.EmpId And p.classCode='" + this.classCode + "'", connection))
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
    public DataTable getAllClasses()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  p.classCode,p.className,p.classTiming,p.classSubject,p.classTeacherPercentage as [Percentage],p.classFee,e.FirstName as [Teacher] from Schedule p,Employee e Where  p.classTeacher=e.EmpId", connection))
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
    public void update()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Schedule set className=@className,classTiming=@classTiming,classSubject=@classSubject,classTeacher=@classTeacher,classFee=@classFeee,classTeacherPercentage=@classTeacherPercentage where classCode='" + this.classCode + "'";
            cmd.Parameters.AddWithValue("@classCode", this.classCode);
            cmd.Parameters.AddWithValue("@className", this.className);
            cmd.Parameters.AddWithValue("@classTiming", this.classTimming);
            cmd.Parameters.AddWithValue("@classSubject", this.classSubject);
            cmd.Parameters.AddWithValue("@classTeacher", this.classTeacher);
            cmd.Parameters.AddWithValue("@classTeacherPercentage", this.classTeacherPercentage);
            cmd.Parameters.AddWithValue("@classFee", this.classFee);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public DataTable getTeacherPercentage()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("select s.classTeacher, s.classTeacherPercentage from schedule s where classCode = '" + this.classCode + "'", connection))
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