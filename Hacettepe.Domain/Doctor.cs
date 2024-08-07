using System.ComponentModel.DataAnnotations;

namespace Hacettepe.Domain;

public class Doctor : EntityBase
{
    public string Name { get; set; }

    public string Unvan_Tr { get; set; }
    
    public string Unvan_En { get; set; }
    
    public string Uzman_Tr { get; set; }
    
    public string Uzman_En { get; set; }
    
    public string Bolum_Tr { get; set; }
    
    public string Bolum_En { get; set; }

    public string Tel { get; set; }

    public string Email { get; set; }

    public string ImageUrl { get; set; }

    
    public string TemplateId_Tr { get; set; }
    
    public string TemplateId_En { get; set; }
    
}