using System;
using System.Configuration;
using System.Data.SqlClient;

public class CourseRegistration
{
    public int serial { get; set; }
    public int registrationCode { get; set; }
    public string courseCode { get; set; }
    public double fee { get; set; }
    public bool active { get; set; }

    string strcon = ConfigurationManager.ConnectionStrings["timesheet"].ConnectionString;

    public CourseRegistration()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //---------------
    public void insertCourseRegistration()
    {
        //insert
        try
        {
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            string sql = "INSERT INTO CourseRegistration(registrationCode,courseCode,Fee,active)"
            + "VALUES(@registrationCode,@courseCode,@Fee,@active)";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@registrationCode", this.registrationCode);
            cmd.Parameters.AddWithValue("@courseCode", this.courseCode);
            cmd.Parameters.AddWithValue("@Fee", this.fee);
            cmd.Parameters.AddWithValue("@active", this.active);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());

        }
    }
}