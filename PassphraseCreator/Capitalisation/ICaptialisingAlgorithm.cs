using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator.Capitalisation
{
    public interface ICaptialisingAlgorithm
    {
        int NumberOfOptions { get; }
        string RandomlyCapitalise(string text, Func<int, int> randomNumberGenerator);
    }
}
