using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator
{
    internal interface IWordList
    {
        IEnumerable<string> GetWords(int numWords);
        IEnumerable<string> GetAllWords();
        string GetRandomWord(Func<int, int> randomNumberGenerator);
        int NumberOfWords { get; }
    }
}
