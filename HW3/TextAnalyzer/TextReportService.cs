using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalyzer
{
    public class TextReportService
    {
        public async Task<string> NumberOfSentences(string text)
        {
            int result = await Task.Run(() => text.Count(x => x == '.' || x == '!' || x == '?'));

            return $"The number of sentences: {result}\n";
        }

        public async Task<string> NumberOfSymbols(string text)
        {
            int result = await Task.Run(() => text.Count());

            return $"The number of symbols: {result}\n";
        }

        public async Task<string> NumberOfWords(string text)
        {
            var words = await Task.Run(() => text.Split(' '));

            return $"The number of words: {words.Length}\n";
        }

        public async Task<string> NumberOfExclamatory(string text)
        {
            int result = await Task.Run(() => text.Count(x => x == '!'));

            return $"The number of exclamatory sentences: {result}\n";
        }

        public async Task<string> NumberOfQuestions(string text)
        {
            int result = await Task.Run(() => text.Count(x => x == '?'));

            return $"The number of questions: {result}\n";
        }

        public async Task<string> FullReport(string text)
        {
            return await NumberOfSentences(text) + await NumberOfSymbols(text) 
                + await NumberOfWords(text) + await NumberOfExclamatory(text) + await NumberOfQuestions(text);
        }
    }
}
