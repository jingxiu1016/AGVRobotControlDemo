using System.ComponentModel;
using System.Net.Sockets;
using System.Reflection;
using System.Text.RegularExpressions;
using controlAGV.utils;
using MauiApp3.app.robot.my_enum;
using MauiApp3.Shared;
using System.Threading;
using EasyModbus;

namespace MauiApp3.app.robot;

public class AgvRobot
{
    // ---- 机器人 连接属性
    private string _name = "agv-300-rmd";  // 机器人名称
    public string Ip = "192.168.1.128";     // 机器人连接ip
    public int Port=502;      // 机器人连接端口
    public bool Status;           // 机器人连接状态
    public int RefreshRate = 1000;       // 机器人数据刷新频率
    private ModbusClient? _client; 
    
    public AgvStatus1 S1;
    public AgvStatus2 S2;
    public AgvCommand1 C1 ;
    public AgvCommand2 C2 ;

    public int[] HoldingRegisters=new int[100];
    public int[] InputRegisters=new int[100];
    public bool[] Coils=new bool[100];
    public bool[] DiscreteInputRegisters=new bool[100];

    // // ---- 机器人 设备状态属性
    // // 状态1 
    // public int X{get;set;}                             // 机器人x坐标 3x0 0001
    // public int Y{get;set;}                             // 机器人y坐标 3x0 0003
    // public int Angle{get;set;}                     // 机器人角度坐标 3x0 0005
    // public int CurrentNavigationSite{get;set;}         // 机器人当前导航站点 3x0 0007
    // public int LocationState{get;set;}                 // 机器人当前定位状态 3x0 0008
    // public int CurrentNavigationState{get;set;}        // 机器人当前导航状态 3x0 0009
    // public int CurrentNavigationType{get;set;}         // 机器人当前导航类型 3x0 00010
    // public int LocationConfidenceCoefficient{get;set;} // 机器人定位置信度 3x0 0011
    //
    // public int BatteryCapacity{get;set;}   // 电量 3x0 00013
    // public int BatteryTemperate{get;set;}  // 电池温度 3x0 00015
    // public int BatteryVoltage{get;set;}    // 电池电压 3x0 00017
    // public int BatteryCurrent{get;set;}    // 电池电流 3x0 00019
    //
    // public int ControllerTemperate{get;set;}   // 控制器温度 3x0 0021
    // public int ControllerHumidity{get;set;}    // 控制器适度 3x0 0023
    // public int ControllerVoltage{get;set;}     // 控制器电压 3x0 0025
    //
    // public int TotalMileage{get;set;}  // 总里程 3x0 0027
    // public int RunningTime{get;set;}       // 累计运行时间 3x0 0029
    //
    // public int Fatal{get;set;}     // fatal 错误码 3x0 0031
    // public int Error{get;set;}     // error 错误发 3x0 0032
    // public int Warning{get;set;}   // warning 错误码 3x0 0033
    //
    // public int NowSite{get;set;}       // 机器人当前所在站点 3x0 0034
    // public int LastSite{get;set;}      // 机器人上一个所在站点 3x0 0035
    // public int NextSite{get;set;}      // 机器人下一个要经过的站点 3x0 0036
    //
    // public int MajorVersion{get;set;}              // Major 版本号 3x0 0037
    // public int MinorVersion{get;set;}              // Minor 版本号 3x0 0038
    // public int PatchVersion{get;set;}              // Patch 版本号 3x0 0039
    // public int RedistributeVersion{get;set;}       // Redistribute 版本号 3x0 0040
    // public int MapName{get;set;}                   // 当前地图名 3x0 0041
    // public int LoadMapState{get;set;}              // 当前地图载人状态 3x0 0042
    // public int ShecudlingState{get;set;}           // 机器人调度状态 3x0 0043
    // public int BlockCause{get;set;}                // 被阻挡的原因 3x0 0044
    // public int BlockUltrasoundId{get;set;}         // 发生阻挡的超声ID号 3x0 0045
    // public int BlockDiid{get;set;}                 // 发生阻挡的DI的ID号 3x0 0046
    // public int BlockX{get;set;}                // 阻挡位置的x坐标 3x0 0047
    //
    // public int BlockY{get;set;}                // 阻挡位置的Y坐标 3x0 0049
    // public int VX{get;set;}                    // 机器人的vx速度 3x0 0051
    // public int VY{get;set;}                    // 机器人的vy速度 3x0 0053
    // public int Palstance{get;set;}             // 机器人的角速度 3x0 0055
    // public int CargoFork{get;set;}             // 货叉高度  3x0 0057
    // public int HelmAngle{get;set;}             // 机器人舵角 3x0 0059
    // public int JackingMechanismState{get;set;}     // 顶升机构状态 3x0 0061
    // public int RollerBarrelState{get;set;}         // 锟筒（皮带）状态 3x0 0062
    // public int JackingCurrentHigh{get;set;}    // 顶升机实时高度 3x0 0064
    // public int JackingError{get;set;}          // 顶升机错误码 3x0 0065
    // public int RollerBarrelError{get;set;}     // 锟筒（皮带）错误码 3x0 0066
    //
    // public int RfidId{get;set;}              // RFID ID 3x0 0069
    // public int Ip1{get;set;}                 // IP1 3x0 0070
    // public int Ip2{get;set;}                 // IP2 3x0 0071
    // public int Ip3{get;set;}                 // IP3 3x0 0072
    // public int Ip4{get;set;}                 // IP4 3x0 0073
    //
    // public int TodayTotalMileage{get;set;}         // 今日总里程 3x0 0081
    // public int CurrentSrcModel{get;set;}               // 当前src模式 3x0 0083
    // public int SlowDown{get;set;}                      // 机器人减速原因 3x0 0084
    //
    // public int PalletAngle{get;set;}              // 托盘角度 3x0 0089
    // public int HelmAngleInfo1{get;set;}           // 舵角信息1 3x0 0091
    // public int HelmAngleInfo2{get;set;}           // 舵角信息2 3x0 0093
    // public int HelmAngleInfo3{get;set;}           // 舵角信息3 3x0 0095
    // public int HelmAngleInfo4{get;set;}           // 舵角信息4 3x0 0097 
    //
    // // 状态2
    // public bool IsSlowDown{get;set;}                // 是否减速 1x0 0001
    // public bool IsBlock{get;set;}                   // 是否被阻挡 1x0 0002
    // public bool IsCharge{get;set;}                  // 是否在充电 1x0 0003
    // public bool IsEmergencyStop{get;set;}           // 是否急停 1x0 0004
    // public bool IsLockBrake{get;set;}               // 是否抱闸 1x0 0005
    // public bool IsForkInPlace{get;set;}            // 货叉是否到位 1x0 0006
    // public bool CargoForkCtrlModel{get;set;}        // 叉车的控制模式 1x0 0007
    // public bool IsFatal{get;set;}                   // 是否有fatal 1x0 0008
    // public bool IsError{get;set;}                   // 是否有Error 1x0 009
    // public bool IsWarning{get;set;}                 // 是否有warning 1x0 0010
    // public bool IsJackingStart{get;set;}            // 顶升机构是否启用 1x0 0011
    // public bool IsJackingStop{get;set;}             // 顶升机构是否急停 1x0 0012
    // public bool IsJackingHaveMeterial{get;set;}     // 顶升机构是否有料 1x0 0013
    // public bool IsRollerBarrelStart{get;set;}       // 锟筒（皮带）是否启用 1x0 0014
    // public bool IsRollerBarrelStop{get;set;}        // 锟筒（皮带）是否急停 1x0 0015
    // public bool IsRollerBarrelHaveMeterial{get;set;}// 锟筒（皮带）是否有料 1x0 0016
    // public bool IsChassisStationary{get;set;}       // 底盘是否静止 1x0 0019
    // public bool Di0{get;set;}                       // DI 0 1x0 0020
    // public bool Di1{get;set;}                       // DI 1 1x0 0021
    // public bool Di2{get;set;}                       // DI 2 1x0 0022
    // public bool Di3{get;set;}                       // DI 3 1x0 0023
    // public bool Di4{get;set;}                       // DI 4 1x0 0024
    // public bool Di5{get;set;}                       // DI 5 1x0 0025
    // public bool Di6{get;set;}                       // DI 6 1x0 0026
    // public bool Di7{get;set;}                       // DI 7 1x0 0027
    // public bool Di8{get;set;}                       // DI 8 1x0 0028
    // public bool Di9{get;set;}                       // DI 9 1x0 0029
    // public bool Di10{get;set;}                      // DI 10 1x0 0030
    // public bool Di11{get;set;}                      // DI 11 1x0 0031
    // public bool Di12{get;set;}                      // DI 12 1x0 0032
    // public bool Di13{get;set;}                      // DI 13 1x0 0033
    // public bool Di14{get;set;}                      // DI 14 1x0 0034
    // public bool Di15{get;set;}                      // DI 15 1x0 0035
    // public bool Do0{get;set;}                       // DO 0 1x0 0060
    // public bool Do1{get;set;}                       // DO 1 1x0 0061
    // public bool Do2{get;set;}                       // DO 2 1x0 0062
    // public bool Do3{get;set;}                       // DO 3 1x0 0063
    // public bool Do4{get;set;}                       // DO 4 1x0 0064
    // public bool Do5{get;set;}                       // DO 5 1x0 0065
    // public bool Do6{get;set;}                       // DO 6 1x0 0066
    // public bool Do7{get;set;}                       // DO 7 1x0 0067
    // public bool Do8{get;set;}                       // DO 8 1x0 0068
    // public bool Do9{get;set;}                       // DO 9 1x0 0069
    // public bool Do10{get;set;}                      // DO 10 1x0 0070
    // public bool Do11{get;set;}                      // DO 11 1x0 0071
    // public bool Do12{get;set;}                      // DO 12 1x0 0072
    // public bool Do13{get;set;}                      // DO 13 1x0 0073
    // public bool Do14{get;set;}                      // DO 14 1x0 0074
    // public bool Do15{get;set;}                      // DO 15 1x0 0075
    //
    // // 机器人命令功能属性
    // // 命令1
    // public int PathToTargetSize{get;set;}          // 让机器人以路径导航去目标站点 4x0 0001
    // public int SetVxSpeed{get;set;}            // 开环下发机器人vx速度 4x0 0005
    // public int SetVySpeed{get;set;}            // 开环下发机器人vy速度 4x0 0007
    // public int SetAngleSpeed{get;set;}         // 开环下发机器人角速度 4x0 0009
    // public int SetHelmAngle{get;set;}          // 开环下发机器人舵角 4x0 0011
    // public int SetCargoForkHigh{get;set;}      // 设置货叉高度 4x0 0013
    // public int SetXTranslation{get;set;}       // X方向直线运动（平动） 4x0 0015
    // public int SetYTranslation{get;set;}       // Y方向直线运动（平动） 4x0 0017
    // public int SetRotation{get;set;}           // 转动 4x0 0019
    // public int SetXTransSpeed{get;set;}        // x方向直线运动速度 4x0 0022
    // public int SetYTransSpeed{get;set;}        // Y方向直线运动速度 4x0 0022
    // public int SetRotationSpeed{get;set;}      // 转动角速度 4x0 0026
    // public int SetTransOrRotation{get;set;}         // 平动、转动的模式 4x0 0028
    // public int SetMap{get;set;}                    // 切换地图 4x0 0029
    // public int SetAudio{get;set;}                  // 播放音频 4x0 0030
    // public int RunStoredTaskChain{get;set;}        // 执行预存的任务连 4x0 0031
    // public int SetShelfDescFile{get;set;}          // 设置货架描述文件 4x0 0032
    // public int ClearShelfDescFile{get;set;}        // 清楚货架描述文件 4x0 0033
    //
    // public int SetJackingUp{get;set;}              // 顶升机构上升 4x0 0050
    // public int SetJackingDown{get;set;}            // 顶升机构下降 4x0 0051
    // public int SetJackingStop{get;set;}            // 顶升机构停止 4x0 0052
    // public int SetJackingFixed{get;set;}           // 顶升机构定稿 4x0 0053
    // public int TractionLoading{get;set;}           // 牵引上料 4x0 0054
    // public int TractionBlanking{get;set;}          // 牵引下料 4x0 0055
    // public int SrcCtrlModel{get;set;}              // SRC 控制模式 4x0 0056
    // public int SrcListenModel{get;set;}            // SRC 监听模式 4x0 0057
    // public int SetDiUse{get;set;}                  // DI 设置可用 4x0 0061
    // public int SetDiUnUser{get;set;}               // DI 设置禁用 4x0 0062
    // public int SetVirtualDiHigh{get;set;}          // Virtual DI设置为高电平 4x0 0063
    // public int SetVirtualDiLow{get;set;}           // Virtual DI设置为低电平 4x0 0064
    // public int MotorMarkZero{get;set;}             // 电机标零 4x0 0065
    // public int CargoForkTrans{get;set;}            // 设置货叉迁移后退 4x0 0071
    // public int SpinDirection{get;set;}             // spin_direction 4x0 0080
    // public int IncreaseSpinAngle{get;set;}         // increase_spin_angle 4x0 0081
    // public int RobotSpinAngle{get;set;}            // robot_spin_angle 4x0 0083
    // public int GlobalSpinAngle{get;set;}           // global_spin_angle 4x0 0085
    //
    // // 命令2
    // public int InHomeRelocation{get;set;}          // 在home点重定位 0x0 0002
    // public int ConfirmLocationRight{get;set;}      // 确认定位正确 0x0 0003
    // public int PauseNavigation{get;set;}           // 暂停导航 0x0 0004
    // public int ContinueNavigation{get;set;}         // 继续导航 0x0 0005
    // public int CancelNavigation{get;set;}          // 取消导航 0x0 0006
    // public int RecycleCtrl{get;set;}               // 回收控制权 0x0 0010
    // public int ReleaseCtrl{get;set;}               // 释放控制器 0x0 0011
    // public int RollerBarrelLeftBeforeLoading{get;set;}// 锟筒（皮带）左侧预上料 0x0 0012
    // public int RollerBarrelRightBeforeLoading{get;set;}// 锟筒（皮带）右侧预上料 0x0 0013
    // public int RollerBarrelLeftLoading{get;set;}    // 锟筒（皮带）左侧上料 0x0 0015
    // public int RollerBarrelLeftBlanking{get;set;}  // 锟筒（皮带）左侧下料 0x0 0016
    // public int RollerBarrelRightLoading{get;set;}   // 锟筒（皮带）右侧上料 0x0 0017
    // public int RollerBarrelRightBlanking{get;set;} // 锟筒（皮带）右侧下料 0x0 0018
    // public int RollerBarrelSop{get;set;}           // 锟筒（皮带）停止 0x0 0019
    // public int Do0ToLow{get;set;}                  // DO 0置为低电平 0x0 0020
    // public int Do1ToLow{get;set;}                  // DO 1置为低电平 0x0 0021
    // public int Do2ToLow{get;set;}                  // DO 2置为低电平 0x0 0022
    // public int Do3ToLow{get;set;}                  // DO 3置为低电平 0x0 0023
    // public int Do4ToLow{get;set;}                  // DO 4置为低电平 0x0 0024
    // public int Do5ToLow{get;set;}                  // DO 5置为低电平 0x0 0025
    // public int Do6ToLow{get;set;}                  // DO 6置为低电平 0x0 0026
    // public int Do7ToLow{get;set;}                  // DO 7置为低电平 0x0 0027
    // public int Do8ToLow{get;set;}                  // DO 8置为低电平 0x0 0028
    // public int Do9ToLow{get;set;}                  // DO 9置为低电平 0x0 0029
    // public int Do10ToLow{get;set;}                 // DO 10置为低电平 0x0 0030
    // public int Do11ToLow{get;set;}                 // DO 11置为低电平 0x0 0031
    // public int Do12ToLow{get;set;}                 // DO 12置为低电平 0x0 0032
    // public int Do13ToLow{get;set;}                 // DO 13置为低电平 0x0 0033
    // public int Do14ToLow{get;set;}                 // DO 14置为低电平 0x0 0034
    // public int Do15ToLow{get;set;}                 // DO 15置为低电平 0x0 0035
    //
    // public int Do0ToHigh{get;set;}                  // DO 0置为高电平 0x0 0060
    // public int Do1ToHigh{get;set;}                  // DO 1置为高电平 0x0 0061
    // public int Do2ToHigh{get;set;}                  // DO 2置为高电平 0x0 0062
    // public int Do3ToHigh{get;set;}                  // DO 3置为高电平 0x0 0063
    // public int Do4ToHigh{get;set;}                  // DO 4置为高电平 0x0 0064
    // public int Do5ToHigh{get;set;}                  // DO 5置为高电平 0x0 0065
    // public int Do6ToHigh{get;set;}                  // DO 6置为高电平 0x0 0066
    // public int Do7ToHigh{get;set;}                  // DO 7置为高电平 0x0 0067
    // public int Do8ToHigh{get;set;}                  // DO 8置为高电平 0x0 0068
    // public int Do9ToHigh{get;set;}                  // DO 9置为高电平 0x0 0069
    // public int Do10ToHigh{get;set;}                 // DO 10置为高电平 0x0 0070
    // public int Do11ToHigh{get;set;}                 // DO 11置为高电平 0x0 0071
    // public int Do12ToHigh{get;set;}                 // DO 12置为高电平 0x0 0072
    // public int Do13ToHigh{get;set;}                 // DO 13置为高电平 0x0 0073
    // public int Do14ToHigh{get;set;}                 // DO 14置为高电平 0x0 0074
    // public int Do15ToHigh{get;set;}                 // DO 15置为高电平 0x0 0075
    //
    public AgvRobot()
    {
        _client = new ModbusClient();
        // _client.SendDataChanged += new ModbusClient.SendDataChangedHandler();
    }

