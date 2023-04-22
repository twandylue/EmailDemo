using System.Reflection;

namespace EmailSender;

public static class Usage
{
    public static void Print()
    {
        var program = Assembly.GetExecutingAssembly().Location;

        Console.WriteLine($"Usage: {program} [Account] [Password] <Attachment>");
    }
}