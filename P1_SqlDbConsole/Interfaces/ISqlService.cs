using System;

namespace P1_SqlDbConsole.Interfaces;

public interface ISqlService
{
    public void CreateUser(string Username, string Email ,string Password);
    public void FindUser(string Email);
    public void UpdateUser(string Email, string NewUsername , string NewPassword);
    public void DeleteUser(string Email);
}
