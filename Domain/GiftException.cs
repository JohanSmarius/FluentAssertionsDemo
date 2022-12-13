using System.Runtime.Serialization;

namespace Domain;

public class GiftException : Exception
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