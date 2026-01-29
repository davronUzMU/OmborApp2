using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormsApp1.AI_service
{
    public class AIPromptBuilder
    {
        public static string BuildProductListPrompt(string question, IEnumerable<object> list)
        {
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });

            return $@"
Foydalanuvchi savoli: {question}

Quyida managerning ushbu savoliga tegishli ma’lumotlar keltirilgan:

{json}

Managerga oddiy, aniq va tushunarli tarzda javob bering.";
        }
    }
}
