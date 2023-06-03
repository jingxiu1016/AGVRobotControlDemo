using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

public class LocationType
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlElement("allowedOperation")]
    public AllowedOperation Operation { get; set; }
}

public class AllowedOperation
{
    [XmlAttribute("name")]
    public string Name { get; set; }
}