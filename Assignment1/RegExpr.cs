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
            foreach (var word in reg.Matches(item))
            {
                var wordy = word.ToString();
                yield return wordy;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {

        var pattern = @"(?<first>[\d]+)(?<eks>[x])(?<second>[\d]+)*";
        var reg = new Regex(pattern);
        foreach (var item in resolutions)
        {
            foreach (Match matches in reg.Matches(item))
            {
                var first = matches.Groups["first"].Value;
                var second = matches.Groups["second"].Value;
                yield return (int.Parse(first), int.Parse(second));
            }
        }

    }



    public static IEnumerable<string> InnerText(string html, string tag)
    {

        //Works with simple tags - not div and p and such. I think the regex needs to be changed.
        var matchesCol = Regex.Matches(html, @"(?<startEle><" + tag + @"(.*?)?>)(?<innerText>[\w \n]+)");

        //var pattern = @"(?<startEle><(?<start>\w+)(.*?)?)(?<innerText>[\w \n]+)(?<end><\/\k<start>>)";
        //var reg = new Regex(pattern);

        foreach (Match match in matchesCol)
        {
            if (match.Success)
            {
                Console.WriteLine(match.Groups["innerText"].Value);
                yield return match.Groups["innerText"].Value;
            }

        }
    }

    public static IEnumerable<(Uri url, string title)> Urls(string html)
    {
        var matchesCol = Regex.Matches(html, @"(?:href=[""'])(?<url>.*?)[""'].*?(?: title=[""'](?<title>.*?)[""'])?.*?>(?<innerText>.*?)<");

        foreach (Match match in matchesCol)
        {
            yield return match.Groups["title"].Success
            ? (new Uri(match.Groups["url"].Value), match.Groups["title"].Value)
            : (new Uri(match.Groups["url"].Value), match.Groups["innerText"].Value);
        }    
    }

}
