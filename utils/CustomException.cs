using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace controlAGV.utils;

public class CustomException:Exception
{
    public CustomException(string message) : base(message)
    {
        // DateTime dt = DateTime.Now;
        // Console.WriteLine($"New Exception({dt.ToString("yyyy年M月d日 HH点mm分ss秒")}): ");
    }

    public CustomException(string message, Exception innerException) : base(message, innerException)
    {
    }
}