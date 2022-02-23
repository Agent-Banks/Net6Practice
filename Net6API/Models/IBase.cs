namespace Net6API.Models;

public interface IBase
{
    Guid ID { get; }
    public string? CreatedBy { get; }
    public DateTime? CreatedOnDate { get; }
    public string? LastUpdatedBy { get; }
    public DateTime? LastUpdatedOnDate { get; }
}

