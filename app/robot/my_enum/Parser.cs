namespace MauiApp3.app.robot.my_enum;

public struct Register
{
    public int Type; // 寄存器类型
    public int Item;    // 寄存器号
}

public class RegisterType
{
    public const int HoldingRegisters = 4;            // 保持寄存器类型
    public const int InputRegisters  = 3;          // 输入寄存器类型
    public const int InputStatus = 2;               // 输入状态
    public const int DiscreteInputRegisters = 1;    // 离散输入寄存器
    public const int Coils = 0;                    
}

public class Parser
{
    public static Register ParseRegisterType(string key)
    {
        Register reg = new Register();
        reg.Item = int.Parse(key.Substring(key.Length - 3));
        switch (key[0])
        {
            case '0': reg.Type = RegisterType.Coils; break;
            case '1': reg.Type = RegisterType.DiscreteInputRegisters; break;
            case '3': reg.Type = RegisterType.InputRegisters; break;
            case '4': reg.Type = RegisterType.HoldingRegisters; break;
        }
        return reg;
    }
}

public class RobotInfo
{
    public string Name { get; set; }
    public object Value { get; set; }
}
