using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Domain.Services;

public class DomainException : Exception
{
    public DomainException(string message) : 
        base(message)
    {
        
    }

    public DomainException(string message, Exception innerException) : 
        base(message, innerException)
    {
    }

    public DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}