using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MauiApp3.app.robot.my_enum;

public class AgvStatus1: BaseEnum
{
    [Description("机器人x坐标 3x0 0001")]
    public const string  X="3x00001";                             // 机器人x坐标 3x0 0001
    [Description("机器人y坐标 3x0 0003")]
    public const string  Y="3x00003";                             // 机器人y坐标 3x0 0003
    [Description("机器人角度坐标 3x0 0005")]
    public const string  Angle="3x00005";                     // 机器人角度坐标 3x0 0005
    [Description("机器人当前导航站点 3x0 0007")]
    public const string  CurrentNavigationSite="3x00007";         // 机器人当前导航站点 3x0 0007
    [Description("机器人当前定位状态 3x0 0008")]
    public const string  LocationState="3x00008";                 // 机器人当前定位状态 3x0 0008
    [Description("机器人当前导航状态 3x0 0009")]
    public const string  CurrentNavigationState="3x00009";        // 机器人当前导航状态 3x0 0009
    [Description("机器人当前导航类型 3x0 00010")]
    public const string  CurrentNavigationType="3x00010";         // 机器人当前导航类型 3x0 00010
    [Description("机器人定位置信度 3x0 00011")]
    public const string  LocationConfidenceCoefficient="3x00011"; // 机器人定位置信度 3x0 0011
    [Description("电量 3x0 00013")]
    public const string  BatteryCapacity="3x00013";   // 电量 3x0 00013
    [Description("电池温度 3x0 00015")]
    public const string  BatteryTemperate="3x00015";  // 电池温度 3x0 00015
    [Description("电池电压 3x0 00017")]
    public const string  BatteryVoltage="3x00017";    // 电池电压 3x0 00017
    [Description("电池电流 3x0 00019")]
    public const string  BatteryCurrent="3x00019";    // 电池电流 3x0 00019
    [Description("控制器温度 3x0 00021")]
    public const string  ControllerTemperate="3x00021";   // 控制器温度 3x0 0021
    [Description("控制器适度 3x0 00023")]
    public const string  ControllerHumidity="3x00023";    // 控制器适度 3x0 0023
    [Description("控制器电压 3x0 00025")]
    public const string  ControllerVoltage="3x00025";     // 控制器电压 3x0 0025
    [Description("总里程 3x0 00027")]
    public const string  TotalMileage="3x00027";  // 总里程 3x0 0027
    [Description("累计运行时间 3x0 00029")]
    public const string  RunningTime="3x00029";       // 累计运行时间 3x0 0029
    [Description("fatal 错误码 3x0 00031")]
    public const string  Fatal="3x00031";     // fatal 错误码 3x0 0031
    [Description("error 错误码 3x0 00032")]
    public const string  Error="3x00032";     // error 错误发 3x0 0032
    [Description("warning 错误码 3x0 00033")]
    public const string  Warning="3x00033";   // warning 错误码 3x0 0033
    [Description("机器人当前所在站点 3x0 00034")]
    public const string  NowSite="3x00034";       // 机器人当前所在站点 3x0 0034
    [Description("机器人上一个所在站点 3x0 00035")]
    public const string  LastSite="3x00035";      // 机器人上一个所在站点 3x0 0035
    [Description("机器人下一个要经过的站点 3x0 00036")]
    public const string  NextSite="3x00036";      // 机器人下一个要经过的站点 3x0 0036
    [Description("Major 版本号 3x0 00037")]
    public const string  MajorVersion="3x00037";              // Major 版本号 3x0 0037
    [Description("Minor 版本号 3x0 00038")]
    public const string  MinorVersion="3x00038";              // Minor 版本号 3x0 0038
    [Description("Patch 版本号 3x0 00039")]
    public const string  PatchVersion="3x00039";              // Patch 版本号 3x0 0039
    [Description("Redistribute 版本号 3x0 0040")]
    public const string  RedistributeVersion="3x00040";       // Redistribute 版本号 3x0 0040
    [Description("当前地图名 3x0 00041")]
    public const string  MapName="3x00041";                   // 当前地图名 3x0 0041
    [Description("当前地图载人状态 3x0 00042")]
    public const string  LoadMapState="3x00042";              // 当前地图载人状态 3x0 0042
    [Description("机器人调度状态 3x0 00043")]
    public const string  ShecudlingState="3x00043";           // 机器人调度状态 3x0 0043
    [Description("被阻挡的原因 3x0 00044")]
    public const string  BlockCause="3x00044";                // 被阻挡的原因 3x0 0044
    [Description("发生阻挡的超声ID号 3x0 00045")]
    public const string  BlockUltrasoundId="3x00045";         // 发生阻挡的超声ID号 3x0 0045
    [Description("发生阻挡的DI的ID号 3x0 00046")]
    public const string  BlockDiid="3x00046";                 // 发生阻挡的DI的ID号 3x0 0046
    [Description("阻挡位置的x坐标 3x0 00047")]
    public const string  BlockX="3x00047";                // 阻挡位置的x坐标 3x0 0047
    [Description("阻挡位置的Y坐标 3x0 00049")]
    public const string  BlockY="3x00049";                // 阻挡位置的Y坐标 3x0 0049
    [Description("机器人的vx速度 3x0 00051")]
    public const string  VX="3x00051";                    // 机器人的vx速度 3x0 0051
    [Description("机器人的vy速度 3x0 00053")]
    public const string  VY="3x00053";                    // 机器人的vy速度 3x0 0053
    [Description("机器人的角速度 3x0 00055")]
    public const string  Palstance="3x00055";             // 机器人的角速度 3x0 0055
    [Description("货叉高度  3x0 00057")]
    public const string  CargoFork="3x00057";             // 货叉高度  3x0 0057
    [Description("机器人舵角 3x0 00059")]
    public const string  HelmAngle="3x00059";             // 机器人舵角 3x0 0059
    [Description("顶升机构状态 3x0 00061")]
    public const string  JackingMechanismState="3x00061";     // 顶升机构状态 3x0 0061
    [Description("锟筒（皮带）状态 3x0 00062")]
    public const string  RollerBarrelState="3x00062";         // 锟筒（皮带）状态 3x0 0062
    [Description("顶升机实时高度 3x0 00064")]
    public const string  JackingCurrentHigh="3x00064";    // 顶升机实时高度 3x0 0064
    [Description("顶升机错误码 3x0 00065")]
    public const string  JackingError="3x00065";          // 顶升机错误码 3x0 0065
    [Description("锟筒（皮带）错误码 3x0 00066")]
    public const string  RollerBarrelError="3x00066";     // 锟筒（皮带）错误码 3x0 0066
    [Description("RFID ID 3x0 00069")]
    public const string  RfidId="3x00069";              // RFID ID 3x0 0069
    [Description("IP1 3x0 00070")]
    public const string  Ip1="3x00070";                 // IP1 3x0 0070
    [Description("IP2 3x0 00071")]
    public const string  Ip2="3x00071";                 // IP2 3x0 0071
    [Description("IP3 3x0 00072")]
    public const string  Ip3="3x00072";                 // IP3 3x0 0072
    [Description("IP4 3x0 00073")]
    public const string  Ip4="3x00073";                 // IP4 3x0 0073
    [Description("今日总里程 3x0 00081")]
    public const string  TodayTotalMileage="3x00081";         // 今日总里程 3x0 0081
    [Description("当前src模式 3x0 00083")]
    public const string  CurrentSrcModel="3x00083";               // 当前src模式 3x0 0083
    [Description("机器人减速原因 3x0 00084")]
    public const string  SlowDown="3x00084";                      // 机器人减速原因 3x0 0084
    [Description("托盘角度 3x0 00089")]
    public const string  PalletAngle="3x00089";              // 托盘角度 3x0 0089
    [Description("舵角信息1 3x0 00091")]
    public const string  HelmAngleInfo1="3x00091";           // 舵角信息1 3x0 0091
    [Description("舵角信息2 3x0 00093")]
    public const string  HelmAngleInfo2="3x00093";           // 舵角信息2 3x0 0093
    [Description("舵角信息3 3x0 00095")]
    public const string  HelmAngleInfo3="3x00095";           // 舵角信息3 3x0 0095
    [Description("舵角信息4 3x0 00097")]
    public const string  HelmAngleInfo4="3x00097";           // 舵角信息4 3x0 0097 

