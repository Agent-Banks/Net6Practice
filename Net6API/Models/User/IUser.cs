namespace Net6API.Models;

public interface IUser
{
    Guid ID { get; }
    string UserName { get; }
    string Password { get; }
    string Email { get; }
    string? CreatedBy { get; }
    DateTime? CreatedOnDate { get; }   
    string? LastUpdatedBy { get; }
    DateTime? LastUpdatedOnDate { get; }    
}
