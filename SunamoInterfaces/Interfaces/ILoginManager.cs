namespace SunamoInterfaces.Interfaces;

public interface ILoginManager
{
    Func<string, string> DoWebRequest { get; set; }
    Func<string, ExternalLoginResult> DeserializeJson { get; set; }
    bool PairLoginAndPassword(string messSuccessfullyLoginedTo, Func<string, string> EncryptPasswordToBase64, string login, string password, string hostWithSlash, bool showOnUserRequest = false);
}
