using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Hacettepe.Application.Utils;

public static class SlugUtil
{
    static readonly Regex RegStripNonAlpha = new Regex(@"[^\w\s\-]+", RegexOptions.Compiled);
    static readonly Regex RegSpaceToDash = new Regex(@"[\s]+", RegexOptions.Compiled);
    
    public static string Slugify(string title)
    {
        var spaceRemoved = RegSpaceToDash.Replace(RegStripNonAlpha.Replace(title, string.Empty).Trim(), "-");
        return string.Join("", spaceRemoved.Normalize(NormalizationForm.FormD)
            .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
            .Replace("ı", "i");
    }
}