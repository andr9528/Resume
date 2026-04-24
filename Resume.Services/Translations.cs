using System.Collections.Generic;
using System.Text;

namespace Resume.Services;

public static partial class Translations
{
    private static Dictionary<string, string> Merge(params Dictionary<string, string>[] dictionaries)
    {
        var result = new Dictionary<string, string>();

        foreach (var dictionary in dictionaries)
        {
            foreach (var pair in dictionary)
            {
                result[pair.Key] = pair.Value;
            }
        }

        return result;
    }

    private static string Paragraphs(params string[] paragraphs)
    {
        var sb = new StringBuilder();

        for (var i = 0; i < paragraphs.Length; i++)
        {
            if (i > 0)
            {
                sb.AppendLine();
                sb.AppendLine();
            }

            sb.Append(paragraphs[i].Trim());
        }

        return sb.ToString();
    }
}
