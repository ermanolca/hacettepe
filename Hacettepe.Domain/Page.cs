using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hacettepe.Domain;

public class Page
{
    [Key]
    public long Id { get; set; }

    public string Title { get; set; }

    [Column("content_tr")]
    public string? Content_TR { get; set; }
    
    [Column("content_en")]
    public string? Content_EN { get; set; }

    public string? Metadata { get; set; }

    public string Slug { get; set; }
}