using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace TestDispenser.Model
{
    public class Variant
    {
        [JsonProperty] public int Number { get; set; }
        [JsonProperty] public string Text { get; set; }

        public Variant(int n, string text)
        {
            Number = n;
            Text = text;
        }
    }
}
