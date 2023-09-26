using System.Runtime.Serialization;

namespace HouseFinder360.Domain.BuildingBlocks.EventSourcing;

[Serializable]
public class EventSourcingException : Exception
{
    public EventSourcingException()
    {
    }

    public EventSourcingException(string message) : base(message)
    {
    }

    public EventSourcingException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected EventSourcingException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}