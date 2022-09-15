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

         var pattern = $@"<(?<start>[{tag}]+)[^>]*>(?<innerText>.*?)(?<end><\/\k<start>>)";
         var regInput = new Regex(pattern);
        
         var replacePattern =  $@"<(/|())(?<start>[a-z]+)(?<innerText>.*?)(?<end>>)";
         var regDeletion = new Regex(replacePattern);
        
        foreach (Match match in regInput.Matches(html))
        {
            if (match.Success)
            {
                String matchResult = match.Groups["innerText"].Value;
                Regex.Replace(matchResult,"<(/|())(?<start>[a-z]+)(?<innerText>.*?)(?<end>>)", "");
                Console.WriteLine(match.Groups["innerText"].Value);
                yield return Regex.Replace(matchResult,"<(/|())(?<start>[a-z]+)(?<innerText>.*?)(?<end>>)", "");
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
