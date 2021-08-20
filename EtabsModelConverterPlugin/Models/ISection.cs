namespace EtabsModelConverterPlugin.Models
{
    public interface ISection
    {
        string PropertyName { get; set; }
        SectionType SectionType { get; set; }
        IMaterial Material { get; set; }
        string AppendSectionName(string originalName, string textToAppend);
    }
}