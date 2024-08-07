using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hacettepe.Domain;

public interface IEntityBase
{
    long Id { get; set; }
    DateTime CreatedDate { get; set; }
    string CreatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
    string? UpdatedBy { get; set; }
    public bool? IsDeleted { get; set; }
}

public class EntityBase : IEntityBase
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    
    public DateTime CreatedDate { get; set; }
    
    public string CreatedBy { get; set; }
    
    public DateTime? UpdatedDate { get; set; }
    
    public string? UpdatedBy { get; set; }
    
    public bool? IsDeleted { get; set; }
}