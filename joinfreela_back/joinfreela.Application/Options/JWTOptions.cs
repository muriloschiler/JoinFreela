namespace joinfreela.Application.Options
{
    public class JWTOptions
    {
        public string SecretKey { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}