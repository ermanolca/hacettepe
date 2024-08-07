using System.ComponentModel.DataAnnotations.Schema;

namespace Hacettepe.Domain;

public class News : EntityBase
{
    [Column("title_tr")]
    public string Title_Tr { get; set; }
    
    [Column("title_en")]
    public string Title_En { get; set; }

    public string ListingImgUrl { get; set; }

    [Column("brief_tr")]
    public string Brief_Tr { get; set; }
    
    [Column("brief_en")]
    public string Brief_En { get; set; }
    
    [Column("full_template_id_tr")]
    public string FullTemplateId_Tr { get; set; }
    
    [Column("full_template_id_en")]
    public string FullTemplateId_En { get; set; }
}