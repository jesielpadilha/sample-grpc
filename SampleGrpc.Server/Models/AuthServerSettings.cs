namespace SampleGrpc.Server.Models
{
    public static partial class AuthenticationConfig
    {
        public class AuthServerSettings
        {
            public string Authority { get; set; }
            public string Scope { get; set; }
        }
    }
}
