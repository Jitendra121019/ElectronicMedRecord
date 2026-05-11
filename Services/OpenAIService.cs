using Google.GenAI;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ElectronicMedRecord.Services
{
    public class OpenAIService
    {
        private readonly IConfiguration _configuration;

        private readonly HttpClient _httpClient;

        private const string API_KEY = "AIzaSyA09Dh_m5p9-hji050egg87UtEhhsy_WKU";

        public OpenAIService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient = new HttpClient();
        }

        public async Task<string> GetSuggestion(string text)
        {
            string Str = "?";
            if (text.Length > 15)
            {
                var apiKey = "AIzaSyAlcW1OUfSF4t9_kDAplzKnGca9sMyCDFc";
                var client = new Client(apiKey: apiKey);

                string originalText = text;
                string rewriteInstruction = "Re-write profesionnaly - ";
                
                try
                {
                    // 3. Call the model (e.g., gemini-2.5-flash)
                    var response = await client.Models.GenerateContentAsync(
                        model: "gemini-2.5-flash",
                        contents: $"{rewriteInstruction}\n\nText: {originalText}"
                    );

                    // 4. Output the rewritten content
                    Console.WriteLine("Rewritten Text:");
                    Console.WriteLine(response.Candidates[0].Content.Parts[0].Text);
                    Str = response.Candidates[0].Content.Parts[0].Text;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return Str;
        }


    }
}