    // // 未连接
    // public AgvRobot(string name, string ip, int port,int refresh)
    // => (_name, Ip, Port, Status, _client, RefreshRate)
    //         = (name, ip, port, false, new ModbusClient(), refresh);

    public ModbusClient GetClient()
    {
        return _client ??= new ModbusClient();
        // return _client ??= GetIpMaster();
    }

    public bool Connect(string name, string ip, int port,int refresh = 500)
    {
        _name = name;
        Ip = ip;
        Port = port;
        RefreshRate = refresh;
        try
        {
            GetClient()?.Connect(Ip, Port);
            Console.WriteLine($"Robot {_name} successful connection!!!");
            Status = true;
        }catch (Exception e) {
            Console.WriteLine($"Robot {_name} failed connection!!!");
            Console.WriteLine(e); 
            Status = false;
            throw;
        }
        return Status;
    }

    public IType CurrentType;
    public List<RobotInfo> Infos = new List<RobotInfo>();
    public List<RobotInfo> PrintInfo(IType type)
    {
        if (!Status || _client == null)
        {
            return Infos;
        }
        CurrentType = type;
       refreshInfos(null);
       return Infos;
    }

    private void refreshInfos(object state)
    {
        Infos.Clear();
        if (!ReadInfo())
        {
            return;
        }
        var list = CurrentType.ReturnField().ToList();
        for(int i = 0; i < list.Count; i++)
        {
            var item = list[i];
            var desc = item.GetCustomAttribute<DescriptionAttribute>()?.Description;
            var key = item.GetValue(this);
            var pattern = @"^[0134]x\d{5}$";
            if (key == null || !Regex.IsMatch(key?.ToString(), pattern)){continue;}
            var reg = Parser.ParseRegisterType(key?.ToString() ?? string.Empty);
            object value = new();
            FieldInfo nextItem = null;
            int span = 0;
            if (i + 1 < list.Count)
            {
                nextItem = list[i + 1];
            }
            if (nextItem != null)
            {
                key = nextItem.GetValue(CurrentType);
                if (key == null || !Regex.IsMatch(key?.ToString(), pattern)){continue;}
                var nextReg = Parser.ParseRegisterType(key?.ToString() ?? string.Empty);
                span = nextReg.Item - reg.Item;
            }
            int index = reg.Item - 1;
            switch (reg.Type)
            {
                case RegisterType.HoldingRegisters:
                    if (span != 1 && span != 0)
                    {
                        value = Convert(span, HoldingRegisters.Skip(index).Take(span).ToArray());
                    }
                    else
                    {
                        value = HoldingRegisters[index];
                    }
                    break;
                case RegisterType.InputRegisters:
                    if (span != 1&& span != 0)
                    {
                        value = Convert(span, InputRegisters.Skip(index).Take(span).ToArray());
                    }
                    else
                    {
                        value = InputRegisters[index];
                    }
                    break;
                case RegisterType.Coils:
                    value = Coils[index];
                    break;
                case RegisterType.DiscreteInputRegisters:
                    value = DiscreteInputRegisters[index];
                    break;
            }
            if (desc != null) Infos.Add(new RobotInfo
            {
                Name = desc,
                Value = value
            });
        }
    }

