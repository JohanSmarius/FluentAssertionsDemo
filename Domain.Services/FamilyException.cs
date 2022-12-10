using System.Runtime.Serialization;

namespace Domain.Services;

public class FamilyException : DomainException
{
    public FamilyException(string message) : base(message)
    {
        
    }
    
    public FamilyException(string message, Exception innerException) : 
        base(message, innerException)
    {
    }

    public FamilyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}