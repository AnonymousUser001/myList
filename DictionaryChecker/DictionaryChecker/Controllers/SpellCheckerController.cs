using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;
using DictionaryChecker.Services;

namespace DictionaryChecker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpellCheckerController : ControllerBase
    {
        private readonly IDictionaryReader reader;
        private readonly IDictionaryComparer comparer;

        // IMPORTANT - WITHOUT CONSTRUCTOR --> NULLREFERENCE
        public SpellCheckerController(IDictionaryReader reader, IDictionaryComparer comparer)
        {
            this.comparer = comparer;
            this.reader = reader;
        }
 
        
        //IActionResult --> return statuscode
        [HttpPost]
        public async Task<IEnumerable<string>> Spellcheck([FromBody] string textToCheck)
        {

            // Split dictionary and text into words (by line ending \n)
            var dictionaryWords = await reader.ReadDictionary().Replace("\r", "").Split("\n");
            var wordsToCheck = textToCheck.Split(' ');
            
            // Iterate over all words in 
            return comparer.GetUnknownWords(wordsToCheck, dictionaryWords);

            //return textToCheck.Split(' ').Where(words => Contains(word))
        }
       // [InternalsVisibleTo("MyTestingProject")]
       
    }
}
