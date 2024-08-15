
namespace Hacettepe.Domain;

public class Doctor : EntityBase
{
    public string Name { get; set; }

    public string Title { get; set; }
    
    public string Specialty { get; set; }
    
    public string Department { get; set; }
    public string ImageUrl { get; set; }
    
    public string Content { get; set; }
    
    public Languages Language { get; set; }
    
}