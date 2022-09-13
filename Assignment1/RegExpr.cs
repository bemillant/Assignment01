using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {
        var pattern = @"[\d\w]+";
        var reg = new Regex(pattern);

        foreach (var item in lines)
        {
                foreach (var word in reg.Matches(item)){
                    var wordy = word.ToString();
                    yield return wordy;
                }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        {
            var pattern = @"(?<first>[\d]+)(?<eks>[x])(?<second>[\d]+)*";
            var reg = new Regex(pattern);
            foreach (var item in resolutions)
            {
                var amountOfMatches = reg.Matches(item).Count;
                foreach (Match matches in reg.Matches(item)){
                var first = matches.Groups["first"].Value;
                var second = matches.Groups["second"].Value;
                yield return (int.Parse(first), int.Parse(second));
                }
                }
            }



    }
    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
    
    }
