using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;
public class Point
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("xPosition")]
    public int XPosition { get; set; }
    [XmlAttribute("yPosition")]
    public int YPosition { get; set; }
    [XmlAttribute("zPosition")]
    public int ZPosition { get; set; }
    [XmlAttribute("vehicleOrientationAngle")]
    public string VehicleOrientationAngle { get; set; }
    [XmlAttribute("type")]
    public string Type { get; set; }
    [XmlElement("outgoingPath")]
    public OutGoingPath[] OutGoingPaths { get; set; }
}

public class OutGoingPath
{
    [XmlAttribute("name")]
    public string Name {get; set; }
}