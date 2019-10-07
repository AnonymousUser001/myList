using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DictionaryChecker.Services
{
    internal class DictionaryFileReader: IDictionaryReader
    {
        private readonly ILogger<DictionaryFileReader> logger;
        private readonly IConfiguration config;

        public DictionaryFileReader(ILogger<DictionaryFileReader> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
        }

        
        //ctor tab tab
      

        /// <summary>
        /// Reads the dictionary file
        /// </summary>
        /// <returns></returns>
        public async Task<string> ReadDictionary()
        {
            var dictionaryText = "";
            try
            {
                // Read the dictionary
                var dictFile = config["dictionaryFileName"] ;
                dictionaryText = await System.IO.File.ReadAllTextAsync(dictFile);
            }
            catch (FileNotFoundException ex)
            {
                logger.LogError(ex, "Dictionary not found");
                throw;
            }

            return dictionaryText;
        }
    }
}
