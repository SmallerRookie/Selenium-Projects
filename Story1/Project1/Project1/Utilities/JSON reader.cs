using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Project1.Utilities
{
    public class JSON_reader
    {
        public string ExtractData(string tokenName)
        {
            string jsonData = File.ReadAllText("Utilities/Testing Data.json");
            JToken jsonObject =  JToken.Parse(jsonData);
            return jsonObject.SelectToken(tokenName).Value<string>();
        }
    }
}
