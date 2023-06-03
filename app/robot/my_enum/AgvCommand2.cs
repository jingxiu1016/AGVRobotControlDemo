using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using Timer = System.Timers.Timer;

namespace MauiApp3.app.robot.my_enum;

public class AgvCommand2 : BaseEnum
{
    [Description("在home点重定位 0x0 0002")]
    public const string InHomeRelocation = "0x00002"; 

    [Description("确认定位正确 0x0 0003")]
    public const string ConfirmLocationRight = "0x00003"; 

    [Description("暂停导航 0x0 0004")]
    public const string PauseNavigation = "0x00004"; 

    [Description("继续导航 0x0 0005")]
    public const string ContinueNavigation = "0x00005"; 

    [Description("取消导航 0x0 0006")]
    public const string CancelNavigation = "0x00006"; 

    [Description("回收控制权 0x0 0010")]
    public const string RecycleCtrl = "0x00010"; 

    [Description("释放控制器 0x0 0011")]
    public const string ReleaseCtrl = "0x00011"; 

    [Description("锟筒（皮带）左侧预上料 0x0 0012")]
    public const string RollerBarrelLeftBeforeLoading = "0x00012"; 

    [Description("锟筒（皮带）右侧预上料 0x0 0013")]
    public const string RollerBarrelRightBeforeLoading = "0x00013"; 

    [Description("锟筒（皮带）左侧上料 0x0 0015")]
    public const string RollerBarrelLeftLoading = "0x00015"; 

    [Description("锟筒（皮带）左侧下料 0x0 0016")]
    public const string RollerBarrelLeftBlanking = "0x00016"; 

    [Description("锟筒（皮带）右侧上料 0x0 0017")]
    public const string RollerBarrelRightLoading = "0x00017"; 

    [Description("锟筒（皮带）右侧下料 0x0 0018")]
    public const string RollerBarrelRightBlanking = "0x00018"; 

    [Description("锟筒（皮带）停止 0x0 0019")]
    public const string RollerBarrelSop = "0x00019"; 

    [Description("DO 0置为低电平 0x0 0020")]
    public const string Do0ToLow = "0x00020"; 

    [Description("DO 1置为低电平 0x0 0021")]
    public const string Do1ToLow = "0x00021"; 

    [Description("DO 2置为低电平 0x0 0022")]
    public const string Do2ToLow = "0x00022"; 

    [Description("DO 3置为低电平 0x0 0023")]
    public const string Do3ToLow = "0x00023"; 

    [Description("DO 4置为低电平 0x0 0024")]
    public const string Do4ToLow = "0x00024"; 

    [Description("DO 5置为低电平 0x0 0025")]
    public const string Do5ToLow = "0x00025"; 

    [Description("DO 6置为低电平 0x0 0026")]
    public const string Do6ToLow = "0x00026"; 

    [Description("DO 7置为低电平 0x0 0027")]
    public const string Do7ToLow = "0x00027"; 

    [Description("DO 8置为低电平 0x0 0028")]
    public const string Do8ToLow = "0x00028"; 

    [Description("DO 9置为低电平 0x0 0029")]
    public const string Do9ToLow = "0x00029"; 

    [Description("DO 10置为低电平 0x0 0030")]
    public const string Do10ToLow = "0x00030"; 

    [Description("DO 11置为低电平 0x0 0031")]
    public const string Do11ToLow = "0x00031"; 

    [Description("DO 12置为低电平 0x0 0032")]
    public const string Do12ToLow = "0x00032"; 

    [Description("DO 13置为低电平 0x0 0033")]
    public const string Do13ToLow = "0x00033"; 

    [Description("DO 14置为低电平 0x0 0034")]
    public const string Do14ToLow = "0x00034"; 

    [Description("DO 15置为低电平 0x0 0035")]
    public const string Do15ToLow = "0x00035"; 

    [Description("DO 0置为高电平 0x0 0060")]
    public const string Do0ToHigh = "0x00060"; 

    [Description("DO 1置为高电平 0x0 0061")]
    public const string Do1ToHigh = "0x00061"; 

    [Description("DO 2置为高电平 0x0 0062")]
    public const string Do2ToHigh = "0x00062"; 

    [Description("DO 3置为高电平 0x0 0063")]
    public const string Do3ToHigh = "0x00063"; 

    [Description("DO 4置为高电平 0x0 0064")]
    public const string Do4ToHigh = "0x00064"; 

    [Description("DO 5置为高电平 0x0 0065")]
    public const string Do5ToHigh = "0x00065"; 

    [Description("DO 6置为高电平 0x0 0066")]
    public const string Do6ToHigh = "0x00066"; 

    [Description("DO 7置为高电平 0x0 0067")]
    public const string Do7ToHigh = "0x00067"; 

    [Description("DO 8置为高电平 0x0 0068")]
    public const string Do8ToHigh = "0x00068"; 

    [Description("DO 9置为高电平 0x0 0069")]
    public const string Do9ToHigh = "0x00069"; 

    [Description("DO 10置为高电平 0x0 0070")]
    public const string Do10ToHigh = "0x00070"; 

    [Description("DO 11置为高电平 0x0 0071")]
    public const string Do11ToHigh = "0x00071"; 

    [Description("DO 12置为高电平 0x0 0072")]
    public const string Do12ToHigh = "0x00072"; 

    [Description("DO 13置为高电平 0x0 0073")]
    public const string Do13ToHigh = "0x00073"; 

    [Description("DO 14置为高电平 0x0 0074")]
    public const string Do14ToHigh = "0x00074"; 

    [Description("DO 15置为高电平 0x0 0075")]
    public const string Do15ToHigh = "0x00075";

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
    //         var pattern = @"^0x\d{5}$";
    //         if (key == null || !Regex.IsMatch(key?.ToString(), pattern))
    //         {
    //             continue;
    //         }
    //
    //         var reg = Parser.ParseRegisterType(key?.ToString() ?? string.Empty);
    //         var value = robot.ReadInfo(reg);
    //         if (desc != null)
    //             infos.Add(new RobotInfo
    //             {
    //                 Name = desc,
    //                 Value = value
    //             });
    //     }
    //
    //     return infos;
    // }
}