    private object Convert(int span,int[] addr)
    {
        return span switch
        {
            1 => addr[0],
            2 => ModbusClient.ConvertRegistersToFloat(addr),
            4 => ModbusClient.ConvertRegistersToDouble(addr),
            _ => null
        };
    }

    public async Task<bool> ConnectAsync()
    {
        try
        {
            await Task.Run(() =>
            {
                try
                {
                    GetClient()?.Connect(Ip, Port);
                    Console.WriteLine($"Robot {_name} successful connection!!!");
                    Status = true;
                }catch (Exception e) {
                    Console.WriteLine($"Robot {_name} failed connection!!!");
                    Console.WriteLine(e); 
                    Status = false;
                }
            });
            return Status;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Status = false;
            throw;
        }
    }

    public void DisConnect()
    {
        GetClient().Disconnect();
        Status = false;
    }
    public List<TabComponent.TabItem> Tabs()
    {
        List<TabComponent.TabItem> tabs = new List<TabComponent.TabItem>
        {
            new ()
            {
                Title = "状态1",
                Content = S1??= new AgvStatus1(),
                IsActive =true,
            },
            new ()
            {
                Title = "状态2",
                Content = S2 ??= new AgvStatus2(),
                IsActive =false,
            },
            new ()
            {
                Title = "状态3",
                Content = C1 ??=new AgvCommand1(),
                IsActive =false,
            },
            new ()
            {
                Title = "状态4",
                Content = C2 ??=new AgvCommand2(),
                IsActive =false,
            },
        };
        return tabs;
    }

