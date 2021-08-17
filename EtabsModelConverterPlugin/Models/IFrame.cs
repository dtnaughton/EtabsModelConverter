namespace EtabsModelConverterPlugin.Models
{
    public interface IFrame
    {
        FramePropertyModifiers PropertyModifiers { get; set; }
        double Width { get; set; }
        double Height { get; set; }
    }
}