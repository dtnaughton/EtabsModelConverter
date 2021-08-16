namespace EtabsModelConverterPlugin.Models
{
    public interface ISection
    {
        string PropertyName { get; set; }
        string GetSectionName(string fullName);
    }
}