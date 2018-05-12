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
        private readonly ICollection<Variant> _variants;
        private int  _correct, _number;

        public Question()
        {
            _variants = new List<Variant>();
        }

        public Question(string questionText, int correct, params string[] variants)
        {
            if (string.IsNullOrEmpty(questionText) || correct <= 0 || correct > variants.Length || variants.Length <= 1)
                throw new ArgumentException("Check question params in config file");

            _questionText = questionText;
            _correct = correct;
            _variants = new List<Variant>();

            int i = 1;
            foreach (var variant in variants)
            {
                var v = new Variant();
                v.Number = i;
                v.Text = variant;

                _variants.Add(v);
            }
        }

        [JsonProperty] public string QuestionText { get; set; }

        [JsonProperty] public ICollection<Variant> Variants { get; set; }

        [JsonProperty] public int Correct { get; set; }

        [JsonProperty] public int Number { get; set; }
    }
}
