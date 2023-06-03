using System.Reflection;

namespace MauiApp3.app.robot.my_enum;

public interface IType
{
    public IEnumerable<FieldInfo> ReturnField();

    public Dictionary<string, FieldInfo> ReturnMapDesc();

}