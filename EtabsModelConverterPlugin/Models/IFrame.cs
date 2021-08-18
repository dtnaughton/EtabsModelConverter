namespace EtabsModelConverterPlugin.Models
{
    public interface IFrame
    {
        FramePropertyModifiers PropertyModifiers { get; set; }
        Geometry Geometry { get; set; }
    }
}