using System.IO;

namespace OddLines;

public class OddLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\Files\input.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        ExtractOddLines(inputFilePath, outputFilePath);
    }

    public static void ExtractOddLines(string inputFilePath, string outputFilePath)
    {
        using (StreamReader reader = new(inputFilePath))
        {
            using (StreamWriter writer = new(outputFilePath))
            {
                int counter = 0;
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (counter % 2 != 0)
                    {
                        writer.WriteLine(line);
                    }

                    counter++;
                }
            }
        }
    }
}

