using MySql.Data.MySqlClient;
public class Connection
{
    public static MySqlConnection GetConnection()
    {
        MySqlConnection myconnection = new MySqlConnection
        {
            ConnectionString = @"server=localhost;user id=root;password=nhatdo25;port=3306;database=StudentManagement1;"
        };
        myconnection.Open();
        return myconnection;
    }
}

//@"server=localhost;user id=root;password=nguyenthequan305;port=3306;database=StudentManagement1;"
//@"server=localhost;user id=root;password=nhatdo25;port=3306;database=StudentManagement1;"



