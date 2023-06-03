using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

public class VisualLayout
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("scaleX")]
    public decimal ScaleX { get; set; }
    [XmlAttribute("scaleY")]
    public decimal ScaleY { get; set; }
    // [XmlElement("modelLayoutElement")]
    // public ModelLayoutElement[] ModelLayoutElements { get; set; }
}

public class ModelLayoutElement
{
    
    [XmlElement("property")]
    public Property[] Properties { get; set; }
}