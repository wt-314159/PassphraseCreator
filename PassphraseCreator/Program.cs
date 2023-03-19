// See https://aka.ms/new-console-template for more information
using PassphraseCreator;
using PassphraseCreator.Capitalisation;
using System.Security.Cryptography;
using System.Text;

Console.WriteLine("<===== Passphrase Creator =====>\n");

var rng = new Random();
var textWordList = new TextWordListReader(@"C:\Users\User\Downloads\FrequencyWordList50k.txt");

ConsoleExtensions.LoopProgram(() =>
{
    Console.WriteLine("Enter the number of words to create a passphrase:");

    int result = 3;
    var input = ConsoleExtensions.GetInput(
        x => !int.TryParse(x, out result),
        "Couldn't parse input into an integer, please enter again.");

    var builder = new StringBuilder();
    for (int i = 0; i < result; i++)
    {
        var randomWord = textWordList.GetRandomWord(x => rng.Next(x));
        randomWord = BasicCapitalisingAlgorithm.Instance.RandomlyCapitalise(randomWord, x => rng.Next(x));
        builder.Append(randomWord);
        builder.Append(" ");
    }
    builder.Remove(builder.Length - 1, 1);

    Console.WriteLine();
    Console.Write(">\t");
    Console.WriteLine(builder.ToString());
});