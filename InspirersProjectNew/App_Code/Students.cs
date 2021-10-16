using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Students
/// </summary>
public class Students
{
    public string code { get; set; }
    public string name { get; set; }
    public string father { get; set; }
    public string gender { get; set; }
    public string mobile { get; set; }
    public string email { get; set; }
    public string address { get; set; }
    public string emergency { get; set; }
    public bool active { get; set; }
    public DateTime registrationDate { get; set; }

    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;
    public Students()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public bool checkStudent()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();

            SqlCommand cmd = new SqlCommand("SELECT count(*) from Students where studentCode='" + this.code + "'", connection);
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
    public void newStudent()
    {
        //insert
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO Students(studentCode,studentName,studentFather,studentGender,studentMobile,studentEmail,studentAddress,studentEmergency,studentActive,studentRegistrationDate)"
            + "VALUES(@studentCode,@studentName,@studentFather,@studentGender,@studentMobile,@studentEmail,@studentAddress,@studentEmergency,@studentActive,@registrationDate)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@studentCode", this.code);
            cmd.Parameters.AddWithValue("@studentName", this.name);
            cmd.Parameters.AddWithValue("@studentFather", this.father);
            cmd.Parameters.AddWithValue("@studentGender", this.gender);
            cmd.Parameters.AddWithValue("@studentMobile", this.mobile);
            cmd.Parameters.AddWithValue("@studentEmail", this.email);
            cmd.Parameters.AddWithValue("@studentAddress", this.address);
            cmd.Parameters.AddWithValue("@studentEmergency", this.emergency);
            cmd.Parameters.AddWithValue("@studentActive", this.active);
            cmd.Parameters.AddWithValue("@registrationDate", this.registrationDate);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
    public DataTable getSpecificStudent()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT * from Students where studentCode= '" + this.code + "'", connection))
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
    public DataTable getAllStudents()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            using (SqlDataAdapter ds1 = new SqlDataAdapter("SELECT * from Students ", connection))
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
    public void updateStudent()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update Students set studentName=@name,studentFather=@father,studentGender=@gender,studentMobile=@mobile,studentEmail=@email,studentAddress=@address,studentEmergency=@emergency,studentActive=@active where studentCode='" + this.code + "'";
            cmd.Parameters.AddWithValue("@studentName", this.name);
            cmd.Parameters.AddWithValue("@studentFather", this.father);
            cmd.Parameters.AddWithValue("@studentGender", this.gender);
            cmd.Parameters.AddWithValue("@studentMobile", this.mobile);
            cmd.Parameters.AddWithValue("@studentEmail", this.email);
            cmd.Parameters.AddWithValue("@studentAddress", this.address);
            cmd.Parameters.AddWithValue("@studentEmergency", this.emergency);
            cmd.Parameters.AddWithValue("@studentActive", this.active);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}