using System.Xml.Serialization;

namespace MauiApp3.app.robot.map_manage;

public class Vehicle
{
    [XmlAttribute("name")]
    public string Name { get; set; }
    [XmlAttribute("length")]
    public decimal Length { get; set; }
    [XmlAttribute("energyLevelCritical")]
    public int EnergyLevelCritical { get; set; }
    [XmlAttribute("energyLevelGood")]
    public int EnergyLevelGood { get; set; }
    [XmlAttribute("energyLevelFullyRecharged")]
    public int EnergyLevelFullyRecharged { set; get; }
    [XmlAttribute("energyLevelSufficientlyRecharged")]
    public int EnergyLevelSufficientlyRecharged { get; set; }
    [XmlAttribute("maxVelocity")]
    public int MaxVelocity { get; set; }
    [XmlAttribute("maxReverseVelocity")]
    public int MaxReverseVelocity { get; set; }
    [XmlAttribute("rechargeOperation")]
    public string RechargeOperation { get; set; }
    [XmlAttribute("type")]
    public string Type { get; set; }
    [XmlElement("processableCategory")]
    public ProcessableCategory[] ProcessableCategories { get; set; }
}


public class ProcessableCategory
{
    [XmlAttribute("name")]
    public string Name { get; set; }
}