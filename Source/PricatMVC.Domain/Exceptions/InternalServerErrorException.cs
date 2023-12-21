using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace PricatMVC.Domain.Exceptions
{
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class InternalServerErrorException : BusinessException
    {
        public InternalServerErrorException()
        {
        }

        public InternalServerErrorException(string message) : base(message)
        {
        }

        public InternalServerErrorException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}