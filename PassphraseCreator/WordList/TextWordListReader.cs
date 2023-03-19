using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassphraseCreator
{
    public class TextWordListReader : IWordList
    {
        public string FilePath { get; }

        public int NumberOfWords { get; }

        public TextWordListReader(string filePath)
        {
            FilePath = filePath;
            if (File.Exists(FilePath) == false)
            {
                throw new ArgumentException($"File doesn't exist: {FilePath}");
            }
            var firstLine = File.ReadLines(FilePath).FirstOrDefault();
            if (firstLine == null)
            {
                throw new ArgumentException($"File is empty: {FilePath}");
            }
            if (firstLine.StartsWith('#') && 
                int.TryParse(firstLine.TrimStart('#'), out int lineCount))
            {
                NumberOfWords = lineCount;
            }
            else
            {
                throw new ArgumentException($"File is incorrectly formatted, " +
                    $"expected an integer on the first line: {firstLine}");
            }
        }

        public string GetRandomWord(Func<int, int> randomNumberGenerator)
        {
            var randomInt = randomNumberGenerator(NumberOfWords);
            var lines = File.ReadLines(FilePath).Skip(1);
            var randomLine = lines.Skip(randomInt).First();
            var spaceIndex = randomLine.IndexOf(' ');
            return randomLine.Substring(0, spaceIndex);
        }

        public IEnumerable<string> GetAllWords()
        {
            var lines = File.ReadLines(FilePath).Skip(1);
            foreach (var line in lines)
            {
                var spaceIndex = line.IndexOf(' ');
                yield return line.Substring(0, spaceIndex);
            }
        }

        public IEnumerable<string> GetWords(int numWords)
        {
            var lines = File.ReadLines(FilePath).Skip(1);
            foreach (var line in lines)
            {
                var spaceIndex = line.IndexOf(' ');
                yield return line.Substring(0, spaceIndex);
            }
        }
    }
}
