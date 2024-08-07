using System.ComponentModel.DataAnnotations.Schema;

namespace Hacettepe.Domain;

public class MenuItem : EntityBase
{
    public string Name { get; set; }

    public long? ParentId { get; set; }

    public MenuItem? Parent { get; set; }

    public ICollection<MenuItem>? SubMenuItems { get; } = new List<MenuItem>();

    [Column("tr_text")]
    public string Tr_Text { get; set; }
    [Column("en_text")]
    public string En_Text { get; set; }

    [Column("tr_url")]
    public string Tr_Url { get; set; }
    
    [Column("en_url")]
    public string En_Url { get; set; }
    
}