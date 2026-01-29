using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinFormsApp1.Services;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;

namespace WinFormsApp1.AI_service
{
    public class ChatAIService
    {
        private readonly AIConfig _config;
        private readonly ProductTexService _texService;
        private readonly ProductEEService _houseService;
        private readonly ProductREService _reService;
        private readonly AICommandDetector _detector;

        public ChatAIService(
            AIConfig config,
            ProductTexService texService,
            ProductEEService houseService,
            ProductREService reService)
        {
            _config = config;
            _texService = texService;
            _houseService = houseService;
            _reService = reService;
            _detector = new AICommandDetector();
        }

        public async Task<string?> AskAsync(string userMessage)
        {
            // Foydalanuvchi xabarini tahlil qilish
            var command = _detector.DetectCommand(userMessage);
            string finalPrompt = userMessage;

            switch (command)
            {
                case AICommandDetector.CommandType.GetTexProducts:
                    var tex = _texService.GetProductTexAll();
                    if (tex != null && tex.Count > 0)
                        finalPrompt = AIPromptBuilder.BuildProductListPrompt(userMessage, tex);
                    break;

                case AICommandDetector.CommandType.GetHouseholdProducts:
                    var hh = _houseService.GetProductEEAll();
                    if (hh != null && hh.Count > 0)
                        finalPrompt = AIPromptBuilder.BuildProductListPrompt(userMessage, hh);
                    break;

                case AICommandDetector.CommandType.GetRealEstateProducts:
                    var re = _reService.GetProductREAll();
                    if (re != null && re.Count > 0)
                        finalPrompt = AIPromptBuilder.BuildProductListPrompt(userMessage, re);
                    break;
            }

            try
            {
                // Use direct HTTP call to OpenAI REST API instead of SDK types that differ by version
                var baseUrl = "url";
                using var http = new System.Net.Http.HttpClient { BaseAddress = new Uri(baseUrl) };
                http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _config.ApiKey);

                var payload = new
                {
                    model = _config.Model,
                    messages = new[]
                    {
                        new { role = "system", content = "Siz managerlar uchun yordamchi suniy intelektsiz. O'zbek tilida qisqa va aniq javob bering." },
                        new { role = "user", content = finalPrompt }
                    }
                };

                var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
                var response = await http.PostAsync("/v1/chat/completions", content);
                var responseText = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    return $"Xato yuz berdi: HTTP {(int)response.StatusCode} - {responseText}";

                using var doc = JsonDocument.Parse(responseText);
                if (doc.RootElement.TryGetProperty("choices", out var choices) &&
                    choices.GetArrayLength() > 0 &&
                    choices[0].TryGetProperty("message", out var message) &&
                    message.TryGetProperty("content", out var msgContent))
                {
                    return msgContent.GetString();
                }

                return "Xato: OpenAI javobidan kutilgan maydon topilmadi.";
            }
            catch (Exception ex)
            {
                return $"Xato yuz berdi: {ex.Message}\n{ex}";
            }
        }
    }
}





