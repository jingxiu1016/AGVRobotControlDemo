using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

public class Path
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("sourcePint")]
    public string SourcePint { get; set; }
    [XmlAttribute("destinationPoint")]
    public string DestinationPoint { get; set; }
    [XmlAttribute("length")]
    public int Length { get; set; }
    [XmlAttribute("routingCost")]
    public int RoutingCost { get; set; }
    [XmlAttribute("maxVelocity")]
    public int MaxVelocity { get; set; }
    [XmlAttribute("maxReverseVelocity")]
    public int MaxReverseVelocity { get; set; }
    [XmlAttribute("locked")]
    public bool Locked { get; set; }
}