    public override Dictionary<string, FieldInfo> ReturnMapDesc()
    {
        Dictionary<string, FieldInfo> infos = new Dictionary<string, FieldInfo>();
        foreach (var item in ReturnField())
        {
            var desc = item.GetCustomAttribute<DescriptionAttribute>()?.Description;
            if (desc != null) infos.Add(desc, item);
        }
        return infos;
    }
    
    public override IEnumerable<FieldInfo> ReturnField()
    {
        return GetType().GetRuntimeFields();
    }
    
    // public override List<RobotInfo> PrintInfo(AgvRobot robot)
    // {
    //     List<RobotInfo> infos = new ();
    //     foreach (var item in ReturnField())
    //     {
    //         var desc = item.GetCustomAttribute<DescriptionAttribute>()?.Description;
    //         var key = item.GetValue(this);
    //         var pattern = @"^3x\d{5}$";
    //         if (key == null || !Regex.IsMatch(key?.ToString(), pattern)){continue;}
    //         var reg = Parser.ParseRegisterType(key?.ToString() ?? string.Empty);
    //         var value = robot.ReadInfo(reg);
    //         if (desc != null) 
    //             infos.Add(new RobotInfo
    //             {
    //                 Name = desc,
    //                 Value = value
    //             });
    //     }
    //     return infos;
    // }
}