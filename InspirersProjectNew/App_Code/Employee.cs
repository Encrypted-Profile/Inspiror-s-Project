using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Employee
{
    public string empCode { get; set; }
    public string empFirstName { get; set; }
    public string empLastName { get; set; }
    public string gender { get; set; }
    public string email { get; set; }
    public string mobile { get; set; }
    public string qualification { get; set; }
    public string address { get; set; }
    public DateTime joiningDate { get; set; }
    public DateTime leavingDate { get; set; }
    public bool status { get; set; }
    public string Designation { get; set; }
    public string Type { get; set; }
    public string grade { get; set; }
    public string LoginId { get; set; }
    public string LoginPwd { get; set; }
    public string pic { get; set; }

    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public bool checkUser()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT COUNT(*) from Employee where Status='true' And LoginId='" + this.LoginId + "' AND LoginPwd='" + this.LoginPwd + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connection;
            Int32 count = (Int32)cmd1.ExecuteScalar();
            connection.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public int countEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT COUNT(*) from Employee where Status='true'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connection;
            Int32 count = (Int32)cmd1.ExecuteScalar();
            connection.Close();
            return count;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public bool checkIfActive()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "SELECT COUNT(*) from Employee where Status='true' And EmpId='" + this.empCode + "'";
            cmd1.CommandType = CommandType.Text;
            cmd1.Connection = connection;
            Int32 count = (Int32)cmd1.ExecuteScalar();
            connection.Close();
            if (count > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public void changeLoginId()
    {

        SqlConnection connection = new SqlConnection(strcon);
        connection.Open();
        SqlCommand cmd = connection.CreateCommand();
        try
        {
            cmd.CommandText = "update Employee set LoginId=@Login_Id where EmpId=+'" + this.empCode + "'";
            cmd.Parameters.AddWithValue("@Login_Id", this.LoginId);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }

    }
    public void changeLoginPassword()
    {

        SqlConnection connection = new SqlConnection(strcon);
        connection.Open();
        SqlCommand cmd = connection.CreateCommand();
        try
        {
            cmd.CommandText = "update Employee set LoginPwd=@Login_Pwd where EmpId=+'" + this.empCode + "'";
            cmd.Parameters.AddWithValue("@Login_Pwd", this.LoginPwd);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }

    }
    public DataTable getTeachers()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT EmpId,FirstName from Employee where Type='Teacher' And Status='True'", connection))
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

    public DataTable getAllActiveEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT EmpId,FirstName,LastName,Mobile,Type,Address from Employee where Status='True'", connection))
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
    public DataTable getAllProjectEmployee(int projectId)
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT a.EmpId,e.FirstName from Employee e,AssignedProjects a where e.EmpId=a.EmpId And e.Status='True' And a.ProjectId='" + projectId + "' And a.Status='true'", connection))
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
    public DataTable getAllEmp()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT EmpId,FirstName from Employee where Type='Employee' And Status='True'", connection))
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
    public DataTable getAllEmpAndAdmin()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT EmpId,FirstName from Employee where Type!='Employee' And Status='True'", connection))
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

    public bool checkEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT count(*) from Employee where EmpId='" + this.empCode + "'", connection);
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
    public string getEmployeeId()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT EmpId from Employee Where LoginId='" + this.LoginId + "' And LoginPwd='" + this.LoginPwd + "'";
            cmd.Connection = connection;
            string value = string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "" : cmd.ExecuteScalar().ToString();
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public string getEmployeeName()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT FirstName from Employee Where LoginId='" + this.LoginId + "' And LoginPwd='" + this.LoginPwd + "' And Status='true'";
            cmd.Connection = connection;
            string value = string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "" : cmd.ExecuteScalar().ToString();
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public string getEmployeeNameByCode()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT FirstName from Employee Where EmpId='" + this.empCode + "'";
            cmd.Connection = connection;
            string value = string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "" : cmd.ExecuteScalar().ToString();
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }
    }
    public string getEmployeeType()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Type from Employee Where EmpId='" + this.empCode + "'";
            cmd.Connection = connection;
            string value = string.IsNullOrEmpty(cmd.ExecuteScalar().ToString()) ? "" : cmd.ExecuteScalar().ToString();
            connection.Close();

            return value;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.ToString());
        }

    }
    //---------------
    public void addEmployee()
    {
        //insert
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            string sql = "INSERT INTO Employee(EmpId,FirstName,LastName,Gender,Email,Mobile,Qualification,Address,JoiningDate,Designation,Type,Status,LoginId,LoginPwd,Grade)"
            + "VALUES(@code,@FName,@LName,@gender,@email,@mobile,@qualification,@address,@JDate,@designation,@type,@status,@loginId,@loginPwd,@grade)";

            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@code", this.empCode);
            cmd.Parameters.AddWithValue("@FName", this.empFirstName);
            cmd.Parameters.AddWithValue("@LName", this.empLastName);
            cmd.Parameters.AddWithValue("@gender", this.gender);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@mobile", this.mobile);
            cmd.Parameters.AddWithValue("@qualification", this.qualification);
            cmd.Parameters.AddWithValue("@address", this.address);
            cmd.Parameters.AddWithValue("@JDate", this.joiningDate);
            cmd.Parameters.AddWithValue("@designation", this.Designation);
            cmd.Parameters.AddWithValue("@type", this.Type);
            cmd.Parameters.AddWithValue("@status", this.status);
            cmd.Parameters.AddWithValue("@loginId", this.LoginId);
            cmd.Parameters.AddWithValue("@loginPwd", this.LoginPwd);
            cmd.Parameters.AddWithValue("@grade", this.grade);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public void updateEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set FirstName=@FName,LastName=@LName,Gender=@gender,Mobile=@mobile,Address=@address,Email=@email,Designation=@designation,Grade=@grade,JoiningDate=@JDate,Qualification=@qualification,Type=@type where EmpId='" + this.empCode + "'";
            cmd.Parameters.AddWithValue("@FName", this.empFirstName);
            cmd.Parameters.AddWithValue("@LName", this.empLastName);
            cmd.Parameters.AddWithValue("@gender", this.gender);
            cmd.Parameters.AddWithValue("@email", this.email);
            cmd.Parameters.AddWithValue("@mobile", this.mobile);
            cmd.Parameters.AddWithValue("@qualification", this.qualification);
            cmd.Parameters.AddWithValue("@address", this.address);
            cmd.Parameters.AddWithValue("@JDate", this.joiningDate);
            cmd.Parameters.AddWithValue("@designation", this.Designation);
            cmd.Parameters.AddWithValue("@type", this.Type);
            cmd.Parameters.AddWithValue("@grade", this.grade);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
    public DataTable getAllEmployees()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  EmpId,FirstName,LastName,Gender,Mobile,Status from Employee where Status='true'", connection))
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
    public DataTable getEmployeeById()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  EmpId,FirstName,LastName,Gender,Email,Mobile,Type,Qualification,Address,convert(varchar, JoiningDate, 6) as JoiningDate,convert(varchar,LeavingDate, 6) as LeavingDate,Status,Designation,Grade from Employee where EmpId='" + this.empCode + "'", connection))
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
    public DataTable getEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT  EmpId,FirstName,LastName,Gender,Mobile,Status from Employee where FirstName= '" + this.empFirstName + "'", connection))
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
    public void activeEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set Status='true' where EmpId='" + this.empCode + "'";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public void resetCredentials()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set LoginId=@loginId,LoginPwd=@loginPwd where EmpId='" + this.empCode + "'";
            cmd.Parameters.AddWithValue("@loginId", this.LoginId);
            cmd.Parameters.AddWithValue("@loginPwd", this.LoginPwd);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public void deactiveEmployee()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set Status='false',LeavingDate='" + this.leavingDate + "' where EmpId='" + this.empCode + "'";

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public void updateLoginId()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set LoginId=@id where EmpId='" + Common.adminId + "'";
            cmd.Parameters.AddWithValue("@id", this.LoginId);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public void updatePassword()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Employee set LoginPwd=@id where EmpId='" + Common.adminId + "'";
            cmd.Parameters.AddWithValue("@id", this.LoginPwd);

            cmd.ExecuteNonQuery();

            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }

}