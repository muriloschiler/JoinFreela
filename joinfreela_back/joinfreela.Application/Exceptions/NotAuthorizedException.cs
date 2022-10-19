namespace joinfreela.Application.Exceptions
{
    public class NotAuthorizedException: Exception
    {
        public NotAuthorizedException():base("Usuário não autorizado")
        {}
    }
}