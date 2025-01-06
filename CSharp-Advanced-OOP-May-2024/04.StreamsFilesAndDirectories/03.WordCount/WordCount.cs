using System.Text;

namespace WordCount;

public class WordCount
{
    static void Main()
    {
        string wordPath = @"..\..\..\Files\words.txt";
        string textPath = @"..\..\..\Files\text.txt";
        string outputPath = @"..\..\..\Files\output.txt";

        CalculateWordCounts(wordPath, textPath, outputPath);
    }

    public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
    {
        Dictionary<string, int> words = new();

        using (var wordsReader = new StreamReader(wordsFilePath))
        {
            string[] input = wordsReader.ReadToEnd().ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in input)
            {
                if (!words.ContainsKey(word))
                {
                    words.Add(word, 0);
                }
            }
        }

        using (var textReader = new StreamReader(textFilePath))
        {
            string[] text = textReader.ReadToEnd().ToLower().Split(new char[] { '\n', '\r', ' ', '.', ',', '!', '?', '-' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in text)
            {
                if (words.ContainsKey(word))
                {
                    words[word]++;
                }
            }
        }

        StringBuilder sb = new();

        foreach (var item in words.OrderByDescending(v => v.Value))
        {
            sb.AppendLine($"{item.Key} - {item.Value}");
        }

        File.WriteAllText(outputFilePath, sb.ToString());
    }
}

