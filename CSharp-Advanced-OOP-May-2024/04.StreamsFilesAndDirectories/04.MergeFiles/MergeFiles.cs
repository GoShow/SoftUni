using System.IO;

namespace MergeFiles;

public class MergeFiles
{
    static void Main()
    {
        string firstInputFilePath = @"..\..\..\Files\input1.txt";
        string secondInputFilePath = @"..\..\..\Files\input2.txt";
        string outputFilePath = @"..\..\..\Files\output.txt";

        MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
    }

    public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
    {
        using (StreamReader firstReader = new(firstInputFilePath))
        {
            using (StreamReader secondReader = new(secondInputFilePath))
            {
                using (StreamWriter writer = new(outputFilePath))
                {
                    string firstLine = firstReader.ReadLine();
                    string secondLine = secondReader.ReadLine();

                    while (firstLine != null || secondLine != null)
                    {
                        if (firstLine != null)
                        {
                            writer.WriteLine(firstLine);
                        }

                        if (secondLine != null)
                        {
                            writer.WriteLine(secondLine);
                        }

                        firstLine = firstReader.ReadLine();
                        secondLine = secondReader.ReadLine();
                    }
                }
            }
        }
    }
}

