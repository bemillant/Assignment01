using System.Text.RegularExpressions;

namespace Assignment1;

public static class RegExpr
{
    public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
    {

        //Can probably be done a lot prettier
        var patternWithSpace = @"[\d\w ]+";
        var patternWithoutSpace = @"[\d\w]+";

        foreach (var item in lines)
        {
            var matchWithoutSpace = Regex.Match(item, patternWithoutSpace);
            var matchWithSpace = Regex.Match(item, patternWithSpace);

            if (matchWithSpace.Success)
            {
                var tempArr = item.Split(" ");
                foreach (var word in tempArr)
                {
                    yield return word;
                }
            }
            else if (matchWithoutSpace.Success)
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<(int width, int height)> Resolution(IEnumerable<string> resolutions)
    {
        //Kunne ikke lige regne den helt ud, nogle idéer til fremgangsmåde er nedenunder:
        yield return (0, 0);
        // {
        //     var pattern = @"(?<first>[\d]+)x(?<second>[\d]+)*";
        //     var reg = new Regex(pattern);

        //     var allGroups = reg.GetGroupNames();

        //     foreach (var item in resolutions)
        //     {
        //         var match = reg.Match(item);
        //         foreach (var grp in allGroups)
        //         {
        //             var first = match.Groups["first"].Value;
        //             var second = match.Groups["second"].Value;
        //             Console.WriteLine(first + " " + second);
        //             yield return (int.Parse(first), int.Parse(second));
        //         }

        //     }


        //     // var patternWithoutSpace = @"(?<first>[\d]+)x(?<second>[\d]+)*";


        //     // foreach (var item in resolutions)
        //     // {
        //     //     var matchWithoutSpace = Regex.Match(item, patternWithoutSpace);


        //     //     if (matchWithoutSpace.Success)
        //     //     {
        //     //         if (item.Contains(" "))
        //     //         {
        //     //             var tempArr = item.Split(" ");

        //     //             foreach (var res in tempArr)
        //     //             {
        //     //                 res.Replace(",", "");
        //     //                 yield return (int.Parse(matchWithoutSpace.Groups["first"].Value), int.Parse(matchWithoutSpace.Groups["second"].Value));
        //     //                 Console.WriteLine(res);
        //     //             }
        //     //         }
        //     //         else
        //     //         {
        //     //             Console.WriteLine("aaaaa");
        //     //             yield return (int.Parse(matchWithoutSpace.Groups["first"].Value), int.Parse(matchWithoutSpace.Groups["second"].Value));
        //     //         }
        //     //     }
        //     // }


    }
    public static IEnumerable<string> InnerText(string html, string tag) => throw new NotImplementedException();
}