using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator.Capitalisation
{
    public class BasicCapitalisingAlgorithm : ICaptialisingAlgorithm
    {
        public static BasicCapitalisingAlgorithm Instance = new BasicCapitalisingAlgorithm();
        private BasicCapitalisingAlgorithm() { }

        public int NumberOfOptions => 3;

        public string RandomlyCapitalise(string text, Func<int, int> randomNumberGenerator)
        {
            var randomNum = randomNumberGenerator(NumberOfOptions);
            if (randomNum == 0)
            {
                return text.ToLower();
            }
            else if (randomNum == 1)
            {
                return text.ToUpper();
            }
            else
            {
                return string.Concat(char.ToUpper(text.First()), text.Substring(1).ToLower());
            }
        }
    }
}
