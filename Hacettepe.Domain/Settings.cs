namespace Hacettepe.Domain;

public class Settings : EntityBase
{
    public long DoctorListingTemplateId_Tr { get; set; }
    
    public long DoctorListingTemplateId_En { get; set; }
    
    public long NewListingTemplateId_Tr { get; set; }
    
    public long NewListingTemplateId_En { get; set; }

    public long HeaderTemplateId_Tr { get; set; }
    
    public long HeaderTemplateId_En { get; set; }
    
    public long FooterTemplateId_Tr { get; set; }
    
    public long FooterTemplateId_En { get; set; }

}