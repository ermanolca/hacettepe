using System.ComponentModel.DataAnnotations;

namespace Hacettepe.Domain;

public class Page : EntityBase
{
    [Key]
    public long Id { get; set; }

    public string Title { get; set; }
    
    public string? Content { get; set; }

    public string? Metadata { get; set; }
    public string Slug { get; set; }
    
}