using System.Runtime.Serialization;

namespace Domain.Services;

public class GiftException : DomainException
{
    public GiftException(string message) : base(message)
    {
    }
    
    public GiftException(string message, Exception innerException) : 
        base(message, innerException)
    {
    }

    public GiftException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
    
}