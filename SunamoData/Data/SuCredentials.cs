namespace SunamoData.Data;

public class SuCredentials
{
    public SuCredentials(string token)
    {
        Token = token;
    }

    public SuCredentials(string login, string password)
    {
        Login = login;
        Password = password;
    }

    public SuCredentials()
    {

    }

    public string Login { get; set; }
    public string Password { get; set; }
    public string Token { get; set; }
}
