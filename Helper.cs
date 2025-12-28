using System;
using System.Linq;

public static class Helper
{
    private static Random random = new Random();

    public static string GenerateUsername(int length)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(
            Enumerable.Repeat(chars, length)
                      .Select(s => s[random.Next(s.Length)])
                      .ToArray());
    }

    public static Role RandomRole()
    {
        var roles = Enum.GetValues(typeof(Role));
        return (Role)roles.GetValue(random.Next(roles.Length));
    }

    public static int RandomDurationMinutes()
    {
        return random.Next(20, 46);
    }

    public static Side RandomSide()
    {
        return random.NextDouble() < 0.5 ? Side.Hero : Side.Villain;
    }

    public static int RandomNetworth()
    {
        return random.Next(5000, 50001);
    }

    public static int RandomKDA(int max = 15)
    {
        return random.Next(0, max + 1);
    }
}
