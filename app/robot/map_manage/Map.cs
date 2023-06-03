using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

[XmlRoot("model")]
public class Map
{
    [XmlAttribute("version")]
    public string Version { get; set; }
    [XmlAttribute("name")]
    public string MapName { get; set; }
    
    [XmlElement("point")]
    public Point[] Points { get; set; }
    [XmlElement("path")]
    public Path[] Paths { get; set; }
    [XmlElement("vechile")]
    public Vehicle[] Vehicles { get; set; }
    [XmlElement("locationType")]
    public LocationType[] LocationTypes { get; set; }
    [XmlElement("visualLayout")]
    public VisualLayout VisualLayouts { get; set; }
    // [XmlElement("property")]
    // public Property[] Properties { get; set; }
}