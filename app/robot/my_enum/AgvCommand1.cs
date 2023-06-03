using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MauiApp3.app.robot.my_enum;

public class AgvCommand1:BaseEnum
{
    [Description("让机器人以路径导航去目标站点 4x0 0001")]
    public const string PathToTargetSize = "4x00001";          // 让机器人以路径导航去目标站点 4x0 0001
    [Description("开环下发机器人vx速度 4x0 0005")]
    public const string SetVxSpeed = "4x00005";            // 开环下发机器人vx速度 4x0 0005
    [Description("开环下发机器人vy速度 4x0 0007")]
    public const string SetVySpeed = "4x00007";            // 开环下发机器人vy速度 4x0 0007
    [Description("开环下发机器人角速度 4x0 0009")]
    public const string SetAngleSpeed = "4x00009";         // 开环下发机器人角速度 4x0 0009
    [Description("开环下发机器人舵角 4x0 0011")]
    public const string SetHelmAngle = "4x00011";          // 开环下发机器人舵角 4x0 0011
    [Description("设置货叉高度 4x0 0013")]
    public const string SetCargoForkHigh = "4x00013";      // 设置货叉高度 4x0 0013
    [Description("X方向直线运动（平动） 4x0 0015")]
    public const string SetXTranslation = "4x00015";       // X方向直线运动（平动） 4x0 0015
    [Description("Y方向直线运动（平动） 4x0 0017")]
    public const string SetYTranslation = "4x00017";       // Y方向直线运动（平动） 4x0 0017
    [Description("转动 4x0 0019")]
    public const string SetRotation = "4x00019";           // 转动 4x0 0019
    [Description("x方向直线运动速度 4x0 0022")]
    public const string SetXTransSpeed = "4x00022";        // x方向直线运动速度 4x0 0022
    [Description("Y方向直线运动速度 4x0 0024")]
    public const string SetYTransSpeed = "4x00024";        // Y方向直线运动速度 4x0 0024
    [Description("转动角速度 4x0 0026")]
    public const string SetRotationSpeed = "4x00026";      // 转动角速度 4x0 0026
    [Description("平动、转动的模式 4x0 0028")]
    public const string SetTransOrRotation = "4x00028";         // 平动、转动的模式 4x0 0028
    [Description("切换地图 4x0 0029")]
    public const string SetMap = "4x00029";                    // 切换地图 4x0 0029
    [Description("播放音频 4x0 0030")]
    public const string SetAudio = "4x00030";                  // 播放音频 4x0 0030
    [Description("执行预存的任务连 4x0 0031")]
    public const string RunStoredTaskChain = "4x00031";        // 执行预存的任务连 4x0 0031
    [Description("设置货架描述文件 4x0 0032")]
    public const string SetShelfDescFile = "4x00032";          // 设置货架描述文件 4x0 0032
    [Description("清楚货架描述文件 4x0 0033")]
    public const string ClearShelfDescFile = "4x00033";        // 清楚货架描述文件 4x0 0033
    [Description("顶升机构上升 4x0 0050")]
    public const string SetJackingUp = "4x00050";              // 顶升机构上升 4x0 0050
    [Description("顶升机构下降 4x0 0051")]
    public const string SetJackingDown = "4x00051";            // 顶升机构下降 4x0 0051
    [Description("顶升机构停止 4x0 0052")]
    public const string SetJackingStop = "4x00052";            // 顶升机构停止 4x0 0052
    [Description("顶升机构定稿 4x0 0053")]
    public const string SetJackingFixed = "4x00053";           // 顶升机构定稿 4x0 0053
    [Description("牵引上料 4x0 0054")]
    public const string TractionLoading = "4x00054";           // 牵引上料 4x0 0054
    [Description("牵引下料 4x0 0055")]
    public const string TractionBlanking = "4x00055";          // 牵引下料 4x0 0055
    [Description("SRC 控制模式 4x0 0056")]
    public const string SrcCtrlModel = "4x00056";              // SRC 控制模式 4x0 0056
    [Description("SRC 监听模式 4x0 0057")]
    public const string SrcListenModel = "4x00057";            // SRC 监听模式 4x0 0057
    [Description("DI 设置可用 4x0 0061")]
    public const string SetDiUse = "4x00061";                  // DI 设置可用 4x0 0061
    [Description("DI 设置禁用 4x0 0062")]
    public const string SetDiUnUser = "4x00062";               // DI 设置禁用 4x0 0062
    [Description("Virtual DI设置为高电平 4x0 0063")]
    public const string SetVirtualDiHigh = "4x00063";          // Virtual DI设置为高电平 4x0 0063
    [Description("Virtual DI设置为低电平 4x0 0064")]
    public const string SetVirtualDiLow = "4x00064";           // Virtual DI设置为低电平 4x0 0064
    [Description("电机标零 4x0 0065")]
    public const string MotorMarkZero = "4x00065";             // 电机标零 4x0 0065
    [Description("设置货叉迁移后退 4x0 0071")]
    public const string CargoForkTrans = "4x00071";            // 设置货叉迁移后退 4x0 0071
    [Description("spindirection 4x0 0080")]
    public const string SpinDirection = "4x00080";             // spindirection 4x0 0080
    [Description("increasespinangle 4x0 0081")]
    public const string IncreaseSpinAngle = "4x00081";         // increasespinangle 4x0 0081
    [Description("robotspinangle 4x0 0083")]
    public const string RobotSpinAngle = "4x00083";            // robotspinangle 4x0 0083
    [Description("globalspinangle 4x0 0085")]
    public const string GlobalSpinAngle = "4x00085";           // globalspinangle 4x0 0085

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
}