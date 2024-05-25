using System.ComponentModel.DataAnnotations;

namespace Hacettepe.Domain;

public class Doctor
{
    [Key]
    public long Id { get; set; }

    public string Name { get; set; }

    public string Contact { get; set; }

    public string Title { get; set; }

    public string Department { get; set; }

    public string Biography { get; set; }

    public string Publications { get; set; }
    
    
}