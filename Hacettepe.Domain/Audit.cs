using System.ComponentModel.DataAnnotations;

namespace Hacettepe.Domain;

public class Audit: IEntity
{
    [Key]
    public int Id { get; set; }
    public string User { get; set; }
    public string Type { get; set; }
    public string TableName { get; set; }
    public DateTime OccurrenceDateTime { get; set; }
    public string? OldValues { get; set; }
    public string? NewValues { get; set; }
    public string? AffectedColumns { get; set; }
    public string PrimaryKey { get; set; }
}