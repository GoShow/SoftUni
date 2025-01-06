using System;
using System.IO;
using System.Linq;

namespace ExtractSpecialBytes;

public class ExtractSpecialBytes
{
    static void Main(string[] args)
    {
        string binaryFilePath = @"..\..\..\Files\example.png";
        string bytesFilePath = @"..\..\..\Files\bytes.txt";
        string outputPath = @"..\..\..\Files\output.bin";

        ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
    }

    public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
    {
        using FileStream stream = new(binaryFilePath, FileMode.Open);

        byte[] bytesRead = File.ReadAllBytes(binaryFilePath);

        byte[] bytesToExtract = File.ReadAllLines(bytesFilePath).Select(s => Convert.ToByte(s)).ToArray();

        byte[] extractedBytes = bytesRead.Where(byteRead => bytesToExtract.Contains(byteRead)).ToArray();

        File.WriteAllBytes(outputPath, extractedBytes);
    }
}

