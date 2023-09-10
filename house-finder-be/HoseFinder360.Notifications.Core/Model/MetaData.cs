namespace HoseFinder360.Notifications.Core.Model;

public class MetaData
{
    public Guid EntityId { get; private set; }
    public string CreatedBy { get; private set; }
    public List<string> SendTo { get; private set; }
    public string Type { get; private set; }
    #pragma warning disable
    private MetaData(){}
}