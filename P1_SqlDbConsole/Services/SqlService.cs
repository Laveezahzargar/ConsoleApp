using System;
using Microsoft.Data.SqlClient;
using P1_SqlDbConsole.Interfaces;

namespace P1_SqlDbConsole.Services;

public class SqlService : ISqlService
{
    private readonly string ConnectionString;
    public SqlService(string CONNECTION_STRING)
    {
        this.ConnectionString = CONNECTION_STRING;
    }
    public void CreateUser(string Username, string Email, string Password)
    {
        try
        {
            Console.WriteLine("Trying To Connect To Database!");

            using SqlConnection connection = new SqlConnection("ConnectionString");

            connection.Open();

            string query = "Insert Into Users (Username ,Email ,Password) Values (@Username ,@Email ,@Password)";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Password", Password);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("User Saved Sucessfully!");
            }
            else
            {
                Console.WriteLine("Query Not Executed!");
            }

        }
        catch (Exception e)
        {

            Console.WriteLine(e.Message);
        }
    }

    public void FindUser(string Email)
    {
        try
        {
            Console.WriteLine("Trying To Connect To Database!");

            using SqlConnection connection = new SqlConnection("ConnectionString");

            connection.Open();

            string query = "Select * From Users Where Email = @ Email";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", Email);

            using SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                Console.WriteLine("User Found ! Below Are The Details Of User : ");

                Console.WriteLine(reader["Username"].ToString());
                Console.WriteLine(reader["Email"].ToString());
                Console.WriteLine(reader["Password"].ToString());
            }
            else
            {
                Console.WriteLine("No User Found With This Email!");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void UpdateUser(string Email, string NewUsername, string NewPassword)
    {
        try
        {
            Console.WriteLine("Trying To Connect To Database!");

            using SqlConnection connection = new SqlConnection("ConnectionString");

            connection.Open();

            string query = "update Users set Username = @NewUsername , Password = @NewPassword where Email = @Email";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@NewUsername", NewUsername);
            command.Parameters.AddWithValue("@NewPassword", NewPassword);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("User Updated Sucessfully!");
            }
            else
            {
                Console.WriteLine("No User Found With This Email");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public void DeleteUser(string Email)
    {
        try
        {
            Console.WriteLine("Trying To Connect To Database!");

            using SqlConnection connection = new SqlConnection("ConnectionString");

            connection.Open();

            string query = "Delete From Users Where Email = @ Email";

            using SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Email", Email);

            int rowsAffected = command.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                Console.WriteLine("User Deleted Sucessfully!");
            }
            else
            {
                Console.WriteLine("Query Not Executed!");
            }


        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

}
