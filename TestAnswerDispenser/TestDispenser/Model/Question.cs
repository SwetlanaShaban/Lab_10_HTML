using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestDispenser.Model
{
    public class Question
    {
        private readonly string _questionText;
        private readonly IDictionary<int, string> _variants;
        private readonly int _correct;

        public Question(string questionText, int correct, params string[] variants)
        {
            if (string.IsNullOrEmpty(questionText) || correct <= 0 || correct > variants.Length || variants.Length <= 1)
                throw new ArgumentException("Check question params in config file");

            _questionText = questionText;
            _correct = correct;
            _variants = new Dictionary<int, string>();

            int i = 1;
            foreach (var variant in variants)
            {
                _variants.Add(i++, variant);
            }
        }

        [JsonProperty]
        private string QuestionText => _questionText;

        [JsonProperty]
        private IDictionary<int, string> Variants => _variants;

        [JsonProperty]
        private int Correct => _correct;
    }
}
