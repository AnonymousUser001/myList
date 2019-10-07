using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryChecker.Services
{
    public interface IDictionaryComparer
    {
        IEnumerable<string> GetUnknownWords(IEnumerable<string> wordsToCheck, IEnumerable<string> dictionaryWords);
    }
}
