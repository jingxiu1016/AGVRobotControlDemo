
using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

public class Property
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("value")]
    public string Value { get; set; }

    public Property(string name, string value) => (Name, Value) = (name, value);
}