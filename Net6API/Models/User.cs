using System.ComponentModel.DataAnnotations;

namespace Net6API.Models;

public class User
{
    [Required]
    string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    public string Email { get; set; }
    public Guid ID { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? CreatedOnDate { get; set; }
    public string? LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOnDate { get; set; }

    public User()
    {
        ID = Guid.NewGuid();
        CreatedOnDate = DateTime.Now;
        CreatedBy = "System";
    }

}
