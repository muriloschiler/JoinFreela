using FluentValidation.Results;

namespace joinfreela.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
        
        public BadRequestException():base("Requisição inválida")
        {}
        public BadRequestException(string message):base(message)
        {}        
        public BadRequestException(string propertyName,string errorMessage):this()
        {
            Errors.Add(new ValidationFailure(propertyName,errorMessage));
        }
        public BadRequestException(ValidationResult validationResult)
        {
            Errors= validationResult.Errors;
        }

    }
}