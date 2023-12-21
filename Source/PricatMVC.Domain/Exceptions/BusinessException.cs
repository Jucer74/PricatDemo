using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace PricatMVC.Domain.Exceptions
{
    /// <summary>
    /// Base Business Exception
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Serializable]
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception innerException): base(message, innerException)
        {
        }
    }
}