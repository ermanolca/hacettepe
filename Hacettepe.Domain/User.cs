using System.ComponentModel.DataAnnotations.Schema;
using Hacettepe.Domain.Enums;

namespace Hacettepe.Domain;

[Table("users")]
public class User : EntityBase
{
     public string Name { get; set; }
    
     public string Email { get; set; }
     
     public string Password { get; set; }
     
     public bool IsActive { get; set; }
     
     public Roles Role { get; set; }
     
     public byte[]? Salt { get; set; }

     public string? Token { get; set; }
}