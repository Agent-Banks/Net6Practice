namespace Net6API.Models;

class NullUser : IUser
{
    public Guid ID => Guid.Empty;
    public string UserName => SetNotFoundString();
    public string Password => SetNotFoundString();
    public string Email => SetNotFoundString();
    public string? CreatedBy => SetNotFoundString();
    public DateTime? CreatedOnDate => SetNotFoundDateTime();
    public string? LastUpdatedBy => SetNotFoundString();
    public DateTime? LastUpdatedOnDate => SetNotFoundDateTime();
    private string SetNotFoundString() => "Not Found";
    private DateTime SetNotFoundDateTime() => DateTime.MinValue;
}