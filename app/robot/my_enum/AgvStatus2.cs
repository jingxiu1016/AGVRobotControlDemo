using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MauiApp3.app.robot.my_enum;

public class AgvStatus2:BaseEnum
{
    [Description("是否减速 1x0 0001")]
    public const string IsSlowDown = "1x00001";                // 是否减速 1x0 0001

    [Description("是否被阻挡 1x0 0002")]
    public const string IsBlock = "1x00002";                   // 是否被阻挡 1x0 0002

    [Description("是否在充电 1x0 0003")]
    public const string IsCharge = "1x00003";                  // 是否在充电 1x0 0003

    [Description("是否急停 1x0 0004")]
    public const string IsEmergencyStop = "1x00004";           // 是否急停 1x0 0004

    [Description("是否抱闸 1x0 0005")]
    public const string IsLockBrake = "1x00005";               // 是否抱闸 1x0 0005

    [Description("货叉是否到位 1x0 0006")]
    public const string IsForkInPlace = "1x00006";            // 货叉是否到位 1x0 0006

    [Description("叉车的控制模式 1x0 0007")]
    public const string CargoForkCtrlModel = "1x00007";        // 叉车的控制模式 1x0 0007

    [Description("是否有fatal 1x0 0008")]
    public const string IsFatal = "1x00008";                   // 是否有fatal 1x0 0008

    [Description("是否有Error 1x0 0009")]
    public const string IsError = "1x00009";                   // 是否有Error 1x0 0009

    [Description("是否有warning 1x0 0010")]
    public const string IsWarning = "1x00010";                 // 是否有warning 1x0 0010

    [Description("顶升机构是否启用 1x0 0011")]
    public const string IsJackingStart = "1x00011";            // 顶升机构是否启用 1x0 0011

    [Description("顶升机构是否急停 1x0 0012")]
    public const string IsJackingStop = "1x00012";             // 顶升机构是否急停 1x0 0012

    [Description("顶升机构是否有料 1x0 0013")]
    public const string IsJackingHaveMeterial = "1x00013";     // 顶升机构是否有料 1x0 0013

    [Description("锟筒（皮带）是否启用 1x0 0014")]
    public const string IsRollerBarrelStart = "1x00014";       // 锟筒（皮带）是否启用 1x0 0014

    [Description("锟筒（皮带）是否急停 1x0 0015")]
    public const string IsRollerBarrelStop = "1x00015";        // 锟筒（皮带）是否急停 1x0 0015

    [Description("锟筒（皮带）是否有料 1x0 0016")]
    public const string IsRollerBarrelHaveMeterial = "1x00016";// 锟筒（皮带）是否有料 1x0 0016

    [Description("底盘是否静止 1x0 0019")]
    public const string IsChassisStationary = "1x00019";       // 底盘是否静止 1x0 0019

    [Description("DI 0 1x0 0020")]
    public const string Di0 = "1x00020";                       // DI 0 1x0 0020

    [Description("DI 1 1x0 0021")]
    public const string Di1 = "1x00021";                       // DI 1 1x0 0021

    [Description("DI 2 1x0 0022")]
    public const string Di2 = "1x00022";                       // DI 2 1x0 0022

    [Description("DI 3 1x0 0023")]
    public const string Di3 = "1x00023";                       // DI 3 1x0 0023

    [Description("DI 4 1x0 0024")]
    public const string Di4 = "1x00024";                       // DI 4 1x0 0024

    [Description("DI 5 1x0 0025")]
    public const string Di5 = "1x00025";                       // DI 5 1x0 0025

    [Description("DI 6 1x0 0026")]
    public const string Di6 = "1x00026";                       // DI 6 1x0 0026

    [Description("DI 7 1x0 0027")]
    public const string Di7 = "1x00027";                       // DI 7 1x0 0027

    [Description("DI 8 1x0 0028")]
    public const string Di8 = "1x00028";                       // DI 8 1x0 0028

    [Description("DI 9 1x0 0029")]
    public const string Di9 = "1x00029";                       // DI 9 1x0 0029

    [Description("DI 10 1x0 0030")]
    public const string Di10 = "1x00030";                      // DI 10 1x0 0030

    [Description("DI 11 1x0 0031")]
    public const string Di11 = "1x00031";                      // DI 11 1x0 0031

    [Description("DI 12 1x0 0032")]
    public const string Di12 = "1x00032";                      // DI 12 1x0 0032

    [Description("DI 13 1x0 0033")]
    public const string Di13 = "1x00033";                      // DI 13 1x0 0033

    [Description("DI 14 1x0 0034")]
    public const string Di14 = "1x00034";                      // DI 14 1x0 0034

    [Description("DI 15 1x0 0035")]
    public const string Di15 = "1x00035";                      // DI 15 1x0 0035

    [Description("DO 0 1x0 0060")]
    public const string Do0 = "1x00060";                       // DO 0 1x0 0060

    [Description("DO 1 1x0 0061")]
    public const string Do1 = "1x00061";                       // DO 1 1x0 0061

    [Description("DO 2 1x0 0062")]
    public const string Do2 = "1x00062";                       // DO 2 1x0 0062

    [Description("DO 3 1x0 0063")]
    public const string Do3 = "1x00063";                       // DO 3 1x0 0063

    [Description("DO 4 1x0 0064")]
    public const string Do4 = "1x00064";                       // DO 4 1x0 0064

    [Description("DO 5 1x0 0065")]
    public const string Do5 = "1x00065";                       // DO 5 1x0 0065

    [Description("DO 6 1x0 0066")]
    public const string Do6 = "1x00066";                       // DO 6 1x0 0066

    [Description("DO 7 1x0 0067")]
    public const string Do7 = "1x00067";                       // DO 7 1x0 0067

    [Description("DO 8 1x0 0068")]
    public const string Do8 = "1x00068";                       // DO 8 1x0 0068

    [Description("DO 9 1x0 0069")]
    public const string Do9 = "1x00069";                       // DO 9 1x0 0069

    [Description("DO 10 1x0 0070")]
    public const string Do10 = "1x00070";                      // DO 10 1x0 0070

    [Description("DO 11 1x0 0071")]
    public const string Do11 = "1x00071";                      // DO 11 1x0 0071

    [Description("DO 12 1x0 0072")]
    public const string Do12 = "1x00072";                      // DO 12 1x0 0072

    [Description("DO 13 1x0 0073")]
    public const string Do13 = "1x00073";                      // DO 13 1x0 0073

    [Description("DO 14 1x0 0074")]
    public const string Do14 = "1x00074";                      // DO 14 1x0 0074

    [Description("DO 15 1x0 0075")]
    public const string Do15 = "1x00075";                      // DO 15 1x0 0075

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
    //         var pattern = @"^1x\d{5}$";
    //         if (key == null || !Regex.IsMatch(key?.ToString(), pattern)){continue;}
    //         var reg = Parser.ParseRegisterType(key?.ToString() ?? string.Empty);
    //         // var value = robot.ReadInfo(reg);
    //         // if (desc != null) infos.Add(new RobotInfo
    //         // {
    //         //     Name = desc,
    //         //     Value = value
    //         // });
    //     }
    //
    //     return infos;
    // }
}