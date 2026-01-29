using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.AI_service
{
    public class AICommandDetector
    {
        public enum CommandType
        {
            None,
            GetTexProducts,
            GetHouseholdProducts,
            GetRealEstateProducts
        }

        public CommandType DetectCommand(string userMessage)
        {
            userMessage = userMessage.ToLower();

            if (userMessage.Contains("tex") || userMessage.Contains("texnologiya"))
                return CommandType.GetTexProducts;

            if (userMessage.Contains("house") || userMessage.Contains("maishiy"))
                return CommandType.GetHouseholdProducts;

            if (userMessage.Contains("mulk") || userMessage.Contains("ko‘chmas"))
                return CommandType.GetRealEstateProducts;

            return CommandType.None;
        }
    }
}
