using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TestDispenser.Model
{
    public class QuestionParser
    {
        private static string _folderPath;
        private const string QNameRegex = @"[#]([1-9]+)[ ](\w+)[:]([1-9]+)";
        private const string VNameRegex = @"(\d+)[.][ ](\w+)";

        public QuestionParser(String physicalFolderPath)
        {
            _folderPath = physicalFolderPath;
        }

        public ICollection<Question> readQuestion(int number)
        {
            if (number <= 0)
                throw new ArgumentException("number");
            ICollection<Question> questions = new List<Question>();

            FileStream fileStream = new FileStream($"Test{number}.txt", FileMode.Open);

            using (StreamReader reader = new StreamReader(fileStream))
            {
                Question question = null;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    Debug.Assert(line != null, nameof(line) + " != null");

                    if (line.StartsWith("#"))
                    {
                        if (question != null)
                        {
                            questions.Add(question);
                        }
                        else
                        {
                            var regex = new Regex(QNameRegex, RegexOptions.IgnoreCase);
                            question = new Question();
                            var match = regex.Match(line);
                            question.Number = Convert.ToInt32(match.Groups[0].Value);
                            question.QuestionText = match.Groups[1].Value;
                            question.Correct = Convert.ToInt32(match.Groups[2].Value);
                        }
                    }
                    else
                    {
                        // Add variants
                        var match = new Regex(VNameRegex).Match(line);
                        Debug.Assert(question != null, nameof(question) + " != null");

                        question.Variants.Add(new Variant(Convert.ToInt32(match.Groups[0].Value), match.Groups[1].Value));
                    }
                }
            }

            return questions;
        }
    }
}
