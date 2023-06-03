using System.ComponentModel;
using System.Reflection;

namespace MauiApp3.app.robot.my_enum;

public class BaseEnum: IType
{
    public virtual IEnumerable<FieldInfo> ReturnField()
    {
        return GetType().GetRuntimeFields();
    }

    public virtual Dictionary<string, FieldInfo> ReturnMapDesc()
    {
        return new Dictionary<string, FieldInfo>();
    }
    
}