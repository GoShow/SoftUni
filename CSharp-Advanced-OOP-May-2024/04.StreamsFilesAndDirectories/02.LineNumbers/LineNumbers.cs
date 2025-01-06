using System.IO;

namespace LineNumbers;

public class LineNumbers
{
    static void Main()
    {
        string inputPath = @"..\..\..\Files\input.txt";
        string outputPath = @"..\..\..\Files\output.txt";

        RewriteFileWithLineNumbers(inputPath, outputPath);
    }

    public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
    {
        using (StreamReader reader = new(inputFilePath))
        {
            using (StreamWriter writer = new(outputFilePath))
            {
                int index = 1;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    writer.WriteLine($"{index}. {line}");
                    index++;
                }
            }
        }
    }
}



