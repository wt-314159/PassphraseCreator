namespace PassphraseCreator.Testing
{
    [TestClass]
    public class ListReadingTests
    {
        private const string _path = @"C:\Users\User\Downloads\FrequencyWordList50k.txt";
        private readonly char[] _forbiddenChars = { '\'', '-', '.' };


        [TestMethod]
        public void ReadingListTest()
        {
            Assert.IsTrue(File.Exists(_path));

            var lines = File.ReadLines(_path);
            if (lines.First().StartsWith('#'))
            {
                lines = lines.Skip(1);
            }
            foreach (var line in lines)
            {
                var spaceIndex = line.IndexOf(' ');
                var span = line.AsSpan();
                var word = span.Slice(0, spaceIndex);
                var frequency = span.Slice(spaceIndex + 1);
            }
        }

        [TestMethod]
        public void TrimPunctuatedWords()
        {
            Assert.IsTrue(File.Exists(_path));
            var lines = File.ReadLines(_path);
            if (lines.First().StartsWith('#'))
            {
                lines = lines.Skip(1);
            }

            var newWordList = new List<string>(50000);
            foreach (var line in lines)
            {
                var spaceIndex = line.IndexOf(' ');
                var span = line.AsSpan();
                var word = span.Slice(0, spaceIndex);
                if (word.Any(x => _forbiddenChars.Contains(x)))
                {
                    continue;
                }
                newWordList.Add(line);
            }

            var wordCount = string.Concat('#', newWordList.Count);
            newWordList.Insert(0, wordCount);
            File.WriteAllLines(_path, newWordList);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            var wordListReader = new TextWordListReader(_path);
            Assert.AreEqual(_path, wordListReader.FilePath);

            var numberOfWords = File.ReadLines(_path).First().TrimStart('#');
            Assert.AreEqual(numberOfWords, wordListReader.NumberOfWords.ToString());
        }

        [TestMethod]
        public void RandomWordTest()
        {
            var wordListReader = new TextWordListReader(_path);
            var random = new Random();
            var randomNum = new Func<int, int>(x => random.Next(x));

            var randomWord1 = wordListReader.GetRandomWord(randomNum);
            var randomWord2 = wordListReader.GetRandomWord(randomNum);

            Assert.AreNotEqual(randomWord1, randomWord2);
        }
    }
}