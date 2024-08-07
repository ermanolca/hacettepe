using System.CodeDom.Compiler;

namespace Hacettepe.Application.Utils;

public static class RandomGenerator
{
    public static string Generate(int length = 8, bool lowerCase = true, bool upperCase = true, bool digit = true, bool nonAlphaNumeric = true)
    {
        var randomChars = new[] {
            "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
            "abcdefghijkmnopqrstuvwxyz",    // lowercase
            "0123456789",                   // digits
            "!@$?_-"                        // non-alphanumeric
        };
        Random random = new Random();
        var chars = new List<char>();

        if (upperCase)
            chars.Insert(random.Next(0, chars.Count),
                randomChars[0][random.Next(0, randomChars[0].Length)]);

        if (lowerCase)
            chars.Insert(random.Next(0, chars.Count),
                randomChars[1][random.Next(0, randomChars[1].Length)]);

        if (digit)
            chars.Insert(random.Next(0, chars.Count),
                randomChars[2][random.Next(0, randomChars[2].Length)]);

        if (nonAlphaNumeric)
            chars.Insert(random.Next(0, chars.Count),
                randomChars[3][random.Next(0, randomChars[3].Length)]);

        for (var i = chars.Count; i < length; i++)
        {
            var rcs = randomChars[random.Next(0, randomChars.Length)];
            chars.Insert(random.Next(0, chars.Count),
                rcs[random.Next(0, rcs.Length)]);
        }

        return new string(chars.ToArray());

    } 
}