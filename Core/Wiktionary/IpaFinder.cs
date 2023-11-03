namespace PinyinCardApi.Core.Wiktionary;

using HtmlAgilityPack;

public class IpaFinder
{
    protected string FindWiktionary(string language, string word)
    {
        var url = $"https://{language}.wiktionary.org/wiki/{word.ToLower().Replace(" ", "_")}";
        var web = new HtmlWeb();
        var doc = web.Load(url);
        var elements = doc.DocumentNode.SelectNodes("//span[@class='IPA']");
        var IPA = "";

        if (elements != null)
        {
            IPA = elements[0].InnerText.Replace("/", string.Empty);
        }

        return IPA;
    }

    public string Find(string language, string word)
    {
        var IPA = this.FindWiktionary(language, word);
        if (IPA == "")
        {
            var words = word.Split(" ");

            foreach (string w in words)
            {
                var tmpIPA = this.FindWiktionary(language, w);
                if (tmpIPA == "")
                {
                    IPA = "";
                    break;
                }

                IPA += $" {tmpIPA}";
            }
        }

        return IPA.Trim();
    }
}
