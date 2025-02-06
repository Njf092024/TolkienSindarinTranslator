using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class TranslateService
{
    private static readonly HttpClient httpClient = new HttpClient();
    private const string apiKey = "google api...";

    public async Task<string> TranslateText(string text, string sourceLang = "en", string targetLang = "fr")
    {
        string url = $"https://translation.googleapis.com/language/translate/v2?key={apiKey}";

        var requestBody = new
        {
            q = text,
            source = sourecLang,
            target = targetLang,
            format = "text"
        };
    }
}