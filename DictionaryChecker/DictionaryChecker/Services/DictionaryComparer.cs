using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryChecker.Services
{
    public class DictionaryComparer : IDictionaryComparer
    {

        private readonly ILogger logger;

        public DictionaryComparer(ILogger<DictionaryComparer> logger)
        {
            this.logger = logger;
        }
        public IEnumerable<string> GetUnknownWords(IEnumerable<string> wordsToCheck, IEnumerable<string> dictionaryWords)
        {
            var result = new List<string>();
            foreach (var word in wordsToCheck)
            {

                if (!dictionaryWords.Contains(word))
                {
                    // If there is a word that we don't know, write it to the log file
                    logger.LogInformation("Unknown word {word}", word);
                    // Return all words from textTocCheck which are not in dictionary
                    result.Add(word);
                }
            }
            return result;
        }

      
    }
}
