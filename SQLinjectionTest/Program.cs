using System.ComponentModel;
using System.Data.SqlClient;

string connectionString = "Server=BILAL-KINALI;Database=UserDb;Trusted_Connection=True;";

Console.Write("Brugernavn: ");
string username = Console.ReadLine();

Console.Write("Password: ");
string password = Console.ReadLine();

using (SqlConnection conn = new SqlConnection(connectionString))
{
    string query = $"SELECT COUNT(*) From Users WHERE Username = @username AND Password = @password";

    using (SqlCommand command = new SqlCommand(query, conn))
    {
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@password", password);

        try
        {
            conn.Open();
            int userCount = (int)command.ExecuteScalar();

            if (userCount > 0)
            {
                Console.WriteLine("Match");
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("En fejl opstod " + ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}