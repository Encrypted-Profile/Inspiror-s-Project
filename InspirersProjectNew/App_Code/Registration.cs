using System;
using System.Configuration;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Registration
/// </summary>
public class Registration
{
    public int registrationCode { get; set; }
    public string studentCode { get; set; }
    public DateTime registrationDate { get; set; }
    public string registrationTime { get; set; }
    public bool active { get; set; }
    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public Registration()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //---------------
    public int insert()
    {
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO Registration(studentCode,registrationDate,registrationTime,active)"
            + "VALUES(@studentCode,@registrationDate,@registrationTime,@active)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@studentCode", this.studentCode);
            cmd.Parameters.AddWithValue("@registrationDate", this.registrationDate);
            cmd.Parameters.AddWithValue("@registrationTime", this.registrationTime);
            cmd.Parameters.AddWithValue("@active", this.active);
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

}