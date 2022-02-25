namespace SampleGrpc.Auth.Models
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string username, string password);
    }
}