    // 读取每个寄存器的100个地址范围
    public bool ReadInfo()
    {
        if (!Status || _client == null)
        {
            return false;
        }
        try
        {
            HoldingRegisters = _client?.ReadHoldingRegisters(0, 100);
            InputRegisters = _client?.ReadInputRegisters(0, 100);
            Coils = _client?.ReadCoils(0, 100);
            DiscreteInputRegisters= _client?.ReadDiscreteInputs(0, 100);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
        return true;
    }

    public object ReadInfoByType(Register reg,int span)
    {
        switch (reg.Type)
        {
            case RegisterType.InputRegisters:
                var res = _client?.ReadInputRegisters(reg.Item-1, span);
                return Convert(span, res);
            case RegisterType.DiscreteInputRegisters:
                var data = _client?.ReadDiscreteInputs(reg.Item-1, 1);
                return data != null && data[0];
        }
        return null;
    }
    public bool CheckCorrectPosition()
    {
        Register reg = Parser.ParseRegisterType(AgvCommand2.ConfirmLocationRight);
        return Operate(reg.Item,true);
    }

    // 回收控制权
    public bool RecycleCtrl()
    {
        Register reg = Parser.ParseRegisterType(AgvCommand2.RecycleCtrl);
        return Operate(reg.Item, true);
    }
    
    // 释放控制权
    public bool ReleaseCtrl()
    {
        Register reg = Parser.ParseRegisterType(AgvCommand2.ReleaseCtrl);
        return Operate(reg.Item, true);
    }

    public int ConfirmCorrectNavigation()
    {
        Register reg = Parser.ParseRegisterType(AgvStatus1.CurrentNavigationState);
        return (int)ReadInfoByType(reg, 1);
    }
    
    // 路径导航去站点
    public bool PathNavigationToSite(int site)
    {

        if (!CheckCorrectPosition())
        {
            return false;
        }

        Register reg = Parser.ParseRegisterType(AgvCommand1.PathToTargetSize);
        if (!Operate(reg.Item, site))
        {
            return false;
        }

        if (ConfirmCorrectNavigation() != 4)
        {
            return false;
        }

        return true;
    }

    public bool Operate(int addr, int value)
    {
        try
        {
            _client?.WriteSingleRegister(addr-1,value);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public bool Operate(int addr, int[] values)
    {
        try
        {
            _client?.WriteMultipleRegisters(addr-1,values);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public bool Operate(int addr,bool value)
    {
        try
        {
            _client?.WriteSingleCoil(addr-1,value);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw;
            return false;
        }
    }

    public bool Operate(int addr,bool[] values)
    {
        try
        {
            _client?.WriteMultipleCoils(addr-1,values);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // throw;
            return false;
        }
    }
} 